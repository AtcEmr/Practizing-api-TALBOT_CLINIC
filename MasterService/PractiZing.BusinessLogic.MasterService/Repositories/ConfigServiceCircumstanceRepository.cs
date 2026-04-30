using PractiZing.Base.Entities.ChargePaymentService;
using PractiZing.Base.Entities.SecurityService;
using PractiZing.Base.Repositories.ChargePaymentService;
using PractiZing.DataAccess.ChargePaymentService.Tables;
using PractiZing.DataAccess.Common;
using ServiceStack.OrmLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using PractiZing.Base.Common;
using System;
using PractiZing.Base.Entities.MasterService;
using PractiZing.DataAccess.MasterService.Tables;
using PractiZing.Base.Repositories.MasterService;
using PractiZing.DataAccess.MasterService;
using AutoMapper;

namespace PractiZing.BusinessLogic.MasterService.Repositories
{
    public class ConfigServiceCircumstanceRepository : ModuleBaseRepository<ConfigServiceCircumstance>, IConfigServiceCircumstanceRepository
    {
        private readonly IMapper _mapper;
        private ICPTModifierRepository _iCPTModifierRepository;
        public ConfigServiceCircumstanceRepository(ValidationErrorCodes errorCodes,
                                     DataBaseContext dbContext,
                                     ILoginUser loggedUser, IMapper mapper, ICPTModifierRepository iCPTModifierRepository)
                                     : base(errorCodes, dbContext, loggedUser)
        {
            this._mapper = mapper;
            this._iCPTModifierRepository = iCPTModifierRepository;
        }

        public async Task<IConfigServiceCircumstance> GetById(int id)
        {
            var query = this.Connection
                              .From<ConfigServiceCircumstance>()
                              .LeftJoin<ConfigServiceCircumstance, CPTModifier>((c, d) => c.CPTModifier_Id == d.ID)
                              .Select<ConfigServiceCircumstance, CPTModifier>((i, j) => new
                              {
                                  i,
                                  CPTModifierUId = j.UId,
                                  Modifier = j.Code
                              }).Where<ConfigServiceCircumstance>(i => i.Id == id);
            var dynamicResult = await this.Connection.SelectAsync<dynamic>(query);

            var result = _mapper.Map<ConfigServiceCircumstance>(dynamicResult);

            return result;

            //return await this.Connection.SingleAsync<ConfigServiceCircumstance>(i => i.Id == id);
        }

        public async Task<IEnumerable<IConfigServiceCircumstance>> Get()
        {
            var query = this.Connection
                              .From<ConfigServiceCircumstance>()
                              .LeftJoin<ConfigServiceCircumstance, CPTModifier>((c, d) => c.CPTModifier_Id == d.ID)
                              .Select<ConfigServiceCircumstance, CPTModifier>((i, j) => new
                              {
                                  i,
                                  CPTModifierUId = j.UId,
                                  Modifier = j.Code,
                                  
                              });
            var dynamicResult = await this.Connection.SelectAsync<dynamic>(query);

            var result = _mapper.Map<List<ConfigServiceCircumstance>>(dynamicResult);

            return result;


            //return (await this.Connection.SelectAsync<ConfigServiceCircumstance>()).OrderBy(i => i.Id);
        }

        public async Task<IConfigServiceCircumstance> AddNew(IConfigServiceCircumstance entity)
        {
            try
            {
                ConfigServiceCircumstance tEntity = entity as ConfigServiceCircumstance;
                var errors = await this.ValidateEntityToAdd(tEntity);
                if (errors.Count() > 0)
                    await this.ThrowEntityException(errors);

                var modifier = await this._iCPTModifierRepository.Get(tEntity.CPTModifierUId);
                tEntity.CPTModifier_Id = modifier.ID;

                return await base.AddNewAsync(tEntity);
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> Update(IConfigServiceCircumstance entity)
        {
            try
            {
                ConfigServiceCircumstance tEntity = entity as ConfigServiceCircumstance;

                var errors = await this.ValidateEntityToUpdate(tEntity);
                if (errors.Count() > 0)
                    await this.ThrowEntityException(errors);
                var modifier = await this._iCPTModifierRepository.Get(tEntity.CPTModifierUId);
                tEntity.CPTModifier_Id = modifier.ID;

                var updateOnlyFields = this.Connection
                                           .From<ConfigServiceCircumstance>()
                                           .Update(x => new
                                           {
                                               x.CPTModifier_Id,
                                               x.Circumstance
                                           })
                                           .Where(i => i.Id == entity.Id);

                return await base.UpdateOnlyAsync(tEntity, updateOnlyFields);
            }
            catch
            {
                throw;
            }
        }

        

        public override async Task<IEnumerable<IValidationResult>> ValidateEntityToAdd(ConfigServiceCircumstance tEntity)
        {
            List<IValidationResult> errors = new List<IValidationResult>();            

            //var iCPTModifiers = await this.Connection.SelectAsync<CPTModifier>(i => i.Code.ToLower().Trim() == tEntity.Code.ToLower().Trim());
            //var entityErrors = await base.ValidateEntity(tEntity);
            //errors.AddRange(entityErrors);
            return errors;
        }

        public override async Task<IEnumerable<IValidationResult>> ValidateEntityToUpdate(ConfigServiceCircumstance tEntity)
        {
            List<IValidationResult> errors = new List<IValidationResult>();
            return errors;
        }
    }
}
