using PractiZing.Base.Entities.MasterService;
using PractiZing.Base.Entities.SecurityService;
using PractiZing.Base.Repositories.MasterService;
using PractiZing.DataAccess.Common;
using PractiZing.DataAccess.MasterService;
using PractiZing.DataAccess.MasterService.Tables;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using PractiZing.BusinessLogic.Common;
using PractiZing.Base.Common;

namespace PractiZing.BusinessLogic.MasterService.Repositories
{
    public class FacilityIdentityRepository : ModuleBaseRepository<FacilityIdentity>, IFacilityIdentityRepository
    {
        private readonly IConfigIdTypeRepository _configIdTypeRepository;
        private readonly IFacilityRepository _facilityRepository;
        public FacilityIdentityRepository(ValidationErrorCodes errorCodes, DataBaseContext dbContext, ILoginUser loggedUser, IConfigIdTypeRepository configIdTypeRepository, IFacilityRepository facilityRepository)
        : base(errorCodes, dbContext, loggedUser)
        {
            _configIdTypeRepository = configIdTypeRepository;
            _facilityRepository = facilityRepository;
        }

        public async Task<IFacilityIdentity> GetDefaultFacilitySUDNPI()
        {
            var query = this.Connection.From<FacilityIdentity>().
                Join<FacilityIdentity, Facility>((i, j) => i.FacilityId == j.Id)
                .Select<FacilityIdentity>(x => new
                {
                    x
                })
                .Where<Facility>(i=>i.IsDefault==true);
            var dynamicResult = await this.Connection.SelectAsync<dynamic>(query);
            var result = Mapper<FacilityIdentity>.Map(dynamicResult);
            return result;
        }

        /// <summary>
        /// Get Identifiers for given facilityId and typeId
        /// </summary>
        /// <param name="facilityId"></param>
        /// <param name="typeId"></param>
        /// <returns></returns>
        public async Task<IFacilityIdentity> GetIdentity(int facilityId, int? typeId)
        {
            try
            {
                //typeId = 1;
                var query = this.Connection.From<FacilityIdentity>()
                      .Join<FacilityIdentity, ConfigIdType>((f, c) => f.TypeId == c.Id)
                       .Select<FacilityIdentity, ConfigIdType>((f, c) => new
                       {
                           Prefix = c.Prefix,
                           f
                       }).Where<FacilityIdentity>(i => i.FacilityId == facilityId && i.TypeId == typeId);

                var dynamicResult = await this.Connection.SelectAsync<dynamic>(query);

                var result = Mapper<FacilityIdentity>.Map(dynamicResult);

                /*if facility identity does not exist for given typeId then it will give an exception,
                'Identifier does not exist'*/
                if (result == null && typeId != 0)
                    await FacilityIdentityDoesNotExist(typeId);

                return result;
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<IFacilityIdentity>> GetIdentifier(string Identifier)
        {
            return await this.Connection.SelectAsync<FacilityIdentity>(i => i.Identifier == Identifier);
        }

        public async Task<IEnumerable<IFacilityIdentity>> GetFacilityIdentifiersByFacilityId(int facilityId)
        {
            return await this.Connection.SelectAsync<FacilityIdentity>(i => i.FacilityId == facilityId);
        }

        public async Task<int> GetFacilityBasedOnNPI(string npi)
        {
            var item=await this.Connection.SingleAsync<FacilityIdentity>(i => i.Identifier == npi && i.TypeId==1);
            return item != null ? item.FacilityId : 0;

        }

        public async Task<IFacilityIdentity> GetById(short id)
        {
            return await this.Connection.SingleAsync<FacilityIdentity>(i => i.Id == id);
        }

        public async Task<IFacilityIdentity> GetByUId(Guid uid)
        {
            var query = this.Connection.From<FacilityIdentity>()
                             .LeftJoin<FacilityIdentity, Facility>((c, f) => c.FacilityId == f.Id)
                             .Select<FacilityIdentity, Facility>((i, j) => new
                             {
                                 i,
                                 FacilityUId = j.UId
                             }).Where(i => i.UId == uid)
                             .OrderBy<ConfigIdType>(i => i.Name);

            var _facilityIdentity = await this.Connection.SelectAsync<dynamic>(query);
            return (Mapper<FacilityIdentity>.Map(_facilityIdentity));
            //return await this.Connection.SingleAsync<FacilityIdentity>(i => i.UId == UId);
        }

        /// <summary>
        /// Get FacilityIdentity by facilityUId
        /// </summary>
        /// <param name="facilityUId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<IFacilityIdentity>> GetByFacility(Guid facilityUId)
        {
            var _facility = await this.Connection.SingleAsync<Facility>(i => i.UId == facilityUId);
            _facility.Id = _facility == null ? (short)0 : _facility.Id;
            var query = this.Connection.From<FacilityIdentity>()
                             .LeftJoin<FacilityIdentity, ConfigIdType>((i, j) => i.TypeId == j.Id)
                             .LeftJoin<FacilityIdentity, Facility>((c, f) => c.FacilityId == f.Id)
                             .Select<FacilityIdentity, Facility>((i, j) => new
                             {
                                 i,
                                 FacilityUId = j.UId
                             }).Where(i => i.FacilityId == _facility.Id)
                             .OrderBy<ConfigIdType>(i => i.Name);

            var _facilityIdentity = await this.Connection.SelectAsync<dynamic>(query);
            return (Mapper<FacilityIdentity>.MapList(_facilityIdentity));
        }

        /*Multiple DML queries applied , FacilityIdentity can be added or updated*/
        public async Task<int> AddOrUpdate(IEnumerable<IFacilityIdentity> entities)
        {
            try
            {
                var updateData = entities.Where(i => i.Id != 0);
                var addData = entities.Where(i => i.Id == 0);

                foreach (var item in updateData)
                    await this.UpdateEntityData(item);

                foreach (var item in addData)
                    await this.AddNew(item);

                return 1;
            }
            catch
            {
                throw;
            }
        }

        public async Task<IFacilityIdentity> AddNew(IFacilityIdentity entity)
        {
            try
            {
                FacilityIdentity tEntity = entity as FacilityIdentity;

                var facility = await this._facilityRepository.GetByUId(entity.FacilityUId);
                tEntity.FacilityId = facility.Id;

                var errors = await this.ValidateEntityToAdd(tEntity);
                if (errors.Count() > 0)
                    await this.ThrowEntityException(errors);
                var result = await base.AddNewAsync(tEntity);
                return result;

            }
            catch
            {
                throw;
            }
        }

        public async Task<long> UpdateEntityData(IFacilityIdentity entity)
        {
            try
            {
                FacilityIdentity tEntity = entity as FacilityIdentity;

                var facility = await this._facilityRepository.GetByUId(entity.FacilityUId);
                tEntity.FacilityId = facility.Id;

                tEntity.ModifiedDate = DateTime.Now;
                var errors = await this.ValidateEntityToUpdate(tEntity);
                if (errors.Count() > 0)
                    await this.ThrowEntityException(errors);

                var query = this.Connection.From<FacilityIdentity>()
                                                .Update(i => new
                                                {
                                                    i.TypeId,
                                                    i.Identifier,
                                                    i.ActiveDate,
                                                    i.InactiveDate,
                                                    i.ModifiedBy,
                                                    i.ModifiedDate

                                                }).Where<FacilityIdentity>(i => i.UId == entity.UId /*&& i.TypeId == entity.OldTypeID*/);
                var result = await this.Connection.UpdateOnlyAsync<FacilityIdentity>(tEntity, query);
                return result;
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> Delete(Guid uid)
        {
            return await this.Connection.DeleteAsync<FacilityIdentity>(i => i.UId == uid);
        }

        public async Task<int> DeleteByFacilityId(int facilityId)
        {
            var list = await this.Connection.SelectAsync<FacilityIdentity>(i => i.FacilityId == facilityId);

            foreach (var item in list)
            {
                 await this.Connection.DeleteAsync<FacilityIdentity>(i => i.UId == item.UId);
            }
            return 1;
        }

        private async Task FacilityIdentityDoesNotExist(int? typeId)
        {
            List<IValidationResult> errors = new List<IValidationResult>();

            var configIdType = await this._configIdTypeRepository.GetById(Convert.ToInt16(typeId));

            errors.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.FacilityDoesnotHaveIdentity], configIdType.Name));

            await this.ThrowEntityException(errors);
        }

        public override async Task<IEnumerable<IValidationResult>> ValidateEntityToAdd(FacilityIdentity tEntity)
        {
            List<IValidationResult> errors = new List<IValidationResult>();

            /*only unique TypeId can be exist for single facility*/
            var _facilityIdentity = await this.Connection.SelectAsync<FacilityIdentity>(i => i.TypeId == tEntity.TypeId && i.FacilityId == tEntity.FacilityId);
            if (_facilityIdentity.Count() > 0)
                errors.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.IdentityAlreadyExist]));

            var entityErrors = await base.ValidateEntity(tEntity);
            errors.AddRange(entityErrors);

            return errors;
        }

        public override async Task<IEnumerable<IValidationResult>> ValidateEntityToUpdate(FacilityIdentity tEntity)
        {
            List<IValidationResult> errors = new List<IValidationResult>();

            /*only unique TypeId can be exist for single facility*/
            var _facilityIdentity = await this.Connection.SelectAsync<FacilityIdentity>(i => i.TypeId == tEntity.TypeId && i.Id != tEntity.Id
                                                                                          && i.FacilityId == tEntity.FacilityId);
            if (_facilityIdentity.Count() > 0)
                errors.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.IdentityAlreadyExist]));

            var entityErrors = await base.ValidateEntity(tEntity);
            errors.AddRange(entityErrors);

            return errors;
        }
    }
}
