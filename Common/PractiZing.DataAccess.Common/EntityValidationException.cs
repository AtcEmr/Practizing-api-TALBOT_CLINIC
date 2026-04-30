using PractiZing.Base.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.DataAccess.Common
{
    public class EntityValidationException : EntityException
    {
        public override IValidationCodeResult ValidationCodeResult { get; set; }
        public EntityValidationException(string message, IEnumerable<IValidationResult> validationErrors) : base(message)
        {
            this.ValidationCodeResult = new EntityValidationCodeResult(validationErrors);
        }
    }

    public class EntityValidationCodeResult : IValidationCodeResult
    {
        public EntityValidationCodeResult(IEnumerable<IValidationResult> validationErrors)
        {
            this.ValidationErrors = validationErrors;
        }
        public IEnumerable<IValidationResult> ValidationErrors { get; private set; }
    }

    public class ErrorMessageResult : IValidationCodeResult
    {
        public string ErrorMessage { get; set; }
    }

    public interface IValidationCodeResult
    {

    }
}
