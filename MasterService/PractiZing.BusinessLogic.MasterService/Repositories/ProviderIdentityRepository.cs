using PractiZing.Base.Common;
using PractiZing.Base.Entities.MasterService;
using PractiZing.Base.Entities.SecurityService;
using PractiZing.Base.Repositories.MasterService;
using PractiZing.BusinessLogic.Common;
using PractiZing.DataAccess.Common;
using PractiZing.DataAccess.MasterService;
using PractiZing.DataAccess.MasterService.Tables;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PractiZing.BusinessLogic.MasterService.Repositories
{
    public class ProviderIdentityRepository : ModuleBaseRepository<ProviderIdentity>, IProviderIdentityRepository
    {
        private readonly IConfigIdTypeRepository _configIdTypeRepository;
        private readonly IProviderRepository _providerRepository;
        public ProviderIdentityRepository(DataAccess.MasterService.ValidationErrorCodes errorCodes,
                                        DataBaseContext dbContext,
                                        ILoginUser loggedUser,
                                        IConfigIdTypeRepository configIdTypeRepository,
                                        IProviderRepository providerRepository
                                        ) : base(errorCodes, dbContext, loggedUser)
        {
            _configIdTypeRepository = configIdTypeRepository;
            _providerRepository = providerRepository;
        }

        public async Task<IEnumerable<IProviderIdentity>> GetAll()
        {
            return (await this.Connection.SelectAsync<ProviderIdentity>()).OrderBy(i => i.Identifier);
        }

        public async Task<IProviderIdentity> Get(Guid uId)
        {
            return await this.Connection.SingleAsync<ProviderIdentity>(i => i.UId == uId);
        }

        public async Task<IProviderIdentity> GetNPIByProviderId(Guid uId)
        {
            var provider = await this._providerRepository.GetByUId(uId);

            return await this.Connection.SingleAsync<ProviderIdentity>(i => i.ProviderId== provider.Id && i.TypeId==1);
        }

        public async Task<IProviderIdentity> GetProviderTaxonomyByProviderUId(Guid uId)
        {
            var provider = await this._providerRepository.GetByUId(uId);

            return await this.Connection.SingleAsync<ProviderIdentity>(i => i.ProviderId == provider.Id && i.TypeId == 14);
        }

        public async Task<IProviderIdentity> GetProviderTaxonomyByProviderUId(Guid uId,IFacility billingFacility)
        {
            var provider = await this._providerRepository.GetByUId(uId);
            IProviderIdentity item=null;
            
            if (billingFacility.IsMentalFacility.HasValue && billingFacility.IsMentalFacility.Value)
            {                
                var  query = this.Connection.From<ProviderIdentity>()
                            .Join<ProviderIdentity, ConfigIdType>((p, c) => p.TypeId == c.Id)
                            .Select<ProviderIdentity>((p) => new
                            {
                                p
                            })
                            .Where<ProviderIdentity,ConfigIdType>((i,j) => j.Name == "MHTAXONOMY" && i.ProviderId==provider.Id);
                var providerIdentity = await this.Connection.SelectAsync<dynamic>(query);
                item = ((Mapper<ProviderIdentity>.Map(providerIdentity)));
            }
            else
            {
                var query = this.Connection.From<ProviderIdentity>()
                            .Join<ProviderIdentity, ConfigIdType>((p, c) => p.TypeId == c.Id)
                            .Select<ProviderIdentity>((p) => new
                            {
                                p
                            })
                            .Where<ProviderIdentity, ConfigIdType>((i, j) => j.Name == "SUDTAXONOMY" && i.ProviderId == provider.Id);
                var providerIdentity = await this.Connection.SelectAsync<dynamic>(query);
                item = ((Mapper<ProviderIdentity>.Map(providerIdentity)));
            }
            return item;
        }

        //public async Task<IEnumerable<IProviderIdentity>> GetIdentityByProvider(int providerId)
        //{
        //    try
        //    {
        //        var query = this.Connection.From<ProviderIdentity>()
        //                    .Join<ProviderIdentity, ConfigIdType>((p, c) => p.TypeId == c.Id)
        //                    .Select<ProviderIdentity>((p) => new
        //                    {
        //                        p
        //                    })
        //                    .Where<ConfigIdType>(i => i.Name == "NPI");

        //        var providerIdentity = await this.Connection.SelectAsync<dynamic>(query);
        //        return ((Mapper<ProviderIdentity>.MapList(providerIdentity)).OrderBy(i => i.Identifier));
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}

        public async Task<IProviderIdentity> GetProviderIdentity(short providerId, int? typeId, DateTime? activeDate, string hcfaField)
        {
            try
            {
                //typeId =  1;
                activeDate = activeDate ?? DateTime.Now.Date;
                var query = this.Connection.From<ProviderIdentity>()
                    .Join<ProviderIdentity, ConfigIdType>((p, c) => p.TypeId == c.Id)
                    .LeftJoin<ProviderIdentity, Provider>((pr, p) => pr.ProviderId == p.Id)
                    .Select<ProviderIdentity, Provider>((pr, p) => new
                    {
                        pr,
                        ProviderUId = p.UId
                    })
                    .Where(i => i.ProviderId == providerId
                             && i.TypeId == typeId
                             && i.ActiveDate <= activeDate.Value.Date);

                var providerIdentity = await this.Connection.SelectAsync<dynamic>(query);

                var result = Mapper<ProviderIdentity>.Map(providerIdentity);
                if (result == null && (hcfaField != "PIN" && hcfaField != "Res10Provider") && typeId != 0)
                    await ProviderIdentityDoesNotExist(typeId);

                return result;
            }
            catch
            {
                throw;
            }
        }

        private async Task ProviderIdentityDoesNotExist(int? typeId)
        {
            List<IValidationResult> errors = new List<IValidationResult>();
            var configIdType = await this._configIdTypeRepository.GetById(Convert.ToInt16(typeId));
            errors.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.ProviderDoesnotHaveIdentity], configIdType.Name));
            await this.ThrowEntityException(errors);
        }

        public async Task<IEnumerable<IProviderIdentity>> GetByProvider(Guid providerUId)
        {
            var query = this.Connection
                            .From<ProviderIdentity>()
                            .Join<ProviderIdentity, ConfigIdType>((p, c) => p.TypeId == c.Id)
                            .Join<ProviderIdentity, Provider>((pr, p) => pr.ProviderId == p.Id)
                            .Select<ProviderIdentity, Provider>((pr, p) => new
                            {
                                pr,
                                ProviderUId = p.UId
                            })
                            .Where<Provider>(p => p.UId == providerUId)
                            .OrderBy<ConfigIdType>(i => i.Name);

            var dynamicData = await this.Connection.SelectAsync<dynamic>(query);
            return (Mapper<ProviderIdentity>.MapList(dynamicData));
        }

        public async Task<int> AddOrUpdate(IEnumerable<IProviderIdentity> entities)
        {
            try
            {
                var updateData = entities.Where(i => i.Id != 0);
                var addData = entities.Where(i => i.Id == 0);

                foreach (var item in updateData)
                    await this.Update(item);

                foreach (var item in addData)
                    await this.AddNew(item);

                return 1;
            }
            catch
            {
                throw;
            }
        }

        public async Task<IProviderIdentity> AddNew(IProviderIdentity entity)
        {
            try
            {
                ProviderIdentity tEntity = entity as ProviderIdentity;

                var provider = await this._providerRepository.GetByUId(entity.ProviderUId);
                tEntity.ProviderId = provider.Id;

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

        public async Task<int> Update(IProviderIdentity entity)
        {
            try
            {
                ProviderIdentity tEntity = entity as ProviderIdentity;

                var provider = await this._providerRepository.GetByUId(entity.ProviderUId);
                tEntity.ProviderId = provider.Id;
                tEntity.ModifiedDate = DateTime.Now;

                var errors = await this.ValidateEntityToUpdate(tEntity);
                if (errors.Count() > 0)
                    await this.ThrowEntityException(errors);

                var updateOnlyFields = this.Connection
                                      .From<ProviderIdentity>()
                                      .Update(x => new
                                      {
                                          x.ProviderId,
                                          x.TypeId,
                                          x.Identifier,
                                          x.ActiveDate,
                                          x.InactiveDate
                                      })
                                      .Where(i => i.UId == tEntity.UId);

                return await this.Connection.UpdateOnlyAsync<ProviderIdentity>(tEntity, updateOnlyFields);
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> Delete(Guid uid)
        {
            return await this.Connection.DeleteAsync<ProviderIdentity>(i => i.UId == uid);
        }

        public async Task<int> DeleteByProviderId(int providerId)
        {
            var list =await this.Connection.SelectAsync<ProviderIdentity>(i => i.ProviderId==providerId);

            foreach (var item in list)
            {
                await this.Connection.DeleteAsync<ProviderIdentity>(i => i.UId == item.UId);
            }
            return 1;
        }

        public async Task<IProvider> GetProviderByFacilityNPI(string  facilitynpi)
        {
            var npiIdentifier=await this.Connection.SingleAsync<ProviderIdentity>(i => i.Identifier==facilitynpi && i.TypeId == 1);
            if(npiIdentifier!=null)
            {
                return await this._providerRepository.GetById(npiIdentifier.ProviderId);
            }

            return null;
        }
    }
}
