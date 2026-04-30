using AutoMapper;
using PractiZing.Base.Common;
using PractiZing.Base.Entities.ChargePaymentService;
using PractiZing.Base.Entities.PatientService;
using PractiZing.Base.Entities.SecurityService;
using PractiZing.Base.Repositories.ChargePaymentService;
using PractiZing.BusinessLogic.Common;
using PractiZing.DataAccess.ChargePaymentService;
using PractiZing.DataAccess.ChargePaymentService.Tables;
using PractiZing.DataAccess.Common;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PractiZing.BusinessLogic.ChargePaymentService.Repositories
{
    public class DrugChargeRepository : ModuleBaseRepository<DrugCharge>, IDrugChargeRepository
    {
        private readonly AutoMapper.IMapper _mapper;
        private IEnumerable<IInsurancePolicy> _insurancePolicies;
        private IInvoiceRepository _invoiceRepository;
        public DrugChargeRepository(ValidationErrorCodes errorCodes,
                                          DataBaseContext dbContext,
                                          ILoginUser loggedUser,
                                          ITransactionProvider transactionProvider,
                                          IMapper mapper,
                                          IInvoiceRepository invoiceRepository
                                          ) : base(errorCodes, dbContext, loggedUser)
        {
            _mapper = mapper;
            _invoiceRepository = invoiceRepository;
        }

        private async Task<int> GetMaxChargeNo()
        {
            int maxId = 1;

            var query = this.Connection.From<DrugCharge>()
                        .Select<DrugCharge>((c) => new
                        {
                            ChargeNo = Sql.Max(c.ChargeNo)
                        })
                        .Where(i => i.PracticeId == LoggedUser.PracticeId);

            var queryResult = await this.Connection.SelectAsync<dynamic>(query);
            var result = Mapper<DrugCharge>.Map(queryResult);

            maxId = result == null ? 1 : result.ChargeNo;
            return maxId;
        }

        public async Task<ICharges> AddNew(ICharges entity, IEnumerable<IInsurancePolicy> insurancePolicies)
        {
            try
            {
                var tEntity = _mapper.Map<DrugCharge>(entity);

                _insurancePolicies = insurancePolicies;
                var errors = await this.ValidateEntityToAdd(tEntity);
                if (errors.Count() > 0)
                    await this.ThrowEntityException(errors);

                tEntity.ChargeNo = (await this.GetMaxChargeNo()) + 1;
                tEntity.Mod1 = tEntity.Mod1 ?? string.Empty;
                tEntity.Mod2 = tEntity.Mod2 ?? string.Empty;
                tEntity.Mod3 = tEntity.Mod3 ?? string.Empty;
                tEntity.Mod4 = tEntity.Mod4 ?? string.Empty;

                if (tEntity.BillToInsurance)
                    tEntity.DueByFlagCD = "PRIMARY";
                else if (tEntity.BillToPatient)
                    tEntity.DueByFlagCD = "PATIENT";

                tEntity.ICD2 = tEntity.ICD2 ?? string.Empty;
                tEntity.ICD3 = tEntity.ICD3 ?? string.Empty;
                tEntity.ICD4 = tEntity.ICD4 ?? string.Empty;

                tEntity.NDCCode = tEntity.NDCCode ?? string.Empty;
                tEntity.Comments = tEntity.Comments ?? string.Empty;
                tEntity.Message1 = tEntity.Message1 ?? string.Empty;
                tEntity.Message2 = tEntity.Message2 ?? string.Empty;


                return await base.AddNewAsync(tEntity);
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<ICharges>> GetByInvoice(string invoiceUId)
        {
            var invoice = await this._invoiceRepository.GetByUId(Guid.Parse(invoiceUId));
            invoice.Id = invoice != null ? invoice.Id : 0;
            return await this.Connection.SelectAsync<DrugCharge>(i => i.InvoiceId == invoice.Id && i.PracticeId == LoggedUser.PracticeId && !i.CPTCode.Contains("S9480"));
        }

        public async Task<int> DeletByInvoice(int invoiceId, int chargeNo)
        {
            return await this.Connection.DeleteAsync<DrugCharge>(i => i.InvoiceId == invoiceId && i.PracticeId == LoggedUser.PracticeId && i.ChargeNo == chargeNo);
        }

        public async Task<int> DeletByInvoice(int invoiceId)
        {
            return await this.Connection.DeleteAsync<DrugCharge>(i => i.InvoiceId == invoiceId && i.PracticeId == LoggedUser.PracticeId);
        }

        public async Task<int> Update(ICharges entity, IEnumerable<IInsurancePolicy> insurancePolicies)
        {
            try
            {
                var tEntity = _mapper.Map<DrugCharge>(entity);
                _insurancePolicies = insurancePolicies;

                var errors = await this.ValidateEntityToUpdate(tEntity);
                if (errors.Count() > 0)
                    await this.ThrowEntityException(errors);

                var updateOnlyFields = this.Connection
                                           .From<DrugCharge>()
                                           .Update(x => new
                                           {
                                               x.ICD1,
                                               x.ICD2,
                                               x.ICD3,
                                               x.ICD4,
                                               x.IsDeleted,
                                               x.IsLocked,
                                               x.IsTaxable,
                                               x.Message1,
                                               x.Message2,
                                               x.Mod1,
                                               x.Mod2,
                                               x.Mod3,
                                               x.Mod4,
                                               x.MultiplyQty,
                                               x.NDCCode,
                                               x.NDCFormat,
                                               x.OrderingProviderId,
                                               x.PatientCaseId,
                                               x.PerformingFacilityId,
                                               x.PerformingProviderId,
                                               x.POSId,
                                               x.Qty,
                                               x.RefNumber,
                                               x.Tax,
                                               x.TOSId,
                                               x.UnitOfMeasure,
                                               x.EntryDate,
                                               x.DueByFlagCD,
                                               x.DrugQty,
                                               x.Discount,
                                               x.Description,
                                               x.CPTCode,
                                               x.Comments,
                                               x.ChargeNo,
                                               x.BillToPatient,
                                               x.BillToInsurance,
                                               x.BillToDate,
                                               x.BillToClinic,
                                               x.BillFromDate,
                                               x.Amount
                                           })
                                           .Where(i => i.UId == entity.UId && i.PracticeId == LoggedUser.PracticeId);

                return await base.UpdateOnlyAsync(tEntity, updateOnlyFields);
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> DeleteCharge(int invoiceId, int chargeId)
        {
            try
            {
                return await this.Connection.DeleteAsync<Charges>(i => i.InvoiceId == invoiceId && i.Id == chargeId && i.PracticeId == LoggedUser.PracticeId);
            }
            catch
            {
                throw;
            }
        }

        private void ICDandModifierValidation(DrugCharge tEntity, ref List<IValidationResult> errors)
        {
            var _icdDuplicacyCondition = ((!string.IsNullOrEmpty(tEntity.ICD2) ? tEntity.ICD2 == tEntity.ICD1 : false)
                                         || ((!string.IsNullOrEmpty(tEntity.ICD3) && !string.IsNullOrEmpty(tEntity.ICD2)) ? tEntity.ICD3 == tEntity.ICD2 : false)
                                         || (!string.IsNullOrEmpty(tEntity.ICD3) ? tEntity.ICD3 == tEntity.ICD1 : false)
                                         || ((!string.IsNullOrEmpty(tEntity.ICD4) && !string.IsNullOrEmpty(tEntity.ICD3)) ? tEntity.ICD4 == tEntity.ICD3 : false)
                                         || ((!string.IsNullOrEmpty(tEntity.ICD4) && !string.IsNullOrEmpty(tEntity.ICD2)) ? tEntity.ICD4 == tEntity.ICD2 : false)
                                         || (!string.IsNullOrEmpty(tEntity.ICD4) ? tEntity.ICD4 == tEntity.ICD1 : false));

            if (_icdDuplicacyCondition)
                errors.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.DiagnosisCodeAlreadyUsedForThisCPT]));

            var _modifiersDuplicacyCondition = ((!string.IsNullOrEmpty(tEntity.Mod2) && (!string.IsNullOrEmpty(tEntity.Mod1))) ? tEntity.Mod2 == tEntity.Mod1 : false
                || ((!string.IsNullOrEmpty(tEntity.Mod3) && (!string.IsNullOrEmpty(tEntity.Mod2))) ? tEntity.Mod3 == tEntity.Mod2 : false)
                || ((!string.IsNullOrEmpty(tEntity.Mod3) && (!string.IsNullOrEmpty(tEntity.Mod1))) ? tEntity.Mod3 == tEntity.Mod1 : false)
                || ((!string.IsNullOrEmpty(tEntity.Mod4) && !string.IsNullOrEmpty(tEntity.Mod3)) ? tEntity.Mod4 == tEntity.Mod3 : false)
                || (!string.IsNullOrEmpty(tEntity.Mod4) && !string.IsNullOrEmpty(tEntity.Mod2) ? tEntity.Mod4 == tEntity.Mod2 : false)
                || (!string.IsNullOrEmpty(tEntity.Mod4) && !string.IsNullOrEmpty(tEntity.Mod1) ? tEntity.Mod4 == tEntity.Mod1 : false));

            if (_modifiersDuplicacyCondition)
                errors.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.ModifierAlreadyExistForThisCPT]));
        }

        private async Task<List<IValidationResult>> ModifierValidation(DrugCharge tEntity, List<IValidationResult> errors)
        {
            var codes = await this.Connection.SelectAsync<DrugCharge>(i => i.CPTCode == tEntity.CPTCode &&
                i.InvoiceId == tEntity.InvoiceId && i.PracticeId == LoggedUser.PracticeId);

            var _modifiers = codes.Where(i => (!string.IsNullOrEmpty(tEntity.Mod1) ? i.Mod1 == tEntity.Mod1 : false)
                                     || (!string.IsNullOrEmpty(tEntity.Mod2) ? i.Mod2 == tEntity.Mod2 : false)
                                     || (!string.IsNullOrEmpty(tEntity.Mod3) ? i.Mod3 == tEntity.Mod3 : false)
                                     || (!string.IsNullOrEmpty(tEntity.Mod4) ? i.Mod4 == tEntity.Mod4 : false));

            if (tEntity.Id > 0 && _modifiers.Count() > 0)
                _modifiers = _modifiers.Where(i => i.Id != tEntity.Id).ToList();

            if (_modifiers.Count() > 0)
                errors.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.ModifierShouldBeUniqueForSameCPTCodes]));

            return errors;
        }

        public override async Task<IEnumerable<IValidationResult>> ValidateEntityToAdd(DrugCharge tEntity)
        {
            List<IValidationResult> errors = new List<IValidationResult>();

            ICDandModifierValidation(tEntity, ref errors);
            errors = await ModifierValidation(tEntity, errors);

            if (tEntity.BillToInsurance && _insurancePolicies.Count() == 0 && !tEntity.IsChargeDeleted)
                errors.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.PatientDoesNotHaveInsurance]));

            var entityErrors = await base.ValidateEntity(tEntity);
            errors.AddRange(entityErrors);

            return errors;
        }

        public override async Task<IEnumerable<IValidationResult>> ValidateEntityToUpdate(DrugCharge tEntity)
        {
            List<IValidationResult> errors = new List<IValidationResult>();

            ICDandModifierValidation(tEntity, ref errors);

            errors = await ModifierValidation(tEntity, errors);

            if (tEntity.BillToInsurance && _insurancePolicies.Count() == 0 && !tEntity.IsChargeDeleted)
                errors.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.PatientDoesNotHaveInsurance]));

            var entityErrors = await base.ValidateEntity(tEntity);
            errors.AddRange(entityErrors);

            return errors;
        }

        public async Task<bool> GetDrugCharge(int invoiceId, int patientCaseId, string cptCode)
        {
            var charge = await this.Connection.SelectAsync<DrugCharge>(i => i.InvoiceId == invoiceId && i.PatientCaseId == patientCaseId && i.CPTCode == cptCode && i.PracticeId == LoggedUser.PracticeId && !i.CPTCode.Contains("S9480"));
            return charge.Count == 0 ? true : false;
        }
    }
}
