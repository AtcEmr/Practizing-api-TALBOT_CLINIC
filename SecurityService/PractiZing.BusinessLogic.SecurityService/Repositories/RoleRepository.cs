using PractiZing.Base.Entities.SecurityService;
using PractiZing.Base.Repositories.SecurityService;
using PractiZing.DataAccess.Common;
using PractiZing.DataAccess.SecurityService;
using PractiZing.DataAccess.SecurityService.Tables;
using ServiceStack.OrmLite;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PractiZing.BusinessLogic.SecurityService.Repositories
{
    public class RoleRepository : ModuleBaseRepository<IRole>, IRoleRepository
    {
        public RoleRepository(ValidationErrorCodes validationErrorCodes,
                                   DataBaseContext dataBaseContext,
                                   ILoginUser loginUser)
                                  : base(validationErrorCodes, dataBaseContext, loginUser)
        {
        }

        public async Task<IEnumerable<IRole>> Get()
        {
            return await this.Connection.SelectAsync<Role>();
        }        

        public async Task<IRole> Get(int id)
        {
            return await this.Connection.SingleAsync<Role>(i => i.Id == id);
        }

        public async Task<IRole> AddNew(IRole entity)
        {
            try
            {
                Role tEntity = entity as Role;
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

        public async Task<int> Update(IRole entity)
        {
            Role tEntity = entity as Role;

            var errors = await this.ValidateEntityToUpdate(tEntity);
            if (errors.Count() > 0)
                await this.ThrowEntityException(errors);

            var updateOnlyFields = this.Connection
                                       .From<Role>()
                                       .Update(x => new
                                       {
                                           x.RoleName
                                       })
                                       .Where(i => i.Id == entity.Id);

            return await this.Connection.UpdateOnlyAsync(tEntity, updateOnlyFields);
        }

        public async Task<int> Delete(int id)
        {
            return await this.Connection.DeleteAsync<Role>(i => i.Id == id);
        }
    }
}
