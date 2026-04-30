using PractiZing.Base.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PractiZing.DataAccess.Common
{
    public class ValidationError
    {
        public ValidationError(string error)
        {
            this.Error = error;
        }
        public string Error { get; set; }
    }

    public class ValidationCodeResult : ValidationResult, IValidationResult
    {
        private List<ValidationCodeResult> errors;

        public int ErrorCode { get; set; }

        public ValidationCodeResult(KeyValuePair<int, string> error, string attachedMessage = "") : base(error.Value + " " + attachedMessage)
        {
            this.ErrorCode = error.Key;
        }

        public ValidationCodeResult(string errorMessage, int errorCode) : base(errorMessage)
        {
            this.ErrorCode = errorCode;
        }

        public ValidationCodeResult(string errorMessage) : this(errorMessage, 0)
        {

        }

        public ValidationCodeResult(string errorMessage, IEnumerable<string> memberNames, int errorCode) : base(errorMessage, memberNames)
        {
            this.ErrorCode = errorCode;
        }

        public ValidationCodeResult(string errorMessage, IEnumerable<string> memberNames) : this(errorMessage, memberNames, 0)
        {

        }

        public ValidationCodeResult(ValidationCodeResult ValidationCodeResult) : base(ValidationCodeResult)
        {

        }

        public ValidationCodeResult(string errorMessage, string errorMessage1) : base(errorMessage)
        {
        }
        
        //public ValidationCodeResult(List<ValidationCodeResult> errors)
        //{
        //    this.errors = errors;
        //}
    }
}
