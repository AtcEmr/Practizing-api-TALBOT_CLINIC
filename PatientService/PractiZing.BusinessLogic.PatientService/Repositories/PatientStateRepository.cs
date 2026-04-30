
using PractiZing.Base.Entities.PatientService;
using PractiZing.Base.Entities.SecurityService;
using PractiZing.Base.Repositories.PatientService;
using PractiZing.DataAccess.Common;
using PractiZing.DataAccess.PatientService;
using PractiZing.DataAccess.PatientService.Tables;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PractiZing.BusinessLogic.PatientService.Repositories
{
    public class PatientStateRepository : ModuleBaseRepository<PatientState>, IPatientStateRepository
    {
        private IPatientStateRepository _patientStateRepository;
        public PatientStateRepository(ValidationErrorCodes validationErrorCodes,
                                     DataBaseContext dataBaseContext,
                                     ILoginUser loginUser,
                                     IPatientStateRepository patientStateRepository) :
                                     base(validationErrorCodes, dataBaseContext, loginUser)
        {
            this._patientStateRepository = patientStateRepository;
        }

        public async Task<IPatientState> AddNew(IPatientState entity)
        {
            try
            {
                PatientState tEntity = entity as PatientState;

                var error = await base.ValidateEntityToAdd(tEntity);
                if (error.Count() > 0)
                    await this.ThrowEntityException(error);

                var result = await base.AddNewAsync(tEntity);
                return result;
            }
            catch
            {
                throw;
            }
        }

      
    }
}
