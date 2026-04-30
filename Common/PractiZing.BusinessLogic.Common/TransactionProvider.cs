using PractiZing.Base.Common;
using PractiZing.DataAccess.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.BusinessLogic.Common
{
    public class TransactionProvider : ITransactionProvider
    {
        private DataBaseContext _dbContext;
        public TransactionProvider(DataBaseContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public string StartTransaction(bool matchTransactionId = false)
        {
            return this._dbContext.BeginTransaction(matchTransactionId);
        }

        public void CommitTransaction(string transactionId = null)
        {
            this._dbContext.CommitTransaction(transactionId);
        }

        public void RollbackTransaction(string transactionId = null)
        {
            this._dbContext.RollbackTransaction(transactionId);
        }
    }
}
