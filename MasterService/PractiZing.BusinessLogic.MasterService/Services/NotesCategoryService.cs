using PractiZing.Base.Common;
using PractiZing.Base.Entities.MasterService;
using PractiZing.Base.Repositories.MasterService;
using PractiZing.Base.Service.MasterService;
using System;
using System.Threading.Tasks;

namespace PractiZing.BusinessLogic.MasterService.Services
{
    public class NotesCategoryService : INotesCategoryService
    {
        private readonly INotesCategoryRepository _notesCategoryRepository;
        public readonly IARSCategoryReasonCodeRepository _aRSCategoryReasonCodeRepository;
        private readonly ITransactionProvider _transactionProvider;

        public NotesCategoryService(INotesCategoryRepository notesCategoryRepository,
                                    IARSCategoryReasonCodeRepository aRSCategoryReasonCodeRepository, 
                                    ITransactionProvider transactionProvider)
        {

            this._notesCategoryRepository = notesCategoryRepository;
            this._aRSCategoryReasonCodeRepository = aRSCategoryReasonCodeRepository;
            this._transactionProvider = transactionProvider;
        }

        /// <summary>
        /// Add ARSCategoryReasonCode while adding NotesCategory
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<INotesCategory> AddNotesCategory(INotesCategory entity)
        {
            string transactionId = this._transactionProvider.StartTransaction(true);
            try
            {
                var result = await this._notesCategoryRepository.AddNew(entity);

                await this._aRSCategoryReasonCodeRepository.AddEntities(entity.aRSCategoryReasonCodes, result.ID);
                this._transactionProvider.CommitTransaction(transactionId);
                return result;

            }
            catch 
            {
                this._transactionProvider.RollbackTransaction(transactionId);
                throw;
            }
        }

        public async Task<bool> UpdateNotesCategory(INotesCategory entity)
        {
            string transactionId = this._transactionProvider.StartTransaction(true);
            try
            {
                await this._notesCategoryRepository.Update(entity);
                await this._aRSCategoryReasonCodeRepository.UpdateEntities(entity.aRSCategoryReasonCodes, entity.ID);
                this._transactionProvider.CommitTransaction(transactionId);
                return true;
            }
            catch (Exception ex)
            {
                this._transactionProvider.RollbackTransaction(transactionId);
                throw;
            }
        }
    }
}
