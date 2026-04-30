using PractiZing.Base.Common;
using PractiZing.Base.Entities.MasterService;
using PractiZing.Base.Entities.SecurityService;
using PractiZing.Base.Repositories.MasterService;
using PractiZing.Base.Repositories.SecurityService;
using PractiZing.Base.Service.MasterService;
using PractiZing.DataAccess.SecurityService;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PractiZing.BusinessLogic.MasterService.Services
{
    public class FacilityService : IFacilityService
    {        
        private readonly IFacilityIdentityRepository _facilityIdentityRepository;
        private readonly IFacilityRepository _facilityRepository;
        public FacilityService(IFacilityIdentityRepository facilityIdentityRepository, IFacilityRepository facilityRepository)
        {
            this._facilityRepository = facilityRepository;
            this._facilityIdentityRepository = facilityIdentityRepository;            
        }

        public async Task<IEnumerable<IFacilityIdentity>> GetFacilityIdentifiersByFacilityId(int facilityId)
        {
            return await this._facilityIdentityRepository.GetFacilityIdentifiersByFacilityId(facilityId);
        }

        public async Task<int> AddIdentities(IEnumerable<IFacilityIdentity> entities)
        {
            try
            {
                foreach (var item in entities)
                {
                    await this._facilityIdentityRepository.AddNew(item);
                }
                return 1;
            }
            catch
            {
                throw;
            }
        }

        public async Task<IFacility> AddNew(IFacility entity)
        {
            try
            {
                var facility = await this._facilityRepository.AddNew(entity);                
                if(facility.ParentId.HasValue && facility.ParentId.Value>0)
                {
                    var listIdentities=await this._facilityIdentityRepository.GetFacilityIdentifiersByFacilityId(facility.ParentId.Value);
                    foreach (var item in listIdentities)
                    {
                        item.FacilityUId = facility.UId;
                    }
                    await AddIdentities(listIdentities);
                }
                return facility;
            }
            catch
            {
                throw;
            }
        }

        public async Task<IFacility> Update(IFacility entity)
        {
            try
            {
                bool parentExists = false;
                int existsParentId=0;

                var facility = await this._facilityRepository.GetById(entity.Id);
                if(facility.ParentId.HasValue && facility.ParentId.Value>0)
                {
                    parentExists = true;
                    existsParentId = facility.ParentId.Value;
                }

                await this._facilityRepository.Update(entity);

                if(entity.ParentId.HasValue && entity.ParentId.Value>0)
                {
                    if(!parentExists)
                    {
                        var listIdentities = await this._facilityIdentityRepository.GetFacilityIdentifiersByFacilityId(entity.ParentId.Value);
                        foreach (var item in listIdentities)
                        {
                            item.FacilityUId = facility.UId;
                        }
                        await AddIdentities(listIdentities);
                    }
                    else
                    {
                        if(existsParentId!=entity.ParentId.Value)
                        {
                            var existsIdentifiersList = await this._facilityIdentityRepository.GetFacilityIdentifiersByFacilityId(facility.Id);
                            foreach (var item in existsIdentifiersList)
                            {
                                await this._facilityIdentityRepository.Delete(item.UId);
                            }

                            var listIdentities = await this._facilityIdentityRepository.GetFacilityIdentifiersByFacilityId(entity.ParentId.Value);
                            foreach (var item in listIdentities)
                            {
                                item.FacilityUId = facility.UId;
                            }
                            await AddIdentities(listIdentities);

                        }
                    }
                }

                
                return facility;
            }
            catch
            {
                throw;
            }
        }

    }
}
