using PractiZing.Base.Entities.MasterService;
using PractiZing.Base.Entities.SecurityService;
using PractiZing.Base.Repositories.MasterService;
using PractiZing.DataAccess.Common;
using PractiZing.DataAccess.MasterService.Tables;
using ServiceStack.OrmLite;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PractiZing.DataAccess.ReportService;
using PractiZing.Base.Entities.ReportService;
using PractiZing.DataAccess.ReportService.Tables;
using PractiZing.Base.Repositories.ReportService;
using PractiZing.Base.Model.ReportService;
using PractiZing.DataAccess.ChargePaymentService.Tables;
using PractiZing.Base.Repositories.ChargePaymentService;
using PractiZing.Base.Entities.ChargePaymentService;
using System;

namespace PractiZing.BusinessLogic.ReportService.Repositories
{
    public class ReportARChargesMonthWiseRepository : ModuleBaseRepository<IReportARChargesMonthWise>, IReportARChargesMonthWiseRepository
    {
        IChargesReportDataRepository _chargesReportDataRepository;
        public ReportARChargesMonthWiseRepository(ValidationErrorCodes errorCodes, DataBaseContext dbContext, ILoginUser loggedUser, IChargesReportDataRepository chargesReportDataRepository)
         : base(errorCodes, dbContext, loggedUser)
        {
            this._chargesReportDataRepository = chargesReportDataRepository;
        }

        public async Task<IEnumerable<IReportARChargesMonthWise>> GetAll(IReportARChargesMonthWiseDTO reportARChargesMonthWiseDTO)
        {
            IEnumerable<IReportARChargesMonthWise> list = null;

            if (reportARChargesMonthWiseDTO.MonthId > 0 && reportARChargesMonthWiseDTO.YearId > 0)
            {
                list = (await this.Connection.SelectAsync<ReportARChargesMonthWise>(i => i.MonthId == reportARChargesMonthWiseDTO.MonthId && i.YearId == reportARChargesMonthWiseDTO.YearId));
            }
            else if (reportARChargesMonthWiseDTO.YearId > 0)
            {
                list = (await this.Connection.SelectAsync<ReportARChargesMonthWise>(i => i.YearId == reportARChargesMonthWiseDTO.YearId));
            }
            else
            {
                list = (await this.Connection.SelectAsync<ReportARChargesMonthWise>());
            }

            await UpdateMonthString(list);

            List<IReportARChargesMonthWise> finalList = new List<IReportARChargesMonthWise>();

            var lst = await this._chargesReportDataRepository.GetData();


            int yearid = 2022;
            if (reportARChargesMonthWiseDTO.YearId > 0)
            {
                yearid = reportARChargesMonthWiseDTO.YearId;
            }

            lst = lst.Where(i => i.DosDate.Year == yearid);


            decimal previousBalance = 0;
            decimal lastMonthBalance = 0;
            int monthId = DateTime.Now.AddDays(-90).Month;

            int tempMonthId = 0;

            foreach (var item in list)
            {
                

                item.Month = GetMonthName(item.MonthId);
                item.Charges = ((item.Jan ?? 0) + (item.Feb ?? 0) + (item.March ?? 0) + (item.April ?? 0) + (item.May ?? 0) + (item.June ?? 0)
                    + (item.July ?? 0) + (item.Aug ?? 0) + (item.Sep ?? 0) + (item.Oct ?? 0) + (item.Nov ?? 0) + (item.Dec ?? 0));
                if (item.Charges.HasValue && item.Charges.Value > 0)
                    item.ChargesString = "$" + Math.Round(item.Charges.Value, 2).ToString();

                if (previousBalance > 0)
                {
                    monthId = tempMonthId;
                    var getAmount = await GetAmountForRecoveryCalculation(item, monthId, lastMonthBalance);

                    item.RecoverdAmount = previousBalance - getAmount;

                    if (item.RecoverdAmount.HasValue && item.RecoverdAmount.Value > 0)
                    {
                        item.RecoverdAmountString = "$" + Math.Round(item.RecoverdAmount.Value, 2).ToString();
                        item.RecoverdPercentage = Math.Round(((item.RecoverdAmount / previousBalance) * 100).Value, 2).ToString() + "%";
                    }
                }
                
                lastMonthBalance =  GetLastMonthAmount(item, monthId,ref tempMonthId);
                previousBalance = item.Charges ?? 0;

                finalList.Add(item);
            }
            finalList.Add(await GetChargesRow(yearid, lst, list));
            finalList.Add(await GetExpectedAmountRow(yearid, lst, list));
            finalList.Add(await GetPaymentRow(yearid, lst, list));
            finalList.Add(await GetAdjustmentRow(yearid, lst, list));
            finalList.Add(await GetWriteOffRow(yearid, lst, list));
            finalList.Add(await GetDenailsRow(yearid, lst, list));
            finalList.Add(await GetUnAdjudicatedAmountRow(yearid, lst, list));
            finalList.Add(await GetDueByInsurane(yearid, lst, list));
            finalList.Add(await GetDueByPatient(yearid, lst, list));

            finalList.Add(await GetRecoveryPercentageRow(yearid, finalList, list));
            foreach (var item in finalList)
            {
                if (item.CreatedDate.HasValue)
                {
                    item.CreatedDateString = item.CreatedDate.Value.ToShortDateString();
                }
            }

            return finalList;
        }

        private async Task<decimal> GetAmountForRecoveryCalculation(IReportARChargesMonthWise item, int monthId, decimal lastMonthValue)
        {
            var charges = ((item.Jan ?? 0) + (item.Feb ?? 0) + (item.March ?? 0) + (item.April ?? 0) + (item.May ?? 0) + (item.June ?? 0)
                    + (item.July ?? 0) + (item.Aug ?? 0) + (item.Sep ?? 0) + (item.Oct ?? 0) + (item.Nov ?? 0) + (item.Dec ?? 0));

            decimal value = 0;
            //if (item.Jan.HasValue && item.Jan.Value > 0)
            //    value = charges - item.Jan.Value;

            //if (item.Feb.HasValue && item.Feb.Value > 0)
            //    value = charges - item.Feb.Value;

            //if (item.March.HasValue && item.March.Value > 0)
            //    value = charges - item.March.Value;

            //if (item.April.HasValue && item.April.Value > 0)
            //    value = charges - item.April.Value;

            //if (item.May.HasValue && item.May.Value > 0)
            //    value = charges - item.May.Value;

            //if (item.June.HasValue && item.June.Value > 0)
            //    value = charges - item.June.Value;

            //if (item.July.HasValue && item.July.Value > 0)
            //    value = charges - item.July.Value;

            //if (item.Aug.HasValue && item.Aug.Value > 0)
            //    value = charges - item.Aug.Value;

            //if (item.Sep.HasValue && item.Sep.Value > 0)
            //    value = charges - item.Sep.Value;

            //if (item.Oct.HasValue && item.Oct.Value > 0)
            //    value = charges - item.Oct.Value;

            //if (item.Nov.HasValue && item.Nov.Value > 0)
            //    value = charges - item.Nov.Value;

            //if (item.Dec.HasValue && item.Dec.Value > 0)
            //    value = charges - item.Dec.Value;


            if (monthId == 1) value = charges - item.Jan ?? 0;
            if (monthId == 2) value = charges - item.Feb ?? 0;
            if (monthId == 3) value = charges - item.March ?? 0;
            if (monthId == 4) value = charges - item.April ?? 0;
            if (monthId == 5) value = charges - item.May ?? 0;
            if (monthId == 6) value = charges - item.June ?? 0;
            if (monthId == 7) value = charges - item.July ?? 0;
            if (monthId == 8) value = charges - item.Aug ?? 0;
            if (monthId == 9) value = charges - item.Sep ?? item.Aug ?? 0;
            if (monthId == 10) value = charges - item.Oct ?? item.Sep ?? 0;
            if (monthId == 11) value = charges - item.Nov ?? item.Oct ?? 0;
            if (monthId == 12) value = charges - item.Dec ?? item.Nov ?? 0;

            value = value + lastMonthValue;

            return value;
        }

        private decimal GetLastMonthAmount(IReportARChargesMonthWise item, int monthId,ref int tempMonthId)
        {
            decimal value = 0;
            if (item.Jan.HasValue && item.Jan.Value > 0)
            {
                value = item.Jan.Value;
                tempMonthId = 1;
            }                

            if (item.Feb.HasValue && item.Feb.Value > 0)
            {
                value = item.Feb.Value;
                tempMonthId = 2;
            }                

            if (item.March.HasValue && item.March.Value > 0)
            {
                value = item.March.Value;
                tempMonthId = 3;
            }                

            if (item.April.HasValue && item.April.Value > 0)
            {
                value = item.April.Value;
                tempMonthId = 4;
            }                

            if (item.May.HasValue && item.May.Value > 0)
            {
                value = item.May.Value;
                tempMonthId = 5;
            }
                

            if (item.June.HasValue && item.June.Value > 0)
            {
                value = item.June.Value;
                tempMonthId = 6;
            }
                

            if (item.July.HasValue && item.July.Value > 0)
            {
                value = item.July.Value;
                tempMonthId = 7;
            }
                

            if (item.Aug.HasValue && item.Aug.Value > 0)
            {
                value = item.Aug.Value;
                tempMonthId = 8;
            }
                

            if (item.Sep.HasValue && item.Sep.Value > 0)
            {
                value = item.Sep.Value;
                tempMonthId = 9;
            }
                

            if (item.Oct.HasValue && item.Oct.Value > 0)
            {
                value = item.Oct.Value;
                tempMonthId = 10;
            }
                

            if (item.Nov.HasValue && item.Nov.Value > 0)
            {
                value = item.Nov.Value;
                tempMonthId = 11;
            }
                

            if (item.Dec.HasValue && item.Dec.Value > 0)
            {
                value = item.Dec.Value;
                tempMonthId = 12;
            }
                

            //if (monthId == 1) value = item.Jan ?? 0;
            //if (monthId == 2) value = item.Feb ?? 0;
            //if (monthId == 3) value = item.March ?? 0;
            //if (monthId == 4) value = item.April ?? 0;
            //if (monthId == 5) value = item.May ?? 0;
            //if (monthId == 6) value = item.June ?? 0;
            //if (monthId == 7) value = item.July ?? 0;
            //if (monthId == 8) value = item.Aug ?? 0;
            //if (monthId == 9) value = item.Sep ?? 0;
            //if (monthId == 10) value = item.Oct ?? 0;
            //if (monthId == 11) value = item.Nov?? item.Oct ?? 0;
            //if (monthId == 12) value = item.Dec ?? item.Nov ?? 0;


            return value;
        }

        private async Task<IEnumerable<IReportARChargesMonthWise>> UpdateMonthString(IEnumerable<IReportARChargesMonthWise> finalList)
        {

            foreach (var row in finalList)
            {
                if (row.Jan.HasValue && row.Jan > 0)
                {
                    row.JanString = "$" + Math.Round(row.Jan.Value, 2).ToString();
                }

                if (row.Feb.HasValue && row.Feb > 0)
                {
                    row.FebString = "$" + Math.Round(row.Feb.Value, 2).ToString();
                }

                if (row.March.HasValue && row.March > 0)
                {
                    row.MarchString = "$" + Math.Round(row.March.Value, 2).ToString();
                }

                if (row.April.HasValue && row.April > 0)
                {
                    row.AprilString = "$" + Math.Round(row.April.Value, 2).ToString();
                }

                if (row.May.HasValue && row.May > 0)
                {
                    row.MayString = "$" + Math.Round(row.May.Value, 2).ToString();
                }

                if (row.June.HasValue && row.June > 0)
                {
                    row.JuneString = "$" + Math.Round(row.June.Value, 2).ToString();
                }

                if (row.July.HasValue && row.July > 0)
                {
                    row.JulyString = "$" + Math.Round(row.July.Value, 2).ToString();
                }

                if (row.Aug.HasValue && row.Aug > 0)
                {
                    row.AugString = "$" + Math.Round(row.Aug.Value, 2).ToString();
                }

                if (row.Sep.HasValue && row.Sep > 0)
                {
                    row.SepString = "$" + Math.Round(row.Sep.Value, 2).ToString();
                }

                if (row.Oct.HasValue && row.Oct > 0)
                {
                    row.OctString = "$" + Math.Round(row.Oct.Value, 2).ToString();
                }

                if (row.Nov.HasValue && row.Nov > 0)
                {
                    row.NovString = "$" + Math.Round(row.Nov.Value, 2).ToString();
                }

                if (row.Dec.HasValue && row.Dec > 0)
                {
                    row.DecString = "$" + Math.Round(row.Dec.Value, 2).ToString();
                }

                if (row.Charges.HasValue && row.Charges > 0)
                {
                    row.ChargesString = "$" + Math.Round(row.Charges.Value, 2).ToString();
                }

            }


            return finalList;
        }

        private async Task<IReportARChargesMonthWise> GetExpectedAmountRow(int year, IEnumerable<IChargesReportData> lst, IEnumerable<IReportARChargesMonthWise> finalList)
        {
            ReportARChargesMonthWise row = new ReportARChargesMonthWise();

            var topRecord = finalList.Where(i => i.YearId == year).OrderByDescending(i => i.Id).FirstOrDefault();

            row.Month = "Expected";

            if (topRecord != null && topRecord.Jan.HasValue && topRecord.Jan > 0)
            {
                row.Jan = lst.Where(i => i.DosDate.Month == 1 && i.DosDate.Year == year).Sum(i => i.FeeAmount);
                row.JanString = "$" + Math.Round(row.Jan.Value, 2).ToString();
            }

            if (topRecord != null && topRecord.Feb.HasValue && topRecord.Feb > 0)
            {
                row.Feb = lst.Where(i => i.DosDate.Month == 2 && i.DosDate.Year == year).Sum(i => i.FeeAmount);
                row.FebString = "$" + Math.Round(row.Feb.Value, 2).ToString();
            }

            if (topRecord != null && topRecord.March.HasValue && topRecord.March > 0)
            {
                row.March = lst.Where(i => i.DosDate.Month == 3 && i.DosDate.Year == year).Sum(i => i.FeeAmount);
                row.MarchString = "$" + Math.Round(row.March.Value, 2).ToString();
            }

            if (topRecord != null && topRecord.April.HasValue && topRecord.April > 0)
            {
                row.April = lst.Where(i => i.DosDate.Month == 4 && i.DosDate.Year == year).Sum(i => i.FeeAmount);
                row.AprilString = "$" + Math.Round(row.April.Value, 2).ToString();
            }

            if (topRecord != null && topRecord.May.HasValue && topRecord.May > 0)
            {
                row.May = lst.Where(i => i.DosDate.Month == 5 && i.DosDate.Year == year).Sum(i => i.FeeAmount);
                row.MayString = "$" + Math.Round(row.May.Value, 2).ToString();
            }

            if (topRecord != null && topRecord.June.HasValue && topRecord.June > 0)
            {
                row.June = lst.Where(i => i.DosDate.Month == 6 && i.DosDate.Year == year).Sum(i => i.FeeAmount);
                row.JuneString = "$" + Math.Round(row.June.Value, 2).ToString();
            }

            if (topRecord != null && topRecord.July.HasValue && topRecord.July > 0)
            {
                row.July = lst.Where(i => i.DosDate.Month == 7 && i.DosDate.Year == year).Sum(i => i.FeeAmount);
                row.JulyString = "$" + Math.Round(row.July.Value, 2).ToString();
            }

            if (topRecord != null && topRecord.Aug.HasValue && topRecord.Aug > 0)
            {
                row.Aug = lst.Where(i => i.DosDate.Month == 8 && i.DosDate.Year == year).Sum(i => i.FeeAmount);
                row.AugString = "$" + Math.Round(row.Aug.Value, 2).ToString();
            }

            if (topRecord != null && topRecord.Sep.HasValue && topRecord.Sep > 0)
            {
                row.Sep = lst.Where(i => i.DosDate.Month == 9 && i.DosDate.Year == year).Sum(i => i.FeeAmount);
                row.SepString = "$" + Math.Round(row.Sep.Value, 2).ToString();
            }

            if (topRecord != null && topRecord.Oct.HasValue && topRecord.Oct > 0)
            {
                row.Oct = lst.Where(i => i.DosDate.Month == 10 && i.DosDate.Year == year).Sum(i => i.FeeAmount);
                row.OctString = "$" + Math.Round(row.Oct.Value, 2).ToString();
            }

            if (topRecord != null && topRecord.Nov.HasValue && topRecord.Nov > 0)
            {
                row.Nov = lst.Where(i => i.DosDate.Month == 11 && i.DosDate.Year == year).Sum(i => i.FeeAmount);
                row.NovString = "$" + Math.Round(row.Nov.Value, 2).ToString();
            }

            if (topRecord != null && topRecord.Dec.HasValue && topRecord.Dec > 0)
            {
                row.Dec = lst.Where(i => i.DosDate.Month == 12 && i.DosDate.Year == year).Sum(i => i.FeeAmount);
                row.DecString = "$" + Math.Round(row.Dec.Value, 2).ToString();
            }

            row.Charges = ((row.Jan ?? 0) + (row.Feb ?? 0) + (row.March ?? 0) + (row.April ?? 0) + (row.May ?? 0) + (row.June ?? 0)
                    + (row.July ?? 0) + (row.Aug ?? 0) + (row.Sep ?? 0) + (row.Oct ?? 0) + (row.Nov ?? 0) + (row.Dec ?? 0));

            if (row.Charges.HasValue && row.Charges > 0)
            {
                row.ChargesString = "$" + Math.Round(row.Charges.Value, 2).ToString();
            }

            return row;
        }

        private async Task<IReportARChargesMonthWise> GetUnAdjudicatedAmountRow(int year, IEnumerable<IChargesReportData> lst, IEnumerable<IReportARChargesMonthWise> finalList)
        {
            ReportARChargesMonthWise row = new ReportARChargesMonthWise();
            List<string> duyBy = new List<string>() { "", "patient" };
            var topRecord = finalList.Where(i => i.YearId == year).OrderByDescending(i => i.Id).FirstOrDefault();

            row.Month = "UnAdjudicated";

            if (topRecord != null && topRecord.Jan.HasValue && topRecord.Jan > 0)
            {
                row.Jan = lst.Where(i => i.DosDate.Month == 1 && i.DosDate.Year == year && i.PaymentReceived.ToLower() == "no" && !duyBy.Contains(i.DueBy.ToLower()) && i.ClaimSent.ToLower() == "yes" && i.IsBillable.Value && i.ClaimSentDate < DateTime.Now.AddDays(-15)).Sum(i => i.DueAmount);
                row.JanString = "$" + Math.Round(row.Jan.Value, 2).ToString();
            }

            if (topRecord != null && topRecord.Feb.HasValue && topRecord.Feb > 0)
            {
                row.Feb = lst.Where(i => i.DosDate.Month == 2 && i.DosDate.Year == year && i.PaymentReceived.ToLower() == "no" && !duyBy.Contains(i.DueBy.ToLower()) && i.ClaimSent.ToLower() == "yes"  && i.IsBillable.Value && i.ClaimSentDate < DateTime.Now.AddDays(-15)).Sum(i => i.DueAmount);
                row.FebString = "$" + Math.Round(row.Feb.Value, 2).ToString();
            }

            if (topRecord != null && topRecord.March.HasValue && topRecord.March > 0)
            {
                row.March = lst.Where(i => i.DosDate.Month == 3 && i.DosDate.Year == year && i.PaymentReceived.ToLower() == "no" && !duyBy.Contains(i.DueBy.ToLower()) && i.ClaimSent.ToLower() == "yes"  && i.IsBillable.Value && i.ClaimSentDate < DateTime.Now.AddDays(-15)).Sum(i => i.DueAmount);
                row.MarchString = "$" + Math.Round(row.March.Value, 2).ToString();
            }

            if (topRecord != null && topRecord.April.HasValue && topRecord.April > 0)
            {
                row.April = lst.Where(i => i.DosDate.Month == 4 && i.DosDate.Year == year && i.PaymentReceived.ToLower() == "no" && !duyBy.Contains(i.DueBy.ToLower()) && i.ClaimSent.ToLower() == "yes"  && i.IsBillable.Value && i.ClaimSentDate < DateTime.Now.AddDays(-15)).Sum(i => i.DueAmount);
                row.AprilString = "$" + Math.Round(row.April.Value, 2).ToString();
            }

            if (topRecord != null && topRecord.May.HasValue && topRecord.May > 0)
            {
                row.May = lst.Where(i => i.DosDate.Month == 5 && i.DosDate.Year == year && i.PaymentReceived.ToLower() == "no" && !duyBy.Contains(i.DueBy.ToLower()) && i.ClaimSent.ToLower() == "yes"  && i.IsBillable.Value && i.ClaimSentDate < DateTime.Now.AddDays(-15)).Sum(i => i.DueAmount);
                row.MayString = "$" + Math.Round(row.May.Value, 2).ToString();
            }

            if (topRecord != null && topRecord.June.HasValue && topRecord.June > 0)
            {
                row.June = lst.Where(i => i.DosDate.Month == 6 && i.DosDate.Year == year && i.PaymentReceived.ToLower() == "no" && !duyBy.Contains(i.DueBy.ToLower()) && i.ClaimSent.ToLower() == "yes"  && i.IsBillable.Value && i.ClaimSentDate < DateTime.Now.AddDays(-15)).Sum(i => i.DueAmount);
                row.JuneString = "$" + Math.Round(row.June.Value, 2).ToString();
            }

            if (topRecord != null && topRecord.July.HasValue && topRecord.July > 0)
            {
                row.July = lst.Where(i => i.DosDate.Month == 7 && i.DosDate.Year == year && i.PaymentReceived.ToLower() == "no" && !duyBy.Contains(i.DueBy.ToLower()) && i.ClaimSent.ToLower() == "yes"  && i.IsBillable.Value && i.ClaimSentDate < DateTime.Now.AddDays(-15)).Sum(i => i.DueAmount);
                row.JulyString = "$" + Math.Round(row.July.Value, 2).ToString();
            }

            if (topRecord != null && topRecord.Aug.HasValue && topRecord.Aug > 0)
            {
                row.Aug = lst.Where(i => i.DosDate.Month == 8 && i.DosDate.Year == year && i.PaymentReceived.ToLower() == "no" && !duyBy.Contains(i.DueBy.ToLower()) && i.ClaimSent.ToLower() == "yes"  && i.IsBillable.Value && i.ClaimSentDate < DateTime.Now.AddDays(-15)).Sum(i => i.DueAmount);
                row.AugString = "$" + Math.Round(row.Aug.Value, 2).ToString();
            }

            if (topRecord != null && topRecord.Sep.HasValue && topRecord.Sep > 0)
            {
                row.Sep = lst.Where(i => i.DosDate.Month == 9 && i.DosDate.Year == year && i.PaymentReceived.ToLower() == "no" && !duyBy.Contains(i.DueBy.ToLower()) && i.ClaimSent.ToLower() == "yes"  && i.IsBillable.Value && i.ClaimSentDate < DateTime.Now.AddDays(-15)).Sum(i => i.DueAmount);
                row.SepString = "$" + Math.Round(row.Sep.Value, 2).ToString();
            }

            if (topRecord != null && topRecord.Oct.HasValue && topRecord.Oct > 0)
            {
                row.Oct = lst.Where(i => i.DosDate.Month == 10 && i.DosDate.Year == year && i.PaymentReceived.ToLower() == "no" && !duyBy.Contains(i.DueBy.ToLower()) && i.ClaimSent.ToLower() == "yes"  && i.IsBillable.Value && i.ClaimSentDate < DateTime.Now.AddDays(-15)).Sum(i => i.DueAmount);
                row.OctString = "$" + Math.Round(row.Oct.Value, 2).ToString();
            }

            if (topRecord != null && topRecord.Nov.HasValue && topRecord.Nov > 0)
            {
                row.Nov = lst.Where(i => i.DosDate.Month == 11 && i.DosDate.Year == year && i.PaymentReceived.ToLower() == "no" && !duyBy.Contains(i.DueBy.ToLower()) && i.ClaimSent.ToLower() == "yes"  && i.IsBillable.Value && i.ClaimSentDate < DateTime.Now.AddDays(-15)).Sum(i => i.DueAmount);
                row.NovString = "$" + Math.Round(row.Nov.Value, 2).ToString();
            }

            if (topRecord != null && topRecord.Dec.HasValue && topRecord.Dec > 0)
            {
                row.Dec = lst.Where(i => i.DosDate.Month == 12 && i.DosDate.Year == year && i.PaymentReceived.ToLower() == "no" && !duyBy.Contains(i.DueBy.ToLower()) && i.ClaimSent.ToLower() == "yes"  && i.IsBillable.Value && i.ClaimSentDate < DateTime.Now.AddDays(-15)).Sum(i => i.DueAmount);
                row.DecString = "$" + Math.Round(row.Dec.Value, 2).ToString();
            }

            row.Charges = ((row.Jan ?? 0) + (row.Feb ?? 0) + (row.March ?? 0) + (row.April ?? 0) + (row.May ?? 0) + (row.June ?? 0)
                    + (row.July ?? 0) + (row.Aug ?? 0) + (row.Sep ?? 0) + (row.Oct ?? 0) + (row.Nov ?? 0) + (row.Dec ?? 0));

            if (row.Charges.HasValue && row.Charges > 0)
            {
                row.ChargesString = "$" + Math.Round(row.Charges.Value, 2).ToString();
            }

            return row;
        }

        private async Task<IReportARChargesMonthWise> GetPaymentRow(int year, IEnumerable<IChargesReportData> lst, IEnumerable<IReportARChargesMonthWise> finalList)
        {
            ReportARChargesMonthWise row = new ReportARChargesMonthWise();
            var topRecord = finalList.Where(i => i.YearId == year).OrderByDescending(i => i.Id).FirstOrDefault();

            row.Month = "Payments";
            if (topRecord != null && topRecord.Jan.HasValue && topRecord.Jan > 0)
            {
                row.Jan = lst.Where(i => i.DosDate.Month == 1 && i.DosDate.Year == year).Sum(i => i.Payment);
                row.JanString = "$" + Math.Round(row.Jan.Value, 2).ToString();
            }

            if (topRecord != null && topRecord.Feb.HasValue && topRecord.Feb > 0)
            {
                row.Feb = lst.Where(i => i.DosDate.Month == 2 && i.DosDate.Year == year).Sum(i => i.Payment);
                row.FebString = "$" + Math.Round(row.Feb.Value, 2).ToString();
            }

            if (topRecord != null && topRecord.March.HasValue && topRecord.March > 0)
            {
                row.March = lst.Where(i => i.DosDate.Month == 3 && i.DosDate.Year == year).Sum(i => i.Payment);
                row.MarchString = "$" + Math.Round(row.March.Value, 2).ToString();
            }

            if (topRecord != null && topRecord.April.HasValue && topRecord.April > 0)
            {
                row.April = lst.Where(i => i.DosDate.Month == 4 && i.DosDate.Year == year).Sum(i => i.Payment);
                row.AprilString = "$" + Math.Round(row.April.Value, 2).ToString();
            }

            if (topRecord != null && topRecord.May.HasValue && topRecord.May > 0)
            {
                row.May = lst.Where(i => i.DosDate.Month == 5 && i.DosDate.Year == year).Sum(i => i.Payment);
                row.MayString = "$" + Math.Round(row.May.Value, 2).ToString();
            }

            if (topRecord != null && topRecord.June.HasValue && topRecord.June > 0)
            {
                row.June = lst.Where(i => i.DosDate.Month == 6 && i.DosDate.Year == year).Sum(i => i.Payment);
                row.JuneString = "$" + Math.Round(row.June.Value, 2).ToString();
            }

            if (topRecord != null && topRecord.July.HasValue && topRecord.July > 0)
            {
                row.July = lst.Where(i => i.DosDate.Month == 7 && i.DosDate.Year == year).Sum(i => i.Payment);
                row.JulyString = "$" + Math.Round(row.July.Value, 2).ToString();
            }

            if (topRecord != null && topRecord.Aug.HasValue && topRecord.Aug > 0)
            {
                row.Aug = lst.Where(i => i.DosDate.Month == 8 && i.DosDate.Year == year).Sum(i => i.Payment);
                row.AugString = "$" + Math.Round(row.Aug.Value, 2).ToString();
            }

            if (topRecord != null && topRecord.Sep.HasValue && topRecord.Sep > 0)
            {
                row.Sep = lst.Where(i => i.DosDate.Month == 9 && i.DosDate.Year == year).Sum(i => i.Payment);
                row.SepString = "$" + Math.Round(row.Sep.Value, 2).ToString();
            }

            if (topRecord != null && topRecord.Oct.HasValue && topRecord.Oct > 0)
            {
                row.Oct = lst.Where(i => i.DosDate.Month == 10 && i.DosDate.Year == year).Sum(i => i.Payment);
                row.OctString = "$" + Math.Round(row.Oct.Value, 2).ToString();
            }

            if (topRecord != null && topRecord.Nov.HasValue && topRecord.Nov > 0)
            {
                row.Nov = lst.Where(i => i.DosDate.Month == 11 && i.DosDate.Year == year).Sum(i => i.Payment);
                row.NovString = "$" + Math.Round(row.Nov.Value, 2).ToString();
            }

            if (topRecord != null && topRecord.Dec.HasValue && topRecord.Dec > 0)
            {
                row.Dec = lst.Where(i => i.DosDate.Month == 12 && i.DosDate.Year == year).Sum(i => i.Payment);
                row.DecString = "$" + Math.Round(row.Dec.Value, 2).ToString();
            }

            row.Charges = ((row.Jan ?? 0) + (row.Feb ?? 0) + (row.March ?? 0) + (row.April ?? 0) + (row.May ?? 0) + (row.June ?? 0)
                    + (row.July ?? 0) + (row.Aug ?? 0) + (row.Sep ?? 0) + (row.Oct ?? 0) + (row.Nov ?? 0) + (row.Dec ?? 0));

            if (row.Charges.HasValue && row.Charges > 0)
            {
                row.ChargesString = "$" + Math.Round(row.Charges.Value, 2).ToString();
            }
            return row;
        }

        private async Task<IReportARChargesMonthWise> GetChargesRow(int year, IEnumerable<IChargesReportData> lst, IEnumerable<IReportARChargesMonthWise> finalList)
        {
            ReportARChargesMonthWise row = new ReportARChargesMonthWise();
            var topRecord = finalList.Where(i=>i.YearId==year).OrderByDescending(i => i.Id).FirstOrDefault();

            row.Month = "Charges";
            if (topRecord != null && topRecord.Jan.HasValue && topRecord.Jan > 0)
            {
                row.Jan = lst.Where(i => i.DosDate.Month == 1 && i.DosDate.Year == year).Sum(i => i.ChargeAmount);
                row.JanString = "$" + Math.Round(row.Jan.Value, 2).ToString();
            }

            if (topRecord != null && topRecord.Feb.HasValue && topRecord.Feb > 0)
            {
                row.Feb = lst.Where(i => i.DosDate.Month == 2 && i.DosDate.Year == year).Sum(i => i.ChargeAmount);
                row.FebString = "$" + Math.Round(row.Feb.Value, 2).ToString();
            }

            if (topRecord != null && topRecord.March.HasValue && topRecord.March > 0)
            {
                row.March = lst.Where(i => i.DosDate.Month == 3 && i.DosDate.Year == year).Sum(i => i.ChargeAmount);
                row.MarchString = "$" + Math.Round(row.March.Value, 2).ToString();
            }

            if (topRecord != null && topRecord.April.HasValue && topRecord.April > 0)
            {
                row.April = lst.Where(i => i.DosDate.Month == 4 && i.DosDate.Year == year).Sum(i => i.ChargeAmount);
                row.AprilString = "$" + Math.Round(row.April.Value, 2).ToString();
            }

            if (topRecord != null && topRecord.May.HasValue && topRecord.May > 0)
            {
                row.May = lst.Where(i => i.DosDate.Month == 5 && i.DosDate.Year == year).Sum(i => i.ChargeAmount);
                row.MayString = "$" + Math.Round(row.May.Value, 2).ToString();
            }

            if (topRecord != null && topRecord.June.HasValue && topRecord.June > 0)
            {
                row.June = lst.Where(i => i.DosDate.Month == 6 && i.DosDate.Year == year).Sum(i => i.ChargeAmount);
                row.JuneString = "$" + Math.Round(row.June.Value, 2).ToString();
            }

            if (topRecord != null && topRecord.July.HasValue && topRecord.July > 0)
            {
                row.July = lst.Where(i => i.DosDate.Month == 7 && i.DosDate.Year == year).Sum(i => i.ChargeAmount);
                row.JulyString = "$" + Math.Round(row.July.Value, 2).ToString();
            }

            if (topRecord != null && topRecord.Aug.HasValue && topRecord.Aug > 0)
            {
                row.Aug = lst.Where(i => i.DosDate.Month == 8 && i.DosDate.Year == year).Sum(i => i.ChargeAmount);
                row.AugString = "$" + Math.Round(row.Aug.Value, 2).ToString();
            }

            if (topRecord != null && topRecord.Sep.HasValue && topRecord.Sep > 0)
            {
                row.Sep = lst.Where(i => i.DosDate.Month == 9 && i.DosDate.Year == year).Sum(i => i.ChargeAmount);
                row.SepString = "$" + Math.Round(row.Sep.Value, 2).ToString();
            }

            if (topRecord != null && topRecord.Oct.HasValue && topRecord.Oct > 0)
            {
                row.Oct = lst.Where(i => i.DosDate.Month == 10 && i.DosDate.Year == year).Sum(i => i.ChargeAmount);
                row.OctString = "$" + Math.Round(row.Oct.Value, 2).ToString();
            }

            if (topRecord != null && topRecord.Nov.HasValue && topRecord.Nov > 0)
            {
                row.Nov = lst.Where(i => i.DosDate.Month == 11 && i.DosDate.Year == year).Sum(i => i.ChargeAmount);
                row.NovString = "$" + Math.Round(row.Nov.Value, 2).ToString();
            }

            if (topRecord != null && topRecord.Dec.HasValue && topRecord.Dec > 0)
            {
                row.Dec = lst.Where(i => i.DosDate.Month == 12 && i.DosDate.Year == year).Sum(i => i.ChargeAmount);
                row.DecString = "$" + Math.Round(row.Dec.Value, 2).ToString();
            }

            row.Charges = ((row.Jan ?? 0) + (row.Feb ?? 0) + (row.March ?? 0) + (row.April ?? 0) + (row.May ?? 0) + (row.June ?? 0)
                    + (row.July ?? 0) + (row.Aug ?? 0) + (row.Sep ?? 0) + (row.Oct ?? 0) + (row.Nov ?? 0) + (row.Dec ?? 0));

            if (row.Charges.HasValue && row.Charges > 0)
            {
                row.ChargesString = "$" + Math.Round(row.Charges.Value, 2).ToString();
            }

            return row;
        }

        private async Task<IReportARChargesMonthWise> GetDueByInsurane(int year, IEnumerable<IChargesReportData> lst, IEnumerable<IReportARChargesMonthWise> finalList)
        {
            ReportARChargesMonthWise row = new ReportARChargesMonthWise();
            var topRecord = finalList.Where(i => i.YearId == year).OrderByDescending(i => i.Id).FirstOrDefault();

            List<string> duyBy = new List<string>() { "", "patient" };

            row.Month = "Due By Insurance";
            if (topRecord != null && topRecord.Jan.HasValue && topRecord.Jan > 0)
            {
                row.Jan = lst.Where(i => i.DosDate.Month == 1 && i.DosDate.Year == year && i.InsuranceCompanyName != "SelfPay"   && !duyBy.Contains(i.DueBy.ToLower())).Sum(i => i.DueAmount);
                row.JanString = "$" + Math.Round(row.Jan.Value, 2).ToString();
            }

            if (topRecord != null && topRecord.Feb.HasValue && topRecord.Feb > 0)
            {
                row.Feb = lst.Where(i => i.DosDate.Month == 2 && i.DosDate.Year == year && i.InsuranceCompanyName != "SelfPay"   && !duyBy.Contains(i.DueBy.ToLower())).Sum(i => i.DueAmount);
                row.FebString = "$" + Math.Round(row.Feb.Value, 2).ToString();
            }

            if (topRecord != null && topRecord.March.HasValue && topRecord.March > 0)
            {
                row.March = lst.Where(i => i.DosDate.Month == 3 && i.DosDate.Year == year && i.InsuranceCompanyName != "SelfPay"   && !duyBy.Contains(i.DueBy.ToLower())).Sum(i => i.DueAmount);
                row.MarchString = "$" + Math.Round(row.March.Value, 2).ToString();
            }

            if (topRecord != null && topRecord.April.HasValue && topRecord.April > 0)
            {
                row.April = lst.Where(i => i.DosDate.Month == 4 && i.DosDate.Year == year && i.InsuranceCompanyName != "SelfPay"   && !duyBy.Contains(i.DueBy.ToLower())).Sum(i => i.DueAmount);
                row.AprilString = "$" + Math.Round(row.April.Value, 2).ToString();
            }

            if (topRecord != null && topRecord.May.HasValue && topRecord.May > 0)
            {
                row.May = lst.Where(i => i.DosDate.Month == 5 && i.DosDate.Year == year && i.InsuranceCompanyName != "SelfPay"   && !duyBy.Contains(i.DueBy.ToLower())).Sum(i => i.DueAmount);
                row.MayString = "$" + Math.Round(row.May.Value, 2).ToString();
            }

            if (topRecord != null && topRecord.June.HasValue && topRecord.June > 0)
            {
                row.June = lst.Where(i => i.DosDate.Month == 6 && i.DosDate.Year == year && i.InsuranceCompanyName != "SelfPay"   && !duyBy.Contains(i.DueBy.ToLower())).Sum(i => i.DueAmount);
                row.JuneString = "$" + Math.Round(row.June.Value, 2).ToString();
            }

            if (topRecord != null && topRecord.July.HasValue && topRecord.July > 0)
            {
                row.July = lst.Where(i => i.DosDate.Month == 7 && i.DosDate.Year == year && i.InsuranceCompanyName != "SelfPay"   && !duyBy.Contains(i.DueBy.ToLower())).Sum(i => i.DueAmount);
                row.JulyString = "$" + Math.Round(row.July.Value, 2).ToString();
            }

            if (topRecord != null && topRecord.Aug.HasValue && topRecord.Aug > 0)
            {
                row.Aug = lst.Where(i => i.DosDate.Month == 8 && i.DosDate.Year == year && i.InsuranceCompanyName != "SelfPay"   && !duyBy.Contains(i.DueBy.ToLower())).Sum(i => i.DueAmount);
                row.AugString = "$" + Math.Round(row.Aug.Value, 2).ToString();
            }

            if (topRecord != null && topRecord.Sep.HasValue && topRecord.Sep > 0)
            {
                row.Sep = lst.Where(i => i.DosDate.Month == 9 && i.DosDate.Year == year && i.InsuranceCompanyName != "SelfPay"   && !duyBy.Contains(i.DueBy.ToLower())).Sum(i => i.DueAmount);
                row.SepString = "$" + Math.Round(row.Sep.Value, 2).ToString();
            }

            if (topRecord != null && topRecord.Oct.HasValue && topRecord.Oct > 0)
            {
                row.Oct = lst.Where(i => i.DosDate.Month == 10 && i.DosDate.Year == year && i.InsuranceCompanyName != "SelfPay"   && !duyBy.Contains(i.DueBy.ToLower())).Sum(i => i.DueAmount);
                row.OctString = "$" + Math.Round(row.Oct.Value, 2).ToString();
            }

            if (topRecord != null && topRecord.Nov.HasValue && topRecord.Nov > 0)
            {
                row.Nov = lst.Where(i => i.DosDate.Month == 11 && i.DosDate.Year == year && i.InsuranceCompanyName != "SelfPay"   && !duyBy.Contains(i.DueBy.ToLower())).Sum(i => i.DueAmount);
                row.NovString = "$" + Math.Round(row.Nov.Value, 2).ToString();
            }

            if (topRecord != null && topRecord.Dec.HasValue && topRecord.Dec > 0)
            {
                row.Dec = lst.Where(i => i.DosDate.Month == 12 && i.DosDate.Year == year && i.InsuranceCompanyName != "SelfPay"   && !duyBy.Contains(i.DueBy.ToLower())).Sum(i => i.DueAmount);
                row.DecString = "$" + Math.Round(row.Dec.Value, 2).ToString();
            }

            row.Charges = ((row.Jan ?? 0) + (row.Feb ?? 0) + (row.March ?? 0) + (row.April ?? 0) + (row.May ?? 0) + (row.June ?? 0)
                    + (row.July ?? 0) + (row.Aug ?? 0) + (row.Sep ?? 0) + (row.Oct ?? 0) + (row.Nov ?? 0) + (row.Dec ?? 0));

            if (row.Charges.HasValue && row.Charges > 0)
            {
                row.ChargesString = "$" + Math.Round(row.Charges.Value, 2).ToString();
            }

            return row;
        }

        private async Task<IReportARChargesMonthWise> GetDueByPatient(int year, IEnumerable<IChargesReportData> lst, IEnumerable<IReportARChargesMonthWise> finalList)
        {
            ReportARChargesMonthWise row = new ReportARChargesMonthWise();
            var topRecord = finalList.Where(i => i.YearId == year).OrderByDescending(i => i.Id).FirstOrDefault();

            List<string> duyBy = new List<string>() { "", "patient" };

            row.Month = "Due By Patient";
            if (topRecord != null && topRecord.Jan.HasValue && topRecord.Jan > 0)
            {
                row.Jan = lst.Where(i => i.DosDate.Month == 1 && i.DosDate.Year == year   && duyBy.Contains(i.DueBy.ToLower())).Sum(i => i.DueAmount);
                row.JanString = "$" + Math.Round(row.Jan.Value, 2).ToString();
            }

            if (topRecord != null && topRecord.Feb.HasValue && topRecord.Feb > 0)
            {
                row.Feb = lst.Where(i => i.DosDate.Month == 2 && i.DosDate.Year == year   && duyBy.Contains(i.DueBy.ToLower())).Sum(i => i.DueAmount);
                row.FebString = "$" + Math.Round(row.Feb.Value, 2).ToString();
            }

            if (topRecord != null && topRecord.March.HasValue && topRecord.March > 0)
            {
                row.March = lst.Where(i => i.DosDate.Month == 3 && i.DosDate.Year == year   && duyBy.Contains(i.DueBy.ToLower())).Sum(i => i.DueAmount);
                row.MarchString = "$" + Math.Round(row.March.Value, 2).ToString();
            }

            if (topRecord != null && topRecord.April.HasValue && topRecord.April > 0)
            {
                row.April = lst.Where(i => i.DosDate.Month == 4 && i.DosDate.Year == year   && duyBy.Contains(i.DueBy.ToLower())).Sum(i => i.DueAmount);
                row.AprilString = "$" + Math.Round(row.April.Value, 2).ToString();
            }

            if (topRecord != null && topRecord.May.HasValue && topRecord.May > 0)
            {
                row.May = lst.Where(i => i.DosDate.Month == 5 && i.DosDate.Year == year   && duyBy.Contains(i.DueBy.ToLower())).Sum(i => i.DueAmount);
                row.MayString = "$" + Math.Round(row.May.Value, 2).ToString();
            }

            if (topRecord != null && topRecord.June.HasValue && topRecord.June > 0)
            {
                row.June = lst.Where(i => i.DosDate.Month == 6 && i.DosDate.Year == year   && duyBy.Contains(i.DueBy.ToLower())).Sum(i => i.DueAmount);
                row.JuneString = "$" + Math.Round(row.June.Value, 2).ToString();
            }

            if (topRecord != null && topRecord.July.HasValue && topRecord.July > 0)
            {
                row.July = lst.Where(i => i.DosDate.Month == 7 && i.DosDate.Year == year   && duyBy.Contains(i.DueBy.ToLower())).Sum(i => i.DueAmount);
                row.JulyString = "$" + Math.Round(row.July.Value, 2).ToString();
            }

            if (topRecord != null && topRecord.Aug.HasValue && topRecord.Aug > 0)
            {
                row.Aug = lst.Where(i => i.DosDate.Month == 8 && i.DosDate.Year == year   && duyBy.Contains(i.DueBy.ToLower())).Sum(i => i.DueAmount);
                row.AugString = "$" + Math.Round(row.Aug.Value, 2).ToString();
            }

            if (topRecord != null && topRecord.Sep.HasValue && topRecord.Sep > 0)
            {
                row.Sep = lst.Where(i => i.DosDate.Month == 9 && i.DosDate.Year == year   && duyBy.Contains(i.DueBy.ToLower())).Sum(i => i.DueAmount);
                row.SepString = "$" + Math.Round(row.Sep.Value, 2).ToString();
            }

            if (topRecord != null && topRecord.Oct.HasValue && topRecord.Oct > 0)
            {
                row.Oct = lst.Where(i => i.DosDate.Month == 10 && i.DosDate.Year == year   && duyBy.Contains(i.DueBy.ToLower())).Sum(i => i.DueAmount);
                row.OctString = "$" + Math.Round(row.Oct.Value, 2).ToString();
            }

            if (topRecord != null && topRecord.Nov.HasValue && topRecord.Nov > 0)
            {
                row.Nov = lst.Where(i => i.DosDate.Month == 11 && i.DosDate.Year == year   && duyBy.Contains(i.DueBy.ToLower())).Sum(i => i.DueAmount);
                row.NovString = "$" + Math.Round(row.Nov.Value, 2).ToString();
            }

            if (topRecord != null && topRecord.Dec.HasValue && topRecord.Dec > 0)
            {
                row.Dec = lst.Where(i => i.DosDate.Month == 12 && i.DosDate.Year == year   && duyBy.Contains(i.DueBy.ToLower())).Sum(i => i.DueAmount);
                row.DecString = "$" + Math.Round(row.Dec.Value, 2).ToString();
            }

            row.Charges = ((row.Jan ?? 0) + (row.Feb ?? 0) + (row.March ?? 0) + (row.April ?? 0) + (row.May ?? 0) + (row.June ?? 0)
                    + (row.July ?? 0) + (row.Aug ?? 0) + (row.Sep ?? 0) + (row.Oct ?? 0) + (row.Nov ?? 0) + (row.Dec ?? 0));

            if (row.Charges.HasValue && row.Charges > 0)
            {
                row.ChargesString = "$" + Math.Round(row.Charges.Value, 2).ToString();
            }

            return row;
        }

        private async Task<IReportARChargesMonthWise> GetWriteOffRow(int year, IEnumerable<IChargesReportData> lst, IEnumerable<IReportARChargesMonthWise> finalList)
        {
            ReportARChargesMonthWise row = new ReportARChargesMonthWise();

            var topRecord = finalList.Where(i => i.YearId == year).OrderByDescending(i => i.Id).FirstOrDefault();

            row.Month = "WriteOff";

            if (topRecord != null && topRecord.Jan.HasValue && topRecord.Jan > 0)
            {
                row.Jan = lst.Where(i => i.DosDate.Month == 1 && i.DosDate.Year == year).Sum(i => i.WriteOffAmount);
                row.JanString = "$" + Math.Round(row.Jan.Value, 2).ToString();
            }

            if (topRecord != null && topRecord.Feb.HasValue && topRecord.Feb > 0)
            {
                row.Feb = lst.Where(i => i.DosDate.Month == 2 && i.DosDate.Year == year).Sum(i => i.WriteOffAmount);
                row.FebString = "$" + Math.Round(row.Feb.Value, 2).ToString();
            }

            if (topRecord != null && topRecord.March.HasValue && topRecord.March > 0)
            {
                row.March = lst.Where(i => i.DosDate.Month == 3 && i.DosDate.Year == year).Sum(i => i.WriteOffAmount);
                row.MarchString = "$" + Math.Round(row.March.Value, 2).ToString();
            }

            if (topRecord != null && topRecord.April.HasValue && topRecord.April > 0)
            {
                row.April = lst.Where(i => i.DosDate.Month == 4 && i.DosDate.Year == year).Sum(i => i.WriteOffAmount);
                row.AprilString = "$" + Math.Round(row.April.Value, 2).ToString();
            }

            if (topRecord != null && topRecord.May.HasValue && topRecord.May > 0)
            {
                row.May = lst.Where(i => i.DosDate.Month == 5 && i.DosDate.Year == year).Sum(i => i.WriteOffAmount);
                row.MayString = "$" + Math.Round(row.May.Value, 2).ToString();
            }

            if (topRecord != null && topRecord.June.HasValue && topRecord.June > 0)
            {
                row.June = lst.Where(i => i.DosDate.Month == 6 && i.DosDate.Year == year).Sum(i => i.WriteOffAmount);
                row.JuneString = "$" + Math.Round(row.June.Value, 2).ToString();
            }

            if (topRecord != null && topRecord.July.HasValue && topRecord.July > 0)
            {
                row.July = lst.Where(i => i.DosDate.Month == 7 && i.DosDate.Year == year).Sum(i => i.WriteOffAmount);
                row.JulyString = "$" + Math.Round(row.July.Value, 2).ToString();
            }


            if (topRecord != null && topRecord.Aug.HasValue && topRecord.Aug > 0)
            {
                row.Aug = lst.Where(i => i.DosDate.Month == 8 && i.DosDate.Year == year).Sum(i => i.WriteOffAmount);
                row.AugString = "$" + Math.Round(row.Aug.Value, 2).ToString();
            }

            if (topRecord != null && topRecord.Sep.HasValue && topRecord.Sep > 0)
            {
                row.Sep = lst.Where(i => i.DosDate.Month == 9 && i.DosDate.Year == year).Sum(i => i.WriteOffAmount);
                row.SepString = "$" + Math.Round(row.Sep.Value, 2).ToString();
            }

            if (topRecord != null && topRecord.Oct.HasValue && topRecord.Oct > 0)
            {
                row.Oct = lst.Where(i => i.DosDate.Month == 10 && i.DosDate.Year == year).Sum(i => i.WriteOffAmount);
                row.OctString = "$" + Math.Round(row.Oct.Value, 2).ToString();
            }

            if (topRecord != null && topRecord.Nov.HasValue && topRecord.Nov > 0)
            {
                row.Nov = lst.Where(i => i.DosDate.Month == 11 && i.DosDate.Year == year).Sum(i => i.WriteOffAmount);
                row.NovString = "$" + Math.Round(row.Nov.Value, 2).ToString();
            }

            if (topRecord != null && topRecord.Dec.HasValue && topRecord.Dec > 0)
            {
                row.Dec = lst.Where(i => i.DosDate.Month == 12 && i.DosDate.Year == year).Sum(i => i.WriteOffAmount);
                row.DecString = "$" + Math.Round(row.Dec.Value, 2).ToString();
            }

            row.Charges = ((row.Jan ?? 0) + (row.Feb ?? 0) + (row.March ?? 0) + (row.April ?? 0) + (row.May ?? 0) + (row.June ?? 0)
                    + (row.July ?? 0) + (row.Aug ?? 0) + (row.Sep ?? 0) + (row.Oct ?? 0) + (row.Nov ?? 0) + (row.Dec ?? 0));

            if (row.Charges.HasValue && row.Charges > 0)
            {
                row.ChargesString = "$" + Math.Round(row.Charges.Value, 2).ToString();
            }

            return row;
        }

        private async Task<IReportARChargesMonthWise> GetRecoveryPercentageRow(int year, IEnumerable<IReportARChargesMonthWise> lst, IEnumerable<IReportARChargesMonthWise> finalList)
        {
            ReportARChargesMonthWise row = new ReportARChargesMonthWise();

            var topRecord = finalList.Where(i => i.YearId == year).OrderByDescending(i => i.Id).FirstOrDefault();

            var payments = lst.FirstOrDefault(i => i.Month == "Payments");
            var expectedAmount = lst.FirstOrDefault(i => i.Month == "Expected");



            row.Month = "RecoveryPercanage";

            if (topRecord != null && topRecord.Jan.HasValue && topRecord.Jan > 0)
            {
                if(payments.Jan>0)
                {
                    row.Jan = ((payments.Jan ?? 0) / expectedAmount.Jan) * 100;
                    row.JanString = Math.Round(row.Jan.Value, 2).ToString() + "%";
                }                
            }

            if (topRecord != null && topRecord.Feb.HasValue && topRecord.Feb > 0)
            {
                if (payments.Feb > 0)
                {
                    row.Feb = ((payments.Feb) / expectedAmount.Feb) * 100;
                    row.FebString = Math.Round(row.Feb.Value, 2).ToString() + "%";
                }
            }

            if (topRecord != null && topRecord.March.HasValue && topRecord.March > 0)
            {
                if (payments.March > 0)
                {
                    row.March = ((payments.March) / expectedAmount.March) * 100;
                    row.MarchString = Math.Round(row.March.Value, 2).ToString() + "%";
                }
            }

            if (topRecord != null && topRecord.April.HasValue && topRecord.April > 0)
            {
                if (payments.April > 0)
                {
                    row.April = ((payments.April) / expectedAmount.April) * 100;
                    row.AprilString = Math.Round(row.April.Value, 2).ToString() + "%";
                }
            }

            if (topRecord != null && topRecord.May.HasValue && topRecord.May > 0)
            {
                if (payments.May > 0)
                {
                    row.May = ((payments.May) / expectedAmount.May) * 100;
                    row.MayString = Math.Round(row.May.Value, 2).ToString() + "%";
                }
            }

            if (topRecord != null && topRecord.June.HasValue && topRecord.June > 0)
            {
                if (payments.June > 0)
                {
                    row.June = ((payments.June) / expectedAmount.June) * 100;
                    row.JuneString = Math.Round(row.June.Value, 2).ToString() + "%";
                }
            }

            if (topRecord != null && topRecord.July.HasValue && topRecord.July > 0)
            {
                if (payments.July > 0)
                {
                    row.July = ((payments.July) / expectedAmount.July) * 100;
                    row.JulyString = Math.Round(row.July.Value, 2).ToString() + "%";
                }
            }

            if (topRecord != null && topRecord.Aug.HasValue && topRecord.Aug > 0)
            {
                if (payments.Aug > 0)
                {
                    row.Aug = ((payments.Aug) / expectedAmount.Aug) * 100;
                    row.AugString = Math.Round(row.Aug.Value, 2).ToString() + "%";
                }
            }

            if (topRecord != null && topRecord.Sep.HasValue && topRecord.Sep > 0)
            {
                if (payments.Sep > 0)
                {
                    row.Sep = ((payments.Sep) / expectedAmount.Sep) * 100;
                    row.SepString = Math.Round(row.Sep.Value, 2).ToString() + "%";
                }
            }

            if (topRecord != null && topRecord.Oct.HasValue && topRecord.Oct > 0)
            {
                if (payments.Oct > 0)
                {
                    row.Oct = ((payments.Oct) / expectedAmount.Oct) * 100;
                    row.OctString = Math.Round(row.Oct.Value, 2).ToString() + "%";
                }
            }

            if (topRecord != null && topRecord.Nov.HasValue && topRecord.Nov > 0)
            {
                if (payments.Nov > 0)
                {
                    row.Nov = ((payments.Nov) / expectedAmount.Nov) * 100;
                    row.NovString = Math.Round(row.Nov.Value, 2).ToString() + "%";
                }
            }

            if (topRecord != null && topRecord.Dec.HasValue && topRecord.Dec > 0)
            {
                if (payments.Dec > 0)
                {
                    row.Dec = ((payments.Dec) / expectedAmount.Dec) * 100;
                    row.DecString = Math.Round(row.Dec.Value, 2).ToString() + "%";
                }
            }

            //row.Jan = ((charges.Jan - (payments.Jan + adjutment.Jan))/ charges.Jan)*100;
            //if (topRecord!=null && topRecord.Jan.HasValue && topRecord.Jan > 0)
            //    row.Jan = ((payments.Jan + adjutment.Jan) / charges.Jan) * 100;
            //if (topRecord!=null && topRecord.Feb.HasValue && topRecord.Feb > 0)
            //    row.Feb = ((payments.Feb + adjutment.Feb) / charges.Feb) * 100;
            //if (topRecord!=null && topRecord.March.HasValue && topRecord.March > 0)
            //    row.March = ((payments.March + adjutment.March) / charges.March) * 100;
            //if (topRecord!=null && topRecord.April.HasValue && topRecord.April > 0)
            //    row.April = ((payments.April + adjutment.April) / charges.April) * 100;
            //if (topRecord!=null && topRecord.May.HasValue && topRecord.May > 0)
            //    row.May = ((payments.May + adjutment.May) / charges.May) * 100;
            //if (topRecord!=null && topRecord.June.HasValue && topRecord.June > 0)
            //    row.June = ((payments.June + adjutment.June) / charges.June) * 100;
            //if (topRecord!=null && topRecord.July.HasValue && topRecord.July > 0)
            //    row.July = ((payments.July + adjutment.July) / charges.July) * 100;
            //if (topRecord!=null && topRecord.Aug.HasValue && topRecord.Aug > 0)
            //    row.Aug = ((payments.Aug + adjutment.Aug) / charges.Aug) * 100;
            //if (topRecord!=null && topRecord.Sep.HasValue && topRecord.Sep > 0)
            //    row.Sep = ((payments.Sep + adjutment.Sep) / charges.Sep) * 100;
            //if (topRecord!=null && topRecord.Oct.HasValue && topRecord.Oct > 0)
            //    row.Oct = ((payments.Oct + adjutment.Oct) / charges.Oct) * 100;
            //if (topRecord!=null && topRecord.Nov.HasValue && topRecord.Nov > 0)
            //    row.Nov = ((payments.Nov + adjutment.Nov) / charges.Nov) * 100;
            //if (topRecord!=null && topRecord.Dec.HasValue && topRecord.Dec> 0)
            //    row.Dec = ((payments.Dec + adjutment.Dec) / charges.Dec) * 100;

            //row.Charges = ((row.Jan ?? 0) + (row.Feb ?? 0) + (row.March ?? 0) + (row.April ?? 0) + (row.May ?? 0) + (row.June ?? 0)
            //        + (row.July ?? 0) + (row.Aug ?? 0) + (row.Sep ?? 0) + (row.Oct ?? 0) + (row.Nov ?? 0) + (row.Dec ?? 0));
            return row;
        }

        private async Task<IReportARChargesMonthWise> GetAdjustmentRow(int year, IEnumerable<IChargesReportData> lst, IEnumerable<IReportARChargesMonthWise> finalList)
        {
            ReportARChargesMonthWise row = new ReportARChargesMonthWise();

            var topRecord = finalList.Where(i => i.YearId == year).OrderByDescending(i => i.Id).FirstOrDefault();

            row.Month = "Adjustment";
            if (topRecord != null && topRecord.Jan.HasValue && topRecord.Jan > 0)
            {
                row.Jan = lst.Where(i => i.DosDate.Month == 1 && i.DosDate.Year == year && i.Denial == "No").Sum(i => i.Adjustment);
                row.JanString = "$" + Math.Round(row.Jan.Value, 2).ToString();
            }

            if (topRecord != null && topRecord.Feb.HasValue && topRecord.Feb > 0)
            {
                row.Feb = lst.Where(i => i.DosDate.Month == 2 && i.DosDate.Year == year && i.Denial == "No").Sum(i => i.Adjustment);
                row.FebString = "$" + Math.Round(row.Feb.Value, 2).ToString();
            }

            if (topRecord != null && topRecord.March.HasValue && topRecord.March > 0)
            {
                row.March = lst.Where(i => i.DosDate.Month == 3 && i.DosDate.Year == year && i.Denial == "No").Sum(i => i.Adjustment);
                row.MarchString = "$" + Math.Round(row.March.Value, 2).ToString();
            }

            if (topRecord != null && topRecord.April.HasValue && topRecord.April > 0)
            {
                row.April = lst.Where(i => i.DosDate.Month == 4 && i.DosDate.Year == year && i.Denial == "No").Sum(i => i.Adjustment);
                row.AprilString = "$" + Math.Round(row.April.Value, 2).ToString();
            }

            if (topRecord != null && topRecord.May.HasValue && topRecord.May > 0)
            {
                row.May = lst.Where(i => i.DosDate.Month == 5 && i.DosDate.Year == year && i.Denial == "No").Sum(i => i.Adjustment);
                row.MayString = "$" + Math.Round(row.May.Value, 2).ToString();
            }

            if (topRecord != null && topRecord.June.HasValue && topRecord.June > 0)
            {
                row.June = lst.Where(i => i.DosDate.Month == 6 && i.DosDate.Year == year && i.Denial == "No").Sum(i => i.Adjustment);
                row.JuneString = "$" + Math.Round(row.June.Value, 2).ToString();
            }

            if (topRecord != null && topRecord.July.HasValue && topRecord.July > 0)
            {
                row.July = lst.Where(i => i.DosDate.Month == 7 && i.DosDate.Year == year && i.Denial == "No").Sum(i => i.Adjustment);
                row.JulyString = "$" + Math.Round(row.July.Value, 2).ToString();
            }

            if (topRecord != null && topRecord.Aug.HasValue && topRecord.Aug > 0)
            {
                row.Aug = lst.Where(i => i.DosDate.Month == 8 && i.DosDate.Year == year && i.Denial == "No").Sum(i => i.Adjustment);
                row.AugString = "$" + Math.Round(row.Aug.Value, 2).ToString();
            }

            if (topRecord != null && topRecord.Sep.HasValue && topRecord.Sep > 0)
            {
                row.Sep = lst.Where(i => i.DosDate.Month == 9 && i.DosDate.Year == year && i.Denial == "No").Sum(i => i.Adjustment);
                row.SepString = "$" + Math.Round(row.Sep.Value, 2).ToString();
            }

            if (topRecord != null && topRecord.Oct.HasValue && topRecord.Oct > 0)
            {
                row.Oct = lst.Where(i => i.DosDate.Month == 10 && i.DosDate.Year == year && i.Denial == "No").Sum(i => i.Adjustment);
                row.OctString = "$" + Math.Round(row.Oct.Value, 2).ToString();
            }

            if (topRecord != null && topRecord.Nov.HasValue && topRecord.Nov > 0)
            {
                row.Nov = lst.Where(i => i.DosDate.Month == 11 && i.DosDate.Year == year && i.Denial == "No").Sum(i => i.Adjustment);
                row.NovString = "$" + Math.Round(row.Nov.Value, 2).ToString();
            }

            if (topRecord != null && topRecord.Dec.HasValue && topRecord.Dec > 0)
            {
                row.Dec = lst.Where(i => i.DosDate.Month == 12 && i.DosDate.Year == year && i.Denial == "No").Sum(i => i.Adjustment);
                row.DecString = "$" + Math.Round(row.Dec.Value, 2).ToString();
            }

            row.Charges = ((row.Jan ?? 0) + (row.Feb ?? 0) + (row.March ?? 0) + (row.April ?? 0) + (row.May ?? 0) + (row.June ?? 0)
                    + (row.July ?? 0) + (row.Aug ?? 0) + (row.Sep ?? 0) + (row.Oct ?? 0) + (row.Nov ?? 0) + (row.Dec ?? 0));

            if (row.Charges.HasValue && row.Charges > 0)
            {
                row.ChargesString = "$" + Math.Round(row.Charges.Value, 2).ToString();
            }
            return row;
        }

        private async Task<IReportARChargesMonthWise> GetDenailsRow(int year, IEnumerable<IChargesReportData> lst, IEnumerable<IReportARChargesMonthWise> finalList)
        {
            ReportARChargesMonthWise row = new ReportARChargesMonthWise();

            var topRecord = finalList.Where(i => i.YearId == year).OrderByDescending(i => i.Id).FirstOrDefault();

            List<string> duyBy = new List<string>() { "", "patient" };

            row.Month = "Denials";
            if (topRecord != null && topRecord.Jan.HasValue && topRecord.Jan > 0)
            {
                row.Jan = lst.Where(i => i.DosDate.Month == 1 && i.DosDate.Year == year && i.Denial == "Yes" && !duyBy.Contains(i.DueBy.ToLower())).Sum(i => i.DueAmount);
                row.JanString = "$" + Math.Round(row.Jan.Value, 2).ToString();
            }

            if (topRecord != null && topRecord.Feb.HasValue && topRecord.Feb > 0)
            {
                row.Feb = lst.Where(i => i.DosDate.Month == 2 && i.DosDate.Year == year && i.Denial == "Yes" && !duyBy.Contains(i.DueBy.ToLower())).Sum(i => i.DueAmount);
                row.FebString = "$" + Math.Round(row.Feb.Value, 2).ToString();
            }

            if (topRecord != null && topRecord.March.HasValue && topRecord.March > 0)
            {
                row.March = lst.Where(i => i.DosDate.Month == 3 && i.DosDate.Year == year && i.Denial == "Yes" && !duyBy.Contains(i.DueBy.ToLower())).Sum(i => i.DueAmount);
                row.MarchString = "$" + Math.Round(row.March.Value, 2).ToString();
            }

            if (topRecord != null && topRecord.April.HasValue && topRecord.April > 0)
            {
                row.April = lst.Where(i => i.DosDate.Month == 4 && i.DosDate.Year == year && i.Denial == "Yes" && !duyBy.Contains(i.DueBy.ToLower())).Sum(i => i.DueAmount);
                row.AprilString = "$" + Math.Round(row.April.Value, 2).ToString();
            }

            if (topRecord != null && topRecord.May.HasValue && topRecord.May > 0)
            {
                row.May = lst.Where(i => i.DosDate.Month == 5 && i.DosDate.Year == year && i.Denial == "Yes" && !duyBy.Contains(i.DueBy.ToLower())).Sum(i => i.DueAmount);
                row.MayString = "$" + Math.Round(row.May.Value, 2).ToString();
            }

            if (topRecord != null && topRecord.June.HasValue && topRecord.June > 0)
            {
                row.June = lst.Where(i => i.DosDate.Month == 6 && i.DosDate.Year == year && i.Denial == "Yes" && !duyBy.Contains(i.DueBy.ToLower())).Sum(i => i.DueAmount);
                row.JuneString = "$" + Math.Round(row.June.Value, 2).ToString();
            }

            if (topRecord != null && topRecord.July.HasValue && topRecord.July > 0)
            {
                row.July = lst.Where(i => i.DosDate.Month == 7 && i.DosDate.Year == year && i.Denial == "Yes" && !duyBy.Contains(i.DueBy.ToLower())).Sum(i => i.DueAmount);
                row.JulyString = "$" + Math.Round(row.July.Value, 2).ToString();
            }

            if (topRecord != null && topRecord.Aug.HasValue && topRecord.Aug > 0)
            {
                row.Aug = lst.Where(i => i.DosDate.Month == 8 && i.DosDate.Year == year && i.Denial == "Yes" && !duyBy.Contains(i.DueBy.ToLower())).Sum(i => i.DueAmount);
                row.AugString = "$" + Math.Round(row.Aug.Value, 2).ToString();
            }

            if (topRecord != null && topRecord.Sep.HasValue && topRecord.Sep > 0)
            {
                row.Sep = lst.Where(i => i.DosDate.Month == 9 && i.DosDate.Year == year && i.Denial == "Yes" && !duyBy.Contains(i.DueBy.ToLower())).Sum(i => i.DueAmount);
                row.SepString = "$" + Math.Round(row.Sep.Value, 2).ToString();
            }

            if (topRecord != null && topRecord.Oct.HasValue && topRecord.Oct > 0)
            { 
                row.Oct = lst.Where(i => i.DosDate.Month == 10 && i.DosDate.Year == year && i.Denial == "Yes" && !duyBy.Contains(i.DueBy.ToLower())).Sum(i => i.DueAmount);
                row.OctString = "$" + Math.Round(row.Oct.Value, 2).ToString();
            }

            if (topRecord != null && topRecord.Nov.HasValue && topRecord.Nov > 0)
            {
                row.Nov = lst.Where(i => i.DosDate.Month == 11 && i.DosDate.Year == year && i.Denial == "Yes" && !duyBy.Contains(i.DueBy.ToLower())).Sum(i => i.DueAmount);
                row.NovString = "$" + Math.Round(row.Nov.Value, 2).ToString();
            }

            if (topRecord != null && topRecord.Dec.HasValue && topRecord.Dec > 0)
            {
                row.Dec = lst.Where(i => i.DosDate.Month == 12 && i.DosDate.Year == year && i.Denial == "Yes" && !duyBy.Contains(i.DueBy.ToLower())).Sum(i => i.DueAmount);
                row.DecString = "$" + Math.Round(row.Dec.Value, 2).ToString();
            }

            row.Charges = ((row.Jan ?? 0) + (row.Feb ?? 0) + (row.March ?? 0) + (row.April ?? 0) + (row.May ?? 0) + (row.June ?? 0)
                    + (row.July ?? 0) + (row.Aug ?? 0) + (row.Sep ?? 0) + (row.Oct ?? 0) + (row.Nov ?? 0) + (row.Dec ?? 0));

            if (row.Charges.HasValue && row.Charges > 0)
            {
                row.ChargesString = "$" + Math.Round(row.Charges.Value, 2).ToString();
            }

            return row;
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
}
