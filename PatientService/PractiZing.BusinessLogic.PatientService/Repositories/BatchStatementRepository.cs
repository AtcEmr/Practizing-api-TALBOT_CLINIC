using PractiZing.Base.Entities.ChargePaymentService;
using PractiZing.Base.Entities.MasterService;
using PractiZing.Base.Entities.PatientService;
using PractiZing.Base.Entities.SecurityService;
using PractiZing.Base.Repositories.MasterService;
using PractiZing.Base.Repositories.PatientService;
using PractiZing.DataAccess.Common;
using PractiZing.DataAccess.PatientService;
using PractiZing.DataAccess.PatientService.Tables;
using PractiZing.Sftp;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PractiZing.BusinessLogic.PatientService.Repositories
{
    public class BatchStatementRepository : ModuleBaseRepository<BatchStatement>, IBatchStatementRepository
    {
        IClearingHouseRepository _clearingHouseRepository;
        IPatientStatementRepository _patientStatementRepository;
        public BatchStatementRepository(IClearingHouseRepository clearingHouseRepository, IPatientStatementRepository patientStatementRepository, ValidationErrorCodes errorCodes,
                                          DataBaseContext dbContext,
                                          ILoginUser loggedUser) : base(errorCodes, dbContext, loggedUser)
        {
            this._clearingHouseRepository = clearingHouseRepository;
            this._patientStatementRepository = patientStatementRepository;
        }

        public async Task<IEnumerable<IBatchStatement>> GetAll()
        {            
            var list= await this.Connection.SelectAsync<BatchStatement>(i => i.PracticeId == LoggedUser.PracticeId);
            foreach (var item in list)
            {
                item.Count=  await this._patientStatementRepository.GetCount(item.Id);
            }
            return list.OrderByDescending(i=>i.Id);
            //return await this.Connection.SelectAsync<BatchStatement>(i => i.PracticeId == LoggedUser.PracticeId);
        }

        public async Task<IEnumerable<IBatchStatement>> GetById(int Id)
        {
            return await this.Connection.SelectAsync<BatchStatement>(i => i.PracticeId == LoggedUser.PracticeId && i.Id == Id);
        }

        public async Task<IBatchStatement> Get(Guid uId)
        {
            return await this.Connection.SingleAsync<BatchStatement>(i => i.PracticeId == LoggedUser.PracticeId && i.UId == uId);
        }

        public async Task<int> Update(Guid uId)
        {
            try
            {
                BatchStatement tEntity = await this.Connection.SingleAsync<BatchStatement>(i => i.UId == uId);
                tEntity.SentDate = DateTime.Now;
                tEntity.SentBy = this.LoggedUser.UserName;
                tEntity.IsSent = true;

                var errors = await this.ValidateEntityToUpdate(tEntity);
                if (errors.Count() > 0)
                    await this.ThrowEntityException(errors);

                var updateOnlyFields = this.Connection
                                       .From<BatchStatement>()
                                       .Update(x => new
                                       {
                                           x.SentDate,
                                           x.IsSent,
                                           x.SentBy
                                       })
                                       .Where(i => i.UId == tEntity.UId && i.PracticeId == LoggedUser.PracticeId);

                return await base.UpdateOnlyAsync(tEntity, updateOnlyFields);
            }
            catch
            {
                throw;
            }
        }

        public async Task<IBatchStatement> AddNew(IBatchStatement entity)
        {
            try
            {
                var list = await this.Connection.SelectAsync<BatchStatement>();
                int maxRecord = 1;
                if (list!=null)
                {
                    maxRecord = list.Count + 1;
                }

                BatchStatement tEntity = entity as BatchStatement;
                tEntity.PracticeId = LoggedUser.PracticeId;
                tEntity.CreatedBy = LoggedUser.UserName;
                tEntity.CreatedDate = DateTime.Now;
                tEntity.IsSent = false;
                tEntity.BatchFileName = (LoggedUser.UserName +"_"+ DateTime.Now.ToShortDateString() + "_" + maxRecord.ToString()).Replace(" ","");
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
            return await this.Connection.DeleteAsync<BatchStatement>(i => i.UId == Guid.Parse(uid) && i.PracticeId == LoggedUser.PracticeId);
        }

        public async Task<bool> SaveFileOnSFTPFile(string fileName,string extension,byte[] content)
        {
            try
            {
                var clearingHouse = await this._clearingHouseRepository.GetById(1);
                SftpService sftpService = GetSftpService(clearingHouse);
                
                await sftpService.UploadAsync(fileName, extension, content);

                return true;
            }
            catch
            {
                
                throw;
            }
        }


        private static SftpService GetSftpService(IClearingHouse clearingHouse)
        {
            return new SftpService(clearingHouse.Host, clearingHouse.HostPort.Value,
                clearingHouse.UserName, clearingHouse.Password,
                clearingHouse.ClaimDirectory, clearingHouse.ClaimExtension,
                clearingHouse.ERADirectory, clearingHouse.ERAExtension, clearingHouse.AckDirectory,
                clearingHouse.AckExtension, clearingHouse.StatementDirectory, clearingHouse.StatementExtension);
        }
    }
}
