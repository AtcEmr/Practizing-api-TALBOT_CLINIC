using PractiZing.Base.Entities.ChargePaymentService;
using PractiZing.Base.Entities.DenialService;
using PractiZing.Base.Model.DenialService;
using PractiZing.Base.Object.DenialService;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.DenialService
{
    public interface IDenialQueueRepository
    {
        Task<IEnumerable<IDenialQueue>> GetAll();
        Task<IDenialQueue> GetById(int id);
        Task<IDenialQueue> GetByUId(Guid UId);
        Task<IAssignedFollowUpDTO> GetAssignedFollowUpCount(IList<int> chargeIds);
        Task<IEnumerable<IDenialQueue>> GetByChargeIds(IList<int> chargeIds);
        Task<int> AddOrUpdate(string chargeUIds, string userUId);
        Task<IDenialQueue> AddNew(IDenialQueue entity);
        Task<int> Update(IDenialQueue entity);
        Task<int> Delete(int id);
        Task<IDenialManagementScreenDTO> GetAgingCount();
        Task<IDenialManagementFilterDTO> GetFilterForDenialCharge();
        Task<IEnumerable<ICharges>> GetCharges(IDenialFilter filter);
        Task<IDenialQueue> GetByChargeId(int chargeId);
        Task<int> UpdateFollowUp(IDenialQueue entity);
        Task<IDenialQueue> CheckDenialQueueExists(int chargeId);
    }
}
