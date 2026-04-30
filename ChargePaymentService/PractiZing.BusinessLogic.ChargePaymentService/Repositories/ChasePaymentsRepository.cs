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
using PractiZing.DataAccess.ChargePaymentService.Tables;
using PractiZing.DataAccess.ChargePaymentService.Objects;
using System.Net.Http;
using Newtonsoft.Json;
using PractiZing.Base.Object.ChargePaymentService;

namespace PractiZing.BusinessLogic.ChargePaymentService.Repositories
{
    public class ChasePaymentsRepository : ModuleBaseRepository<ChasePayments>, IChasePaymentsRepository
    {
        private readonly IBankReconciliationRepository _bankReconciliationRepository;
        private readonly IChasePaymentChildRepository _chasePaymentChildRepository;
        public ChasePaymentsRepository(ValidationErrorCodes errorCodes,
                                            DataBaseContext dbContext,
                                            ILoginUser loggedUser,
                                            IBankReconciliationRepository bankReconciliationRepository,
                                            IChasePaymentChildRepository chasePaymentChildRepository
                                            ) : base(errorCodes, dbContext, loggedUser)
        {
            this._bankReconciliationRepository = bankReconciliationRepository;
            this._chasePaymentChildRepository = chasePaymentChildRepository;
        }

        public async Task<bool>CheckRecordExists(int monthId,int yearId)
        {
            var record = await this.Connection.SingleAsync<ChasePayments>(i => i.MonthId == monthId && i.YearId == yearId);
            if (record != null)
                return true;
            else return  false;

        }

        public async Task<IChasePaymentDashboardDTO> Get(int monthId,int yearId)
        {

            //var ids = await this._bankReconciliationRepository.GetDataForChasePayment(monthId, yearId);

            //IEnumerable<IChasePayments> list = null;
            //if (ids.Count()>0)
            //{
            //    list = await this.Connection.SelectAsync<ChasePayments>(i => i.MonthId == monthId && i.YearId == yearId && !ids.Contains(i.Id.ToString()));
            //}
            //else
            //{
            //    list = await this.Connection.SelectAsync<ChasePayments>(i => i.MonthId == monthId && i.YearId == yearId);

            //}

            var paymentDTOs = await this._bankReconciliationRepository.GetData(monthId,yearId);

            ChasePaymentDashboardDTO chasePaymentDashboardDTO = new ChasePaymentDashboardDTO();

            var list = await this.Connection.SelectAsync<ChasePayments>(i => i.MonthId == monthId && i.YearId == yearId);
            foreach (var item in list)
            {
                item.PaymentDTOs = await this._bankReconciliationRepository.GetDataByChasePaymentId(item.Id);
                if(item.PaymentDTOs.Count()>0)
                {

                }
                item.PaymentAmount = item.PaymentDTOs.Count() > 0 ? item.PaymentDTOs.Sum(i => i.TotalPayment):0;
                item.CheckNumber = "";
                item.DiffAmount = item.Amount - item.PaymentAmount;
                string[] descriptionSplit= item.Description.Split("TRN*1*");
                if(descriptionSplit.Count()>1)
                {
                    string[] trnNumber = descriptionSplit[1].Split("*");
                    if(trnNumber.Count()>0)
                    {
                        string checkNumber = trnNumber[0].Trim();
                        item.CheckNumber = checkNumber;
                    }                    
                }
                else
                {
                    if(item.Description.ToLower().Contains("stripe"))
                    {
                        item.CheckNumber = "Stripe";
                    }
                }
            }
            chasePaymentDashboardDTO.ChasePayments = list;
            chasePaymentDashboardDTO.TotalChasePayment = list.Sum(i=>i.Amount);
            chasePaymentDashboardDTO.OwnerPayments = list.Where(i=>i.IsOwnerDeposit==true).Sum(i => i.Amount);
            chasePaymentDashboardDTO.TotalPostedPayment = list.Sum(i => i.PaymentAmount);
            chasePaymentDashboardDTO.TotalDiffPayment = list.Sum(i => i.DiffAmount)- chasePaymentDashboardDTO.OwnerPayments;
            chasePaymentDashboardDTO.UnmatchedPayment = paymentDTOs.Sum(i=>i.TotalPayment);

            //var unmatchedChasePayments = await this.GetUnMappedChasePayments(monthId, yearId);

            //chasePaymentDashboardDTO.UnmatchedChasePayment = unmatchedChasePayments.Sum(i=>i.Amount);

            var yearlyPosted = await GetDataYearWise(yearId);
            chasePaymentDashboardDTO.YearlyPosted = yearlyPosted.PostedAmountYearly;
            return chasePaymentDashboardDTO;
        }

        public async Task<IChasePaymentReporParenttDTO> GetDataYearWise(int yearId)
        {

            ChasePaymentReporParenttDTO chasePaymentReporParenttDTO = new ChasePaymentReporParenttDTO();

            var list = await this.Connection.SelectAsync<ChasePayments>(i => i.YearId == yearId);

            var results = list.GroupBy(i => new
            {
                i.YearId,
                i.MonthId
            }).Select(i => new ChasePaymentReportDTO
            {
                MonthId = i.Key.MonthId,
                YearId = i.Key.YearId,
                TotalChasePayment = Convert.ToDecimal(i.Sum(y => y.Amount))
            }).ToList();

            var deposits = await this._bankReconciliationRepository.GetDataYearWise(yearId);
            var unMatchedDeposits = await this._bankReconciliationRepository.GetUnmacnedDepositsYearWise(yearId);


            foreach (var item in results)
            {
                item.TotalDiffPayment = item.TotalChasePayment;
                item.TotalPostedPayment = 0;
                item.UnmatchedPayment = 0;
                item.TotalClinicPostedPayment = 0;
                item.TotalLABPostedPayment = 0;
                item.TotalRESPostedPayment = 0;
                item.MonthName = GetMonthName(item.MonthId);

                var depositRecord = deposits.FirstOrDefault(i => i.YearId == yearId && i.MonthId == item.MonthId);
                if (depositRecord != null)
                {                    
                    var clinicTotal = depositRecord.ClinicTotalPayment.HasValue ? depositRecord.ClinicTotalPayment.Value : 0;
                    var labTotal = depositRecord.LabTotalPayment.HasValue ? depositRecord.LabTotalPayment.Value : 0;
                    var resTotal = depositRecord.ResTotalPayment.HasValue ? depositRecord.ResTotalPayment.Value : 0;

                    item.TotalClinicPostedPayment = clinicTotal;
                    item.TotalLABPostedPayment = labTotal;
                    item.TotalRESPostedPayment = resTotal;


                    var postedAmount = clinicTotal + labTotal + resTotal;
                    item.TotalPostedPayment = postedAmount;
                    item.TotalDiffPayment = item.TotalChasePayment - item.TotalPostedPayment;

                    var unmacthedRecord = unMatchedDeposits.FirstOrDefault(i=>i.YearId==yearId && i.MonthId==item.MonthId);
                    if(unmacthedRecord!=null)
                    {
                        var clinicUnMatchedTotal = unmacthedRecord.ClinicTotalPayment.HasValue ? unmacthedRecord.ClinicTotalPayment.Value : 0;
                        var labUnMatchedTotal = unmacthedRecord.LabTotalPayment.HasValue ? unmacthedRecord.LabTotalPayment.Value : 0;
                        var resUnMatchedTotal = unmacthedRecord.ResTotalPayment.HasValue ? unmacthedRecord.ResTotalPayment.Value : 0;

                        var unmatchedTotal = clinicUnMatchedTotal + labUnMatchedTotal + resUnMatchedTotal;

                        item.UnmatchedPayment = unmatchedTotal;
                    }

                    item.TotalOwnerPayment = 0;
                    var ownerPayment = list.Where(i => i.MonthId == item.MonthId);
                    if(ownerPayment!=null)
                    {
                        item.TotalOwnerPayment = list.Where(i => i.MonthId == item.MonthId && i.IsOwnerDeposit==true).Sum(i=>i.Amount);
                        item.TotalDiffPayment = item.TotalDiffPayment - (item.TotalOwnerPayment!=null? item.TotalOwnerPayment .Value:0);
                    }
                    
                }                
            }

            chasePaymentReporParenttDTO.ChasePaymentYearly = results.OrderBy(i => i.MonthId);
            chasePaymentReporParenttDTO.PostedAmountYearly = results.Sum(i => i.TotalPostedPayment);
            return chasePaymentReporParenttDTO;
        }

        public async Task<bool> AddBulk(IEnumerable<IChasePayments> entityList)
        {
            List<ChasePayments> chasePaymentsList = new List<ChasePayments>();
            entityList.ToList().ForEach((res) =>
            {
                ChasePayments chasePayments = res as ChasePayments;
                chasePaymentsList.Add(chasePayments);
            });

            await base.AddAllAsync(chasePaymentsList);
            return true;
        }

        public async Task<IChasePayments> AddNew(IChasePayments entity)
        {
            try
            {
                ChasePayments tEntity = entity as ChasePayments;


                var errors = await this.ValidateEntityToAdd(tEntity);
                if (errors.Count() > 0)
                    await this.ThrowEntityException(errors);

                
                return await base.AddNewAsync(tEntity);
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> AddChasePaymentChild(IChasePaymentDTO chasePaymentDTO)        
        {
            List<ChasePaymentChild> lst = new List<ChasePaymentChild>();
            foreach (var item in chasePaymentDTO.BankReconciliationIds.Distinct())
            {
                ChasePaymentChild chasePaymentChild = new ChasePaymentChild();
                chasePaymentChild.ChasePaymentId = chasePaymentDTO.ChasePaymentId;
                chasePaymentChild.BankReconciliationId = item;
                chasePaymentChild.CreatedBy = this.LoggedUser.UserName;
                chasePaymentChild.CreatedDate = DateTime.Now;
                lst.Add(chasePaymentChild);
            }

            await this._chasePaymentChildRepository.AddBulk(lst);
            return true;

        }

        public async Task<int> UpdateAsOwenerDeposit(int chasePaymentId)
        {
            try
            {
                ChasePayments tEntity = await this.Connection.SingleAsync<ChasePayments>(i => i.Id == chasePaymentId);
                var getChildData = await this._chasePaymentChildRepository.Get(chasePaymentId);

                if(getChildData.Count()>0)
                {
                    throw new Exception("This record already mapped with a deposit, so cannot marked as Owner Payment");
                }

                tEntity.IsOwnerDeposit = true;
                tEntity.ModifiedDate = DateTime.Now;
                tEntity.ModifiedBy = this.LoggedUser.UserName;
                var updateOnlyFields = this.Connection
                                           .From<ChasePayments>()
                                           .Update(x => new
                                           {
                                               x.IsOwnerDeposit,       
                                               x.ModifiedBy,
                                               x.ModifiedDate
                                           })
                                           .Where(i => i.Id == tEntity.Id );

                return await base.UpdateOnlyAsync(tEntity, updateOnlyFields);
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<IChasePayments>> GetUnMappedChasePayments(int monthId,int yearId)
        {
            var query = this.Connection.From<ChasePayments>()
                .LeftJoin<ChasePayments, ChasePaymentChild>((i, j) => i.Id == j.ChasePaymentId)
                .Select<ChasePayments,ChasePaymentChild>((i,j) => new 
                {
                    Id=i.Id,
                    ChildId=j.Id
                }).Where<ChasePayments>(x=>x.MonthId==monthId && x.YearId==yearId);

            var queryResult = await this.Connection.SelectAsync<dynamic>(query);

            var result = (Mapper<Test>.MapList(queryResult)).ToList();

            var ids = result.Where(i => i.ChildId == 0).Select(i => i.Id.ToString());

            var list = await this.Connection.SelectAsync<ChasePayments>(i => i.IsOwnerDeposit==false && ids.Contains(i.Id.ToString()));

            foreach (var item in list)
            {   
                item.CheckNumber = "";                
                string[] descriptionSplit = item.Description.Split("TRN*1*");
                if (descriptionSplit.Count() > 1)
                {
                    string[] trnNumber = descriptionSplit[1].Split("*");
                    if (trnNumber.Count() > 0)
                    {
                        string checkNumber = trnNumber[0].Trim();
                        item.CheckNumber = checkNumber;
                    }
                }
            }

            return list;
        }

        public async Task<IEnumerable<IChasePayments>> GetOwnerChasePayments(int monthId, int yearId)
        {
            var query = this.Connection.From<ChasePayments>()
                .LeftJoin<ChasePayments, ChasePaymentChild>((i, j) => i.Id == j.ChasePaymentId)
                .Select<ChasePayments, ChasePaymentChild>((i, j) => new
                {
                    Id = i.Id,
                    ChildId = j.Id
                }).Where<ChasePayments>(x => x.MonthId == monthId && x.YearId == yearId);

            var queryResult = await this.Connection.SelectAsync<dynamic>(query);

            var result = (Mapper<Test>.MapList(queryResult)).ToList();

            var ids = result.Where(i => i.ChildId == 0).Select(i => i.Id.ToString());

            var list = await this.Connection.SelectAsync<ChasePayments>(i => i.IsOwnerDeposit == true && ids.Contains(i.Id.ToString()));

            foreach (var item in list)
            {
                item.CheckNumber = "";
                string[] descriptionSplit = item.Description.Split("TRN*1*");
                if (descriptionSplit.Count() > 1)
                {
                    string[] trnNumber = descriptionSplit[1].Split("*");
                    if (trnNumber.Count() > 0)
                    {
                        string checkNumber = trnNumber[0].Trim();
                        item.CheckNumber = checkNumber;
                    }
                }
            }

            return list;
        }

        


        private string GetMonthName(int monthId)
        {
            string value = "";
            if (monthId == 1) value = "Jan";
            if (monthId == 2) value = "Feb";
            if (monthId == 3) value = "March";
            if (monthId == 4) value = "April";
            if (monthId == 5) value = "May";
            if (monthId == 6) value = "June";
            if (monthId == 7) value = "July";
            if (monthId == 8) value = "Aug";
            if (monthId == 9) value = "Sep";
            if (monthId == 10) value = "Oct";
            if (monthId == 11) value = "Nov";
            if (monthId == 12) value = "Dec";

            return value;
        }
    }

    public class Test
    {
        public int Id { get; set; }
        public int ChildId { get; set; }
    }
}
