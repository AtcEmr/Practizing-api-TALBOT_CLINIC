using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PractiZing.DataAccess.Common
{
    public abstract class BaseValidationErrorCodes
    {
        public BaseValidationErrorCodes()
        {
            this.ErrorCodes = new Dictionary<int, string>();
        }

        protected virtual void InitializeErrorCodes()
        {
        }

        public virtual void AddErrorCode(Int32 errorCode, string message)
        {
            this.ErrorCodes.Add((int)errorCode, message);
        }

        public virtual KeyValuePair<int, string> this[int errorCode, params object[] formatter]
        {
            get
            {
                string errorMessage = this.ErrorCodes[(int)errorCode];
                var returnValue = new KeyValuePair<int, string>((int)errorCode, formatter.Length > 0 ? string.Format(errorMessage, formatter) : errorMessage);
                return returnValue;
            }
        }

        public Dictionary<int, string> ErrorCodes { get; set; }

        public void Union<T>() where T : BaseValidationErrorCodes, new()
        {
            T codes = new T();
            this.ErrorCodes.Union(codes.ErrorCodes);
        }
    }
}
