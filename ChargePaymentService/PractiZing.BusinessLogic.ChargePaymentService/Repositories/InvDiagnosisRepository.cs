using PractiZing.Base.Common;
using PractiZing.Base.Entities.ChargePaymentService;
using PractiZing.Base.Entities.SecurityService;
using PractiZing.Base.Repositories.ChargePaymentService;
using PractiZing.Base.Repositories.MasterService;
using PractiZing.DataAccess.ChargePaymentService;
using PractiZing.DataAccess.Common;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using PractiZing.DataAccess.MasterService.Tables;
using PractiZing.BusinessLogic.Common;

namespace PractiZing.BusinessLogic.ChargePaymentService.Repositories
{
    public class InvDiagnosisRepository : ModuleBaseRepository<InvDiagnosis>, IInvDiagnosisRepository
    {
        private readonly IICDCodeRepository _iCDCodeRepository;
        private readonly IInvoiceRepository _invoiceRepository;
        public InvDiagnosisRepository(ValidationErrorCodes errorCodes,
                                            DataBaseContext dbContext,
                                            ILoginUser loggedUser,
                                            IICDCodeRepository iCDCodeRepository,
                                            IInvoiceRepository invoiceRepository
                                            ) : base(errorCodes, dbContext, loggedUser)
        {
            _iCDCodeRepository = iCDCodeRepository;
            _invoiceRepository = invoiceRepository;
        }

        public async Task<IInvDiagnosis> AddNew(IInvDiagnosis entity)
        {
            try
            {
                InvDiagnosis tEntity = entity as InvDiagnosis;
                /*Save InvDiagnosis*/
                // tEntity.ICDCode = tEntity.ICDCode == null ? null : (await this._iCDCodeRepository.GetByUId(new System.Guid(tEntity.ICDCode))).Code;
                return await base.AddNewAsync(tEntity);
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> AddNewEntities(IEnumerable<IInvDiagnosis> entities, int invoiceId)
        {
            try
            {
                await this.ICDValidation(entities.Where(i=>i.IsDiagnosisDeleted==false));
                foreach (var item in entities.Where(i => i.IsDiagnosisDeleted == false))
                {
                    item.InvoiceId = invoiceId;
                    if (string.IsNullOrWhiteSpace( item.ICDCode ))
                        continue;
                    await this.AddNew(item);
                }
                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> Delete(string invoiceUId)
        {
            try
            {
                var invoice = await this._invoiceRepository.GetByUId(Guid.Parse(invoiceUId));
                var invoiceId = invoice == null ? 0 : invoice.Id;
                return await this.Connection.DeleteAsync<InvDiagnosis>(i => i.InvoiceId == invoiceId);
            }
            catch
            {
                throw;
            }
        }

        private async Task ICDValidation(IEnumerable<IInvDiagnosis> tEntities)
        {
            bool _icdDuplicateCount = tEntities.Where(i=>i.IsDiagnosisDeleted == false).GroupBy(x => x.ICDCode).Any(g => g.Count() > 1); 
            if(_icdDuplicateCount)
                await this.ThrowEntityException(new ValidationCodeResult(ErrorCodes[EnumErrorCode.DiagnosisCodeDuplicate]));

        }

        public async Task<int> DeleteDiagnosis(int invoiceId, int diagnosisId)
        {
            try
            {
                return await this.Connection.DeleteAsync<InvDiagnosis>(i => i.InvoiceId == invoiceId && i.Id == diagnosisId);
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<IInvDiagnosis>> GetAll()
        {
            return await this.Connection.SelectAsync<InvDiagnosis>();
        }

        public async Task<IInvDiagnosis> GetByInvoiceUId(string invoiceUId)
        {
            var invoice = await this._invoiceRepository.GetByUId(Guid.Parse(invoiceUId));
            var invoiceId = invoice == null ? 0 : invoice.Id;
            return await this.Connection.SingleAsync<InvDiagnosis>(i => i.InvoiceId == invoiceId);
        }

        public async Task<IEnumerable<IInvDiagnosis>> GetByInvoiceId(IEnumerable<int> invoiceIds)
        {
            return await this.Connection.SelectAsync<InvDiagnosis>(i => invoiceIds.Contains(i.InvoiceId));
        }

        public async Task<IEnumerable<IInvDiagnosis>> GetByInvoice(int invoiceId)
        {
            try
            {
                char c1 = 'A';

                var query = this.Connection.From<InvDiagnosis>()
                       .Join<InvDiagnosis, ICDCode>((pc, p) => pc.ICDCode == p.Code, NoLockTableHint.NoLock)
                       .SelectDistinct<InvDiagnosis, ICDCode>((pc, v) => new
                       {
                           pc,
                           IcdType=v.IcdType
                       })
                       .Where<InvDiagnosis>((i => i.InvoiceId == invoiceId));

                var queryResult = await this.Connection.SelectAsync<dynamic>(query);
                var result = Mapper<InvDiagnosis>.MapList(queryResult);

                //var result = await this.Connection.SelectAsync<InvDiagnosis>(i => i.InvoiceId == invoiceId);
                foreach (var item in result)
                {
                    item.ICDCode = item.ICDCode;
                    // item.ICDCodeLabel = item.ICDCode == null ? null : icd.Code.ToString();
                    item.DiagnoseNo = c1.ToString();
                    c1++;
                }

                return result;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> UpdateEntities(IEnumerable<IInvDiagnosis> entities, int invoiceId)
        {
            try
            {
                await this.ICDValidation(entities);
                foreach (var item in entities)
                {
                    if (string.IsNullOrWhiteSpace( item.ICDCode))
                    {
                        await this.DeleteDiagnosis((int)item.InvoiceId, item.Id);
                        continue;
                    }
                        

                    item.InvoiceId = invoiceId;
                    /*Diagnosis to update*/
                    if (item.Id != 0 && !item.IsDiagnosisDeleted)
                        await this.Update(item);
                    /*Diagnosis to save new*/
                    else if (item.Id == 0 && !item.IsDiagnosisDeleted)
                        await this.AddNew(item);
                    /*Diagnosis to delete*/
                    else
                        await this.DeleteDiagnosis((int)item.InvoiceId, item.Id);
                }
                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> Update(IInvDiagnosis entity)
        {
            try
            {
                InvDiagnosis tEntity = entity as InvDiagnosis;
                //tEntity.ICDCode = tEntity.ICDCode == null ? null : (await this._iCDCodeRepository.GetByUId(new System.Guid(tEntity.ICDCode))).Code;

                var updateOnlyFields = this.Connection
                                           .From<InvDiagnosis>()
                                           .Update(x => new
                                           {
                                               x.IsICD10,
                                               x.ICDCode,
                                               x.Description,
                                               x.InvoiceId
                                           })
                                           .Where(i => i.Id == entity.Id);

                return await base.UpdateOnlyAsync(tEntity, updateOnlyFields);
            }
            catch
            {
                throw;
            }
        }
    }
}
