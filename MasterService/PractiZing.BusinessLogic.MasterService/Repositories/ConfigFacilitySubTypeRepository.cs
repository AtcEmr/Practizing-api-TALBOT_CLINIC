using PractiZing.Base.Entities.MasterService;
using PractiZing.Base.Entities.SecurityService;
using PractiZing.Base.Repositories.MasterService;
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
    public class ConfigFacilitySubTypeRepository : ModuleBaseRepository<ConfigFacilitySubType>, IConfigFacilitySubTypeRepository
    {
        IFacilityRepository _facilityRepository;
        public ConfigFacilitySubTypeRepository(ValidationErrorCodes errorCodes, DataBaseContext dbContext, ILoginUser loggedUser, IFacilityRepository facilityRepository)
         : base(errorCodes, dbContext, loggedUser)
        {
            _facilityRepository = facilityRepository;
        }

        public async Task<IEnumerable<IConfigFacilitySubType>> GetAll()
        {
            return (await this.Connection.SelectAsync<ConfigFacilitySubType>()).OrderBy(i => i.TypeName);
        }

        public async Task<IEnumerable<IConfigFacilitySubType>> GetByFacilityUId(string faciltyUId)
        {
            try
            {
                var facility = await this._facilityRepository.GetByUId(Guid.Parse(faciltyUId));
                var facilityId = facility == null ? 0 : facility.Id;
                var result = await this.Connection.SelectAsync<ConfigFacilitySubType>(i => i.ParentId == facilityId);
                return result;
            }
            catch
            {
                throw;
            }
        }
    }
}
