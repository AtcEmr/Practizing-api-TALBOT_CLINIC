using AutoMapper;
using PractiZing.Base.Common;
using PractiZing.Base.Entities.MasterService;
using PractiZing.Base.Entities.SecurityService;
using PractiZing.Base.Object.CommonEntites;
using PractiZing.Base.Object.MasterServcie;
using PractiZing.Base.Repositories.MasterService;
using PractiZing.BusinessLogic.Common;
using PractiZing.DataAccess.ChargePaymentService.Tables;
using PractiZing.DataAccess.Common;
using PractiZing.DataAccess.MasterService.Tables;
using PractiZing.DataAccess.PatientService.Object;
using PractiZing.DataAccess.SecurityService;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PractiZing.BusinessLogic.MasterService.Repositories
{
    public class ProviderRepository : ModuleBaseRepository<Provider>, IProviderRepository
    {
        private readonly IMapper _mapper;
        private IFacilityRepository _facilityRepository;
        public ProviderRepository(DataAccess.MasterService.ValidationErrorCodes errorCodes,
                                                            DataBaseContext dbContext,
                                                            ILoginUser loggedUser,
                                                            IFacilityRepository facilityRepository,
                                                            IMapper mapper)
        : base(errorCodes, dbContext, loggedUser)
        {
            _mapper = mapper;
            _facilityRepository = facilityRepository;
        }

        /// <summary>
        /// Get Providers with their speciality
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<IPaginationQuery<IProvider>> GetProviderList(SearchQuery<IProviderFilter> entity)
        {
            try
            {
                var query = this.Connection
                              .From<Provider>()
                              .LeftJoin<Provider, User>((i, j) => i.PUserId == j.Id)
                              .LeftJoin<Provider, ConfigProviderSpecialty>((p, s) => p.SpecialtyId == s.Id)
                              .LeftJoin<Provider, ConfigPractitionerService>((c, i) => c.PractitionerServiceId == i.Id, this.Connection.JoinAlias("MHQual"))
                              .LeftJoin<Provider, ConfigPractitionerService>((c, i) => c.SUDPractitionerServiceId == i.Id, this.Connection.JoinAlias("SUDQual"))
                              .Select<Provider, User, ConfigProviderSpecialty, ConfigPractitionerService>((i, j, k,x) => new
                              {
                                  i,
                                  j.UserName,
                                  SpecialityName = k.Description,
                                  ProfessionalAbbreviation = Sql.JoinAlias(x.ProfessionalAbbreviation, "MHQual"),
                                  ProvidingService = Sql.JoinAlias(x.ProvidingService, "MHQual"),
                                  Designation = Sql.JoinAlias(x.Designation, "MHQual"),
                                  SUDProfessionalAbbreviation = Sql.JoinAlias(x.ProfessionalAbbreviation, "SUDQual"),
                                  SUDProvidingService = Sql.JoinAlias(x.ProvidingService, "SUDQual"),
                              })
                               .OrderBy<Provider>(i => i.LastName);

                string selectExpression = $"{query.SelectExpression} {query.FromExpression}";
                string countExpression = query.ToCountStatement();

                string whereExpression = await WhereClauseProvider<IProviderFilter>.GetWhereClause(entity.Filter);
                entity.SortExpression = query.OrderByExpression;

                string defaultExpression = $"{query.Where<Provider>(i => i.PracticeId == LoggedUser.PracticeId).WhereExpression.Replace("@0", $"{LoggedUser.PracticeId}")}".Replace("WHERE", "");
                whereExpression = string.IsNullOrEmpty(whereExpression) ? defaultExpression : defaultExpression + " AND " + whereExpression;

                var result = await this.Connection.QueryPagination<Provider, IProviderFilter>(entity, selectExpression, whereExpression, countExpression);

                foreach (var item in result.Data)
                {
                    item.IsProviderAUser = ((string.IsNullOrEmpty(item.UserName)) ? false : true);                    
                    if(item.SupervisorId.HasValue && item.SupervisorId.Value>0)
                    {
                        var superVisor = result.Data.FirstOrDefault(i => i.Id == item.SupervisorId);
                        if(superVisor!=null)
                        {
                            item.SupervisorName= string.IsNullOrEmpty(superVisor.Middle) ? $"{superVisor.LastName} {superVisor.FirstName}" : $"{superVisor.LastName} {superVisor.FirstName}, {superVisor.Middle}";
                        }
                            
                    }
                }
                    

                return new PaginationQuery<IProvider>(result.Data, result.TotalRecords);
            }
            catch
            {
                throw;
            }
        }

        public async Task<IProvider> GetById(Int16 id)
        {
            return await this.Connection.SingleAsync<Provider>(i => i.Id == id && i.PracticeId == LoggedUser.PracticeId);
        }

        public async Task<IProvider> GetByEmrId(int id)
        {
            return await this.Connection.SingleAsync<Provider>(i => i.EmrProviderId == id && i.PracticeId == LoggedUser.PracticeId);
        }

        public async Task<IProvider> GetByUId(Guid uid, bool isForInternalUser = false)
        {
            if (isForInternalUser)
            {
                return await this.Connection.SingleAsync<Provider>(i => i.UId == uid && i.PracticeId == LoggedUser.PracticeId);
            }
            var query = this.Connection.From<Provider>()
                                       .LeftJoin<Provider, User>((i, j) => i.PUserId == j.Id)
                                       .LeftJoin<Provider, Facility>((p, f) => p.FacilityId == f.Id)
                                       .LeftJoin<Provider, ConfigPractitionerService>((p, f) => p.PractitionerServiceId == f.Id)
                                       .LeftJoin<Provider, ConfigProviderSpecialty>((p, s) => p.SpecialtyId == s.Id)
                                       .LeftJoin<Provider, Provider>((p, pr) => Sql.JoinAlias(p.SupervisorId, "Provider".ToString()) == pr.Id, this.Connection.JoinAlias("Supervisior"))
                                       .LeftJoin<Provider, Provider>((p, pr) => Sql.JoinAlias(p.SwapProviderId, "Provider".ToString()) == pr.Id, this.Connection.JoinAlias("SwapProvider"))
                                       .Select<Provider, User, ConfigProviderSpecialty, Facility, ConfigPractitionerService>((i, j, k, f,x) => new
                                       {
                                           i,
                                           j.UserName,
                                           SpecialityName = k.Description,
                                           FacilityUId = f.UId,
                                           SupervisorUId= Sql.JoinAlias(i.UId, "Supervisior"),
                                           SwapProviderUId = Sql.JoinAlias(i.UId, "SwapProvider"),
                                           ProfessionalAbbreviation = x.ProfessionalAbbreviation
                                           //SupervisorUId = i.UId
                                       })
                                       .Where(i => i.UId == uid && i.PracticeId == LoggedUser.PracticeId);

            var dynamicResult = await this.Connection.SelectAsync<dynamic>(query);
            var result = Mapper<Provider>.Map(dynamicResult);
            if (result != null)
                result.IsProviderAUser = string.IsNullOrEmpty(result.UserName) ? false : true;
            return result;
        }

        public async Task<IProvider> GetByIdWithQualification(short id)
        {
            
            var query = this.Connection.From<Provider>()
                                       .LeftJoin<Provider, ConfigPractitionerService>((p, f) => p.PractitionerServiceId == f.Id)
                                       .Select<ConfigPractitionerService>(( x) => new
                                       {   
                                           ProfessionalAbbreviation = x.ProfessionalAbbreviation                                           
                                       })
                                       .Where(i => i.Id == id && i.PracticeId == LoggedUser.PracticeId);

            var dynamicResult = await this.Connection.SelectAsync<dynamic>(query);
            var result = Mapper<Provider>.Map(dynamicResult);
            if (result != null)
                result.IsProviderAUser = string.IsNullOrEmpty(result.UserName) ? false : true;
            return result;
        }

        public async Task<IProvider> GetByIdWithQualificationSUD(short id)
        {

            var query = this.Connection.From<Provider>()
                                       .LeftJoin<Provider, ConfigPractitionerService>((p, f) => p.SUDPractitionerServiceId == f.Id)
                                       .Select<ConfigPractitionerService>((x) => new
                                       {
                                           ProfessionalAbbreviation = x.ProfessionalAbbreviation
                                       })
                                       .Where(i => i.Id == id && i.PracticeId == LoggedUser.PracticeId);

            var dynamicResult = await this.Connection.SelectAsync<dynamic>(query);
            var result = Mapper<Provider>.Map(dynamicResult);
            if (result != null)
                result.IsProviderAUser = string.IsNullOrEmpty(result.UserName) ? false : true;
            return result;
        }

        /// <summary>
        /// Get Provider for given identifier
        /// </summary>
        /// <param name="npi"></param>
        /// <returns></returns>
        public async Task<IProvider> Get(string npi)
        {
            var query = this.Connection.From<Provider>()
                .Join<Provider, ProviderIdentity>((p, pi) => p.Id == pi.ProviderId)
                .Join<ProviderIdentity, ConfigIdType>((p, c) => p.TypeId == c.Id)
                .Select<Provider>(p => new
                {
                    p
                }).Where<Provider, ProviderIdentity>((pr, p) => p.Identifier == npi && pr.PracticeId == LoggedUser.PracticeId);


            var dynamicResult = await this.Connection.SelectAsync<dynamic>(query);

            return Mapper<Provider>.Map(dynamicResult);
        }

        public async Task<IEnumerable<IProvider>> GetByFacilityUId(Guid facilityUId)
        {
            var query = this.Connection
                            .From<Provider>()
                            .Join<Provider, Facility>((p, f) => p.FacilityId == f.Id)
                            .Select<Provider>(p => new
                            {
                                p
                            })
                            .Where<Provider, Facility>((p, f) => f.UId == facilityUId && p.PracticeId == LoggedUser.PracticeId);

            return await this.Connection.QueryAsync<Provider, Provider>(query, facilityUId.ToString(), LoggedUser.PracticeId);
        }

        public async Task<IEnumerable<IProvider>> GetAll()
        {
            return (await this.Connection.SelectAsync<Provider>(i => i.PracticeId == LoggedUser.PracticeId)).OrderBy(i => i.FullName);
        }

        public async Task<IEnumerable<IDropDownDTO>> GetForDDO()
        {
            var providers = await this.GetAll();
            var result = new List<DropDownDTO>();
            foreach (var item in providers)
            {
                var ddoItem = new DropDownDTO();
                ddoItem.label = item.FullName;
                ddoItem.value = item.UId;
                result.Add(ddoItem);
            }
            return result;
        }

        private async Task DefaultProvider()
        {
            var _provider = await this.GetDefaultProvider();
            if (_provider != null)
            {
                _provider.FacilityUId = _provider.FacilityId == null ? Guid.Empty : (await this._facilityRepository.GetById(_provider.FacilityId)).UId;
                _provider.IsDefault = false;
                await Update(_provider);
            }
        }

        public async Task<IProvider> GetDefaultProvider()
        {
            return await this.Connection.SingleAsync<Provider>(i => i.IsDefault == true && i.PracticeId == LoggedUser.PracticeId);
        }

        public async Task<IEnumerable<IProviderDTO>> GetProviderDTO()
        {
            var query = this.Connection
                            .From<Provider>()
                            .LeftJoin<Provider, ConfigPractitionerService>((c, i) => c.PractitionerServiceId == i.Id, this.Connection.JoinAlias("MHQual"))
                         .LeftJoin<Provider, ConfigPractitionerService>((c, i) => c.SUDPractitionerServiceId == i.Id, this.Connection.JoinAlias("SUDQual"))
                         .LeftJoin<Provider, ConfigPractitionerService>((c, i) => c.PractitionerServiceId == i.Id)
                            .LeftJoin<ConfigPractitionerService,CPTModifier>((a, b) => a.CPTModifier_Id==b.ID)
                            .LeftJoin<Provider, Provider>((p, pr) => Sql.JoinAlias(p.SupervisorId, "Provider".ToString()) == pr.Id, this.Connection.JoinAlias("Supervisior"))
                            .LeftJoin<Provider, Facility>((a, b) => a.FacilityId== b.Id)
                            .Select<Provider, CPTModifier, Facility, ConfigPractitionerService>((p,x,f, cps) => new
                            {
                                p,
                                Modifier=x.Code,
                                SupervisorId = Sql.JoinAlias(p.Id, "Supervisior"),
                                SupervisorUId = Sql.JoinAlias(p.UId, "Supervisior"),
                                FacilityUId=f.UId,
                                Qualification = Sql.JoinAlias(cps.ProfessionalAbbreviation, "MHQual"),
                                SUDQualification = Sql.JoinAlias(cps.ProfessionalAbbreviation, "SUDQual"),
                            })
                            .Where<Provider>(p=>  p.PracticeId == LoggedUser.PracticeId);

            var dynamicResult = await this.Connection.SelectAsync<dynamic>(query);

            var result = _mapper.Map<List<ProviderDTO>>(dynamicResult);


            //var res = await this.Connection.SelectAsync<Provider>(i => i.PracticeId == LoggedUser.PracticeId && i.IsActive == true);

            //var result = _mapper.Map<List<ProviderDTO>>(res);

            return result.OrderBy(i => i.LastName);
        }

        public async Task<IEnumerable<IProviderDTO>> GetSupervisionProviderDTO()
        {
            var query = this.Connection
                            .From<Provider>()
                            .LeftJoin<Provider, ConfigPractitionerService>((p, f) => p.PractitionerServiceId == f.Id)
                            .LeftJoin<ConfigPractitionerService, CPTModifier>((a, b) => a.CPTModifier_Id == b.ID)
                            .LeftJoin<Provider, Provider>((p, pr) => Sql.JoinAlias(p.SupervisorId, "Provider".ToString()) == pr.Id, this.Connection.JoinAlias("Supervisior"))
                            .Select<Provider, CPTModifier>((p, x) => new
                            {
                                p,
                                Modifier = x.Code,
                                SupervisorId = Sql.JoinAlias(p.Id, "Supervisior"),
                                SupervisorUId = Sql.JoinAlias(p.UId, "Supervisior"),
                            })
                            .Where<Provider,ConfigPractitionerService>((p,x) => p.PracticeId == LoggedUser.PracticeId && x.CanBeSupervision==true);

            var dynamicResult = await this.Connection.SelectAsync<dynamic>(query);

            var result = _mapper.Map<List<ProviderDTO>>(dynamicResult);


            //var res = await this.Connection.SelectAsync<Provider>(i => i.PracticeId == LoggedUser.PracticeId && i.IsActive == true);

            //var result = _mapper.Map<List<ProviderDTO>>(res);

            return result.OrderBy(i => i.LastName);
        }

        public async Task<IProvider> AddNew(IProvider entity)
        {
            try
            {
                Provider tEntity = entity as Provider;
                var facility = await this._facilityRepository.GetByUId(entity.FacilityUId);
                entity.FacilityId = facility.Id;
                if (entity.SupervisorUId.HasValue)
                {
                    var supervisor = await this.GetByUId(entity.SupervisorUId.Value, true);
                    entity.SupervisorId = supervisor.Id;
                }

                if (entity.SwapProviderUId.HasValue)
                {
                    var swapProvider = await this.GetByUId(entity.SwapProviderUId.Value, true);
                    entity.SwapProviderId = swapProvider.Id;
                }

                /*Check user wants to make this Provider as a Default Provider.
               In that case first check, there is already exist default Provider. if yes, then make previous Provider to No Default Provider
               then update the given Provider as a Default Provider.*/
                if (tEntity.IsDefault == true)
                    await this.DefaultProvider();

                var errors = await this.ValidateEntityToAdd(tEntity);
                if (errors.Count() > 0)
                    await this.ThrowEntityException(errors);

                var result = await base.AddNewAsync(tEntity);
                result.UserName = entity.UserName;
                result.IsProviderAUser = entity.IsProviderAUser;

                return result;
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> Update(IProvider entity)
        {
            try
            {
                Provider tEntity = entity as Provider;
                if(entity.FacilityId==0)
                entity.FacilityId = entity.FacilityUId == Guid.Empty ? (short)0 : (await this._facilityRepository.GetByUId(entity.FacilityUId)).Id;
                if (entity.SupervisorUId.HasValue)
                {
                    var supervisor = await this.GetByUId(entity.SupervisorUId.Value, true);
                    entity.SupervisorId = supervisor.Id;
                }
                else
                {
                    entity.SupervisorId = null;
                }

                if (entity.SwapProviderUId.HasValue)
                {
                    var swapProvider = await this.GetByUId(entity.SwapProviderUId.Value, true);
                    entity.SwapProviderId = swapProvider.Id;
                }
                else
                {
                    entity.SwapProviderId = null;
                }

                /*Check user wants to make this Provider as a Default Provider.
                  In that case first check, there is already exist default Provider. if yes, then make previous Provider to No Default Provider
                  then update the given Provider as a Default Provider.*/

                if (tEntity.IsDefault == true)
                    await this.DefaultProvider();

                var errors = await this.ValidateEntityToUpdate(tEntity);
                if (errors.Count() > 0)
                    await this.ThrowEntityException(errors);

                var updateOnlyFields = this.Connection
                                       .From<Provider>()
                                       .Update(x => new
                                       {
                                           x.PUserId,
                                           x.LastName,
                                           x.FirstName,
                                           x.Middle,
                                           x.Suffix,
                                           x.Prefix,
                                           x.FacilityId,
                                           x.IsActive,
                                           x.License,
                                           x.Signature,
                                           x.TOC,
                                           x.Slot,
                                           x.SSN,
                                           x.SpecialtyId,
                                           x.Specialty,
                                           x.BillUnderGroupNPI,
                                           x.IsDefault,
                                           x.ModifiedDate,
                                           x.ModifiedBy,
                                           x.SupervisionTypeId,
                                           x.SupervisorId,
                                           x.PractitionerServiceId,
                                           x.IsBillUnderSupervisor,
                                           x.ServiceCircumstanceId,
                                           x.IsPrescriber,
                                           x.SwapProviderId,
                                           x.SUDPractitionerServiceId
                                       })
                                       .Where(i => i.UId == entity.UId && i.PracticeId == LoggedUser.PracticeId);

                return await base.UpdateOnlyAsync(tEntity, updateOnlyFields);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<int> Delete(Int16 id)
        {
            try
            {
                return await this.Connection.DeleteAsync<Provider>(i => i.Id == id && i.PracticeId == LoggedUser.PracticeId);
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<IProvider>> GetByUId(IEnumerable<Guid> Ids)
        {
            return await this.Connection.SelectAsync<Provider>(i => Ids.Contains(i.UId) && i.PracticeId == LoggedUser.PracticeId);
        }

        public async Task ThrowError()
        {
            await this.ThrowEntityException(new ValidationCodeResult("Performing and Supervising Provider should not be same."));
        }
    }
}