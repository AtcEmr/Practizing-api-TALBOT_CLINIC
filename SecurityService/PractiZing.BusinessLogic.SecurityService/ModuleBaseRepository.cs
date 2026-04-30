using PractiZing.Base.Common;
using PractiZing.Base.Entities.SecurityService;
using PractiZing.BusinessLogic.Common;
using PractiZing.DataAccess.Common;
using PractiZing.DataAccess.SecurityService;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PractiZing.BusinessLogic.SecurityService
{
    //public class ModuleBaseRepository : BaseRepository
    //{
    //    public ModuleBaseRepository(ValidationCodeResult validationCodeResult,DataBaseContext dbContext) : base(dbContext)
    //    {

    //    }
    //}
    public class ModuleBaseRepository<T> : BaseRepository<T> where T : class
    {
        public ModuleBaseRepository(BaseValidationErrorCodes validationErrorCodes, 
            DataBaseContext dbContext,
            ILoginUser loggedUser
            )
            : base(validationErrorCodes, dbContext, loggedUser)
        {

        }

        public new ValidationErrorCodes ErrorCodes
        {
            get
            {
                return base.ErrorCodes as ValidationErrorCodes;
            }
        }

        public override async Task<IEnumerable<IValidationResult>> ValidateEntityToAdd(T entity)
        {
            return await this.ValidateEntity(entity);
        }

        public override async Task<IEnumerable<IValidationResult>> ValidateEntityToUpdate(T entity)
        {
          return  await this.ValidateEntity(entity);
        }

        public override async Task<IEnumerable<IValidationResult>> ValidateEntity(T entity)
        {
             return await base.ValidateEntity(entity);
        }
    }
}
