using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using PractiZing.Base.Entities.ChargePaymentService;
using PractiZing.Base.Entities.SecurityService;
using PractiZing.Base.Repositories.ChargePaymentService;
using PractiZing.BusinessLogic.ChargePaymentService;
using PractiZing.DataAccess.ChargePaymentService;
using PractiZing.DataAccess.ChargePaymentService.Tables;
using PractiZing.DataAccess.Common;
using RestSharp;
using ServiceStack;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;

namespace PractiZing.BusinessLogic.ChargePaymentService.Repositories
{
    public class HL7RulesScriptsRepository : ModuleBaseRepository<HL7RuleScripts>, IHL7RuleStatementsRepository
    {
        private ILogger _logger;

        public HL7RulesScriptsRepository(ValidationErrorCodes errorCodes,
                                            DataBaseContext dbContext,
                                            ILoginUser loggedUser
                                            ) : base(errorCodes, dbContext, loggedUser)
        {

        }

        public async Task RunChargePostIdHl7Scripts(int chargeId)
        {
            var hl7Rule = await this.Connection.SingleAsync<HL7RuleScripts>(i => i.PracticeId == LoggedUser.PracticeId);
            if(hl7Rule!=null)
            {
                string sqlQuery = hl7Rule.SqlStatement + chargeId;
                //await this.Connection.UpdateAllAsync(sqlQuery);
                await this.Connection.ExecuteNonQueryAsync(sqlQuery);
            }
        }
    }
}
