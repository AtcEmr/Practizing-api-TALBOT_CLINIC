using PractiZing.Base.Entities.ChargePaymentService;
using PractiZing.Base.Entities.SecurityService;
using PractiZing.Base.Repositories.ChargePaymentService;
using PractiZing.DataAccess.ChargePaymentService;
using PractiZing.DataAccess.ChargePaymentService.Tables;
using PractiZing.DataAccess.Common;
using ServiceStack.OrmLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using PractiZing.Base.Common;
using System;
using PractiZing.DataAccess.MasterService.Tables;
using AutoMapper;

namespace PractiZing.BusinessLogic.ChargePaymentService.Repositories
{
    public class CPTModifierRepository : ModuleBaseRepository<CPTModifier>, ICPTModifierRepository
    {
        private readonly IMapper _mapper;
        public CPTModifierRepository(ValidationErrorCodes errorCodes,
                                     DataBaseContext dbContext,
                                     ILoginUser loggedUser, IMapper mapper)
                                     : base(errorCodes, dbContext, loggedUser)
        {
            this._mapper = mapper;
        }

        public async Task<IEnumerable<ICPTModifier>> Get()
        {
            //var query = this.Connection
            //                  .From<CPTModifier>()
            //                  .LeftJoin<CPTModifier, ConfigServiceCircumstance>((c, d) => c.ID == d.CPTModifier_Id)
            //                  .Select<CPTModifier, ConfigServiceCircumstance>((i, j) => new
            //                  {
            //                      i,
            //                      CircumstanceModifierId=j.CPTModifier_Id
            //                  });
            //var dynamicResult = await this.Connection.SelectAsync<dynamic>(query);

            //var result = _mapper.Map<List<CPTModifier>>(dynamicResult);
            //if(result!=null)
            //{
            //    foreach (var item in result)
            //    {
            //        if(item.CircumstanceModifierId>0)
            //        {
            //            item.IsServiceCircumstance = true;
            //        }
            //    }
            //}

            //return result.OrderBy(i=>i.Code);

            return (await this.Connection.SelectAsync<CPTModifier>()).OrderBy(i => i.Code);
        }

        public async Task<ICPTModifier> Get(Guid uid)
        {
            return await this.Connection.SingleAsync<CPTModifier>(i => i.UId == uid);
        }

        public async Task<ICPTModifier> GetByCode(string code)
        {
            return await this.Connection.SingleAsync<CPTModifier>(i => i.Code == code);
        }

        public async Task<ICPTModifier> AddNew(ICPTModifier entity)
        {
            try
            {
                CPTModifier tEntity = entity as CPTModifier;
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

        public async Task<int> Update(ICPTModifier entity)
        {
            try
            {
                CPTModifier tEntity = entity as CPTModifier;

                var errors = await this.ValidateEntityToUpdate(tEntity);
                if (errors.Count() > 0)
                    await this.ThrowEntityException(errors);

                var updateOnlyFields = this.Connection
                                           .From<CPTModifier>()
                                           .Update(x => new
                                           {
                                               x.Code,
                                               x.Description,
                                               x.IsActive
                                           })
                                           .Where(i => i.UId == entity.UId);

                return await base.UpdateOnlyAsync(tEntity, updateOnlyFields);
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> Delete(Guid uId)
        {
            try
            {
                return await this.Connection.DeleteAsync<CPTModifier>(i => i.UId == uId);
            }
            catch
            {
                throw;
            }
        }

        public override async Task<IEnumerable<IValidationResult>> ValidateEntityToAdd(CPTModifier tEntity)
        {
            List<IValidationResult> errors = new List<IValidationResult>();
            CheckForNull(tEntity, ref errors);

            var iCPTModifiers = await this.Connection.SelectAsync<CPTModifier>(i => i.Code.ToLower().Trim() == tEntity.Code.ToLower().Trim());

            if (iCPTModifiers.Count() > 0)
                errors.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.CodeAlreadyExists]));

            var entityErrors = await base.ValidateEntity(tEntity);
            errors.AddRange(entityErrors);

            return errors;
        }

        public override async Task<IEnumerable<IValidationResult>> ValidateEntityToUpdate(CPTModifier tEntity)
        {
            List<IValidationResult> errors = new List<IValidationResult>();

            CheckForNull(tEntity, ref errors);

            var Codes = await this.Connection.SelectAsync<CPTModifier>(i => i.Code.ToLower().Trim() == tEntity.Code.ToLower().Trim()
                                                                          && i.ID != tEntity.ID);

            if (Codes.Count() > 0)
                errors.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.CodeAlreadyExists]));

            var entityErrors = await base.ValidateEntity(tEntity);
            errors.AddRange(entityErrors);

            return errors;
        }

        private void CheckForNull(CPTModifier tEntity, ref List<IValidationResult> errors)
        {
            if (string.IsNullOrEmpty(tEntity.Code))
                errors.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.CodeCannotBeNullOrEmpty]));

            if (string.IsNullOrEmpty(tEntity.Description))
                errors.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.DescriptionCannotBeNullOrEmpty]));
        }
    }
}
