using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Common
{
    public interface ITransactionProvider
    {
        string StartTransaction(bool matchTransactionId = false);

        void CommitTransaction(string transactionId = null);

       void RollbackTransaction(string transactionId = null);
    }
}
