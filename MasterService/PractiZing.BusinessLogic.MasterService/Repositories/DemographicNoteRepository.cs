using PractiZing.Base.Common;
using PractiZing.Base.Entities.MasterService;
using PractiZing.Base.Entities.SecurityService;
using PractiZing.Base.Repositories.MasterService;
using PractiZing.DataAccess.Common;
using PractiZing.DataAccess.MasterService;
using PractiZing.DataAccess.MasterService.Tables;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using ServiceStack.OrmLite;

namespace PractiZing.BusinessLogic.MasterService.Repositories
{
    public class DemographicNoteRepository : ModuleBaseRepository<DemographicNote>, IDemographicNoteRepository
    {
        private readonly ITransactionProvider _transactionProvider;
        public DemographicNoteRepository(ValidationErrorCodes errorCodes,
                                           DataBaseContext dbContext,
                                           ILoginUser loggedUser,
                                           ITransactionProvider transactionProvider
                                           ) : base(errorCodes, dbContext, loggedUser)
        {
            this._transactionProvider = transactionProvider;
        }

        public async Task<IEnumerable<IDemographicNote>> GetAll()
        {
            return (await this.Connection.SelectAsync<DemographicNote>(i => i.PracticeId == LoggedUser.PracticeId)).OrderBy(i => i.Note);
        }

        public async Task<IDemographicNote> GetById(int id)
        {
            return await this.Connection.SingleAsync<DemographicNote>(i => i.Id == id && i.PracticeId == LoggedUser.PracticeId);
        }

        public async Task<IDemographicNote> GetByUId(Guid uid)
        {
            return await this.Connection.SingleAsync<DemographicNote>(i => i.UId == uid && i.PracticeId == LoggedUser.PracticeId);
        }

        public async Task<IDemographicNote> GetByChargeNumber(long chargeNumber)
        {
            return await this.Connection.SingleAsync<DemographicNote>(i => i.ChargeNumber == chargeNumber && i.PracticeId == LoggedUser.PracticeId);
        }

        public async Task<IDemographicNote> AddNew(IDemographicNote entity)
        {
            try
            {
                DemographicNote tEntity = entity as DemographicNote;

                var errors = await this.ValidateEntityToAdd(tEntity);
                if (errors.Count() > 0)
                    await this.ThrowEntityException(errors);

                tEntity.ResponseBy = string.IsNullOrEmpty(tEntity.ResponseBy) ? LoggedUser.UserName : tEntity.ResponseBy;

                tEntity.NoteBy = tEntity.IsAddNote = true ? false : true;

                if (!tEntity.IsAddNote)
                {
                    tEntity.HasFollowUp = null;
                    tEntity.FollowUpDate = null;
                }

                tEntity.NoteID += await this.GetMaxID(entity.PatientId, (long)entity.ChargeNumber);

                return await base.AddNewAsync(tEntity);
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> Update(IDemographicNote entity)
        {
            try
            {
                DemographicNote tEntity = entity as DemographicNote;

                var errors = await this.ValidateEntityToUpdate(tEntity);

                if (errors.Count() > 0)
                    await this.ThrowEntityException(errors);

                var updateOnlyFields = this.Connection
                                       .From<DemographicNote>()
                                       .Update(x => new
                                       {
                                           x.DemographicNoteId,
                                           x.NoteID,
                                           x.Note,
                                           x.Dos,
                                           x.NoteTypeId,
                                           x.AttachedFile,
                                           x.IsBilling,
                                           x.TransactionID,
                                           x.CategoryID,
                                           x.HasFollowUp,
                                           x.FollowUpDate,
                                           x.NoteBy,
                                           x.ResponseBy,
                                           x.SubCategoryID,
                                           x.ChargeNumber,
                                           x.PatientId
                                       })
                                       .Where(i => i.UId == entity.UId && i.PracticeId == LoggedUser.PracticeId);

                var value = await base.UpdateOnlyAsync(tEntity, updateOnlyFields);
                return value;
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> Delete(Guid uid)
        {
            try
            {
                return await this.Connection.DeleteAsync<DemographicNote>(i => i.UId == uid && i.PracticeId == LoggedUser.PracticeId);
            }
            catch
            {
                throw;
            }
        }

        private async Task<int> GetMaxID(int patientId, long chgNo)
        {

            int noteId = 0;
            var result = (await this.Connection.SelectAsync<DemographicNote>(i => i.PracticeId == LoggedUser.PracticeId
            && i.PatientId == patientId && i.ChargeNumber == chgNo));
            if (result.Count() > 0)
                noteId = result.Max<DemographicNote>(i => i.NoteID);

            return noteId;
        }

        //public async Task<IDemographicNote> AddNew(IDemographicNote entity)
        //{
        //    try
        //    {
        //        DemographicNote tEntity = entity as DemographicNote;
        //        DenialQueue denialQueue = new DenialQueue();

        //        var errors = await this.ValidateEntityToAdd(tEntity);
        //        if (errors.Count() > 0)
        //        {
        //            await this.ThrowEntityException(errors);
        //        }

        //        tEntity.NoteID += await this.GetMaxID(entity.PatientId, (long)entity.ChargeNumber);

        //        tEntity.ResponseBy = string.IsNullOrEmpty(tEntity.ResponseBy) ? LoggedUser.UserName : tEntity.ResponseBy;

        //        if (tEntity.NoteBy == true)
        //        {
        //            var responseBy = this.Connection
        //                            .From<DemographicNote>()
        //                            .Join<DemographicNote, NotesCategory>((dm, nc) => dm.CategoryID == nc.ID)
        //                            .Select<DemographicNote, NotesCategory>((dm, nc) => new
        //                            {
        //                                ResponseByName = nc.ResponseBy.Max<>()
        //                            })
        //                             .OrderByDescending(dm => dm.NoteID)
        //                            .Where<DemographicNote>(i => i.ChargeNumber == tEntity.ChargeNumber
        //                            && i.NoteBy == false && i.PatientId == tEntity.PatientId);
        //        }

        //        tEntity.ResponseBy = string.IsNullOrEmpty(tEntity.ResponseBy) ? LoggedUser.UserName : tEntity.ResponseBy;

        //        return await base.AddNewAsync(tEntity);
        //        if (tEntity.NoteTypeId == 1 || tEntity.NoteTypeId == 2)
        //        {
        //            if (denialQueue.Id != 0)
        //            {
        //                var denialQueueId = (await this.Connection.SelectAsync<IDenialQueue>(i => i.TransactionId == tEntity.ChargeNumber)).Select(i => i.Id);

        //                if (tEntity.HasFollowUp == true && denialQueue.TransactionId == tEntity.ChargeNumber)
        //                {
        //                    denialQueue.LastFollowUpNoteId = tEntity.Id;

        //                    denialQueue.IsFollowing = tEntity.HasFollowUp;
        //                }
        //                denialQueue.LastNoteId = tEntity.Id;
        //            }
        //            else
        //            {
        //                denialQueue = null;
        //                denialQueue.TransactionId = Convert.ToInt32(tEntity.ChargeNumber);
        //                if (tEntity.HasFollowUp == true)
        //                    denialQueue.LastFollowUpNoteId = tEntity.Id;
        //                denialQueue.LastNoteId = tEntity.Id;
        //            }

        //        }
        //        
        //    }
        //    catch (Exception ex)
        //    {
        //        this._transactionProvider.RollbackTransaction();

        //        throw;
        //    }
        //}
    }
}

