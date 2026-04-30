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
    public class ClaimStatusInquiryRepository : ModuleBaseRepository<ClaimStatusInquiry>, IClaimStatusInquiryRepository
    {
        private readonly IMapper _mapper;
        public ClaimStatusInquiryRepository(ValidationErrorCodes errorCodes,
                                    DataBaseContext dbContext,
                                    ILoginUser loggedUser,
                                    IMapper mapper)
                                    : base(errorCodes, dbContext, loggedUser)
        {
            this._mapper = mapper;
        }

       

        public async Task<IClaimStatusInquiry> AddNew(IClaimStatusInquiry entity)
        {
            try
            {
                ClaimStatusInquiry tEntity = entity as ClaimStatusInquiry;
                tEntity.PracticeId = this.LoggedUser.PracticeId;
                tEntity.CreatedDate = System.DateTime.Now;

                var result = await base.AddNewAsync(tEntity);
                return result;
            }
            catch
            {
                throw;
            }
        }

        public async Task AddNew(IEnumerable<IClaimStatusInquiry> entities)
        {
            try
            {
                foreach (var item in entities)
                {
                    await this.AddNew(item);
                }
            }
            catch
            {
                throw;
            }
        }



    }
}
