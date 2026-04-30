using PractiZing.Base.Entities.PatientService;
using PractiZing.Base.Entities.SecurityService;
using PractiZing.Base.Repositories.PatientService;
using PractiZing.DataAccess.Common;
using PractiZing.DataAccess.PatientService;
using PractiZing.DataAccess.PatientService.Tables;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace PractiZing.BusinessLogic.PatientService.Repositories
{
    public class PatientStatementRepository : ModuleBaseRepository<PatientStatement>, IPatientStatementRepository
    {

        public PatientStatementRepository(ValidationErrorCodes errorCodes,
                                          DataBaseContext dbContext,
                                          ILoginUser loggedUser) : base(errorCodes, dbContext, loggedUser)
        {
        }

        public async Task<IEnumerable<IPatientStatement>> GetAll(int patientId)
        {
            return await this.Connection.SelectAsync<PatientStatement>(i => i.PracticeId == LoggedUser.PracticeId && i.PatientId == patientId);
        }

        public async Task<IEnumerable<IPatientStatement>> GetById(int Id)
        {
            return await this.Connection.SelectAsync<PatientStatement>(i => i.PracticeId == LoggedUser.PracticeId && i.Id == Id);
        }

        public async Task<IPatientStatement> Get(Guid uId)
        {
            return await this.Connection.SingleAsync<PatientStatement>(i => i.PracticeId == LoggedUser.PracticeId && i.UId == uId);
        }

        public async Task<IPatientStatement> AddNew(IPatientStatement entity)
        {
            try
            {
                PatientStatement tEntity = entity as PatientStatement;
                tEntity.PracticeId = LoggedUser.PracticeId;
                tEntity.CreatedBy = LoggedUser.UserName;
                tEntity.CreatedDate = DateTime.Now;
                tEntity.FromDate = entity.FromDate;
                tEntity.ToDate = entity.ToDate;

                var errors = await this.ValidateEntityToAdd(tEntity);
                if (errors.Count() > 0)
                    await this.ThrowEntityException(errors);

                return await base.AddNewAsync(tEntity);
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> Delete(string uid)
        {
            return await this.Connection.DeleteAsync<PatientStatement>(i => i.UId == Guid.Parse(uid) && i.PracticeId == LoggedUser.PracticeId);
        }

        public async Task<string> GetPatientByIds(List<string> ids)
        {
            var list = await this.Connection.SelectAsync<Patient>(i => i.PracticeId == LoggedUser.PracticeId && ids.Contains(i.Id.ToString()));
            string patientIds = "";
            list.ToList().ForEach((item) =>
            {
                if (string.IsNullOrWhiteSpace(patientIds))
                {
                    patientIds = item.UId.ToString();
                }
                else
                {
                    patientIds += "," + item.UId.ToString();
                }

            });
            return patientIds;
        }

        public async Task<int> GetCount(int batchStatementId)
        {
            return (await this.Connection.SelectAsync<PatientStatement>(i => i.PracticeId == LoggedUser.PracticeId && i.BatchStatementId == batchStatementId)).Count();
        }
    }
}
