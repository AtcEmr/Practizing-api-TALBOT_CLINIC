using Microsoft.AspNetCore.Http;
using PractiZing.Base.Common;
using PractiZing.Base.Entities.ChargePaymentService;
using PractiZing.Base.Entities.DenialService;
using PractiZing.Base.Entities.PatientService;
using PractiZing.Base.Entities.SecurityService;
using PractiZing.Base.Enums.DenialService;
using PractiZing.Base.Enums.MasterService;
using PractiZing.Base.Repositories.ChargePaymentService;
using PractiZing.Base.Repositories.DenialService;
using PractiZing.Base.Repositories.MasterService;
using PractiZing.Base.Repositories.PatientService;
using PractiZing.BusinessLogic.Common;
using PractiZing.DataAccess.Common;
using PractiZing.DataAccess.DenialService;
using PractiZing.DataAccess.DenialService.Tables;
using PractiZing.DataAccess.MasterService.Tables;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PractiZing.BusinessLogic.DenialService.Repositories
{
    public class ActionNoteRepository : ModuleBaseRepository<ActionNote>, IActionNoteRepository
    {
        private IChargesRepository _chargeRespository;
        private IActionCategoryRepository _actionCategoryRespository;
        private IPatientRepository _patientRespository;
        private IAttFileRepository _attFileRepository;
        private IDenialQueueRepository _denialQueueRepository;
        private IPatientCaseRepository _patientCaseRepository;

        public ActionNoteRepository(ValidationErrorCodes errorCodes,
                                           DataBaseContext dbContext,
                                           ILoginUser loggedUser,
                                           IChargesRepository chargeRespository,
                                           IActionCategoryRepository actionCategoryRespository,
                                           IPatientRepository patientRespository,
                                           IAttFileRepository attFileRepository,
                                           IDenialQueueRepository denialQueueRepository,
                                           IPatientCaseRepository patientCaseRepository
                                           ) : base(errorCodes, dbContext, loggedUser)
        {
            this._chargeRespository = chargeRespository;
            this._actionCategoryRespository = actionCategoryRespository;
            this._patientRespository = patientRespository;
            this._attFileRepository = attFileRepository;
            this._denialQueueRepository = denialQueueRepository;
            this._patientCaseRepository = patientCaseRepository;
        }

        public async Task<IEnumerable<IActionNote>> GetByChargeUId(Guid patientUId, Guid chargeUId)
        {
            try
            {
                SqlExpression<ActionNote> query = null;
                int patientId = patientUId == Guid.Empty ? 0 : (await _patientRespository.GetByUId(patientUId)).Id;

                int chargeId = chargeUId == Guid.Empty ? 0 : (await _chargeRespository.GetByUId(chargeUId)).Id;

                if (patientId > 0)
                {
                    query = this.Connection.From<ActionNote>()
                       .LeftJoin<ConfigSystemCD>((i, k) => i.NoteSourceCD == k.CD, this.Connection.JoinAlias("configOne"))
                       .LeftJoin<ConfigSystemCD>((i, k) => i.ResponseByCD == k.CD, this.Connection.JoinAlias("configTwo"))
                       .LeftJoin<ActionCategory>((i, m) => i.ActionCategoryId == m.Id, this.Connection.JoinAlias("actionCategoryOne"))
                       .LeftJoin<ActionCategory>((i, m) => i.ActionSubCategoryId == m.Id, this.Connection.JoinAlias("actionCategoryTwo"))
                       .Select<ActionNote, ConfigSystemCD, ActionCategory>((i, k, m) => new
                       {
                           i,
                           NoteSourceCDDescription = Sql.JoinAlias(k.Description, "configOne"),
                           ResponseByCDDescription = Sql.JoinAlias(k.Description, "configTwo"),
                           ActionCategoryName = Sql.JoinAlias(m.CategoryName, "actionCategoryOne"),
                           ActionSubCategoryName = Sql.JoinAlias(m.CategoryName, "actionCategoryTwo"),
                           ActionCategoryUId = Sql.JoinAlias(m.UId, "actionCategoryOne"),
                           ActionSubCategoryUId = Sql.JoinAlias(m.UId, "actionCategoryTwo"),
                       })
                       .Where(i => i.PatientId == patientId && i.PracticeId == LoggedUser.PracticeId);
                }

                query = chargeId > 0 ? query.Where(i => i.ChargeId == chargeId && (i.NoteSourceCD.Trim().ToLower() == ConfigSystemCDConstant.Charge.Trim().ToLower() || i.NoteSourceCD.Trim().ToLower() == ConfigSystemCDConstant.Claim.Trim().ToLower()))
                                     : query.Where(i => i.NoteSourceCD.Trim().ToLower() == ConfigSystemCDConstant.Patient.Trim().ToLower());

                var queryResult = await this.Connection.SelectAsync<dynamic>(query);
                var result = Mapper<ActionNote>.MapList(queryResult);
                var ids = result.Select(i => i.Id);

                var attachments = await this._attFileRepository.GetByTableId(ids, AttTableConstant.ActionNote);

                result.ToList().ForEach(i => i.AttFiles = attachments.Where(x => x.TableIdValue == i.Id));
                result = result.OrderBy(i => i.CreatedDate);
                if (chargeId > 0)
                {
                    var denialQueue = await this._denialQueueRepository.GetByChargeId(chargeId);
                    if (result.Count() == 0)
                    {
                        var lstActionNote = new List<ActionNote>();
                        lstActionNote.Add(new ActionNote());
                        result = lstActionNote;
                    }
                    if (denialQueue != null)
                    {
                        result.ToList()[0].AssignedTo = denialQueue.AssignedTo;
                        result.ToList()[0].DenialQueueFollowUpDate = (denialQueue.HasFollowUp == true ? denialQueue.FollowUpDate : null);
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IEnumerable<int>> GetByCategoryUIds(string uids)
        {
            try
            {
                var categoryIds = (await this._actionCategoryRespository.GetByUIds(uids)).ToList();
                if (categoryIds != null)
                {
                    var notes = await this.Connection.SelectAsync<ActionNote>(i => i.ActionCategoryId != null);
                    notes = notes.Where(i => categoryIds.Contains(i.ActionCategoryId.Value)).ToList();
                    if (notes.Count() > 0)
                        return notes.Select(i => i.ChargeId.Value);
                }
                return null;
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<IActionNote>> GetByPatientUId(string patientUId)
        {
            try
            {
                var patientData = await this._patientRespository.GetByUId(Guid.Parse(patientUId));
                var notes = await this.Connection.SelectAsync<ActionNote>(i => i.PatientId == patientData.Id && i.NoteSourceCD == ConfigSystemCDConstant.Patient);
                return notes.OrderByDescending(i => i.CreatedDate);
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<IActionNote>> GetByPatientUIdExceptPatientsNotes(string patientUId)
        {
            try
            {
                var patientData = await this._patientRespository.GetByUId(Guid.Parse(patientUId));
                var notes = await this.Connection.SelectAsync<ActionNote>(i => i.PatientId == patientData.Id && i.NoteSourceCD != ConfigSystemCDConstant.Patient);
                return notes.OrderByDescending(i => i.CreatedDate);
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<IActionNote>> Get()
        {

            return (await this.Connection.SelectAsync<ActionNote>(i => i.PracticeId == LoggedUser.PracticeId)).OrderBy(i => i.Note);
        }

        public async Task<IActionNote> Get(int id)
        {
            return await this.Connection.SingleAsync<ActionNote>(i => i.Id == id && i.PracticeId == LoggedUser.PracticeId);
        }

        public async Task<IActionNote> Get(Guid UId)
        {
            return await this.Connection.SingleAsync<ActionNote>(i => i.UId == UId && i.PracticeId == LoggedUser.PracticeId);
        }

        public async Task<IEnumerable<IActionNote>> GetByActionCategory(Guid actionCategoryUId)
        {
            var category = await this._actionCategoryRespository.Get(actionCategoryUId);
            category.Id = category == null ? 0 : category.Id;
            var result = await this.Connection.SelectAsync<ActionNote>(i => i.ActionCategoryId == category.Id);
            return result;
        }

        public async Task<IActionNote> AddNew(IActionNote entity, IEnumerable<IFormFile> formFiles)
        {
            try
            {
                ActionNote tEntity = entity as ActionNote;

                var errors = await this.ValidateEntityToAdd(tEntity);
                if (errors.Count() > 0)
                    await this.ThrowEntityException(errors);

                if (tEntity.ActionCategoryUId.HasValue && tEntity.ActionCategoryUId != Guid.Empty && !string.IsNullOrEmpty(tEntity.ActionCategoryUId.ToString()))
                {
                    var actionCategoryObj = await _actionCategoryRespository.Get(tEntity.ActionCategoryUId.Value);
                    if (actionCategoryObj != null)
                    {
                        tEntity.ActionCategoryId = actionCategoryObj.Id;
                    }
                }

                if (tEntity.ActionSubCategoryUId.HasValue && tEntity.ActionSubCategoryUId != Guid.Empty && !string.IsNullOrEmpty(tEntity.ActionSubCategoryUId.ToString()))
                {
                    var actionSubCategoryObj = await _actionCategoryRespository.Get(tEntity.ActionSubCategoryUId.Value);

                    if (actionSubCategoryObj != null)
                    {
                        tEntity.ActionSubCategoryId = actionSubCategoryObj.Id;
                    }
                }

                var patientObj = await _patientRespository.GetByUId(tEntity.PatientUId);
                if (patientObj != null)
                {
                    tEntity.PatientId = patientObj.Id;
                }

                var chargeObj = await _chargeRespository.GetByUId(tEntity.ChargeUId);
                if (chargeObj != null)
                {
                    tEntity.ChargeId = chargeObj.Id;
                }

                tEntity.UserName = (LoggedUser.FirstName + " " + LoggedUser.LastName);

                var actionNote = await base.AddNewAsync(tEntity);
                if (actionNote != null && (tEntity.HasFollowUp.HasValue && tEntity.HasFollowUp.Value) && tEntity.ChargeId.HasValue)
                {                    
                    var denialQueue = await this._denialQueueRepository.CheckDenialQueueExists(tEntity.ChargeId.Value);
                    if (denialQueue != null)
                    {
                        denialQueue.ChargeId = tEntity.ChargeId;
                        denialQueue.HasFollowUp = tEntity.HasFollowUp;
                        denialQueue.FollowUpDate = tEntity.FollowUpDate;
                        await this._denialQueueRepository.UpdateFollowUp(denialQueue);
                    }
                    else
                    {
                        denialQueue = new DenialQueue();
                        denialQueue.ChargeId = tEntity.ChargeId;
                        denialQueue.AssignedTo = tEntity.AssignedTo==null?this.LoggedUser.UserName: tEntity.AssignedTo;
                        denialQueue.AssignedBy = LoggedUser.UserName;
                        denialQueue.AssignedDate = DateTime.Now;
                        denialQueue.HasFollowUp = tEntity.HasFollowUp;
                        denialQueue.FollowUpDate = tEntity.FollowUpDate;
                        denialQueue.IsClosed = false;
                        denialQueue.LastNoteId = actionNote.Id;
                        await this._denialQueueRepository.AddNew(denialQueue);
                    }
                }

                // save attachment's
                foreach (var formFile in formFiles)
                {
                    var addAttachment = await this._attFileRepository.CreateAttachments(formFile, actionNote.Id, AttTableConstant.ActionNote, formFile.FileName);
                    var fullPath = await this._attFileRepository.SaveFile(formFile, addAttachment.UId.ToString(), AttTableConstant.ActionNote);
                }

                return actionNote;
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> Update(IActionNote entity)
        {
            try
            {
                ActionNote tEntity = entity as ActionNote;

                var errors = await this.ValidateEntityToUpdate(tEntity);
                if (errors.Count() > 0)
                    await this.ThrowEntityException(errors);

                var updateOnlyFields = this.Connection
                                       .From<ActionNote>()
                                       .Update(x => new
                                       {
                                           x.PatientId,
                                           x.ChargeId,
                                           x.ClaimId,
                                           x.Note,
                                           x.NoteSourceCD,
                                           x.ActionCategoryId,
                                           x.HasFollowUp,
                                           x.FollowUpDate,
                                           x.ResponseByCD,
                                           x.HasAttachment
                                       })
                                       .Where(i => i.UId == entity.UId && i.PracticeId == LoggedUser.PracticeId);

                return await base.UpdateOnlyAsync(tEntity, updateOnlyFields);
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> UpdatePatientNote(IActionNote entity)
        {
            try
            {
                ActionNote tEntity = entity as ActionNote;

                var errors = await this.ValidateEntityToUpdate(tEntity);
                if (errors.Count() > 0)
                    await this.ThrowEntityException(errors);

                var updateOnlyFields = this.Connection
                                       .From<ActionNote>()
                                       .Update(x => new
                                       {
                                           x.PatientId,
                                           x.Note
                                       })
                                       .Where(i => i.UId == entity.UId && i.PracticeId == LoggedUser.PracticeId);

                return await base.UpdateOnlyAsync(tEntity, updateOnlyFields);
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> Update(int[] noteIds)
        {
            try
            {
                ActionNote actionNote = new ActionNote();
                actionNote.ClaimId = null;
                actionNote.NoteSourceCD = ConfigSystemCDConstant.Charge;

                var updateOnlyFields = this.Connection
                                       .From<ActionNote>()
                                       .Update(x => new
                                       {
                                           x.ClaimId,
                                           x.NoteSourceCD
                                       })
                                       .Where(i => noteIds.Contains(i.Id) && i.PracticeId == LoggedUser.PracticeId);

                return await base.UpdateOnlyAsync(actionNote, updateOnlyFields);
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> Delete(Guid actionNoteUId)
        {
            try
            {
                int actionNoteId = 0;
                bool canDelete = false;
                var actionNote = (await this.Connection.SingleAsync<ActionNote>(i => i.UId == actionNoteUId && i.PracticeId == LoggedUser.PracticeId));
                if (actionNote != null)
                {
                    actionNoteId = actionNote.Id;
                    if (actionNote.CreatedBy.Trim().ToLower() == LoggedUser.UserName.Trim().ToLower())
                        canDelete = true;
                }

                if (!canDelete)
                {
                    var errors = await this.ValidateEntityToDelete(actionNote);
                    if (errors.Count() > 0)
                        await this.ThrowEntityException(errors);
                }

                return await this.Connection.DeleteAsync<ActionNote>(i => i.Id == actionNoteId && i.PracticeId == LoggedUser.PracticeId);
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> Delete(IEnumerable<int> actionNoteUIds)
        {
            try
            {
                int actionNoteId = 0;
                bool canDelete = false;
                var actionNote = (await this.Connection.SelectAsync<ActionNote>(i => actionNoteUIds.Contains(i.Id) && i.PracticeId == LoggedUser.PracticeId));

                foreach (var item in actionNote)
                {
                    if (actionNote.Count > 0)
                    {
                        actionNoteId = item.Id;
                        if (item.CreatedBy.Trim().ToLower() == LoggedUser.UserName.Trim().ToLower())
                            canDelete = true;
                    }

                    if (!canDelete)
                    {
                        var errors = await this.ValidateEntityToDelete(item);
                        if (errors.Count() > 0)
                            await this.ThrowEntityException(errors);
                    }

                    await this.Connection.DeleteAsync<ActionNote>(i => i.Id == actionNoteId && i.PracticeId == LoggedUser.PracticeId);
                    actionNoteId = 0;
                }

                return 1;
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> DeleteByChargeId(int chargeId)
        {
            try
            {
                await this.Connection.DeleteAsync<ActionNote>(i => i.ChargeId == chargeId && i.PracticeId == LoggedUser.PracticeId);
                return 1;
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> UpdateClaim(int[] claimId)
        {
            try
            {
                var getClaimNote = await this.Connection.SelectAsync<ActionNote>(i => claimId.Contains(i.ClaimId.Value) && i.PracticeId == LoggedUser.PracticeId);
                int[] noteIds = getClaimNote.Select(i => i.Id).ToArray();
                return await this.Update(noteIds);
            }
            catch
            {
                throw;
            }
        }

        public async Task ActionNoteExist(Guid actionCategoryUId)
        {
            var _notes = await this.GetByActionCategory(actionCategoryUId);
            if (_notes.Count() > 0)
                await this.ThrowEntityException(new ValidationCodeResult(ErrorCodes[EnumErrorCode.ActionNoteExist]));
        }

        private async Task<IEnumerable<IValidationResult>> ValidateEntityToDelete(IActionNote entity)
        {
            List<IValidationResult> errors = new List<IValidationResult>();
            errors.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.ActionNoteDelete]));
            return errors;
        }

        public async Task AddNote(IEnumerable<IActionNote> entities)
        {
            try
            {
                foreach (var item in entities)
                {
                    ActionNote tEntity = item as ActionNote;
                    await base.AddNewAsync(tEntity);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IActionNote> AddPatientNote(IActionNote entity)
        {
            try
            {
                ActionNote tEntity = entity as ActionNote;
                tEntity.ClaimId = null;
                tEntity.ChargeId = null;
                tEntity.HasFollowUp = null;
                tEntity.ActionCategoryId = null;
                tEntity.HasAttachment = false;
                tEntity.NoteSourceCD = ConfigSystemCDConstant.Patient;
                tEntity.FollowUpDate = null;
                tEntity.ResponseByCD = null;
                tEntity.IsNote = true;

                var patientObj = await _patientRespository.GetByUId(tEntity.PatientUId);
                if (patientObj != null)
                {
                    tEntity.PatientId = patientObj.Id;
                }

                tEntity.UserName = (LoggedUser.FirstName + " " + LoggedUser.LastName);

                var errors = await this.ValidateEntityToAdd(tEntity);
                if (errors.Count() > 0)
                    await this.ThrowEntityException(errors);

                return await base.AddNewAsync(tEntity);
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<IActionNote>> CreateObject(int patientCaseId, IEnumerable<ICharges> chargeIds, int claimId, string note)
        {
            List<IActionNote> actionNotes = new List<IActionNote>();
            IPatientCase patientCase = null;

            if (patientCaseId != 0)
                patientCase = await this._patientCaseRepository.GetById(patientCaseId);

            foreach (var item in chargeIds)
            {
                ActionNote actionNote = new ActionNote();
                actionNote.UserName = "System";
                actionNote.ChargeId = item.Id;
                actionNote.ClaimId = claimId;

                if (patientCase == null)
                {
                    var patientCaseIdCharge = await this._chargeRespository.GetById(item.Id);
                    patientCase = await this._patientCaseRepository.GetById(patientCaseIdCharge.PatientCaseId);
                }

                actionNote.PatientId = patientCase == null ? (int)0 : (int)patientCase.PatientId;
                actionNote.PracticeId = LoggedUser.PracticeId;
                actionNote.Note = note + "for accession number (#" + item.AccessionNumber + ") on cpt code (# " + item.CPTCode + ")";
                actionNote.HasFollowUp = null;
                actionNote.ActionCategoryId = null;
                actionNote.HasAttachment = false;
                actionNote.NoteSourceCD = ConfigSystemCDConstant.Claim;
                actionNote.FollowUpDate = null;
                actionNote.ResponseByCD = null;
                actionNote.IsNote = true;

                actionNotes.Add(actionNote);
            }

            await this.AddNote(actionNotes);

            return actionNotes;
        }

        public async Task<IEnumerable<IActionNote>> AddPaymentNote(int patientId, int chargeId, string note)
        {
            List<IActionNote> actionNotes = new List<IActionNote>();

            ActionNote actionNote = new ActionNote();
            actionNote.UserName = "System";
            actionNote.ChargeId = chargeId;
            actionNote.ClaimId = null;
            actionNote.PatientId = patientId;
            actionNote.PracticeId = LoggedUser.PracticeId;
            actionNote.Note = note;
            actionNote.HasFollowUp = null;
            actionNote.ActionCategoryId = null;
            actionNote.HasAttachment = false;
            actionNote.NoteSourceCD = ConfigSystemCDConstant.Charge;
            actionNote.FollowUpDate = null;
            actionNote.ResponseByCD = null;
            actionNote.IsNote = true;
            actionNotes.Add(actionNote);

            await this.AddNote(actionNotes);
            return actionNotes;
        }

        public async Task<IEnumerable<IActionNote>> GetByChargeId(int chargeId)
        {
            try
            {
                return await this.Connection.SelectAsync<ActionNote>(i => i.ChargeId == chargeId && i.PracticeId == LoggedUser.PracticeId && i.UserName.ToLower() == "system");
            }
            catch
            {
                throw;
            }
        }
    }
}
