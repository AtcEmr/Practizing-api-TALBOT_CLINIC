using PractiZing.Base.Common;
using PractiZing.Base.Entities.SecurityService;
using PractiZing.BusinessLogic.Common;
using PractiZing.DataAccess.ChargePaymentService;
using PractiZing.DataAccess.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PractiZing.BusinessLogic.ChargePaymentService
{
    //public class ModuleBaseRepository : BaseRepository
    //{
    //    public ModuleBaseRepository(DataBaseContext dbContext) : base(dbContext)
    //    {

    //    }
    //}
    public class ModuleBaseRepository<T> : BaseRepository<T> where T : class
    {
        public ModuleBaseRepository(ValidationErrorCodes errorCodes,
            DataBaseContext dbContext,
            ILoginUser loggedUser
            )
            : base(errorCodes, dbContext, loggedUser)
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
            return await this.ValidateEntity(entity);
        }

        public override async Task<IEnumerable<IValidationResult>> ValidateEntity(T entity)
        {
             return await base.ValidateEntity(entity);
        }
    }
}
