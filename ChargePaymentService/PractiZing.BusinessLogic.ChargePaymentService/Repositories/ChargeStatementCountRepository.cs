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
    public class ChargeStatementCountRepository : ModuleBaseRepository<ChargeStatementCount>, IChargeStatementCountRepository
    {
        private readonly IMapper _mapper;
        public ChargeStatementCountRepository(ValidationErrorCodes errorCodes,
                                     DataBaseContext dbContext,
                                     ILoginUser loggedUser, IMapper mapper)
                                     : base(errorCodes, dbContext, loggedUser)
        {
            this._mapper = mapper;
        }

        public async Task<bool> AddNew(IEnumerable<IChargeStatementCount> entities)
        {
            try
            {
                List<ChargeStatementCount> chargeStatementCountList = new List<ChargeStatementCount>();
                entities.ToList().ForEach((res) =>
                {
                    ChargeStatementCount chargeStatementCount = res as ChargeStatementCount;
                    chargeStatementCountList.Add(chargeStatementCount);
                });

                await base.AddAllAsync(chargeStatementCountList);

                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<string>> GetList()
        {
            var firstDayOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

            firstDayOfMonth = firstDayOfMonth.AddMonths(-1);

            var list = await this.Connection.SelectAsync<ChargeStatementCount>(i => i.StatementDate >= firstDayOfMonth);

            list = list.Where(i => i.StatementDate.Month == firstDayOfMonth.Month && i.StatementDate.Year == firstDayOfMonth.Year).ToList();

            if (list.Count>0)
            {                
                return list.Select(i => i.ChargeId.ToString());
            }

            return new List<string>();
        }


        public override async Task<IEnumerable<IValidationResult>> ValidateEntityToAdd(ChargeStatementCount tEntity)
        {
            List<IValidationResult> errors = new List<IValidationResult>();

            var entityErrors = await base.ValidateEntity(tEntity);
            errors.AddRange(entityErrors);

            return errors;
        }

        public override async Task<IEnumerable<IValidationResult>> ValidateEntityToUpdate(ChargeStatementCount tEntity)
        {
            List<IValidationResult> errors = new List<IValidationResult>();
            var entityErrors = await base.ValidateEntity(tEntity);
            errors.AddRange(entityErrors);

            return errors;
        }
    }
}
