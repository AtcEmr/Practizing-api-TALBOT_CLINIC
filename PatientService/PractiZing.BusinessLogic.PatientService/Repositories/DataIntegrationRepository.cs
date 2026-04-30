using AutoMapper;
using Newtonsoft.Json;
using PractiZing.Base.Common;
using PractiZing.Base.Entities.ChargePaymentService;
using PractiZing.Base.Entities.PatientService;
using PractiZing.Base.Entities.SecurityService;
using PractiZing.Base.Model;
using PractiZing.Base.Model.PatientService;
using PractiZing.Base.Object.PatientService;
using PractiZing.Base.Repositories.PatientService;
using PractiZing.BusinessLogic.Common;
using PractiZing.DataAccess.ChargePaymentService.Tables;
using PractiZing.DataAccess.Common;
using PractiZing.DataAccess.Common.Helpers;
using PractiZing.DataAccess.MasterService.Tables;
using PractiZing.DataAccess.PatientService;
using PractiZing.DataAccess.PatientService.Model;
using PractiZing.DataAccess.PatientService.Object;
using PractiZing.DataAccess.PatientService.Tables;
//using PractiZing.DataAccess.SecurityService;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.Dapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PractiZing.BusinessLogic.PatientService.Repositories
{
    public class DataIntegrationRepository : ModuleBaseRepository<Patient>, IDataIntegrationRepository
    {
        private readonly ITransactionProvider _transactionProvider;
        private readonly IMapper _mapper;

        public DataIntegrationRepository(ValidationErrorCodes errorCodes,
                                 DataBaseContext dbContext,
                                 ILoginUser loggedUser,
                                 ITransactionProvider transactionProvider,                                 
        IMapper mapper) : base(errorCodes, dbContext, loggedUser)
        {
            this._transactionProvider = transactionProvider;
            _mapper = mapper;            
        }

                
    }
}
