using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
namespace PractiZing.DataAccess.Common
{
    public class DataBaseContext : IDisposable
    {
        private string _connectionString;
        private string _transactionId;
        private bool _matchTransactionId = false;
        private OrmLiteConnectionFactory _dbConnectionFactory;
        private readonly IHttpContextAccessor _context;
        public bool TransInitialized { get; private set; }

        private string _practiceCode;

        private static List<string> _practiceCodes;

        public DataBaseContext(OrmLiteConnectionFactory dbConnectionFactory,
                               IHttpContextAccessor context)
        {
            this._dbConnectionFactory = dbConnectionFactory;
            this._context = context;
            this._dbConnectionFactory = dbConnectionFactory;
            this._context = context;
            //_logger = logger;
            if (_context.HttpContext != null)
            {
                var hearder = GetPraciteCodeFromHeader();
                string practiceCode = string.Empty;

                if (hearder.Contains("localhost"))
                    practiceCode = "localhost";
                else
                    practiceCode = hearder.Split(".").FirstOrDefault();

                this.SetPracticeCode(practiceCode);
            }
            else
            {
                this.SetPracticeCode();
            }
        }

        public void SetPracticeCode(string practiceCode = "PracticeCentral")
        {
            _practiceCode = practiceCode;
        }

        private IDbConnection _connection;
        public IDbConnection Connection
        {
            get
            {
                //_logger.LogInformation($"Practice Code1 - {_practiceCode}");
                if (_connection == null || _connection.State == ConnectionState.Broken || _connection.State == ConnectionState.Closed)
                {
                    this.OpenConnection();
                }
                else if (!_practiceCodes.Contains(_practiceCode) && _connection != null)
                    this.OpenConnection();
                return _connection;
            }
            set
            {
                _connection = value;
            }
        }

        private void OpenConnection()
        {
            _practiceCodes = _practiceCodes == null ? new List<string>() : _practiceCodes;
            if (!_practiceCodes.Contains(_practiceCode))
            {
                _practiceCodes.Add(_practiceCode);
            }

            Console.WriteLine("Opening Connection for - " + _practiceCode);
            this._connection = _dbConnectionFactory.Open(_practiceCode);

        }

        private string GetPraciteCodeFromHeader()
        {
            var headers = this._context.HttpContext.Request.Headers;
            string headerOrigin = "";
            if (headers.ContainsKey("origin"))
                headerOrigin = headers["Origin"];
            else if (headers.ContainsKey("Referer"))
                headerOrigin = headers["Referer"];
            else
                headerOrigin = headers["Host"];

            if (headerOrigin.Contains("http"))
            {
                headerOrigin = headerOrigin.Replace("http://", "");
                headerOrigin = headerOrigin.Replace("https://", "");
                headerOrigin = headerOrigin.Replace("www.", "");
            }
            return headerOrigin;
        }

        public IDbTransaction _currentTransaction;
        public IDbTransaction CurrentTransaction
        {
            get
            {
                return _currentTransaction;
            }
            private set
            {
                this._currentTransaction = value;
            }
        }

        public string BeginTransaction(bool matchTransactionId = false)
        {

            if (this._matchTransactionId != true)
                this._matchTransactionId = matchTransactionId;

            /* if there is no existing transaction going on*/
            if (this.CurrentTransaction == null)
            {
                /* so this transaction is initialized by this function 
                 * commit it after all CUD is done
                 */
                this.CurrentTransaction = this.Connection.OpenTransaction();
                
                this.TransInitialized = true;
                _transactionId = Guid.NewGuid().ToString();
            }

            return _transactionId;
        }

        public void BeginCommittedTransaction()
        {
            /* if there is no existing transaction going on*/
            this.CurrentTransaction = this.Connection.OpenTransaction();
            this.CurrentTransaction = this.Connection.BeginTransaction(System.Data.IsolationLevel.ReadUncommitted);
        }

        public void CommitTransaction(string transactionId = null)
        {
            if (this.TransInitialized && this.CurrentTransaction != null)
            {
                if (!this._matchTransactionId || (this._matchTransactionId && transactionId == this._transactionId))
                {
                    this.CurrentTransaction.Commit();

                    this._matchTransactionId = false;
                    this._transactionId = "";
                    this.CurrentTransaction = null;
                }
            }
        }

        public void RollbackTransaction(string transactionId = null)
        {
            if (this.TransInitialized && this.CurrentTransaction != null)
            {
                if (!this._matchTransactionId || (this._matchTransactionId && transactionId == this._transactionId))
                {
                    this.CurrentTransaction.Rollback();

                    this._matchTransactionId = false;
                    this._transactionId = "";
                    this.CurrentTransaction = null;
                }
            }
        }

        public void Dispose()
        {

            if (this._connection != null)
            {
                this._connection.Close();
                this._connection = null;
            }
        }
    }
}
