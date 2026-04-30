using PractiZing.Base.Entities.ChargePaymentService;
using PractiZing.Base.Entities.SecurityService;
using PractiZing.Base.Repositories.ChargePaymentService;
using PractiZing.DataAccess.ChargePaymentService;
using PractiZing.DataAccess.ChargePaymentService.Tables;
using PractiZing.DataAccess.Common;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PractiZing.DataAccess.ChargePaymentService.Objects;
using PractiZing.BusinessLogic.Common;
using PractiZing.Base.Object.ChargePaymentService;
using AutoMapper;
using PractiZing.DataAccess.PatientService.Tables;
using PractiZing.Base.Repositories.MasterService;
using PractiZing.Base.Object.CommonEntites;

namespace PractiZing.BusinessLogic.ChargePaymentService.Repositories
{
    public class ChargeBatchRepository : ModuleBaseRepository<ChargeBatch>, IChargeBatchRepository
    {
        private readonly IMapper _mapper;
        private readonly IInsuranceCompanyRepository _insuranceCompanyRepository;


        public ChargeBatchRepository(ValidationErrorCodes errorCodes,
                                            DataBaseContext dbContext,
                                            ILoginUser loggedUser,
                                            IMapper mapper,
                                            IInsuranceCompanyRepository insuranceCompanyRepository
                                            ) : base(errorCodes, dbContext, loggedUser)
        {
            _mapper = mapper;
            _insuranceCompanyRepository = insuranceCompanyRepository;
        }

        public async Task<IEnumerable<IChargeBatch>> GetAll(IEnumerable<int> chargeBatchIds)
        {
            try
            {
                var result = await this.Connection.SelectAsync<ChargeBatch>(i => chargeBatchIds.Contains(i.Id) && i.PracticeId == LoggedUser.PracticeId);
                return result;
            }
            catch
            {
                throw;
            }
        }

        public async Task<IChargeBatch> Get(int id)
        {
            var result = await this.Connection.SingleAsync<ChargeBatch>(i => i.Id == id && i.PracticeId == LoggedUser.PracticeId);
            return result;
        }

        public async Task<IChargeBatch> GetByUId(string uid)
        {
            var result = await this.Connection.SingleAsync<ChargeBatch>(i => i.UId == new Guid(uid) && i.PracticeId == LoggedUser.PracticeId);
            return result;
        }

        /// <summary>
        /// this method is generating batch number 
        /// </summary>
        /// <returns></returns>
        public async Task<IGetBatchNumberDTO> GetBatchNumber()
        {
            var batchData = await this.Connection.SelectAsync<ChargeBatch>();
            GetBatchNumberDTO number = new GetBatchNumberDTO();

            // this loc is creating batch number with frist 3 character and then - then today's date with - seperator and then total batch count present in table.
            number.BatchNumber = LoggedUser.UserName.Substring(0, 3).ToUpper() + '-' + DateTime.Now.Date.ToShortDateString().Replace("/", "") + '-' + (batchData.Count() == 0 ? 1 : Convert.ToInt32((batchData.Max(i => i.Id)) + 1));

            return number;
        }

        public async Task<IEnumerable<IDropDownDTO>> GetActive()
        {
            List<IDropDownDTO> dropDownDTOs = new List<IDropDownDTO>();
            var chargeBatchData = await this.Connection.SelectAsync<ChargeBatch>(i => i.IsActive == true && i.PracticeId == LoggedUser.PracticeId && i.CreatedBy == LoggedUser.UserName);
            chargeBatchData.ForEach((res) =>
            {
                DropDownDTO dropDown = new DropDownDTO();
                dropDown.label = res.BatchNo;
                dropDown.value = res.UId;

                dropDownDTOs.Add(dropDown);
            });

            return dropDownDTOs;
        }

        /// <summary>
        /// get current active batch 
        /// </summary>
        /// <returns></returns>
        public async Task<IChargeBatch> GetCurrentBatch()
        {
            // get all batches generated today.
            var chargeBatches = await this.Connection.SelectAsync<ChargeBatch>(i => i.PracticeId == LoggedUser.PracticeId);
            var result = chargeBatches.Where(i => i.BatchDate.Date == DateTime.Now.Date);

            // if no batch generated today then new charge batch will create.
            if (result.Count() == 0)
            {
                var chargeBatch = await this.AddNew(new ChargeBatch());
                return chargeBatch;
                //await GetCurrentBatch();
            }

            return result.LastOrDefault();
        }

        public async Task<IEnumerable<IBatchDTO>> GetChargeGrid(IBatchFilter filter)
        {
            try
            {
                // this query is to find charge batch with amount and get total cpt codes exists in this batch and 
                //sum of charges amount exists in these cpt codes.

                // filter.InsuranceCompanyId = filter.InsuranceCompanyUId == string.Empty ? 0 : (await this._insuranceCompanyRepository.GetByUId(Guid.Parse(filter.InsuranceCompanyUId))).Id;

                var query = this.Connection.From<ChargeBatch>()
                                 .LeftJoin<ChargeBatch, Invoice>((cb, i) => cb.Id == i.ChargeBatchId)
                                 .LeftJoin<Invoice, Charges>((i, c) => i.Id == c.InvoiceId)
                                 .LeftJoin<Invoice, InsurancePolicy>((i, p) => i.PatientCaseId == p.PatientCaseId)
                                 .SelectDistinct<ChargeBatch, Charges, InsurancePolicy>((x, c, p) => new
                                 {
                                     BatchDate = x.BatchDate,
                                     BatchNo = x.BatchNo,
                                     BatchAmount = Sql.Avg(x.BatchAmount),
                                     RecordCount = x.RecordCount,
                                     Id = x.Id,
                                     UId = x.UId,
                                     PostedChargesValue = Sql.Sum(c.MultiplyQty ? (c.Amount * c.Qty) : c.Amount), // find 
                                     PostedChargesCount = Sql.CountDistinct(c.CPTCode),
                                     Active = x.IsActive
                                 })
                                 .GroupBy<ChargeBatch, Charges, InsurancePolicy>((i, j, k) => new
                                 {
                                     i.Id,
                                     i.UId,
                                     i.BatchDate,
                                     i.BatchNo,
                                     i.RecordCount,
                                     i.IsActive
                                 })
                                 .Where<ChargeBatch, Charges>((i, j) => i.PracticeId == LoggedUser.PracticeId);

                //this will bind our filter object with ChargeBatchFilter object
                var resultFilter = _mapper.Map<ChargeBatchFilter>(filter);

                //this is the select expression and from expression of query.
                string selectExpression = $"{query.SelectExpression} {query.FromExpression}";
                //this is the count expression of query.
                string countExpression = query.ToCountStatement();
                // this will create where expression query using the filter parameter's
                string whereExpression = await WhereClauseProvider<IChargeBatchFilter>.GetWhereClause(resultFilter);
                //and then concat upper where expression(line no. 185) with this where expression(line no 195)
                query.WhereExpression = query.WhereExpression + " AND " + whereExpression;

                var queryResult = await this.Connection.SelectAsync<dynamic>(query);
                var result = Mapper<BatchDTO>.MapList(queryResult);

                return result.OrderByDescending(i => i.Id);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// add method for creating new charge batch
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<IChargeBatch> AddNew(IChargeBatch entity)
        {
            try
            {
                ChargeBatch tEntity = entity as ChargeBatch;
                tEntity.BatchDate = DateTime.Now;
                tEntity.IsActive = true;

                // this is the method to generate new batch number.
                var batchNumber = await this.GetBatchNumber();
                tEntity.BatchNo = batchNumber.BatchNumber;

                var result = await base.AddNewAsync(tEntity);
                return result;
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> Update(IChargeBatch entity)
        {
            try
            {
                ChargeBatch tEntity = entity as ChargeBatch;

                var updateOnlyFields = this.Connection
                                           .From<ChargeBatch>()
                                           .Update(x => new
                                           {
                                               x.RecordCount,
                                               x.BatchAmount
                                           })
                                           .Where(i => i.UId == entity.UId && i.PracticeId == LoggedUser.PracticeId);

                var value = await base.UpdateOnlyAsync(tEntity, updateOnlyFields);
                return value;
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> UpdateStatus(string chargeBatchUId, bool isActive)
        {
            try
            {
                Guid chargeBatch = (chargeBatchUId == string.Empty || chargeBatchUId == null) ? new Guid() : new Guid(chargeBatchUId);
                var chargeBatchData = await this.Connection.SingleAsync<ChargeBatch>(i => i.UId == chargeBatch);

                ChargeBatch tEntity = chargeBatchData as ChargeBatch;
                tEntity.IsActive = isActive;

                var updateOnlyFields = this.Connection
                                           .From<ChargeBatch>()
                                           .Update(x => new
                                           {
                                               x.IsActive
                                           })
                                           .Where(i => i.UId == tEntity.UId && i.PracticeId == LoggedUser.PracticeId);

                var value = await base.UpdateOnlyAsync(tEntity, updateOnlyFields);
                return value;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// method to delete charge batch 
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public async Task<int> Delete(Guid uid)
        {
            try
            {
                var result = await this.Connection.DeleteAsync<ChargeBatch>(i => i.UId == uid && i.PracticeId == LoggedUser.PracticeId);
                return result;
            }
            catch
            {
                throw;
            }
        }

        public async Task ThrowError()
        {
            await this.ThrowEntityException(new ValidationCodeResult(ErrorCodes[EnumErrorCode.NoDeletionOfChargeBatch]));
        }

        public async Task<string> UpdateCCNClaims()
        {
            try
            {
                await base.ExecuteStoredProcedureAsync<dynamic>("usp_UpdatePayerControlNumberToClaims");
                return "Success";
            }

            catch
            {
                throw;
            }
        }
    }
}
