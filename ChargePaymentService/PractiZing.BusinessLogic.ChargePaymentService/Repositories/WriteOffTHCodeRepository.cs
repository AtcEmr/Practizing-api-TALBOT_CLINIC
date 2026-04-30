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
using PractiZing.Base.Object.ChargePaymentService;
using PractiZing.DataAccess.ChargePaymentService.Objects;

namespace PractiZing.BusinessLogic.ChargePaymentService.Repositories
{
    public class WriteOffTHCodeRepository : ModuleBaseRepository<WriteOffTHCode>, IWriteOffTHCodeRepository
    {
        private readonly IMapper _mapper;
        public WriteOffTHCodeRepository(ValidationErrorCodes errorCodes,
                                    DataBaseContext dbContext,
                                    ILoginUser loggedUser,
                                    IMapper mapper)
                                    : base(errorCodes, dbContext, loggedUser)
        {
            this._mapper = mapper;
        }

       

        public async Task<bool> AddNew(IEnumerable<IWriteOffTHCode> entityList)
        {
            try
            {
                List<WriteOffTHCode> writeOffTHCodeList = new List<WriteOffTHCode>();
                entityList.ToList().ForEach((res) =>
                {
                    WriteOffTHCode writeOffTHCode = res as WriteOffTHCode;
                    writeOffTHCodeList.Add(writeOffTHCode);
                });

                await base.AddAllAsync(writeOffTHCodeList);
                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<IWriteOffEMRObjectDTO>> GetDataFormEMR()
        {
            try
            {
                var query = this.Connection.From<WriteOffTHCode>()
                         .Join<WriteOffTHCode, Invoice>((c, f) => c.InvoiceId == f.Id)
                         .Select<Invoice>(i => new
                         {
                             i.AccessionNumber

                         })
                         .Where<WriteOffTHCode>(i => i.IsAckNeeded==true);

                var queryResult = await this.Connection.SelectAsync<dynamic>(query);
                var result = Mapper<WriteOffEMRObjectDTO>.MapList(queryResult);

                // return await this.Connection.SelectAsync<Charges>(i => i.InvoiceId == invoiceId && i.PracticeId == LoggedUser.PracticeId && i.PatientCaseId == patientCaseId && !i.IsDeleted);
                return result;
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<int>> GetDataFormEMR(IEnumerable<IWriteOffEMRObjectDTO> list)
        {
            try
            {
                var query = this.Connection.From<WriteOffTHCode>()
                         .Join<WriteOffTHCode, Invoice>((c, f) => c.InvoiceId == f.Id)
                         .Select<WriteOffTHCode>(i => new
                         {
                             i.Id
                         })
                         .Where<Invoice>(i =>  list.Select(x=>x.AccessionNumber).Contains(i.AccessionNumber));

                var queryResult = await this.Connection.SelectAsync<int>(query);
                //var result = Mapper<int>.MapList(queryResult);

                // return await this.Connection.SelectAsync<Charges>(i => i.InvoiceId == invoiceId && i.PracticeId == LoggedUser.PracticeId && i.PatientCaseId == patientCaseId && !i.IsDeleted);
                return queryResult;
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> UpdateWriteOffEMRAcknowledgement(IEnumerable<IWriteOffEMRObjectDTO> list)
        {
            try
            {

                var dataList = await GetDataFormEMR(list);

                foreach (var item in dataList)
                {
                    WriteOffTHCode tEntity = await this.GetById(item);
                    tEntity.IsAckNeeded = false;
                    var updateOnlyFields = this.Connection
                                               .From<WriteOffTHCode>()
                                               .Update(x => new
                                               {
                                                   x.IsAckNeeded

                                               })
                                               .Where(i => i.Id ==tEntity.Id);

                    await base.UpdateOnlyAsync(tEntity, updateOnlyFields);
                }

                return 2;
                
            }
            catch
            {
                throw;
            }
        }
    }
}
