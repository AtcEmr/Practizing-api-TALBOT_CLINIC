using PractiZing.Base.Common;
using PractiZing.Base.Entities.MasterService;
using PractiZing.Base.Entities.SecurityService;
using PractiZing.Base.Repositories.MasterService;
using PractiZing.DataAccess.Common;
using PractiZing.DataAccess.MasterService;
using PractiZing.DataAccess.MasterService.Tables;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PractiZing.BusinessLogic.MasterService.Repositories
{
    public class DrugClassRepository : ModuleBaseRepository<DrugClass>, IDrugClassRepository
    {
        private ICPTCodeRepository _CPTCodeRepository;
        public DrugClassRepository(ValidationErrorCodes errorCodes, DataBaseContext dbContext, ICPTCodeRepository CPTCodeRepository, ILoginUser loggedUser) : base(errorCodes, dbContext, loggedUser)
        {
            _CPTCodeRepository = CPTCodeRepository;
        }

        public async Task<IEnumerable<IDrugClass>> GetAll()
        {
            return (await this.Connection.SelectAsync<DrugClass>()).OrderBy(i => i.DrugCode);

        }

        public async Task<IDrugClass> GetById(int id)
        {
            return await this.Connection.SingleAsync<DrugClass>(i => i.Id == id);

        }

        public async Task<IDrugClass> AddNew(IDrugClass entity)
        {
            try
            {
                ICollection<IValidationResult> errors = new List<IValidationResult>();
                IDrugClass tCode = null;
                var codeStatus = await this.Connection.SingleAsync<DrugClass>(i => i.DrugCode == entity.DrugCode);
                if (codeStatus != null)
                {
                    errors.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.DrugCodeAlreadyExists]));
                    await this.ThrowEntityException(errors);
                }
                else
                {
                    DrugClass tEntity = entity as DrugClass;
                    var result = await this.Connection.InsertAsync<DrugClass>(tEntity, selectIdentity: true);
                    tCode = await this.GetById(result);
                    return tCode;
                }

                return tCode;
            }
            catch
            {
                throw;
            }
        }

        public async Task<long> Update(IDrugClass entity)
        {
            try
            {
                DrugClass tEntity = entity as DrugClass;
                tEntity.ModifiedDate = DateTime.Now;
                var updateOnlyFields = this.Connection
                                      .From<DrugClass>()
                                      .Update(x => new
                                      {
                                          x.Description,
                                          x.IsActive
                                      })
                                      .Where<DrugClass>(i => i.Id == tEntity.Id);

                var result = await this.Connection.UpdateOnlyAsync<DrugClass>(tEntity, updateOnlyFields);
                return result;
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> Delete(int id)
        {
            try
            {
                ICollection<IValidationResult> errors = new List<IValidationResult>();

                var result = await _CPTCodeRepository.GetCPTCodeByDrugClassId(id);
                if (result != null)
                {
                    errors.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.DrugClassAlreadyExists]));
                }

                if (errors.Count == 0)
                {
                    var deleteRecord = await this.Connection.DeleteByIdAsync<DrugClass>(id);
                    return deleteRecord;
                }
                await this.ThrowEntityException(errors);
                return 0;

            }
            catch
            {
                throw;
            }
        }
    }
}
