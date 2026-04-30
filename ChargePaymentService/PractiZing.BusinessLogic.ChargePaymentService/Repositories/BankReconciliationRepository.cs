using Microsoft.Extensions.Configuration;
using PractiZing.Base.Entities.ChargePaymentService;
using PractiZing.Base.Entities.SecurityService;
using PractiZing.Base.Object.ChargePaymentService;
using PractiZing.Base.Repositories.ChargePaymentService;
using PractiZing.BusinessLogic.Common;
using PractiZing.DataAccess.ChargePaymentService;
using PractiZing.DataAccess.ChargePaymentService.Objects;
using PractiZing.DataAccess.ChargePaymentService.Tables;
using PractiZing.DataAccess.Common;
using PractiZing.DataAccess.Common.Helpers;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PractiZing.BusinessLogic.ChargePaymentService.Repositories
{
    public class BankReconciliationRepository : ModuleBaseRepository<BankReconciliation>, IBankReconciliationRepository
    {
        private IConfiguration _configuration;
        public BankReconciliationRepository(ValidationErrorCodes errorCodes,
                                            DataBaseContext dbContext,
                                            ILoginUser loggedUser,
                                            IConfiguration configuration
                                            ) : base(errorCodes, dbContext, loggedUser)
        {
            this._configuration = configuration;
            //this.Connection.ConnectionString = this._configuration.GetConnectionString("DefaultConnection");
            //this.DbContext.Connection.ConnectionString = this._configuration.GetConnectionString("DefaultConnection");
            
        }    
        
        public async Task<IEnumerable<IBankReconciliationDTO>>GetDataYearWise(int yearId)
        {
            //var list = await this.Connection.SelectAsync<BankReconciliation>(i => i.YearId == yearId);
            var query = this.Connection.From<BankReconciliation>()
                .Join<BankReconciliation, ChasePaymentChild>((i, j) => i.Id == j.BankReconciliationId)
                .Join<ChasePaymentChild, ChasePayments>((i, j) => i.ChasePaymentId == j.Id)
                .Select<BankReconciliation>((j) => new
                {
                    j
                }).Where<BankReconciliation>(i => i.YearId == yearId);
            var queryResult = await this.Connection.SelectAsync<dynamic>(query);
            var list = (Mapper<BankReconciliation>.MapList(queryResult)).ToList();



            var results = list.GroupBy(i => new
            {
                i.YearId,
                i.MonthId
            }).Select(i => new BankReconciliationDTO
            {
                MonthId=i.Key.MonthId,
                YearId=i.Key.YearId,
                ClinicTotalPayment= Convert.ToDecimal(i.Sum(y => y.ClinicPaymentAmount)),
                LabTotalPayment = Convert.ToDecimal(i.Sum(y => y.LABPaymentAmount)),
                ResTotalPayment = Convert.ToDecimal(i.Sum(y => y.RESPaymentAmount)),
            });

            return results;
        }

        public async Task<IEnumerable<IBankReconciliation>> GetData(int monthId,int yearId)
        {

            //var query = this.Connection.From<BankReconciliation>()
            //    .Join<BankReconciliation, ChasePaymentChild>((i, j) => i.Id == j.BankReconciliationId)
            //    .Join<ChasePaymentChild, ChasePayments>((i, j) => i.ChasePaymentId == j.Id)
            //    .Select<BankReconciliation>((j) => new
            //    {
            //        j.Id
            //    }).Where<BankReconciliation>(i => i.MonthId == monthId && i.YearId == yearId);
            //var queryResult = await this.Connection.SelectAsync<dynamic>(query);
            //var result = (Mapper<BankReconciliation>.MapList(queryResult)).ToList();

            var query = this.Connection.From<BankReconciliation>()
                .LeftJoin<BankReconciliation, ChasePaymentChild>((i, j) => i.Id == j.BankReconciliationId)
                //.Join<ChasePaymentChild, ChasePayments>((i, j) => i.ChasePaymentId == j.Id)
                .Select<BankReconciliation, ChasePaymentChild>((j, k) => new
                {
                    Id = j.Id,
                    ChildId = k.Id
                }).Where<BankReconciliation>(i => i.MonthId == monthId && i.YearId == yearId);
            var queryResult = await this.Connection.SelectAsync<dynamic>(query);
            var result = (Mapper<Test>.MapList(queryResult)).ToList();

            var lstBankDeposits = result.Where(i => i.ChildId == 0).Select(i => i.Id.ToString());
            //var lstBankDeposits = result.Select(i => i.Id.ToString());

            List<BankReconciliation> list = new List<BankReconciliation>();
            if (lstBankDeposits.Count()>0)
            {
                list = await this.Connection.SelectAsync<BankReconciliation>(i => i.MonthId == monthId && i.YearId == yearId && lstBankDeposits.Contains(i.Id.ToString()));
            }
            else
            {
                list = await this.Connection.SelectAsync<BankReconciliation>(i => i.MonthId == monthId && i.YearId == yearId);
            }
            

            

            foreach (var item in list)
            {
                var clinicDeposit= item.ClinicDepositAmount.HasValue ? item.ClinicDepositAmount.Value : 0;
                var labDeposit = item.LABDepositAmount.HasValue ? item.LABDepositAmount.Value : 0;
                var resDeposit = item.RESDepositAmount.HasValue ? item.RESDepositAmount.Value : 0;
                item.TotalDeposit = clinicDeposit + labDeposit + resDeposit;

                var clinicPayment = item.ClinicPaymentAmount.HasValue ? item.ClinicPaymentAmount.Value : 0;
                var labPayment = item.LABPaymentAmount.HasValue ? item.LABPaymentAmount.Value : 0;
                var resPayment = item.RESPaymentAmount.HasValue ? item.RESPaymentAmount.Value : 0;
                item.TotalPayment = clinicPayment + labPayment  + resPayment;

                item.TotalDifference = item.TotalDeposit - item.TotalPayment;

                if (item.ClinicEffectiveDate.HasValue)
                    item.EffectiveDate = item.ClinicEffectiveDate.Value;
                else if (item.LABEffectiveDate.HasValue)
                    item.EffectiveDate = item.LABEffectiveDate.Value;
                else if (item.RESEffectiveDate.HasValue)
                    item.EffectiveDate = item.RESEffectiveDate.Value;

                if (item.ClinicEffectiveDate.HasValue)
                    item.EffectiveDate = item.ClinicEffectiveDate.Value;
                else if (item.LABEffectiveDate.HasValue)
                    item.EffectiveDate = item.LABEffectiveDate.Value;
                else if (item.RESEffectiveDate.HasValue)
                    item.EffectiveDate = item.RESEffectiveDate.Value;

                if (!string.IsNullOrWhiteSpace(item.ClinicPayerName))
                    item.ClinicPayerName = item.ClinicPayerName;
                else if (!string.IsNullOrWhiteSpace(item.LABPayerName))
                    item.ClinicPayerName = item.LABPayerName;
                else if (!string.IsNullOrWhiteSpace(item.RESPayerName))
                    item.ClinicPayerName = item.RESPayerName;

                item.ChasePaymentAmount = item.ChasePaymentAmount.HasValue ? item.ChasePaymentAmount : 0;
                item.LABPaymentAmount = item.LABPaymentAmount.HasValue ? item.LABPaymentAmount : 0;
                item.RESPaymentAmount = item.RESPaymentAmount.HasValue ? item.RESPaymentAmount : 0;
                item.ClinicPaymentAmount = item.ClinicPaymentAmount.HasValue ? item.ClinicPaymentAmount : 0;
                
            }

            return list.OrderBy(i=>i.EffectiveDate);
        }


        public async Task<IEnumerable<IBankReconciliationDTO>> GetUnmacnedDepositsYearWise(int yearId)
        {

            var query = this.Connection.From<BankReconciliation>()
                .LeftJoin<BankReconciliation, ChasePaymentChild>((i, j) => i.Id == j.BankReconciliationId)
                //.Join<ChasePaymentChild, ChasePayments>((i, j) => i.ChasePaymentId == j.Id)
                .Select<BankReconciliation, ChasePaymentChild>((j,k) => new
                {
                    Id = j.Id,
                    ChildId = k.Id
                }).Where<BankReconciliation>(i => i.YearId == yearId);
            var queryResult = await this.Connection.SelectAsync<dynamic>(query);
            var result = (Mapper<Test>.MapList(queryResult)).ToList();

            var lstBankDeposits = result.Where(i => i.ChildId == 0).Select(i => i.Id.ToString());

            List<List<string>> tempIds = new List<List<string>>();

            if (lstBankDeposits.Count() > 0)
            {
                //Chunks a collection into smaller lists of a specified size.
                tempIds = CollectionChunksHelper.Chunk(lstBankDeposits, 2000);
            }

            List<BankReconciliation> list = new List<BankReconciliation>();
            if (lstBankDeposits.Count() > 0)
            {
                foreach (var item in tempIds)
                {
                    var selectIds = item.Select(i => i.ToString());
                   var  templist = await this.Connection.SelectAsync<BankReconciliation>(i => i.YearId == yearId && selectIds.Contains(i.Id.ToString()));
                    list.AddRange(templist);
                }
                //list = await this.Connection.SelectAsync<BankReconciliation>(i => i.YearId == yearId && !lstBankDeposits.Contains(i.Id.ToString()));
            }
            else
            {
                list = await this.Connection.SelectAsync<BankReconciliation>(i => i.YearId == yearId);
            }


            foreach (var item in list)
            {
                var clinicDeposit = item.ClinicDepositAmount.HasValue ? item.ClinicDepositAmount.Value : 0;
                var labDeposit = item.LABDepositAmount.HasValue ? item.LABDepositAmount.Value : 0;
                var resDeposit = item.RESDepositAmount.HasValue ? item.RESDepositAmount.Value : 0;
                item.TotalDeposit = clinicDeposit + labDeposit + resDeposit;

                var clinicPayment = item.ClinicPaymentAmount.HasValue ? item.ClinicPaymentAmount.Value : 0;
                var labPayment = item.LABPaymentAmount.HasValue ? item.LABPaymentAmount.Value : 0;
                var resPayment = item.RESPaymentAmount.HasValue ? item.RESPaymentAmount.Value : 0;
                item.TotalPayment = clinicPayment + labPayment + resPayment;

                item.TotalDifference = item.TotalDeposit - item.TotalPayment;

                if (item.ClinicEffectiveDate.HasValue)
                    item.EffectiveDate = item.ClinicEffectiveDate.Value;
                else if (item.LABEffectiveDate.HasValue)
                    item.EffectiveDate = item.LABEffectiveDate.Value;
                else if (item.RESEffectiveDate.HasValue)
                    item.EffectiveDate = item.RESEffectiveDate.Value;

                if (item.ClinicEffectiveDate.HasValue)
                    item.EffectiveDate = item.ClinicEffectiveDate.Value;
                else if (item.LABEffectiveDate.HasValue)
                    item.EffectiveDate = item.LABEffectiveDate.Value;
                else if (item.RESEffectiveDate.HasValue)
                    item.EffectiveDate = item.RESEffectiveDate.Value;

                if (!string.IsNullOrWhiteSpace(item.ClinicPayerName))
                    item.ClinicPayerName = item.ClinicPayerName;
                else if (!string.IsNullOrWhiteSpace(item.LABPayerName))
                    item.ClinicPayerName = item.LABPayerName;
                else if (!string.IsNullOrWhiteSpace(item.RESPayerName))
                    item.ClinicPayerName = item.RESPayerName;

                item.ChasePaymentAmount = item.ChasePaymentAmount.HasValue ? item.ChasePaymentAmount : 0;
                item.LABPaymentAmount = item.LABPaymentAmount.HasValue ? item.LABPaymentAmount : 0;
                item.RESPaymentAmount = item.RESPaymentAmount.HasValue ? item.RESPaymentAmount : 0;
                item.ClinicPaymentAmount = item.ClinicPaymentAmount.HasValue ? item.ClinicPaymentAmount : 0;

            }


            var results = list.GroupBy(i => new
            {
                i.YearId,
                i.MonthId
            }).Select(i => new BankReconciliationDTO
            {
                MonthId = i.Key.MonthId,
                YearId = i.Key.YearId,
                ClinicTotalPayment = Convert.ToDecimal(i.Sum(y => y.ClinicPaymentAmount)),
                LabTotalPayment = Convert.ToDecimal(i.Sum(y => y.LABPaymentAmount)),
                ResTotalPayment = Convert.ToDecimal(i.Sum(y => y.RESPaymentAmount)),
            });


            return results;
        }

        public async Task<int> Update(int voucherId, int chasePaymentId)
        {
            try
            {
                BankReconciliation tEntity = await this.GetById(voucherId);
                tEntity.ChaseTransactionId = chasePaymentId;
                tEntity.ChaseTransactionDate = System.DateTime.Now;
                tEntity.ChaseTransactionUpdatedBy = this.LoggedUser.UserName;
                var updateOnlyFields = this.Connection
                                       .From<BankReconciliation>()
                                       .Update(x => new
                                       {
                                           x.ChaseTransactionId,
                                           x.ChaseTransactionUpdatedBy,x.ChaseTransactionDate
                                       })
                                       .Where(i => i.Id == tEntity.Id);
                return await base.UpdateOnlyAsync(tEntity, updateOnlyFields);
                
                
            }
            catch
            {
                throw;
            }
        }

        public async Task<string> SyncData(int monthId, int yearid)
        {
            try
            {
                string command = "usp_GetAllPracticesVouchers " + monthId.ToString() + "," + yearid.ToString();
                var result = await base.ExecuteStoredProcedureAsync<dynamic>(command);

                return "True";
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public async Task<IEnumerable<string>> GetDataForChasePayment(int monthId, int yearId)
        {
            var list = await this.Connection.SelectAsync<BankReconciliation>(i => i.YearId == yearId && i.MonthId == monthId && i.ChaseTransactionId.HasValue);
            var ids = list.Select(i => i.ChaseTransactionId.Value.ToString());
            return ids;
        }

        public async Task<IEnumerable<IBankReconciliation>> GetDataByChasePaymentId(int chasePaymentId)
        {

            var query = this.Connection.From<BankReconciliation>()
                .Join<BankReconciliation, ChasePaymentChild>((i, j) => i.Id == j.BankReconciliationId)
                .Join<ChasePaymentChild, ChasePayments>((i, j) => i.ChasePaymentId == j.Id)
                .Select<BankReconciliation, ChasePaymentChild>((j,k) => new
                {
                    j,
                    ChasePaymentChildId=k.Id
                }).Where<ChasePayments>(i => i.Id== chasePaymentId);
            var queryResult = await this.Connection.SelectAsync<dynamic>(query);
            var result = (Mapper<BankReconciliation>.MapList(queryResult)).ToList();

            //var lstBankDeposits = result.Select(i => i.Id.ToString());

            //var list = await this.Connection.SelectAsync<BankReconciliation>(i => !lstBankDeposits.Contains(i.Id.ToString()));



            foreach (var item in result)
            {
                var clinicDeposit = item.ClinicDepositAmount.HasValue ? item.ClinicDepositAmount.Value : 0;
                var labDeposit = item.LABDepositAmount.HasValue ? item.LABDepositAmount.Value : 0;
                var resDeposit = item.RESDepositAmount.HasValue ? item.RESDepositAmount.Value : 0;
                item.TotalDeposit = clinicDeposit + labDeposit + resDeposit;

                var clinicPayment = item.ClinicPaymentAmount.HasValue ? item.ClinicPaymentAmount.Value : 0;
                var labPayment = item.LABPaymentAmount.HasValue ? item.LABPaymentAmount.Value : 0;
                var resPayment = item.RESPaymentAmount.HasValue ? item.RESPaymentAmount.Value : 0;
                item.TotalPayment = clinicPayment + labPayment + resPayment;

                item.TotalDifference = item.TotalDeposit - item.TotalPayment;

                if (item.ClinicEffectiveDate.HasValue)
                    item.EffectiveDate = item.ClinicEffectiveDate.Value;
                else if (item.LABEffectiveDate.HasValue)
                    item.EffectiveDate = item.LABEffectiveDate.Value;
                else if (item.RESEffectiveDate.HasValue)
                    item.EffectiveDate = item.RESEffectiveDate.Value;

                if (item.ClinicEffectiveDate.HasValue)
                    item.EffectiveDate = item.ClinicEffectiveDate.Value;
                else if (item.LABEffectiveDate.HasValue)
                    item.EffectiveDate = item.LABEffectiveDate.Value;
                else if (item.RESEffectiveDate.HasValue)
                    item.EffectiveDate = item.RESEffectiveDate.Value;

                if (!string.IsNullOrWhiteSpace(item.ClinicPayerName))
                    item.ClinicPayerName = item.ClinicPayerName;
                else if (!string.IsNullOrWhiteSpace(item.LABPayerName))
                    item.ClinicPayerName = item.LABPayerName;
                else if (!string.IsNullOrWhiteSpace(item.RESPayerName))
                    item.ClinicPayerName = item.RESPayerName;

                item.ChasePaymentAmount = item.ChasePaymentAmount.HasValue ? item.ChasePaymentAmount : 0;
                item.LABPaymentAmount = item.LABPaymentAmount.HasValue ? item.LABPaymentAmount : 0;
                item.RESPaymentAmount = item.RESPaymentAmount.HasValue ? item.RESPaymentAmount : 0;
                item.ClinicPaymentAmount = item.ClinicPaymentAmount.HasValue ? item.ClinicPaymentAmount : 0;

            }

            return result.OrderBy(i => i.EffectiveDate);
        }


        public async Task<int> SyncDepositsWithChasePayments(int monthId, int yearId)
        {

            try
            {
                string command = "USP_SyncDepositsWithChasePayments " + monthId.ToString() + "," + yearId.ToString();
                var result = await base.ExecuteStoredProcedureAsync<dynamic>(command);

                return 0;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }


    }
}
