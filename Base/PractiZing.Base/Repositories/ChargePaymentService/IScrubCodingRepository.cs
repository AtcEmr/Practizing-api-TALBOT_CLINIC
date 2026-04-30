using PractiZing.Base.Entities.ChargePaymentService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.ChargePaymentService
{
    public interface IScrubCodingRepository
    {
        Task<IEnumerable<IScrubCoding>> GetByPatientCase(int patientCaseId);

        Task<IScrubCoding> AddNew(IScrubCoding entity, int count);

    }
}
