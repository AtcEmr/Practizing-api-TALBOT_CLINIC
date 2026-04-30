using PractiZing.Base.Common;
using PractiZing.Base.Entities.MasterService;
using PractiZing.Base.Repositories.ChargePaymentService;
using PractiZing.Base.Repositories.MasterService;
using PractiZing.Base.Repositories.PatientService;
using PractiZing.Base.Service.MasterService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PractiZing.BusinessLogic.MasterService.Services
{
    public class InsuranceCompanyService : IInsuranceCompanyService
    {
        private readonly ITransactionProvider _transactionProvider;
        private IInsuranceCompanyRepository _insuranceCompanyRepository;
        private IFSDiscountRepository _fsDiscountRepository;
        private IConfigInsuranceCompanyTypeRepository _configInsuranceCompanyTypeRepository;
        private IClaimConfigRepository _claimConfigRepository;
        private IVoucherRepository _voucherRepository;
        private IInsurancePolicyRepository _insurancePolicyRepository;

        public InsuranceCompanyService(ITransactionProvider transactionProvider,
                                       IInsuranceCompanyRepository insuranceCompanyRepository,
                                       IConfigInsuranceCompanyTypeRepository configInsuranceCompanyTypeRepository,
                                       IClaimConfigRepository claimConfigRepository,
                                       IFSDiscountRepository fSDiscountRepository,
                                       IVoucherRepository voucherRepository,
                                       IInsurancePolicyRepository insurancePolicyRepository)
        {
            _transactionProvider = transactionProvider;
            this._insuranceCompanyRepository = insuranceCompanyRepository;
            this._configInsuranceCompanyTypeRepository = configInsuranceCompanyTypeRepository;
            this._claimConfigRepository = claimConfigRepository;
            _fsDiscountRepository = fSDiscountRepository;
            _voucherRepository = voucherRepository;
            _insurancePolicyRepository = insurancePolicyRepository;
        }

        /*Insurance company can newly add or update old one*/
        public async Task<int> AddOrUpdate(IEnumerable<IInsuranceCompany> entities)
        {
            var updateData = entities.Where(i => i.Id != 0);
            var addData = entities.Where(i => i.Id == 0);

            foreach (var item in updateData)
                await this._insuranceCompanyRepository.Update(item);

            foreach (var item in addData)
                await this._insuranceCompanyRepository.AddNew(item);

            return 1;
        }

        public async Task<IEnumerable<IConfigInsuranceCompanyType>> Get(string typeName)
        {

            var getTypes = await this._configInsuranceCompanyTypeRepository.GetAll(typeName);
            var getCompanies = await this._insuranceCompanyRepository.Get();

            foreach (var item in getTypes)
            {
                var newORNot = await this._claimConfigRepository.Get(item.Id);
                item.IsNew = newORNot == null ? true : false;
                item.InsuranceCompanies = getCompanies.Where(i => i.CompanyTypeId == item.Id);
            }

            return getTypes;
        }

        /// <summary>
        /// Delete Insurance company
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<int> Delete(Guid uid)
        {
            string transactionId = this._transactionProvider.StartTransaction(true);
            try
            {
                var insuranceCompany = await this._insuranceCompanyRepository.GetByUId(uid);
                var id = insuranceCompany == null ? 0 : insuranceCompany.Id;
                var insurancePolicy = await this._insurancePolicyRepository.Get(id);

                var _company = await this._insuranceCompanyRepository.GetById(id);
                var _claimConfig = await this._claimConfigRepository.GetCompany(id);
                var _fsDiscount = await this._fsDiscountRepository.GetByInsuranceCompanyId(id);
                var _insurancePolicy = await this._insurancePolicyRepository.GetByInsuranceCompanyId(id);
                var _voucher = await this._voucherRepository.GetByInsuranceCompanyId(id);

                /*check insurance company is not being use, which is going to delete. if given insurance company is being use somewhere
                 that can be claim configuration/FeeSchedule Discount/Payment/Patient's Insurance policy then it will throw an exception
                 and refuse delete request.*/
                if (_claimConfig == null && _fsDiscount == null && _voucher == null && _insurancePolicy == null)
                    await this._insuranceCompanyRepository.DeleteByUId(uid);
                else
                    await this._insuranceCompanyRepository.InsuranceCompanyIsInUse();

                this._transactionProvider.CommitTransaction(transactionId);
                return 1;
            }
            catch
            {
                this._transactionProvider.RollbackTransaction(transactionId);
                throw;
            }
        }
    }
}
