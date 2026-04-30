using PractiZing.Base.Entities.ChargePaymentService;
using PractiZing.Base.Entities.SecurityService;
using PractiZing.Base.Repositories.ChargePaymentService;
using PractiZing.DataAccess.Common;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ServiceStack.OrmLite;
using PractiZing.BusinessLogic.Common;
using PractiZing.DataAccess.MasterService.Objects;
using PractiZing.Base.Repositories.MasterService;

namespace PractiZing.BusinessLogic.ChargePaymentService.Repositories
{
    public class ConfigHCFAFormFieldRepository : ModuleBaseRepository<ConfigHCFAFormField>, IConfigHCFAFormFieldRepository
    {
        private IInsuranceCompanyRepository _insuranceCompanyRepository;
        public ConfigHCFAFormFieldRepository(DataAccess.ChargePaymentService.ValidationErrorCodes errorCodes,
                                            DataBaseContext dbContext,
                                            ILoginUser loggedUser,
                                            IInsuranceCompanyRepository insuranceCompanyRepository
                                            ) : base(errorCodes, dbContext, loggedUser)
        {
            _insuranceCompanyRepository = insuranceCompanyRepository;
        }

        public async Task<IConfigHCFAFormField> AddNew(IConfigHCFAFormField entity)
        {
            try
            {
                ConfigHCFAFormField tEntity = entity as ConfigHCFAFormField;
                var errors = await this.ValidateEntityToAdd(tEntity);
                if (errors.Count() > 0)
                    await this.ThrowEntityException(errors);

                var data = await this.GetAllByInsuranceCompanyUId(tEntity.InsuranceCompanyOrTypeId, tEntity.CompanyTypeId, null, true);

                foreach (var item in data)
                {
                    item.InsuranceCompanyOrTypeId = (item.ViewType == 1) ? -item.CompanyTypeId :
                                                  ((item.ViewType == 2) ? item.InsuranceCompanyOrTypeId
                                                  : item.InsuranceCompanyOrTypeId);
                }

                var _res = data.FirstOrDefault() as ConfigHCFAFormField;
                var result = _res != null ? await base.AddNewEntity(_res) : await base.AddNewEntity(_res);
                return result;
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> Update(IConfigHCFAFormField entity)
        {
            try
            {
                ConfigHCFAFormField tEntity = entity as ConfigHCFAFormField;
                var errors = await this.ValidateEntityToUpdate(tEntity);
                if (errors.Count() > 0)
                    await this.ThrowEntityException(errors);

                var updateOnlyFields = this.Connection
                                        .From<ConfigHCFAFormField>()
                                            .Update(x => new
                                            {

                                                x.AuthNum,
                                                x.Blank11abc,
                                                x.Blank9abcd,
                                                x.BlankBalance,
                                                x.Box11,
                                                x.Box11dBlank,
                                                x.Box14,
                                                x.Box17Over,
                                                x.Box1aBlank,
                                                x.Box23,
                                                x.Box24,
                                                x.Box31Clinic,
                                                x.Box33,
                                                x.Box33bSpace,
                                                x.Box9a,
                                                x.Box9aPrefix,
                                                x.Box9cAddress,
                                                x.Box9dPayorId,
                                                x.Box9Same,
                                                x.ClaimType,
                                                x.EoB,
                                                x.ExcludeAdjustments,
                                                x.FacilityNum,
                                                x.FilingCode,
                                                x.GroupNPI,
                                                x.GRP,
                                                x.InsuranceCompanyOrTypeId,
                                                x.LabOnly,
                                                x.MedigapOnly
                                            })
                                            .Where(i => i.InsuranceCompanyOrTypeId == tEntity.InsuranceCompanyOrTypeId);

                var value = await base.UpdateOnlyAsync(tEntity, updateOnlyFields);
                return value;
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<IConfigHCFAFormField>> GetAllByInsuranceCompanyUId(int insuranceCompanyId, int insuranceCompanyTypeId, string insuranceCompanyUId, bool IsAddNew)
        {
            try
            {
                var query1 = this.Connection
                            .From<ConfigHCFAFormField>()
                            //.LeftJoin<ConfigHCFAFormField, ConfigIdType>((hcfa, it) => hcfa.FacilityNum == it.Id)
                            //.LeftJoin<ConfigHCFAFormField, ConfigIdType>()
                            .Select<ConfigHCFAFormField>(i => new
                            { i }
                            );

                if (!IsAddNew)
                {
                    var company = await this._insuranceCompanyRepository.GetByUId(Guid.Parse(insuranceCompanyUId));
                    insuranceCompanyId = company != null ? company.Id : 0;
                }

                // part 1 of sp
                query1 = query1.Where<ConfigHCFAFormField>(i => i.InsuranceCompanyOrTypeId == insuranceCompanyId);

                var queryResult = await this.Connection.SelectAsync<dynamic>(query1);
                if (queryResult.Count() == 0)

                //part 2 of sp
                {
                    var res = await this.Connection.SelectAsync<ConfigHCFAFormField>(i => i.InsuranceCompanyOrTypeId == insuranceCompanyId);
                    if (res.Count() == 0)
                    {
                        query1 = query1.Where<ConfigHCFAFormField>(i => i.InsuranceCompanyOrTypeId == -insuranceCompanyTypeId);

                        queryResult = await this.Connection.SelectAsync<dynamic>(query1);
                    }
                }

                //part 3 of sp
                if (queryResult.Count() == 0)
                {
                    var res = await this.Connection.SelectAsync<ConfigHCFAFormField>(i => i.InsuranceCompanyOrTypeId == insuranceCompanyId &&
                    i.InsuranceCompanyOrTypeId == -insuranceCompanyTypeId);
                    if (res.Count() == 0)
                        query1 = query1.Where<ConfigHCFAFormField>(i => i.InsuranceCompanyOrTypeId == 0);

                    queryResult = await this.Connection.SelectAsync<dynamic>(query1);
                }

                return Mapper<ConfigHCFAFormField>.MapList(queryResult);
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<IConfigHCFAFormField>> Get(string insuranceCompanyUId)
        {
            var insuranceCompany = await this._insuranceCompanyRepository.GetByUId(Guid.Parse(insuranceCompanyUId));
            var insuranceCompanyId = insuranceCompany != null ? insuranceCompany.Id : 0;
            return await this.Connection.SelectAsync<ConfigHCFAFormField>(i => i.InsuranceCompanyOrTypeId != insuranceCompanyId);
        }

        public async Task<int> Delete(int insuranceCompanyOrTypeId)
        {
            return await this.Connection.DeleteAsync<ConfigHCFAFormField>(i => i.InsuranceCompanyOrTypeId == insuranceCompanyOrTypeId);
        }

        public async Task<IConfigHCFAFormField> GetByInsuranceCompanyUId(string insuranceCompanyUId)
        {
            var company = await this._insuranceCompanyRepository.GetByUId(Guid.Parse(insuranceCompanyUId));
            var insuranceCompanyId = company != null ? company.Id : 0;
            return await this.Connection.SingleAsync<ConfigHCFAFormField>(i => i.InsuranceCompanyOrTypeId == insuranceCompanyId);
        }
    }
}


