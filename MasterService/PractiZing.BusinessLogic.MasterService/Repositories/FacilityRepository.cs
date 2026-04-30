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
    public class FacilityRepository : ModuleBaseRepository<Facility>, IFacilityRepository
    {
        private readonly DefaultSettings _settings;
        public FacilityRepository(ValidationErrorCodes errorCodes,
                                  DataBaseContext dbContext,
                                  ILoginUser loggedUser,
                                  MyConfiguration configuration)
        : base(errorCodes, dbContext, loggedUser)
        {
            this._settings = configuration.settings.DefaultSettings;
        }

        /// <summary>
        /// Get Facility with it's POS
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<IFacility>> GetAll()
        {
            var query = this.Connection.From<Facility>()
                    .LeftJoin<Facility, ConfigPOS>((i, j) => i.POSCode == j.Code)
                    .Select<Facility, ConfigPOS>((i, j) => new
                    {
                        i,
                        POSCodeDesc = j.Description
                    })
                    .Where((i) => i.PracticeId == LoggedUser.PracticeId)
                    .OrderBy(i => i.Name);

            var dynamicResult = await this.Connection.SelectAsync<dynamic>(query);

            return Mapper<Facility>.MapList(dynamicResult);
        }

        public async Task<IFacility> GetById(short id)
        {
            return await this.Connection.SingleAsync<Facility>(i => i.Id == id && i.PracticeId == LoggedUser.PracticeId);
        }

        public async Task<IFacility> GetByCode(string code,bool isMH)
        {
            return await this.Connection.SingleAsync<Facility>(i => i.FacilityCode == code && i.IsMentalFacility==isMH && i.PracticeId == LoggedUser.PracticeId);
        }

        public async Task<IFacility> GetByUId(Guid uid)
        {
            var result = await this.Connection.SingleAsync<Facility>(i => i.UId == uid && i.PracticeId == LoggedUser.PracticeId);
            return result;
        }

        public async Task<IEnumerable<IFacility>> GetByUId(IEnumerable<Guid> Ids)
        {
            return await this.Connection.SelectAsync<Facility>(i => Ids.Contains(i.UId) && i.PracticeId == LoggedUser.PracticeId);
        }

        public async Task<IFacility> GetFacilityByName(string name)
        {
            return await this.Connection.SingleAsync<Facility>(i => i.Name == name && i.PracticeId == LoggedUser.PracticeId);
        }

        public async Task<IFacility> GetFacilityByNPI(string npi)
        {
            var item =await this.Connection.SingleAsync<FacilityIdentity>(i => i.TypeId==1 && i.Identifier==npi);
            if (item != null)
                return await this.Connection.SingleAsync<Facility>(i => i.Id==item.FacilityId && i.PracticeId == LoggedUser.PracticeId);
            else
                return null;
        }

        public async Task<IFacility> GetFacilityByNPIAndCode(string npi, string facilityCode)
        {
            var itemlist = await this.Connection.SelectAsync<FacilityIdentity>(i => i.TypeId == 1 && i.Identifier == npi);
            IFacility facility = null;
            foreach (var item in itemlist)
            {
                facility = await this.Connection.SingleAsync<Facility>(i => i.Id == item.FacilityId && i.FacilityCode == facilityCode && i.PracticeId == LoggedUser.PracticeId);
                if(facility!=null)
                {                    
                    break;
                }
            }
            return facility;
        }

        public async Task<string> GetFacilityNPIByICDClassification(int classificationType)
        {
            IFacility facility;
            if(classificationType==1)
            {
                facility = await this.Connection.SingleAsync<Facility>(i => i.IsMentalDefault == true);
            }
            else
            {
                facility = await this.Connection.SingleAsync<Facility>(i => i.IsDefault == true);
            }

            var facilityNPI = await this.Connection.SingleAsync<FacilityIdentity>(i => i.TypeId == 1 && i.FacilityId==facility.Id);
            return facilityNPI.Identifier;            
        }


        public async Task<IEnumerable<IFacility>> GetAllActiveFacility()
        {
            return (await this.Connection.SelectAsync<Facility>(i => i.PracticeId == LoggedUser.PracticeId && i.IsActive == true)).OrderBy(i => i.Name);
        }

        public async Task<IEnumerable<IFacility>> GetParentActiveFacility()
        {
            return (await this.Connection.SelectAsync<Facility>(i => i.PracticeId == LoggedUser.PracticeId && i.IsActive == true && i.IsMentalDefault==true || i.IsDefault==true)).OrderBy(i => i.Name);
        }


        private async Task DefaultFacility()
        {

            var _facility = await this.GetDefaultFacility();

            if (_facility != null)
            {
                _facility.IsDefault = false;
                var updateOnlyFields = this.Connection
                                   .From<Facility>()
                                   .Update(x => new
                                   {
                                       x.IsDefault
                                   })
                                   .Where(i => i.UId == _facility.UId && i.PracticeId == LoggedUser.PracticeId);

                Facility tEntity = _facility as Facility;
                await base.UpdateOnlyAsync(tEntity, updateOnlyFields);
            }
        }

        private async Task DefaultMentalFacility()
        {

            var _facility = await this.GetMentalDefaultFacility();

            if (_facility != null)
            {
                _facility.IsDefault = false;
                var updateOnlyFields = this.Connection
                                   .From<Facility>()
                                   .Update(x => new
                                   {
                                       x.IsMentalDefault
                                   })
                                   .Where(i => i.UId == _facility.UId && i.PracticeId == LoggedUser.PracticeId);

                Facility tEntity = _facility as Facility;
                await base.UpdateOnlyAsync(tEntity, updateOnlyFields);
            }
        }

        public async Task<IFacility> GetDefaultFacility()
        {
            return await this.Connection.SingleAsync<Facility>(i => i.IsDefault == true && i.PracticeId == LoggedUser.PracticeId);
        }

        public async Task<IFacility> GetByEmrId(int id)
        {
            return await this.Connection.SingleAsync<Facility>(i => i.EMRFacilityId == id && i.PracticeId == LoggedUser.PracticeId);
        }

        public async Task<IFacility> GetByEmrIdWithMH(int id,bool isMH)
        {
            return await this.Connection.SingleAsync<Facility>(i => i.EMRFacilityId == id && i.IsMentalFacility== isMH && i.PracticeId == LoggedUser.PracticeId);
        }

        public async Task<IFacility> GetMentalDefaultFacility()
        {
            return await this.Connection.SingleAsync<Facility>(i => i.IsMentalDefault == true && i.PracticeId == LoggedUser.PracticeId);
        }


        public async Task<IFacility> AddNew(IFacility entity)
        {
            try
            {
                Facility tEntity = entity as Facility;

                tEntity.TimeZone = this._settings.TimeZone;
                tEntity.Fax = tEntity.LocationCode = string.Empty;
                tEntity.ServiceTypeCode = this._settings.ServiceTypeCode;

                /*Check if user wants to make this facility as Default Facility.
                in that case first check,if there is already an existing default facility. if yes, then make previous default facility to Non Default facility
                then make the given facility as default facility.*/
                if (tEntity.IsDefault == true)
                    await this.DefaultFacility();

                if (tEntity.IsMentalDefault == true)
                    await this.DefaultMentalFacility();

                var errors = await this.ValidateEntityToAdd(tEntity);
                if (errors.Count() > 0)
                    await this.ThrowEntityException(errors);

                return  await base.AddNewAsync(tEntity);
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> Update(IFacility entity)
        {
            Facility tEntity = entity as Facility;

            /*Check if user wants to make this facility as Default Facility.
                in that case first check,if there is already an existing default facility. if yes, then make previous default facility to Non Default facility
                then make the given facility as default facility.*/
            if (tEntity.IsDefault == true)
                await this.DefaultFacility();

            if (tEntity.IsMentalDefault == true)
                await this.DefaultMentalFacility();

            var errors = await this.ValidateEntityToUpdate(tEntity);
            if (errors.Count() > 0)
                await this.ThrowEntityException(errors);

            var updateOnlyFields = this.Connection
                                   .From<Facility>()
                                   .Update(x => new
                                   {
                                       x.Name,
                                       x.Address1,
                                       x.Address2,
                                       x.city,
                                       x.state,
                                       x.ZipCode,
                                       x.Phone,
                                       x.FacilityCode,
                                       x.FacilityDescription,
                                       x.Fax,
                                       x.POSCode,
                                       x.LocationCode,
                                       x.TimeZone,
                                       x.ServiceTypeCode,
                                       x.ContactName,
                                       x.FacilitySubTypeId,
                                       x.DefaultProviderId,
                                       x.IsActive,
                                       x.IsDefault,
                                       x.ModifiedDate,
                                       x.ModifiedBy,
                                       x.VenderId,
                                       x.ParentId,
                                       x.IsMentalDefault,
                                       x.ChildFacilityName
                                   })
                                   .Where(i => i.UId == entity.UId && i.PracticeId == LoggedUser.PracticeId);

            return await base.UpdateOnlyAsync(tEntity, updateOnlyFields);
        }

        public async Task<int> Delete(int id)
        {
            return await this.Connection.DeleteAsync<Facility>(i => i.Id == id && i.PracticeId == LoggedUser.PracticeId);
        }

        public override async Task<IEnumerable<IValidationResult>> ValidateEntityToAdd(Facility tEntity)
        {
            List<IValidationResult> errors = new List<IValidationResult>();
            if (tEntity.IsDefault.HasValue && tEntity.IsMentalDefault.HasValue)
            {
                if (tEntity.IsDefault.Value && tEntity.IsMentalDefault.Value)
                {
                    errors.Add(new ValidationCodeResult("Single facility cannot set as default for Both (Substance and Mental)"));
                }
            }

            var entityErrors = await base.ValidateEntity(tEntity);
            errors.AddRange(entityErrors);

            return errors;
        }

        public override async Task<IEnumerable<IValidationResult>> ValidateEntityToUpdate(Facility tEntity)
        {
            List<IValidationResult> errors = new List<IValidationResult>();
            if (tEntity.IsDefault.HasValue && tEntity.IsMentalDefault.HasValue)
            {
                if (tEntity.IsDefault.Value && tEntity.IsMentalDefault.Value)
                {
                    errors.Add(new ValidationCodeResult("Single facility cannot set as default for Both (Substance and Mental)"));
                }
            }
                

            var entityErrors = await base.ValidateEntity(tEntity);
            errors.AddRange(entityErrors);

            return errors;
        }

        public async Task ThrowError()
        {
            await this.ThrowEntityException(new ValidationCodeResult("Diagnosis does not match with Billing Facility"));
        }

        public async Task ThrowError(string cptCode)
        {
            await this.ThrowEntityException(new ValidationCodeResult("Primary diagnosis does not match with Billing Facility for cpt code: "+ cptCode));
        }
    }
}
