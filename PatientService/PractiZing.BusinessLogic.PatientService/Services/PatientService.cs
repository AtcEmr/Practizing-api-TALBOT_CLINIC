using PractiZing.Base.Common;
using PractiZing.Base.Entities.PatientService;
using PractiZing.Base.Object.PatientService;
using PractiZing.Base.Repositories.MasterService;
using PractiZing.Base.Repositories.PatientService;
using PractiZing.Base.Service.PatientService;
using PractiZing.DataAccess.PatientService.Tables;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using ServiceStack;
using PractiZing.Base.Repositories.ChargePaymentService;
using PractiZing.Base.Entities.MasterService;
using PractiZing.DataAccess.PatientService.Model;

namespace PractiZing.BusinessLogic.PatientService.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;
        private readonly ITransactionProvider _transactionProvider;
        private readonly IPatientCaseRepository _patientCaseRepository;
        private readonly IInsuranceGuarantorRepository _insuranceGuarantorRepository;
        private readonly IInsuranceCompanyRepository _insuranceCompanyRepository;
        private readonly IInsurancePolicyRepository _insurancePolicyRepository;
        private readonly IInsurancePolicyHolderRepository _insurancePolicyHolderRepository;
        private readonly IPatientAuthorizationNumberRepository _patientAuthorizationNumberRepository;
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IVoucherRepository _voucherRepository;
        private readonly IPaymentRepository _paymentRepository;
        private readonly IProviderRepository _providerRepository;
        private readonly IPatientStatementRepository _patientStatementRepository;
        private readonly IPracticeRepository _practiceRepository;

        public PatientService(ITransactionProvider transactionProvider, IPatientRepository patientRepository,
                              IInsuranceGuarantorRepository insuranceGuarantorRepository, IPatientCaseRepository patientCaseRepository,
                              IInsurancePolicyRepository insurancePolicyRepository, IInsuranceCompanyRepository insuranceCompanyRepository,
                              IInsurancePolicyHolderRepository insurancePolicyHolderRepository,
                              IPatientAuthorizationNumberRepository patientAuthorizationNumberRepository,
                              IInvoiceRepository invoiceRepository,
                              IVoucherRepository voucherRepository,
                              IPaymentRepository paymentRepository,
                              IProviderRepository providerRepository,
                              IPatientStatementRepository patientStatementRepository,
                              IPracticeRepository practiceRepository)
        {
            this._transactionProvider = transactionProvider;
            this._patientRepository = patientRepository;
            this._patientCaseRepository = patientCaseRepository;
            this._insuranceGuarantorRepository = insuranceGuarantorRepository;
            this._insurancePolicyRepository = insurancePolicyRepository;
            this._insuranceCompanyRepository = insuranceCompanyRepository;
            this._insurancePolicyHolderRepository = insurancePolicyHolderRepository;
            this._patientAuthorizationNumberRepository = patientAuthorizationNumberRepository;
            this._invoiceRepository = invoiceRepository;
            this._voucherRepository = voucherRepository;
            this._paymentRepository = paymentRepository;
            this._providerRepository = providerRepository;
            this._patientStatementRepository = patientStatementRepository;
            this._practiceRepository = practiceRepository;
        }

        public async Task<IEnumerable<IPatientStatement>> GetPatientStatement(string patientUId)
        {
            var patient = await this._patientRepository.GetByUId(Guid.Parse(patientUId));
            patient.Id = patient == null ? 0 : patient.Id;
            return await this._patientStatementRepository.GetAll(patient.Id);
        }

        /// <summary>
        /// get patient by patientId
        /// </summary>
        /// <param name="pateintId"></param>
        /// <returns></returns>
        public async Task<IPatient> GetById(int Id)
        {
            var result = await this._patientRepository.GetById(Id);
            List<int> vs = new List<int>() { Id };
            result.PatientCase = await this._patientCaseRepository.GetPatient(vs);
            return result;
        }

        /// <summary>
        /// get patient by UId
        /// </summary>
        /// <param name="UId"></param>
        /// <returns></returns>
        public async Task<IPatient> GetByUId(Guid UId)
        {
            IProvider providerData = null;
            var result = await this._patientRepository.GetByUId(UId);
            providerData = await this._providerRepository.GetById(result.ProviderId);
            result.ProviderUId = providerData.UId;

            List<int> vs = new List<int>() { result.Id };
            result.PatientCase = await this._patientCaseRepository.GetPatient(vs);
            return result;
        }

        public async Task<IEnumerable<IPatientChargeDTO>> Get(string patientName)
        {
            try
            {
                patientName = patientName == null ? string.Empty : patientName;

                var patientData = await this._patientRepository.GetAllPatient(patientName);

                var patientCases = await this._patientCaseRepository.GetPatient((patientData.Select(i => i.Id)).ToList());

                var insurancePolicys = await this._insurancePolicyRepository.GetByCaseId(patientCases.Select(i => i.Id));

                foreach (var item in patientData)
                {
                    var patientCase = (patientCases.Where(i => i.PatientId == item.Id));
                    if (patientCase.Count() != 0)
                    {
                        item.PatientCaseUId = patientCase.Select(i => i.UId.ToString());
                        item.PatientCaseId = patientCase.Select(i => i.Id);
                        item.InsuranceCompanyId = (insurancePolicys.Where(i => item.PatientCaseId.Contains(i.PatientCaseId))).Select(i => i.InsuranceCompanyID).Distinct();
                    }
                }

                return patientData.Take(40);
            }
            catch
            {
                throw;
            }
        }

        public async Task<IPatient> Get(Guid patientUId, int patientCaseId)
        {
            try
            {
                IPatient patient = await this._patientRepository.GetByPatientUId(patientUId);
                if (patient == null)
                {
                    await this._patientRepository.ThrowError(patient);
                }

                List<int> vs = new List<int>() { patient.Id };
                patient.PatientCase = await this._patientCaseRepository.GetPatient(vs);
                patient.InsuranceGuarantor = await this._insuranceGuarantorRepository.GetByPatientId(patient.Id);
                //patientCaseId = patientCaseId > 0 ? patientCaseId : patient.PatientCase == null ? 0 : patient.PatientCase.FirstOrDefault().Id;
                patientCaseId = patientCaseId > 0 ? patientCaseId : patient.PatientCase.FirstOrDefault().Id;
                patient.InsurancePolicy = await this._insurancePolicyRepository.GetByPatientId(patientCaseId);
                foreach (var item in patient.InsurancePolicy)
                    item.PatientAuthorizationNumber = await this._patientAuthorizationNumberRepository.GetAuthorization(item.Id);

                return patient;
            }
            catch
            {
                throw;
            }
        }

        public async Task<IPatient> GetByPatientUId(Guid patientUId)
        {
            try
            {
                IPatient patient = await this._patientRepository.Get(patientUId);
                if (patient == null)
                {
                    await this._patientRepository.ThrowError(patient);
                }

                List<int> vs = new List<int>() { patient.Id };
                patient.PatientCase = await this._patientCaseRepository.GetPatient(vs);
                patient.InsuranceGuarantor = await this._insuranceGuarantorRepository.GetByPatientId(patient.Id);
                //patientCaseId = patientCaseId > 0 ? patientCaseId : patient.PatientCase == null ? 0 : patient.PatientCase.FirstOrDefault().Id;
                var patientCaseId = patient.PatientCase.FirstOrDefault().Id;
                patient.InsurancePolicy = await this._insurancePolicyRepository.GetByPatientId(patientCaseId);
                foreach (var item in patient.InsurancePolicy)
                    item.PatientAuthorizationNumber = await this._patientAuthorizationNumberRepository.GetAuthorization(item.Id);

                return patient;
            }
            catch
            {
                throw;
            }
        }

        public async Task<IPatientAuthorizationNumber> GetByInsurancePolicyUId(string insurancePolicyUId)
        {
            var insurancePolicy = await this._insurancePolicyRepository.GetByUId(Guid.Parse(insurancePolicyUId));
            insurancePolicy.Id = insurancePolicy == null ? 0 : insurancePolicy.Id;
            return await this._patientAuthorizationNumberRepository.GetByInsurancePolicyId(insurancePolicy.Id);
        }

        /// <summary>
        /// Add new patient from user
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<IPatient> AddNew(IPatient entity)
        {
            string transactionId = this._transactionProvider.StartTransaction(true);
            try
            {
                List<IPatientCase> patientCases = new List<IPatientCase>();
                IPatientCase patientCase = new PatientCase();
                var provider = await this._providerRepository.GetByUId(entity.ProviderUId.Value, true);
                entity.ProviderId = provider.Id;
                var result = await this._patientRepository.AddNew(entity);
                patientCase.PatientId = result.Id;
                patientCase.CaseIdNumber = Convert.ToString(result.Id * 100 + 1);
                var res = await this._patientCaseRepository.AddNew(patientCase);
                patientCases.Add(res);
                entity.DefaultCaseId = res.Id;
                result.PatientCase = patientCases;
                entity.Id = result.Id;
                await this._patientRepository.UpdateEntity(entity);
                result.DefaultCaseId = res.Id;
                result.PatientCaseUId = res.UId;
                this._transactionProvider.CommitTransaction(transactionId);
                return result;
            }
            catch
            {
                this._transactionProvider.RollbackTransaction(transactionId);
                throw;
            }
        }

        public async Task<IPatient> AddPatientInsuranceDetail(IPatient entity)
        {
            string transactionId = this._transactionProvider.StartTransaction(true);
            try
            {
                var provider = await this._providerRepository.GetByUId(entity.ProviderUId.Value, true);
                entity.ProviderId = provider.Id;/*provider == null ? 0 : (short?)provider.Id;*/
                var patient = await this._patientRepository.UpdatePatientFromInsurance(entity);
                entity.InsuranceGuarantor.PatientID = entity.Id;

                //Stopped By Rohit on 07142023
                var practice = await this._practiceRepository.Get();
                if (practice.IsRequiredInsuranceAddEdit)
                {
                    patient.InsuranceGuarantor = await this._insuranceGuarantorRepository.AddNew(entity.InsuranceGuarantor);
                    var insurancePolicies = entity.InsurancePolicy.FirstOrDefault(i => i.IsEdit == true);

                    if (insurancePolicies != null)
                    {
                        insurancePolicies.InsurancePolicyHolder.PatientUId = patient.UId;
                        insurancePolicies.PHRelationshipToPatient = insurancePolicies.InsurancePolicyHolder.PHRel;
                        //await this._insuranceCompanyRepository.Update(item.InsuranceCompany);
                        await this._insurancePolicyHolderRepository.Update(insurancePolicies.InsurancePolicyHolder);

                        await this._insurancePolicyRepository.Update(insurancePolicies, isfromUI: true);
                        await this._patientAuthorizationNumberRepository.UpdateEntities(insurancePolicies.PatientAuthorizationNumber);
                    }
                }
                    //Stopped By Rohit on 07142023
                    this._transactionProvider.CommitTransaction(transactionId);
                return patient;
            }
            catch
            {
                this._transactionProvider.RollbackTransaction(transactionId);
                throw;
            }
        }

        public async Task<IPatient> UpdateEntity(IPatient entity)
        {
            string transactionId = this._transactionProvider.StartTransaction(true);
            try
            {
                var provider = await this._providerRepository.GetByUId(entity.ProviderUId.Value, true);
                entity.ProviderId = provider == null ? (short)0 : provider.Id;
                await this._patientRepository.UpdateEntity(entity);
                await this._patientCaseRepository.UpdateEntity(entity.PatientCase, entity.Id);
                var insurancePolicies = await this._insurancePolicyRepository.GetByPatientId(entity.DefaultCaseId.Value);
                foreach (var item in insurancePolicies)
                {
                    if(item.PHRelationshipToPatient.ToLower().Trim()=="self")
                    {
                        item.PHFirstName = entity.FirstName;
                        item.PHLastName = entity.LastName;
                        item.PHDOB = entity.DOB.ToString();
                        item.InsurancePolicyHolder.FirstName = entity.FirstName;
                        item.InsurancePolicyHolder.LastName = entity.LastName;
                        item.InsurancePolicyHolder.DOB = entity.DOB;
                        item.InsurancePolicyHolder.Zip = entity.ZipCode;
                        item.InsurancePolicyHolder.City = entity.City;
                        item.InsurancePolicyHolder.State = entity.State;
                        item.InsurancePolicyHolder.Address1 = entity.Address1;
                        item.InsurancePolicyHolder.Address2 = entity.Address2;
                        await this._insurancePolicyRepository.Update(item, false);
                        item.InsurancePolicyHolder.PatientUId = entity.UId
;                        await this._insurancePolicyHolderRepository.Update(item.InsurancePolicyHolder);
                    }
                    
                }
                this._transactionProvider.CommitTransaction(transactionId);
                return entity;
            }
            catch
            {
                this._transactionProvider.RollbackTransaction(transactionId);
                throw;
            }
        }

        public async Task<int> Delete(Guid uid)
        {
            string transactionId = this._transactionProvider.StartTransaction(true);
            try
            {
                //get the details of the patient
                var _patient = await this._patientRepository.GetByUId(uid);
                //get the case of the patient
                var _case = await this._patientCaseRepository.Get(_patient.Id);

                //get the charges of the patient
                var _invoice = await this._invoiceRepository.Get(_case.Id);
                //if charges exist on patient, return error that patient can not be deleted
                await this._invoiceRepository.ThrowError(_invoice.Count());

                //get the vouchers of the patient
                var _voucher = await this._voucherRepository.GetByPatientId(_patient.Id);
                //if vouchers exist on patient, return error that patient can not be deleted
                await this._voucherRepository.ThrowError(_voucher.Count());

                //get the payments of the patient
                var _payment = await this._paymentRepository.Get(_patient.Id);
                //if payments exist on patient, return error that patient can not be deleted
                await this._paymentRepository.ThrowError(_payment.Count());

                //if no charges, vouchers and payments exist on user, then delete the insurance policy holder of the patient
                await this._insurancePolicyHolderRepository.DeleteByPatientId(_patient.Id);
                //delete insurance guarantor of the patient
                await this._insuranceGuarantorRepository.Delete(_patient.Id);
                //delete insurance policies of the patient
                await this._insurancePolicyRepository.DeleteByPatientCaseId(_case.Id);
                //delete patient case
                await this._patientCaseRepository.DeleteCase(_patient.Id);
                //delete patient
                await this._patientRepository.Delete(uid);

                this._transactionProvider.CommitTransaction(transactionId);
                //if patient is deleted successfully, return 1
                return 1;
            }
            catch
            {
                this._transactionProvider.RollbackTransaction(transactionId);
                throw;
            }
        }

        public async Task<int> DeletePatient(int patientId)
        {
            string transactionId = this._transactionProvider.StartTransaction(true);
            try
            {
                var result = await this._patientRepository.Delete(patientId);
                await this._patientCaseRepository.DeleteCase(patientId);
                this._transactionProvider.CommitTransaction(transactionId);
                return result;
            }
            catch
            {
                this._transactionProvider.RollbackTransaction(transactionId);
                throw;
            }
        }

        public async Task<IEnumerable<IPatientStatementRDLCDTO>> GetAgingPatient()
        {
            var result = await this._patientRepository.Get();
            return result;
        }

        public async Task<IEnumerable<IArPatient>> GetArPatientBillingData()
        {
            var result = await this._patientRepository.GetArPatientBillingData();
            return result;
        }
    }
}
