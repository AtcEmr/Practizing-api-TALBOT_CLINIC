using PractiZing.Base.Entities.ChargePaymentService;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.ChargePaymentService
{
    public interface IPaymentAdjustmentNotesRepository
    {        
        Task<IPaymentAdjustmentNotes> AddNew(IPaymentAdjustmentNotes entity);
        Task<bool> SendNotesToEMR();
    }
}
