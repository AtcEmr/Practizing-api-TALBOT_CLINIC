using PractiZing.Base.Entities.ChargePaymentService;
using PractiZing.Base.Entities.SecurityService;
using PractiZing.Base.Repositories.ChargePaymentService;
using PractiZing.DataAccess.ChargePaymentService;
using PractiZing.DataAccess.ChargePaymentService.Tables;
using PractiZing.DataAccess.Common;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.Model;

namespace PractiZing.BusinessLogic.ChargePaymentService.Repositories
{
    public class HistoryPaymentRepository : ModuleBaseRepository<HistoryPayment>, IHistoryPaymentRepository
    {

        private readonly AmazonDynamoDBClient _client;
        private readonly DynamoDBContext _context;

        public HistoryPaymentRepository(ValidationErrorCodes errorCodes,
                                    DataBaseContext dbContext,
                                    ILoginUser loggedUser)
                                    : base(errorCodes, dbContext, loggedUser)
        {
            //_client = new AmazonDynamoDBClient("AKIA3JXRCLK5EZFUZGEC", "2u+CgIqTpVY0n3Fdhcbi5uY96JOd2jnLQcVliQJQ",Amazon.RegionEndpoint.USEast1);
            _client = new AmazonDynamoDBClient("AKIA3JXRCLK5EZFUZGECTest", "2u+CgIqTpVY0n3Fdhcbi5uY96JOd2jnLQcVliQJQTest", Amazon.RegionEndpoint.USEast1);

            _context = new DynamoDBContext(_client);
        }

        public async Task Add(IHistoryPayment entity)
        {
            var reader = new HistoryPayment
            {
                
            };

            await _context.SaveAsync<HistoryPayment>(reader);
        }

        public async Task<IEnumerable< IHistoryPayment>> All(string paginationToken = "")
        {
            // Get the Table ref from the Model
            var table = _context.GetTargetTable<HistoryPayment>();

            // If there's a PaginationToken
            // Use it in the Scan options
            // to fetch the next set
            var scanOps = new ScanOperationConfig();

            if (!string.IsNullOrEmpty(paginationToken))
            {
                scanOps.PaginationToken = paginationToken;
            }

            // returns the set of Document objects
            // for the supplied ScanOptions
            var results = table.Scan(scanOps);
            List<Document> data = await results.GetNextSetAsync();

            // transform the generic Document objects
            // into our Entity Model
            IEnumerable<HistoryPayment> readers = _context.FromDocuments<HistoryPayment>(data);

            return readers;
        }

        public async Task<IEnumerable<IHistoryPayment>> Find()
        {
            var scanConditions = new List<ScanCondition>();
            scanConditions.Add(new ScanCondition("IsExported", ScanOperator.IsNull));
            //scanConditions.Add(new ScanCondition("AccountNumber", ScanOperator.IsNotNull));
            //scanConditions.Add(new ScanCondition("Amount", ScanOperator.IsNotNull));
            //scanConditions.Add(new ScanCondition("Date", ScanOperator.IsNotNull));
            //scanConditions.Add(new ScanCondition("PaymentConfirmationCode", ScanOperator.IsNotNull));
            //scanConditions.Add(new ScanCondition("TransactionID", ScanOperator.IsNotNull));
            return await _context.ScanAsync<HistoryPayment>(scanConditions, null).GetRemainingAsync();
        }

        public async Task Remove(string readerId)
        {
            await _context.DeleteAsync<HistoryPayment>(readerId);
        }

        public async Task<IHistoryPayment> Single(string readerId)
        {
            return await _context.LoadAsync<HistoryPayment>(readerId); //.QueryAsync<Reader>(readerId.ToString()).GetRemainingAsync();
        }

        public async Task Update(string historyPaymentId)
        {
            var reader = await Single(historyPaymentId);
            HistoryPayment tEntity = reader as HistoryPayment;
            //reader.EmailAddress = entity.EmailAddress;
            //reader.Username = entity.Username;
            //reader.Name = entity.Name;
            tEntity.IsExported = "true";
            await _context.SaveAsync<HistoryPayment>(tEntity);
        }
    }
}
