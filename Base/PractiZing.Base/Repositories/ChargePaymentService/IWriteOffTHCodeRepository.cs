using PractiZing.Base.Entities.ChargePaymentService;
using PractiZing.Base.Object.ChargePaymentService;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.ChargePaymentService
{
    public interface IWriteOffTHCodeRepository
    {
        Task<bool> AddNew(IEnumerable<IWriteOffTHCode> entityList);
        Task<IEnumerable<IWriteOffEMRObjectDTO>> GetDataFormEMR();
        Task<int> UpdateWriteOffEMRAcknowledgement(IEnumerable<IWriteOffEMRObjectDTO> list);
    }
}
