using PractiZing.Base.Repositories.DenialService;
using PractiZing.Base.Service.DenialService;
using System;
using System.Threading.Tasks;

namespace PractiZing.BusinessLogic.DenialService.Services
{
    public class ActionCategoryService : IActionCategoryService
    {
        private IActionCategoryRepository _actionCategoryRepository;
        private IActionNoteRepository _actionNoteRepository;
        public ActionCategoryService(IActionCategoryRepository actionCategoryRepository,
                                     IActionNoteRepository actionNoteRepository)
        {
            _actionCategoryRepository = actionCategoryRepository;
            _actionNoteRepository = actionNoteRepository;
        }

        public async Task<int> Delete(Guid uid)
        {
            try
            {
                //throw error if subCategory exist on this action category
                await this._actionCategoryRepository.ParentCategoryExist(uid);

                //throw error if action note exist on this action category
                await this._actionNoteRepository.ActionNoteExist(uid);

                //delete action category 
                return await this._actionCategoryRepository.Delete(uid);
            }
            catch
            {
                throw;
            }
        }
    }
}
