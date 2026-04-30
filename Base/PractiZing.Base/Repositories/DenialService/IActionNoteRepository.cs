using Microsoft.AspNetCore.Http;
using PractiZing.Base.Entities.ChargePaymentService;
using PractiZing.Base.Entities.DenialService;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.DenialService
{
    public interface IActionNoteRepository
    {
        Task<IEnumerable<IActionNote>> Get();
        Task<IActionNote> Get(int id);
        Task<IActionNote> Get(Guid UId);
        Task<IEnumerable<int>> GetByCategoryUIds(string uids);
        Task<IEnumerable<IActionNote>> GetByActionCategory(Guid actionCategoryUId);
        Task<IActionNote> AddNew(IActionNote entity, IEnumerable<IFormFile> formFiles);
        Task<int> Update(IActionNote entity);
        Task<int> Delete(Guid actionNoteUId);
        Task<IEnumerable<IActionNote>> GetByChargeUId(Guid patientUId, Guid chargeUId);
        Task ActionNoteExist(Guid actionCategoryUId);
        Task AddNote(IEnumerable<IActionNote> entities);
        Task<IEnumerable<IActionNote>> CreateObject(int patientCaseId, IEnumerable<ICharges> chargeIds, int claimId, string note);
        Task<int> UpdateClaim(int[] claimId);
        Task<IEnumerable<IActionNote>> AddPaymentNote(int patientId, int chargeId, string note);
        Task<IActionNote> AddPatientNote(IActionNote entity);
        Task<IEnumerable<IActionNote>> GetByPatientUId(string patientUId);
        Task<int> UpdatePatientNote(IActionNote entity);
        Task<IEnumerable<IActionNote>> GetByChargeId(int chargeId);
        Task<int> Delete(IEnumerable<int> actionNoteUIds);
        Task<int> DeleteByChargeId(int chargeId);
        Task<IEnumerable<IActionNote>> GetByPatientUIdExceptPatientsNotes(string patientUId);
    }
}
