using PractiZing.Base.Entities.ChargePaymentService;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.ChargePaymentService
{
    public interface IFeeScheduleRepository
    {
        Task<IEnumerable<IFeeSchedule>> GetAll();
        Task<IFeeSchedule> GetByUId(Guid UId);
        Task<IFeeSchedule> GetById(short id);
        Task<IFeeSchedule> AddNew(IFeeSchedule entity);
        Task<int> Update(IFeeSchedule entity);
        Task<int> Delete(short id);
        Task<IEnumerable<IFeeSchedule>> GetFeeSchedule(string cptCode);
        Task<IFeeSchedule> GetFeeSchedules(DateTime fromDate);
        Task FeeScheduleNotExist();
        Task<IFeeSchedule> GetLatestUid();
    }
}
