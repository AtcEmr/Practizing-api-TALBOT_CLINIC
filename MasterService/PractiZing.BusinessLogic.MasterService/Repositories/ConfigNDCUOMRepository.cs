using PractiZing.Base.Common;
using PractiZing.Base.Entities.MasterService;
using PractiZing.Base.Entities.SecurityService;
using PractiZing.Base.Repositories.MasterService;
using PractiZing.DataAccess.Common;
using PractiZing.DataAccess.MasterService;
using PractiZing.DataAccess.MasterService.Tables;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace PractiZing.BusinessLogic.MasterService.Repositories
{
    public class ConfigNDCUOMRepository : ModuleBaseRepository<ConfigNDCUOM>, IConfigNDCUOMRepository

    {
        public ConfigNDCUOMRepository(ValidationErrorCodes errorCodes,
                                           DataBaseContext dbContext,
                                           ILoginUser loggedUser
                                           ) : base(errorCodes, dbContext, loggedUser)
        {

        }
        public async Task<IConfigNDCUOM> AddNew(IConfigNDCUOM entity)
        {
            try
            {
                ConfigNDCUOM tEntity = entity as ConfigNDCUOM;
                var errors = await this.ValidateEntityToAdd(tEntity);
                if (errors.Count() > 0)
                {
                    await this.ThrowEntityException(errors);
                }

                return await base.AddNewAsync(tEntity);

            }
            catch
            {
                throw;
            }
        }

        public override async Task<IEnumerable<IValidationResult>> ValidateEntityToAdd(ConfigNDCUOM tEntity)
        {
            List<IValidationResult> errors = new List<IValidationResult>();

            var result = await this.Connection.SingleAsync<ConfigNDCUOM>(i => i.Code.ToLower().Trim() == tEntity.Code.ToLower().Trim());

            if (result != null)
                errors.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.CodeAlreadyExists]));

            var entityErrors = await base.ValidateEntity(tEntity);
            errors.AddRange(entityErrors);

            return errors;
        }


        public async Task<int> Update(IConfigNDCUOM entity)
        {
            try
            {
                ConfigNDCUOM tEntity = entity as ConfigNDCUOM;

                var errors = await this.ValidateEntityToUpdate(tEntity);

                if (errors.Count() > 0)
                {
                    await this.ThrowEntityException(errors);
                }

                var updateOnlyFields = this.Connection
                                           .From<ConfigNDCUOM>()
                                           .Update(x => new
                                           {
                                               x.Code,

                                               x.Description
                                           }).Where<ConfigNDCUOM>(i => i.Id == entity.Id);

                var value = await base.UpdateOnlyAsync(tEntity, updateOnlyFields);
                return value;
            }
            catch
            {
                throw;
            }
        }

        public override async Task<IEnumerable<IValidationResult>> ValidateEntityToUpdate(ConfigNDCUOM tEntity)
        {
            List<IValidationResult> errors = new List<IValidationResult>();

            var entityErrors = await base.ValidateEntity(tEntity);
            errors.AddRange(entityErrors);

            return errors;
        }

        public async Task<int> Delete(Int16 id)
        {
            try
            {
                return await this.Connection.DeleteAsync<ConfigNDCUOM>(i => i.Id == id);

            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<IConfigNDCUOM>> GetConfigNDCUOMCodes()
        {
            return (await this.Connection.SelectAsync<ConfigNDCUOM>(i => i.IsActive == true)).OrderBy(i => i.Code);

        }
    }
}
