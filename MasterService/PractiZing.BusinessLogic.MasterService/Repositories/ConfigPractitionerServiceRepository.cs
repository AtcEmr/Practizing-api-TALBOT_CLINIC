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
    public class ConfigPractitionerServiceRepository : ModuleBaseRepository<ConfigPractitionerService>, IConfigPractitionerServiceRepository
    {
        private readonly IMapper _mapper;
        private ICPTModifierRepository _iCPTModifierRepository;
        public ConfigPractitionerServiceRepository(ValidationErrorCodes errorCodes,
                                     DataBaseContext dbContext,
                                     ILoginUser loggedUser, IMapper mapper, ICPTModifierRepository iCPTModifierRepository)
                                     : base(errorCodes, dbContext, loggedUser)
        {
            this._mapper = mapper;
            this._iCPTModifierRepository = iCPTModifierRepository;
        }

        public async Task<IEnumerable<IConfigPractitionerService>> Get()
        {
            var query = this.Connection
                              .From<ConfigPractitionerService>()
                              .LeftJoin<ConfigPractitionerService, CPTModifier>((c, d) => c.CPTModifier_Id == d.ID)
                              .Select<ConfigPractitionerService, CPTModifier>((i, j) => new
                              {
                                  i,
                                  CPTModifierUId = j.UId,
                                  Modifier = j.Code                                  
                              });                              
            var dynamicResult = await this.Connection.SelectAsync<dynamic>(query);

            var result = _mapper.Map<List<ConfigPractitionerService>>(dynamicResult);
            foreach (var item in result)
            {
                if(!string.IsNullOrWhiteSpace( item.Designation))
                {
                    item.Qualification = item.ProfessionalAbbreviation + "-" + item.ProvidingService;
                }
            }
            return result;
            //return (await this.Connection.SelectAsync<ConfigPractitionerService>()).OrderBy(i => i.Id);
        }

        public async Task<IConfigPractitionerService> GetByEmrId(int emrId)
        {
            return await this.Connection.SingleAsync<ConfigPractitionerService>(i=>i.EmrId==emrId);
        }

        public async Task<IConfigPractitionerService> GetById(int id)
        {

            var query = this.Connection
                              .From<ConfigPractitionerService>()
                              .LeftJoin<ConfigPractitionerService, CPTModifier>((c, d) => c.CPTModifier_Id == d.ID)
                              .Select<ConfigPractitionerService, CPTModifier>((i, j) => new
                              {
                                  i,
                                  CPTModifierUId = j.UId,
                                  Modifier = j.Code
                              }).Where<ConfigPractitionerService>(i=>i.Id==id);
            var dynamicResult = await this.Connection.SelectAsync<dynamic>(query);

            var result = _mapper.Map<ConfigPractitionerService>(dynamicResult);

            return result;

            //return await this.Connection.SingleAsync<ConfigPractitionerService>(i => i.Id == id);
        }

        public async Task<IConfigPractitionerService> GetByQualticationId(int id)
        {
            return await this.Connection.SingleAsync<ConfigPractitionerService>(i => i.Id == id);
        }

        public async Task<IConfigPractitionerService> AddNew(IConfigPractitionerService entity)
        {
            try
            {
                ConfigPractitionerService tEntity = entity as ConfigPractitionerService;
                var errors = await this.ValidateEntityToAdd(tEntity);
                if (errors.Count() > 0)
                    await this.ThrowEntityException(errors);

                var modifier = await this._iCPTModifierRepository.Get(tEntity.CPTModifierUId);
                if(modifier!=null)
                tEntity.CPTModifier_Id = modifier.ID;

                return await base.AddNewAsync(tEntity);
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> Update(IConfigPractitionerService entity)
        {
            try
            {
                ConfigPractitionerService tEntity = entity as ConfigPractitionerService;

                var errors = await this.ValidateEntityToUpdate(tEntity);
                if (errors.Count() > 0)
                    await this.ThrowEntityException(errors);

                var modifier=await this._iCPTModifierRepository.Get(tEntity.CPTModifierUId);
                if(modifier!=null)
                tEntity.CPTModifier_Id = modifier.ID;

                var updateOnlyFields = this.Connection
                                           .From<ConfigPractitionerService>()
                                           .Update(x => new
                                           {
                                               x.CPTModifier_Id,
                                               x.ProfessionalAbbreviation,
                                               x.IsActive,
                                               x.ProvidingService,
                                               x.PractitionerModifier,
                                               x.CanBeSupervision,
                                               x.EmrId
                                           })
                                           .Where(i => i.Id == entity.Id);

                return await base.UpdateOnlyAsync(tEntity, updateOnlyFields);
            }
            catch
            {
                throw;
            }
        }

        

        public override async Task<IEnumerable<IValidationResult>> ValidateEntityToAdd(ConfigPractitionerService tEntity)
        {
            List<IValidationResult> errors = new List<IValidationResult>();            

            //var iCPTModifiers = await this.Connection.SelectAsync<CPTModifier>(i => i.Code.ToLower().Trim() == tEntity.Code.ToLower().Trim());
            //var entityErrors = await base.ValidateEntity(tEntity);
            //errors.AddRange(entityErrors);
            return errors;
        }

        public override async Task<IEnumerable<IValidationResult>> ValidateEntityToUpdate(ConfigPractitionerService tEntity)
        {
            List<IValidationResult> errors = new List<IValidationResult>();
            return errors;
        }
    }
}
