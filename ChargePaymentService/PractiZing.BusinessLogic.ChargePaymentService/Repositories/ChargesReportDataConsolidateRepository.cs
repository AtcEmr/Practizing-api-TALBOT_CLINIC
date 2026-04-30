using AutoMapper;
using PractiZing.Base.Entities.ChargePaymentService;
using PractiZing.Base.Entities.MasterService;
using PractiZing.Base.Entities.SecurityService;
using PractiZing.Base.Object.ChargePaymentService;
using PractiZing.Base.Repositories.ChargePaymentService;
using PractiZing.Base.Repositories.MasterService;
using PractiZing.BusinessLogic.Common;
using PractiZing.DataAccess.ChargePaymentService;
using PractiZing.DataAccess.ChargePaymentService.Objects;
using PractiZing.DataAccess.ChargePaymentService.Tables;
using PractiZing.DataAccess.Common;
using PractiZing.DataAccess.DenialService.Tables;
using PractiZing.DataAccess.PatientService.Tables;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PractiZing.BusinessLogic.ChargePaymentService.Repositories
{
    public class ChargesReportDataConsolidateRepository : ModuleBaseRepository<ChargesReportDataConsolidate>, IChargesReportDataConsolidateRepository
    {
        
        private readonly IMapper _mapper;
        public ChargesReportDataConsolidateRepository(ValidationErrorCodes errorCodes,
                                      DataBaseContext dbContext,
                                      ILoginUser loggedUser,                                      
                                      IMapper mapper)
                                      : base(errorCodes, dbContext, loggedUser)
        {
            
            this._mapper = mapper;
            
        }


        public async Task<int> Update(IEnumerable<IChargesReportDataConsolidate> entities)
        {
            try
            {
                List<ChargesReportDataConsolidate> tEntityList = entities as List<ChargesReportDataConsolidate>;

                foreach (var item in tEntityList)
                {
                    item.IsSynced = true;
                    var updateOnlyFields = this.Connection
                                           .From<ChargesReportDataConsolidate>()
                                           .Update(x => new
                                           {
                                               x.IsSynced
                                           })
                                           .Where(i => i.Id==item.Id);

                    await base.UpdateOnlyAsync(item,updateOnlyFields);
                }
                return 0;
                
            }
            catch
            {
                throw;
            }
        }
       
    }
}
