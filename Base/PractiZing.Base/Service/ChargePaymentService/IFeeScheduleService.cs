using PractiZing.Base.Entities.ChargePaymentService;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PractiZing.Base.Service.ChargePaymentService
{
    public interface IFeeScheduleService
    {
        Task<IFSCharge> GetChargeByCPT(string cptCode, IEnumerable<string> modifiers, string providerUId, string insuranceCompanyUId, DateTime fromDate);
        Task<IFeeSchedule> GetFeeSchedule(Guid uId);
        Task<IFeeSchedule> GetFeeScheduleCPTCodes(Guid uid);
        Task<IFeeSchedule> AddNew(IFeeSchedule entity);
        Task<IFSCharge> AddFSCharge(IFSCharge entity);
        Task<int> Update(IFeeSchedule entity);
        Task<bool> UpdateFSCharge(IFSCharge entity);
        Task<int> DeleteFSCharge(short id);
        Task<int> DeleteFeeSchedule(Guid uId);
    }
}
