using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Reflection;
using System.Text;

namespace PractiZing.DataAccess.Common
{
    public class EntityException : Exception
    {
        public virtual IValidationCodeResult ValidationCodeResult { get; set; }

        public EntityException(string message) : base(message)
        {

        }
    }

    public class EntityUpdateException : EntityException
    {
        public override IValidationCodeResult ValidationCodeResult { get; set; }

        public new string Message { get; set; }

        public EntityUpdateException(Exception ex) : base(ex.Message)
        {
            Type type = ex.GetType();
            ValidationCodeResult = new EntityUpdateErrorResult();
            var entityUpdateErrorResult = (EntityUpdateErrorResult)ValidationCodeResult;
            if (type == typeof(SqlException))
            {
                SqlException dbEx = ex as SqlException;
                this.Message = dbEx.Message;

                entityUpdateErrorResult.Data = dbEx.Data;
                entityUpdateErrorResult.ErrorCode = dbEx.ErrorCode;
                entityUpdateErrorResult.ClientConnectionId = dbEx.ClientConnectionId;
                entityUpdateErrorResult.Errors = dbEx.Errors;
                entityUpdateErrorResult.Data = dbEx.Data;
                entityUpdateErrorResult.HelpLink = dbEx.HelpLink;
                entityUpdateErrorResult.HResult = dbEx.HResult;
                entityUpdateErrorResult.InnerException = dbEx.InnerException;
                entityUpdateErrorResult.LineNumber = dbEx.LineNumber;
                entityUpdateErrorResult.Number = dbEx.Number;
                entityUpdateErrorResult.SchemaName = dbEx.Procedure;
                entityUpdateErrorResult.Server = dbEx.Server;
                entityUpdateErrorResult.Source = dbEx.Source;
                entityUpdateErrorResult.StackTrace = dbEx.StackTrace;
                entityUpdateErrorResult.TargetSite = dbEx.TargetSite;
            }
        }
    }

    public class EntityUpdateErrorResult : IValidationCodeResult
    {
        public int ErrorCode { get; set; }

        public Guid ClientConnectionId { get; set; }

        public SqlErrorCollection Errors { get; set; }

        public IDictionary Data { get; set; }

        public string DataTypeName { get; set; }

        public string HelpLink { get; set; }

        public int HResult { get; set; }

        public Exception InnerException { get; set; }

        public int LineNumber { get; set; }

        public int Number { get; set; }

        public string Procedure { get; }

        public int Position { get; set; }

        public string Routine { get; set; }

        public string SchemaName { get; set; }

        public string Server { get; set; }

        public string Source { get; set; }

        public string StackTrace { get; set; }

        public MethodBase TargetSite { get; set; }

        public EntityUpdateErrorResult()
        {

        }
    }
}
