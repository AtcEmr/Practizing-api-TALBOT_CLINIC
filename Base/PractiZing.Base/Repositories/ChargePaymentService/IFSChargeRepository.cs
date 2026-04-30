using PractiZing.Base.Entities.ChargePaymentService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.ChargePaymentService
{
    public interface IFSChargeRepository
    {
        Task<IEnumerable<IFSCharge>> GetAll();
        Task<IFSCharge> GetByCPT(string cptCode);
        Task<IEnumerable<IFSCharge>> GetByFeeSchedule(short feeScheduleId);
        Task<IEnumerable<IFSCharge>> GetByCPTCharge(string cptCode, string modifier, short feeScheduleId, string insuranceCompanyId = "", int providerId = 0);
        Task<IFSCharge> AddNew(IFSCharge entity);
        Task<int> Update(IFSCharge entity);
        Task<bool> UpdateEntities(IEnumerable<IFSCharge> entities, short feeScheduleId);
        Task<int> Delete(short id);
        Task<IFSCharge> GetByCPT(string cptCode, short feeScheduleId);
        Task<IEnumerable<IFSCharge>> GetByCPTChargeByQualification(string cptCode, string modifier, short feeScheduleId, string insuranceCompanyId = "", int qualificationId = 0);
        Task<IEnumerable<IFSCharge>> GetByCPTChargeByQualificationOLD(string cptCode, string modifier, short feeScheduleId, string insuranceCompanyId = "", int qualificationId = 0);
        Task<IFSCharge> GetDefaultFeeRates(string cptCode, short feeScheduleId);
    }
}
