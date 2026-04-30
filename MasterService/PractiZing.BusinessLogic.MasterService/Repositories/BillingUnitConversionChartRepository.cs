using PractiZing.Base.Entities.MasterService;
using PractiZing.Base.Repositories.MasterService;
using PractiZing.DataAccess.MasterService;
using PractiZing.DataAccess.MasterService.Tables;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PractiZing.DataAccess.Common;
using PractiZing.Base.Entities.PatientService;
using PractiZing.Base.Entities.SecurityService;
using System.Linq;

namespace PractiZing.BusinessLogic.MasterService.Repositories
{
    public class BillingUnitConversionChartRepository : ModuleBaseRepository<BillingUnitConversionChart>, IBillingUnitConversionChartRepository
    {
        public BillingUnitConversionChartRepository(ValidationErrorCodes errorCodes, DataBaseContext dbContext, ILoginUser loggedUser)
          : base(errorCodes, dbContext, loggedUser)
        {

        }

        public async Task<int> GetUnitByMinutes(int minutes)
        {
            int billingUnit=0;
            var item=await this.Connection.SingleAsync<BillingUnitConversionChart>(i => i.MinimumMinutes <= minutes && i.MaximumMinutes >= minutes);
            if(item!=null)
            {
                billingUnit = item.BillingUnit;
            }
            return billingUnit;
        }
    }
}

