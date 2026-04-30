using Microsoft.AspNetCore.Http;
using PractiZing.Base.Entities.ChargePaymentService;
using PractiZing.Base.Model.ChargePaymentService;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.ChargePaymentService
{
    public interface IPlaidPaymentRepository
    {
        Task GetBankTransaction(IPlaidPaymentSearch plaidPaymentSearch);
        Task Test();
        Task<IEnumerable<IPlaidPayment>> GetAllPlaidPayments();
        Task<int> UpdatePlaidMatched(List<int> ids);
        Task<string> GetBankTransactionSync(IPlaidPaymentSearch plaidPaymentSearch);
        Task<decimal> GetDepositsAmount(DateTime fromDate, DateTime toDate);
        Task<IEnumerable<IPlaidPayment>> GetPaymentsOnFilterDates(IPlaidPaymentSearch voucherViewFilter);
        Task<string> GeneratePlaidPaymentsFromExcelImport(int monthId, int yearId, IFormFile file);
    }
}
