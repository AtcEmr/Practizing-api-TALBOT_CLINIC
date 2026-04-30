using PractiZing.Base.Common;
using PractiZing.Base.Entities.ChargePaymentService;
using PractiZing.Base.Entities.MasterService;
using PractiZing.Base.Repositories.ChargePaymentService;
using PractiZing.Base.Repositories.MasterService;
using PractiZing.Base.Service.ChargePaymentService;
using PractiZing.DataAccess.ChargePaymentService.Tables;
using PractiZing.DataAccess.MasterService.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PractiZing.BusinessLogic.ChargePaymentService.Services
{
    public class FeeScheduleService : IFeeScheduleService
    {
        private readonly ITransactionProvider _transactionProvider;
        private readonly IFeeScheduleRepository _feeScheduleRepository;
        private readonly IFSChargeRepository _fsChargeRepository;
        private readonly IFSDiscountRepository _fsDiscountRepository;
        private readonly ICPTCodeRepository _cptCodeRepository;
        private IProviderRepository _providerRepository;
        private IInsuranceCompanyRepository _insuranceCompanyRepository;
        private readonly IAppSettingRepository _appSettingRepository;
        private readonly IConfigPractitionerServiceRepository _configPractitionerServiceRepository;

        private IEnumerable<IAppSetting> _configAppSettingPracticeGenConfig;

        public FeeScheduleService(ITransactionProvider transactionProvider,
                                  IFeeScheduleRepository feeScheduleRepository,
                                  IFSChargeRepository fsChargeRepository,
                                  IFSDiscountRepository fsDiscountRepository,
                                  ICPTCodeRepository cptCodeRepository,
                                  IProviderRepository providerRepository,
                                  IInsuranceCompanyRepository insuranceCompanyRepository,
                                  IAppSettingRepository appSettingRepository,
                                  IConfigPractitionerServiceRepository configPractitionerServiceRepository)
        {
            this._configPractitionerServiceRepository = configPractitionerServiceRepository;
            _transactionProvider = transactionProvider;
            this._appSettingRepository = appSettingRepository;
            _feeScheduleRepository = feeScheduleRepository;
            _fsChargeRepository = fsChargeRepository;
            _fsDiscountRepository = fsDiscountRepository;
            _cptCodeRepository = cptCodeRepository;
            this._providerRepository = providerRepository;
            this._insuranceCompanyRepository = insuranceCompanyRepository;
        }

        /// <summary>
        /// add new FeeSchedule
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<IFeeSchedule> AddNew(IFeeSchedule entity)
        {
            string transactionId = this._transactionProvider.StartTransaction(true);
            try
            {
                FeeSchedule tEntity = entity as FeeSchedule;
                var result = await this._feeScheduleRepository.AddNew(tEntity);

                this._transactionProvider.CommitTransaction(transactionId);
                return result;

            }
            catch
            {
                this._transactionProvider.RollbackTransaction(transactionId);
                throw;
            }
        }

        public async Task<IFSCharge> AddFSCharge(IFSCharge entity)
        {
            string transactionId = this._transactionProvider.StartTransaction(true);
            try
            {
                FSCharge tEntity = entity as FSCharge;

                /*fetch feeSchedule on behalf of feeScheduleUId*/
                var feeSchedule = await this._feeScheduleRepository.GetByUId(tEntity.FeeScheduleUId);

                IInsuranceCompany insuranceCompany = null;
                if (tEntity.InsuranceCompayUId.HasValue)
                {
                    if (!string.IsNullOrWhiteSpace(tEntity.InsuranceCompayUId.Value.ToString()))
                        insuranceCompany = await this._insuranceCompanyRepository.GetByUId(tEntity.InsuranceCompayUId);
                }

                IProvider provider = null;
                if (tEntity.ProviderUId.HasValue)
                {
                    if (!string.IsNullOrWhiteSpace(tEntity.ProviderUId.Value.ToString()))
                        provider = await this._providerRepository.GetByUId(tEntity.ProviderUId.Value);
                }

                /*Check discount is exist on given FeeSchedule for given CPT Code*/
                if (tEntity.FSDiscounts.Count() > 0)
                {
                    foreach (var item in tEntity.FSDiscounts)
                    {
                        /*discount's effective date should be in between feeSchedule's effective Date and feeSchedule's expiry Date.
                         if above statement does not follow than it will throw exception 'Fee Discount should be in the Date range of Fee Schedule..' */
                        if (item.EffectiveDate.Date >= feeSchedule.EffectiveDate.Date && item.EffectiveDate.Date <= feeSchedule.ExpiryDate)
                        {
                            /*discount should be less than it's Charge amount. if discount is greater thatn it's charge amount.
                             it will throw exception "Discount on any CPT cannot be more than it's charge"*/
                            if (tEntity.NonFacilityCharge < item.NonFacilityDiscount || tEntity.FacilityCharge < item.FacilityDiscount)
                                await this._fsDiscountRepository.FeeDiscountValidation();
                        }

                        else
                        {
                            await this._fsDiscountRepository.FeeDiscountEffectiveDate();
                        }
                    }
                }

                tEntity.FeeScheduleId = feeSchedule.Id;
                if(insuranceCompany!=null)
                tEntity.InsuranceCompayId = insuranceCompany.Id;
                if (provider != null)
                    tEntity.ProviderId = provider.Id;

                //var res = await this._fsChargeRepository.AddNew(tEntity);
                //foreach (var item in tEntity.FSDiscounts)
                //{
                //    if (item.ProviderUId != null)
                //    {
                //        var provider = await this._providerRepository.GetByUId(item.ProviderUId.Value, true);
                //        item.ProviderId = provider.Id;
                //    }
                //    if (item.InsuranceCompanyUId != null)
                //    {
                //        var insuranceCompany = await this._insuranceCompanyRepository.GetByUId(item.InsuranceCompanyUId.Value);
                //        item.InsuranceCompanyId = insuranceCompany.Id;
                //    }

                //}
                /*Insert Charge of CPT*/
                var res = await this._fsChargeRepository.AddNew(tEntity);
                //var insuranceCompany = new InsuranceCompany() ;
                //foreach (var item in tEntity.FSDiscounts)
                //{
                //    var insuranceCompany = await this._insuranceCompanyRepository.GetByUId(item.InsuranceCompanyUId);
                //    item.InsuranceCompanyId = insuranceCompany == null ? 0 : insuranceCompany.Id;
                //}


                /*Insert Discount of CPT*/
                await this._fsDiscountRepository.AddNewEntities(tEntity.FSDiscounts, res.Id);

                this._transactionProvider.CommitTransaction(transactionId);
                return res;
            }
            catch
            {
                this._transactionProvider.RollbackTransaction(transactionId);
                throw;
            }
        }

        public async Task<bool> UpdateFSCharge(IFSCharge entity)
        {
            string transactionId = this._transactionProvider.StartTransaction(true);
            try
            {
                FSCharge tEntity = entity as FSCharge;

                /*fetch feeSchedule on behalf of feeScheduleUId*/
                var feeSchedule = await this._feeScheduleRepository.GetByUId(tEntity.FeeScheduleUId);

                IInsuranceCompany insuranceCompany = null;
                if(tEntity.InsuranceCompayUId.HasValue)
                {
                    if (!string.IsNullOrWhiteSpace(tEntity.InsuranceCompayUId.Value.ToString()))
                        insuranceCompany = await this._insuranceCompanyRepository.GetByUId(tEntity.InsuranceCompayUId);
                }

                IProvider provider = null;
                if (tEntity.ProviderUId.HasValue)
                {
                    if (!string.IsNullOrWhiteSpace(tEntity.ProviderUId.Value.ToString()))
                        provider = await this._providerRepository.GetByUId(tEntity.ProviderUId.Value);
                }


                /*Check discount is exist on given FeeSchedule for given CPT Code*/
                if (tEntity.FSDiscounts.Count() > 0)
                {
                    foreach (var item in tEntity.FSDiscounts)
                    {
                        item.ProviderId = item.ProviderUId == null ? null : (short?)(await this._providerRepository.GetByUId(item.ProviderUId.Value, true)).Id;

                        item.InsuranceCompanyId = item.InsuranceCompanyUId == null ? null : (int?)(await this._insuranceCompanyRepository.GetByUId(item.InsuranceCompanyUId.Value)).Id;
                        /*Discount can be give on 
                         * 1. particular insurance company 
                         * 2. particular Provider 
                         * 3. specific Insurance Company and Provider both.*/

                        /*discount's effective date should be in between feeSchedule's effective Date and feeSchedule's expiry Date.
                        if above statement does not follow than it will throw exception 'Fee Discount should be in the Date range of Fee Schedule..' */
                        if (item.EffectiveDate.Date >= feeSchedule.EffectiveDate.Date && item.EffectiveDate.Date <= feeSchedule.ExpiryDate)
                        {
                            /*discount should be less than it's Charge amount. if discount is greater thatn it's charge amount.
                            it will throw exception "Discount on any CPT cannot be more than it's charge"*/
                            if (tEntity.NonFacilityCharge < item.NonFacilityDiscount || tEntity.FacilityCharge < item.FacilityDiscount)
                                await this._fsDiscountRepository.FeeDiscountValidation();
                        }
                        else
                        {
                            await this._fsDiscountRepository.FeeDiscountEffectiveDate();
                        }
                    }
                }
                tEntity.FeeScheduleId = feeSchedule.Id;
                if (insuranceCompany != null)
                    tEntity.InsuranceCompayId = insuranceCompany.Id;
                else
                    tEntity.InsuranceCompayId = null;

                if (provider != null)
                    tEntity.ProviderId = provider.Id;
                else
                    tEntity.ProviderId = null;

                /*Update Charge amount of CPT*/
                var res = await this._fsChargeRepository.Update(tEntity);

                /*Update Discount of CPT*/
                await this._fsDiscountRepository.UpdateEntities(tEntity.FSDiscounts, tEntity.Id);

                this._transactionProvider.CommitTransaction(transactionId);
                return true;
            }
            catch
            {
                this._transactionProvider.RollbackTransaction(transactionId);
                throw;
            }
        }

        public async Task<int> Update(IFeeSchedule entity)
        {
            string transactionId = this._transactionProvider.StartTransaction(true);
            try
            {
                FeeSchedule tEntity = entity as FeeSchedule;
                var result = await this._feeScheduleRepository.Update(tEntity);

                var fsCharge = await this._fsChargeRepository.UpdateEntities(tEntity.FSCharges, tEntity.Id);
                foreach (var item in tEntity.FSCharges)
                    await this._fsDiscountRepository.UpdateEntities(item.FSDiscounts, item.Id);

                this._transactionProvider.CommitTransaction(transactionId);
                return result;
            }
            catch
            {
                this._transactionProvider.RollbackTransaction(transactionId);
                throw;
            }
        }

        public async Task<IFeeSchedule> GetFeeSchedule(Guid uId)
        {
            var feeSchedule = await this._feeScheduleRepository.GetByUId(uId);

            feeSchedule.FSCharges = await this._fsChargeRepository.GetByFeeSchedule(feeSchedule.Id);
            foreach (var item in feeSchedule.FSCharges)
                item.FSDiscounts = await this._fsDiscountRepository.GetByChargeId(item.Id);

            return feeSchedule;
        }

        /*Get Charge of CPT Code on behalf of given params*/ //02042025- Rohit rename as need new logic to implement
        public async Task<IFSCharge> GetChargeByCPTOLD(string cptCode, IEnumerable<string> modifiers, string providerUId, string insuranceCompanyUId, DateTime fromDate)
        {
            IFSCharge result = null;
            IFSCharge tempresult = null;
            /*Get FeeSchedule on behalf of date*/
            var feeSchedule = await this._feeScheduleRepository.GetFeeSchedules(fromDate);

            if (feeSchedule != null)
            {
                int qualificationId = 0;
                var provider = await this._providerRepository.GetByUId(Guid.Parse(providerUId));
                if(provider.PractitionerServiceId.HasValue)
                {
                    qualificationId = provider.PractitionerServiceId.Value;
                }

                /*first get fsCharges without any Modifier*/
                //var fsCharges = await this._fsChargeRepository.GetByCPTCharge(cptCode, string.Empty, feeSchedule.Id,insuranceCompanyUId, provider.Id);
                var fsCharges = await this._fsChargeRepository.GetByCPTChargeByQualification(cptCode, string.Empty, feeSchedule.Id, insuranceCompanyUId, qualificationId);
                if (fsCharges.Count() > 0)
                {
                    result = fsCharges.OrderByDescending(i => i.NonFacilityCharge).FirstOrDefault();
                    tempresult = fsCharges.OrderByDescending(i => i.NonFacilityCharge).FirstOrDefault();                    
                }
                    

                List<IFSCharge> _fsCharges = new List<IFSCharge>();
                List<IFSCharge> _fsChargesTemp = new List<IFSCharge>();
                //if (result != null)
                //    _fsCharges.Add(result);

                string[] _modifiers = null;

                if (modifiers.Count() > 0 && modifiers.ToArray()[0] != null && modifiers.ToArray()[0].Contains(","))
                    _modifiers = modifiers.ToArray()[0].Split(',');

                if (_modifiers == null)
                    _modifiers = modifiers.ToArray();

                _modifiers = _modifiers.Where(i => i != string.Empty).ToArray();

                _configAppSettingPracticeGenConfig = await this._appSettingRepository.GetAppSettingPracticeConfig();

                //var ignoreModifiers = _configAppSettingPracticeGenConfig.FirstOrDefault(i => i.SettingCD == "IgnoreModifiersFSCharge");

                //if (ignoreModifiers!=null    && ignoreModifiers.SettingValue.ToLower()=="true")
                //{
                //    _modifiers = new string[1];
                //    _modifiers[0] = "";
                //}

                
                foreach (var item in _modifiers)
                {                    
                        result = null;
                        string _item = item ?? string.Empty;

                        /*Get fsCharge with modifier*/
                        var fsCharge = (await this._fsChargeRepository.GetByCPTChargeByQualification(cptCode, _item, feeSchedule.Id,insuranceCompanyUId, qualificationId));
                        if (fsCharge.Count() > 0)
                        {
                            result = fsCharge.OrderByDescending(i => i.NonFacilityCharge).FirstOrDefault();
                            fsCharge = new List<IFSCharge>();
                            if (result != null)
                                _fsCharges.Add(result);
                        }                    
                }

                foreach (var item in _fsCharges)
                {
                    /*Get FSDiscount with given params*/
                    var fSDiscounts = await this._fsDiscountRepository.GetCPTDiscount(item.Id, fromDate, providerUId, insuranceCompanyUId);

                    if (fSDiscounts.Count() > 0)
                    {
                        item.FSDiscounts = fSDiscounts.OrderByDescending(i => i.NonFacilityDiscount);
                        item.NonFacilityCharge -= item.FSDiscounts.FirstOrDefault().NonFacilityDiscount;
                        item.FacilityCharge -= item.FSDiscounts.FirstOrDefault().FacilityDiscount;
                    }
                }

                foreach (var item in _fsCharges)
                {
                    if (item.FSDiscounts.Count() > 0)
                        _fsChargesTemp.Add(item);
                }

                if (_fsChargesTemp.Count() > 0)
                {
                    result = _fsChargesTemp.OrderByDescending(i => i.NonFacilityCharge).FirstOrDefault(i => i.Modifier != null || i.Modifier != string.Empty);
                    if (result == null)
                        result = _fsChargesTemp.OrderByDescending(i => i.NonFacilityCharge).FirstOrDefault();
                }
                else
                {

                    if (_fsCharges.FirstOrDefault(i => i.Modifier != null || i.Modifier != string.Empty) != null)
                        result = _fsCharges.OrderByDescending(i => i.NonFacilityCharge).FirstOrDefault(i => i.Modifier != null || i.Modifier != string.Empty);

                    if (result == null)
                        result = _fsCharges.OrderByDescending(i => i.NonFacilityCharge).FirstOrDefault();
                }

                
                return result==null?tempresult:result;
            }

            return null;
        }

        /*Get Charge of CPT Code on behalf of given params*/
        public async Task<IFSCharge> GetChargeByCPT(string cptCode, IEnumerable<string> modifiers, string providerUId, string insuranceCompanyUId, DateTime fromDate)
        {
            IFSCharge result = null;
            IFSCharge tempresult = null;
            /*Get FeeSchedule on behalf of date*/
            var feeSchedule = await this._feeScheduleRepository.GetFeeSchedules(fromDate);

            if (feeSchedule != null)
            {
                int qualificationId = 0;
                var provider = await this._providerRepository.GetByUId(Guid.Parse(providerUId));
                if (provider.PractitionerServiceId.HasValue)
                {
                    qualificationId = provider.PractitionerServiceId.Value;
                }

                /*first get fsCharges without any Modifier*/
                //var fsCharges = await this._fsChargeRepository.GetByCPTCharge(cptCode, string.Empty, feeSchedule.Id,insuranceCompanyUId, provider.Id);
                var fsCharges = await this._fsChargeRepository.GetByCPTChargeByQualification(cptCode, string.Empty, feeSchedule.Id, insuranceCompanyUId, qualificationId);
                if (fsCharges.Count() > 0)
                {
                    result = fsCharges.OrderByDescending(i => i.NonFacilityCharge).FirstOrDefault(i=>string.IsNullOrEmpty(i.Modifier));
                    tempresult = fsCharges.OrderByDescending(i => i.NonFacilityCharge).FirstOrDefault(i => string.IsNullOrEmpty(i.Modifier));
                    if (result==null)
                    {
                        result = await this._fsChargeRepository.GetDefaultFeeRates(cptCode, feeSchedule.Id);
                        tempresult = result;
                    }                    
                }


                List<IFSCharge> _fsCharges = new List<IFSCharge>();
                List<IFSCharge> _fsChargesTemp = new List<IFSCharge>();
                //if (result != null)
                //    _fsCharges.Add(result);

                string[] _modifiers = null;

                if (modifiers.Count() > 0 && modifiers.ToArray()[0] != null && modifiers.ToArray()[0].Contains(","))
                    _modifiers = modifiers.ToArray()[0].Split(',');

                if (_modifiers == null)
                    _modifiers = modifiers.ToArray();

                _modifiers = _modifiers.Where(i => !string.IsNullOrWhiteSpace(i)).ToArray();
                if(_modifiers.Count()>0)
                    _modifiers = _modifiers.OrderBy(i => i.ToString()).ToArray();

                _configAppSettingPracticeGenConfig = await this._appSettingRepository.GetAppSettingPracticeConfig();

                
                if(_modifiers.Count()>0)
                {
                    if(_modifiers.Count()==1)
                    {
                        result= fsCharges.FirstOrDefault((i => i.Modifier == _modifiers[0].ToString()));
                    }
                    if (_modifiers.Count() == 2)
                    {
                        result = fsCharges.FirstOrDefault((i => i.Modifier == _modifiers[0].ToString() && i.Modifier2==_modifiers[1]));
                    }
                    if (_modifiers.Count() == 3)
                    {
                        result = fsCharges.FirstOrDefault((i => i.Modifier == _modifiers[0].ToString() && i.Modifier2 == _modifiers[1] && i.Modifier3 == _modifiers[2]));
                    }
                    if (_modifiers.Count() == 4)
                    {
                        result = fsCharges.FirstOrDefault((i => i.Modifier == _modifiers[0].ToString() && i.Modifier2 == _modifiers[1] && i.Modifier3 == _modifiers[2] && i.Modifier4 == _modifiers[3]));
                    }
                }
                                              

                foreach (var item in _fsCharges)
                {
                    /*Get FSDiscount with given params*/
                    var fSDiscounts = await this._fsDiscountRepository.GetCPTDiscount(item.Id, fromDate, providerUId, insuranceCompanyUId);

                    if (fSDiscounts.Count() > 0)
                    {
                        item.FSDiscounts = fSDiscounts.OrderByDescending(i => i.NonFacilityDiscount);
                        item.NonFacilityCharge -= item.FSDiscounts.FirstOrDefault().NonFacilityDiscount;
                        item.FacilityCharge -= item.FSDiscounts.FirstOrDefault().FacilityDiscount;
                    }
                }

                foreach (var item in _fsCharges)
                {
                    if (item.FSDiscounts.Count() > 0)
                        _fsChargesTemp.Add(item);
                }

                if (_fsChargesTemp.Count() > 0)
                {
                    result = _fsChargesTemp.OrderByDescending(i => i.NonFacilityCharge).FirstOrDefault(i => i.Modifier != null || i.Modifier != string.Empty);
                    if (result == null)
                        result = _fsChargesTemp.OrderByDescending(i => i.NonFacilityCharge).FirstOrDefault();
                }
                else
                {

                    if (_fsCharges.FirstOrDefault(i => i.Modifier != null || i.Modifier != string.Empty) != null)
                        result = _fsCharges.OrderByDescending(i => i.NonFacilityCharge).FirstOrDefault(i => i.Modifier != null || i.Modifier != string.Empty);

                    if (result == null)
                        result = _fsCharges.OrderByDescending(i => i.NonFacilityCharge).FirstOrDefault();
                }


                return result == null ? tempresult : result;
            }

            return null;
        }



        public async Task<int> DeleteFSCharge(short id)
        {
            try
            {
                /*Delete Discount by FSChargeId*/
                await this._fsDiscountRepository.DeleteDiscountByCharge(id);

                /*Delete CPT amount by FSChargeId*/
                var result = await this._fsChargeRepository.Delete(id);
                return result;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Delete FeeSchedule with it's CPT's Charge amount and it's Discount
        /// </summary>
        /// <param name="uId"></param>
        /// <returns></returns>
        public async Task<int> DeleteFeeSchedule(Guid uId)
        {
            try
            {
                var feeSchedule = await this._feeScheduleRepository.GetByUId(uId);
                var charges = await this._fsChargeRepository.GetByFeeSchedule(feeSchedule.Id);
                foreach (var item in charges)
                {
                    await this._fsDiscountRepository.DeleteDiscountByCharge(item.Id);

                    await this._fsChargeRepository.Delete(item.Id);
                }
                return await this._feeScheduleRepository.Delete(feeSchedule.Id);
            }
            catch
            {
                throw;
            }

        }

        public async Task<IFeeSchedule> GetFeeScheduleCPTCodes(Guid uId)
        {
            try
            {
                /*Get FeeSchedule by UId*/
                var feeSchedule = await this._feeScheduleRepository.GetByUId(uId);
                List<IFSCharge> fSCharges = new List<IFSCharge>();

                /*Get CPT's Charge by feeScheduleId*/
                var res = (await this._fsChargeRepository.GetByFeeSchedule(feeSchedule.Id)).ToList();

                /*Get Fee Discount by fsChargeId*/
                foreach (var item in res)
                {
                    if(item.InsuranceCompayId.HasValue && item.InsuranceCompayId.Value>0)
                    {
                        var ins = await this._insuranceCompanyRepository.GetById(item.InsuranceCompayId);
                        item.InsuranceCompanyName = ins.CompanyName;
                        item.InsuranceCompayUId = ins.UId;                        
                    }
                    if (item.QualificationId.HasValue && item.QualificationId.Value > 0)
                    {
                        var quaiification = await this._configPractitionerServiceRepository.GetByQualticationId(item.QualificationId.Value);
                        if (quaiification != null)
                        {                            
                            item.ProviderName = quaiification.ProfessionalAbbreviation;
                        }
                    }
                    string allModifiers = "";
                    allModifiers += !string.IsNullOrWhiteSpace(item.Modifier) ? item.Modifier : "";
                    allModifiers += !string.IsNullOrWhiteSpace(item.Modifier2) ? (", "+item.Modifier2) : "";
                    allModifiers += !string.IsNullOrWhiteSpace(item.Modifier3) ? (", " + item.Modifier3) : "";
                    allModifiers += !string.IsNullOrWhiteSpace(item.Modifier4) ? (", " + item.Modifier4) : "";

                    item.Modifiers = allModifiers;
                    item.FSDiscounts = await this._fsDiscountRepository.GetByChargeId(item.Id);
                    foreach (var discount in item.FSDiscounts)
                    {
                        if (discount.ProviderId != null)
                            discount.ProviderUId = (await this._providerRepository.GetById(discount.ProviderId.Value))?.UId;
                        if (discount.InsuranceCompanyId != null)
                            discount.InsuranceCompanyUId = (await this._insuranceCompanyRepository.GetById(discount.InsuranceCompanyId.Value))?.UId;
                    }
                }



                /*filter FSCharge for Modifier is null or empty.*/
                var rest = res.Where(i => i.Modifier == null || i.Modifier == string.Empty);

                foreach (var item in rest)
                {
                    var tempData = fSCharges.Where(i => i.CPTCode == item.CPTCode).ToList();
                    foreach (var data in tempData)
                        fSCharges.RemoveAll(x => x.CPTCode == data.CPTCode);
                }

                fSCharges.AddRange(res);
                feeSchedule.FSCharges = fSCharges;

                /*Get all favourites CPT Codes*/
                //var result = (await this._cptCodeRepository.GetCPTCodes());
                //foreach (var item in result)
                //{
                //    FSCharge fSCharge = new FSCharge();
                //    fSCharge.CPTCode = item.CPTCode;
                //    fSCharge.FeeScheduleId = feeSchedule.Id;
                //    fSCharge.Modifier = string.Empty;

                //    /*add all favourite CPT Code on FSCharge List for each of FeeSchedule. so that user can make more charge on cpt using
                //     another insurance company or another provider and with any different modifier.*/
                //    fSCharges.Add(fSCharge);
                //}

                return feeSchedule;
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
