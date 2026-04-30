using PractiZing.Base.Entities.ChargePaymentService;
using PractiZing.Base.Entities.ERAService;
using PractiZing.DataAccess.ChargePaymentService.Tables;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PractiZing.BussinessLogic.ERAService.Converter
{
    public interface IPaymentBatchConverter
    {
        Task<IPaymentBatch> IniIPaymentBatch(IERARoot eRARoot);
    }

    public class PaymentBatchConverter : IPaymentBatchConverter
    {
        public async Task<IPaymentBatch> IniIPaymentBatch(IERARoot eRARoot)
        {
            PaymentBatch paymentBatchEntity = new PaymentBatch();
            paymentBatchEntity.Id = 0;
            paymentBatchEntity.BatchAmount = eRARoot.EraPayment;
            paymentBatchEntity.Amount = eRARoot.EraPayment;
            paymentBatchEntity.RecordCount = 0;
            paymentBatchEntity.IsSystem = true;

            return paymentBatchEntity;
        }
    }
}
