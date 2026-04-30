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
using AutoMapper;
using PractiZing.BusinessLogic.Common;
using PractiZing.DataAccess.MasterService.Tables;
using PractiZing.Base.Common;
using PractiZing.DataAccess.BatchPaymentService.Tables;

namespace PractiZing.BusinessLogic.ChargePaymentService.Repositories
{
    public class Claim824StatusRepository : ModuleBaseRepository<EDI824>, IClaim824StatusRepository
    {
        private readonly IMapper _mapper;
        public Claim824StatusRepository(ValidationErrorCodes errorCodes,
                                    DataBaseContext dbContext,
                                    ILoginUser loggedUser,
                                    IMapper mapper)
                                    : base(errorCodes, dbContext, loggedUser)
        {
            this._mapper = mapper;
        }

       

        public async Task<IEDI824> AddNew(IEDI824 entity)
        {
            try
            {
                EDI824 tEntity = entity as EDI824;
                
                tEntity.CreatedDate = System.DateTime.Now;

                var result = await base.AddNewAsync(tEntity);
                return result;
            }
            catch
            {
                throw;
            }
        }
    }
}
