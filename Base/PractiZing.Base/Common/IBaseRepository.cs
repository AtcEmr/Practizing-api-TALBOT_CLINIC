using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;

namespace PractiZing.Base.Common
{
    public interface IBaseRepository
    {
        void ValidateModel(IEnumerable<ModelError> allErrors, bool isValidModelState, bool validateRequiredFields = true);
    }
}
