using PractiZing.Base.Entities.ChargePaymentService;
using PractiZing.Base.Entities.SecurityService;
using PractiZing.Base.Repositories.ChargePaymentService;
using PractiZing.DataAccess.ChargePaymentService;
using PractiZing.DataAccess.ChargePaymentService.Tables;
using PractiZing.DataAccess.Common;
using ServiceStack.OrmLite;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PractiZing.BusinessLogic.ChargePaymentService.Repositories
{
    public class ScrubCodingRepository : ModuleBaseRepository<ScrubCoding>, IScrubCodingRepository
    {
        public ScrubCodingRepository(ValidationErrorCodes errorCodes,
                                            DataBaseContext dbContext,
                                            ILoginUser loggedUser
                                            ) : base(errorCodes, dbContext, loggedUser)
        {

        }

        public async Task<IEnumerable<IScrubCoding>> GetByPatientCase(int patientCaseId)
        {
            var scrubCoding = await this.Connection.SelectAsync<ScrubCoding>(i => i.PatientCaseId == patientCaseId);
            return scrubCoding;
            
        }

        public async Task<IScrubCoding> AddNew(IScrubCoding entity, int count)
        {
            try
            {
                ScrubCoding tEntity = entity as ScrubCoding;
                var errors = await this.ValidateEntityToAdd(tEntity);
                if (errors.Count() > 0)
                    await this.ThrowEntityException(errors);

                if (count == 0)
                    await this.DeleteExistScrubError(tEntity.PatientCaseId);
                return await base.AddNewAsync(tEntity);
            }
            catch
            {
                throw;
            }
        }

        private async Task DeleteExistScrubError(int patientCaseId)
        {
            await this.Connection.DeleteAsync<ScrubCoding>(i => i.PatientCaseId == patientCaseId);
            
        }
    }
}
