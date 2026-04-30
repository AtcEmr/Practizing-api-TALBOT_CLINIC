using PractiZing.Base.Entities.ERAService;
using PractiZing.Base.Object.ChargePaymentService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PractiZing.Base.Service.ChargePaymentService
{
    public interface IERAPaymentService
    {
        Task AddPaymentFromERA(long eraRootId);
        Task<IPaymentBatchDTO> AddPaymentFromERA(IERARoot entity);
        Task<IPaymentBatchDTO> CreatePaymentObject(long eraRootId);
    }
}
