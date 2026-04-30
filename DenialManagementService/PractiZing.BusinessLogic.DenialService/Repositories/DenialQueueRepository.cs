using PractiZing.Base.Entities.ChargePaymentService;
using PractiZing.Base.Entities.DenialService;
using PractiZing.Base.Entities.SecurityService;
using PractiZing.Base.Enums.DenialService;
using PractiZing.Base.Model.DenialService;
using PractiZing.Base.Object.DenialService;
using PractiZing.Base.Repositories.ChargePaymentService;
using PractiZing.Base.Repositories.DenialService;
using PractiZing.Base.Repositories.MasterService;
using PractiZing.Base.Repositories.SecurityService;
using PractiZing.BusinessLogic.Common;
using PractiZing.DataAccess.Common;
using PractiZing.DataAccess.DenialService;
using PractiZing.DataAccess.DenialService.Model;
using PractiZing.DataAccess.DenialService.Object;
using PractiZing.DataAccess.DenialService.Tables;
using PractiZing.DataAccess.ReportService.Objects;
using PractiZing.DataAccess.ReportService.Tables;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PractiZing.BusinessLogic.DenialService.Repositories
{
    public class DenialQueueRepository : ModuleBaseRepository<DenialQueue>, IDenialQueueRepository
    {
        private IChargesRepository _chargeRespository;
        private IPaymentChargeRepository _paymentChargeRepository;
        private IPaymentAdjustmentRepository _paymentAdjustmentRepository;
        private IInsuranceCompanyRepository _insuranceCompanyRepository;
        private IConfigInsuranceCompanyTypeRepository _insuranceCompanyTypeRepository;
        private readonly IARSCategoryReasonCodeRepository _aRSCategoryReasonCodeRepository;
        private IUserRepository _userRepository;

        public DenialQueueRepository(ValidationErrorCodes errorCodes,
                                     DataBaseContext dbContext,
                                     ILoginUser loggedUser,
                                     IChargesRepository chargeRespository,
                                     IPaymentChargeRepository paymentChargeRepository,
                                     IPaymentAdjustmentRepository paymentAdjustmentRepository,
                                     IConfigInsuranceCompanyTypeRepository insuranceCompanyTypeRepository,
                                     IInsuranceCompanyRepository insuranceCompanyRepository,
                                     IUserRepository userRepository,
                                     IARSCategoryReasonCodeRepository aRSCategoryReasonCodeRepository
                                     ) : base(errorCodes, dbContext, loggedUser)
        {
            this._chargeRespository = chargeRespository;
            this._paymentChargeRepository = paymentChargeRepository;
            this._paymentAdjustmentRepository = paymentAdjustmentRepository;
            this._insuranceCompanyRepository = insuranceCompanyRepository;
            this._aRSCategoryReasonCodeRepository = aRSCategoryReasonCodeRepository;
            this._insuranceCompanyTypeRepository = insuranceCompanyTypeRepository;
            this._userRepository = userRepository;
        }

        public async Task<IDenialQueue> AddNew(IDenialQueue entity)
        {
            try
            {
                DenialQueue tEntity = entity as DenialQueue;
                return await base.AddNewAsync(tEntity);
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
                return await this.Connection.DeleteAsync<DenialQueue>(i => i.Id == id && i.PracticeId == LoggedUser.PracticeId);
            }
            catch
            {
                throw;
            }
        }

        public async Task<IDenialQueue> GetById(int id)
        {
            return await this.Connection.SingleAsync<DenialQueue>(i => i.Id == id && i.PracticeId == LoggedUser.PracticeId);
        }

        public async Task<IDenialQueue> GetByUId(Guid UId)
        {
            return await this.Connection.SingleAsync<DenialQueue>(i => i.UId == UId && i.PracticeId == LoggedUser.PracticeId);
        }

        public async Task<IEnumerable<IDenialQueue>> GetAll()
        {
            return await this.Connection.SelectAsync<DenialQueue>(i => i.PracticeId == LoggedUser.PracticeId);
        }

        public async Task<IEnumerable<IDenialQueue>> GetByChargeIds(IList<int> chargeIds)
        {
            return await this.Connection.SelectAsync<DenialQueue>(i => chargeIds.ToList().Contains(i.ChargeId.Value) && i.PracticeId == LoggedUser.PracticeId);
        }

        public async Task<IAssignedFollowUpDTO> GetAssignedFollowUpCount(IList<int> chargeIds)
        {
            try
            {
                //var denial = await GetByChargeIds(chargeIds.ToList());
                var query = this.Connection
                    .From<DenialQueue>()
                //    .Join<DenialQueue, ChargeStat>((dq, cs) => cs.Id == dq.ChargeId)
                    .Select<DenialQueue>(i => new
                    {
                        i.HasFollowUp,
                        i.AssignedTo,
                        i.ChargeId
                    })
                    .Where<DenialQueue>(i => i.ChargeId != null && i.PracticeId == LoggedUser.PracticeId);

                var queryResult = await this.Connection.SelectAsync<dynamic>(query);
                var denial = Mapper<DenialQueue>.MapList(queryResult);
                //var denial = await this.Connection.SelectAsync<DenialQueue>(i => i.ChargeId != null && i.PracticeId == LoggedUser.PracticeId);
                denial = denial.Where(i => chargeIds.Contains(i.ChargeId.Value)).ToList();

                var existingChargeIds = denial.Select(i => i.ChargeId);
                var nonexistingChargeIds = chargeIds.Where(i => !existingChargeIds.Contains(i));

                //var noDenialPresent = existingChargeIds;
                //var noDenialPresent = denial.Select(i => i.ChargeId);
                AssignedFollowUpDTO entity = new AssignedFollowUpDTO();
                entity.AssignedToMeCount = denial.Where(i => i.AssignedTo == LoggedUser.UserName).Count();
                entity.AssignedToOthersCount = (denial.Where(i => i.AssignedTo != LoggedUser.UserName)).Count();
                entity.UnAssignedCount = nonexistingChargeIds == null ? 0 : nonexistingChargeIds.Count();
                entity.FollowUpCount = (denial.Where(i => i.HasFollowUp == true && i.AssignedTo == LoggedUser.UserName)).Count();
                return entity;
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> AddOrUpdate(string chargeUIds, string userUId)
        {
            try
            {
                //var chargesUIds = chargesUIds.Split(",");
                var chargesUIds = chargeUIds.Split(',').ToArray<string>();
                /*for inserting assignedTo in denialQueue, get user details from UId */
                var user = await this._userRepository.GetByUId(Guid.Parse(userUId));

                /*if user is not found for incoming userUId, then throw error*/
                if (user == null)
                    await this.ThrowEntityException(new ValidationCodeResult(ErrorCodes[EnumErrorCode.UserNotFound]));

                var chargeIds = (await this._chargeRespository.GetByUIds(chargesUIds)).ToList();

                /*get all denialQueue data on incoming chargeIds*/
                var existingDenials = await GetByChargeIds(chargeIds);

                /*if denial queue table is empty, then insert data for all incoming chargeIds*/
                if (existingDenials.Count() == 0)
                    await this.AddNew(chargeIds, user.UserName);

                else
                {
                    var existingChargeIds = existingDenials.Select(i => i.ChargeId.Value).ToList();
                    var newChargeIds = chargeIds.Where(i => !existingChargeIds.Contains(i));

                    /*Update data of denial Queue for existing chargeIds*/
                    if (existingChargeIds.Count() > 0)
                        await this.Update(existingChargeIds, user.UserName);

                    /*insert data into denial queue for new chargeIds*/
                    if (newChargeIds.Count() > 0)
                        await this.AddNew(newChargeIds, user.UserName);
                }

                return 1;
            }
            catch
            {
                throw;
            }
        }

        private async Task Update(IList<int> existingChargeIds, string userName)
        {
            var existingDenialQueues = await GetByChargeIds(existingChargeIds);
            foreach (var item in existingDenialQueues)
            {
                item.AssignedBy = LoggedUser.UserName;
                item.AssignedTo = userName;
                await Update(item);
            }
        }

        private async Task AddNew(IEnumerable<int> newChargeIds, string userName)
        {
            DenialQueue denialQueue = new DenialQueue();
            denialQueue.AssignedBy = LoggedUser.UserName;
            denialQueue.AssignedTo = userName;
            denialQueue.IsClosed = false;
            denialQueue.AssignedDate = DateTime.Now;

            foreach (var item in newChargeIds)
            {
                denialQueue.ChargeId = item;
                await AddNew(denialQueue);
            }
        }

        public async Task<int> Update(IDenialQueue entity)
        {
            try
            {
                DenialQueue tEntity = entity as DenialQueue;

                var updateOnlyFields = this.Connection
                                           .From<DenialQueue>()
                                           .Update(x => new
                                           {
                                               x.AssignedTo,
                                               x.AssignedBy,
                                               x.AssignedDate,
                                               x.HasFollowUp,
                                               x.FollowUpDate,
                                               x.IsClosed,
                                               x.LastNoteId,
                                               x.ClosedBy,
                                               x.ClosedDate,
                                               x.ChargeId
                                           })
                                           .Where(i => i.UId == entity.UId && i.PracticeId == LoggedUser.PracticeId);

                var value = await base.UpdateOnlyAsync(tEntity, updateOnlyFields);
                return value;
            }
            catch
            {
                throw;
            }
        }

        public async Task<IDenialManagementScreenDTO> GetAgingCount()
        {
            DenialManagementScreenDTO denialManagementDTO = new DenialManagementScreenDTO();
            denialManagementDTO.DenialManagements = await base.ExecuteStoredProcedureAsync<DenialManagementDTO>("usp_GetDenialManagementAgingCountByRange");
            denialManagementDTO.DenialManagementsByCompanyType = (await base.ExecuteStoredProcedureAsync<DenialManagementInsuranceTypeDTO>("usp_DenialManagementForCompanyType")).Take(5);
            denialManagementDTO.DenialManagementsByCompany = (await base.ExecuteStoredProcedureAsync<DenialManagementInsuranceTypeDTO>("usp_DenialManagementForInsuranceCompany")).Take(5);
            denialManagementDTO.DenialManagementsByAdjustments = (await base.ExecuteStoredProcedureAsync<DenailForAdjustment>("usp_DenialManagementForTotalAdjustment")).Take(5);
            denialManagementDTO.ClaimDetailForDenialDTO = (await base.ExecuteStoredProcedureAsync<ClaimDetailForDenialDTO>("usp_DenialManagementForClaimDetail")).FirstOrDefault();

            return denialManagementDTO;
        }

        public async Task<IDenialManagementFilterDTO> GetFilterForDenialCharge()
        {
            var denialData = await this.GetAgingCount();

            DenialManagementFilterDTO denialManagementFilterDTO = new DenialManagementFilterDTO();
            denialManagementFilterDTO.DenialManagements.DenialManagementDTOs = denialData.DenialManagements;
            denialManagementFilterDTO.DenialManagements.Header = DenialManagementFilterHeaderConstant.Aging;

            denialManagementFilterDTO.DenialManagementsByAdjustments.Header = DenialManagementFilterHeaderConstant.FollowUpCategories;
            denialManagementFilterDTO.DenialManagementsByAdjustments.DenialForAdjustment = denialData.DenialManagementsByAdjustments;

            denialManagementFilterDTO.DenialManagementsByCompany.Header = DenialManagementFilterHeaderConstant.InsuranceCompanies;
            denialManagementFilterDTO.DenialManagementsByCompany.DenialManagementInsuranceTypeDTOs = denialData.DenialManagementsByCompany;

            denialManagementFilterDTO.DenialManagementsByDenialQueue.Header = DenialManagementFilterHeaderConstant.DenialCategories;
            denialManagementFilterDTO.DenialManagementsByDenialQueue.DenialManagementDTOs = denialData.DenialManagementsByDenialQueue;

            denialManagementFilterDTO.DenialManagementsByCompanyType.Header = DenialManagementFilterHeaderConstant.InsuranceCompaniesTypes;
            denialManagementFilterDTO.DenialManagementsByCompanyType.DenialManagementInsuranceTypeDTOs = denialData.DenialManagementsByCompanyType;

            denialManagementFilterDTO.DenialManagements.DenialManagementDTOs.ToList().ForEach((res) =>
            {
                res.IsSelected = false;
            });

            denialManagementFilterDTO.DenialManagementsByAdjustments.DenialForAdjustment.ToList().ForEach((res) =>
            {
                res.IsSelected = false;
            });

            denialManagementFilterDTO.DenialManagementsByCompany.DenialManagementInsuranceTypeDTOs.ToList().ForEach((res) =>
            {
                res.IsSelected = false;
            });

            denialManagementFilterDTO.DenialManagementsByCompanyType.DenialManagementInsuranceTypeDTOs.ToList().ForEach((res) =>
            {
                res.IsSelected = false;
            });

            denialManagementFilterDTO.DenialManagementsByDenialQueue.DenialManagementDTOs.ToList().ForEach((res) =>
            {
                res.IsSelected = false;
            });

            return denialManagementFilterDTO;
        }

        public async Task<IEnumerable<ICharges>> GetCharges(IDenialFilter filter)
        {
            DenialManagementScreenDTO denialManagement = new DenialManagementScreenDTO();
            List<ICharges> charges = new List<ICharges>();

            switch (filter.IsFilterTrue)
            {
                case 1:
                    var filterTags = filter.DenialManagementsTags.Split(",");
                    denialManagement.DenialManagements = await base.ExecuteStoredProcedureAsync<DenialManagementDTO>("usp_GetDenialManagementAgingCountByRangeFilter");
                    denialManagement.DenialManagements = denialManagement.DenialManagements.Where(i => filterTags.Contains(i.Tag));

                    var allCharges = (await this._chargeRespository.GetByIds(denialManagement.DenialManagements.Select(i => i.PatientCount))).ToList();
                    charges.AddRange(allCharges);

                    break;

                case 2:
                    List<IDenailForAdjustment> forAdjustments = new List<IDenailForAdjustment>();
                    var filterAdjustments = filter.DenialAdjustments.Split(",");
                    denialManagement.DenialManagementsByAdjustments = await base.ExecuteStoredProcedureAsync<DenailForAdjustment>("usp_DenialManagementForTotalAdjustmentCharges");

                    foreach (var item in filterAdjustments)
                        forAdjustments.AddRange(denialManagement.DenialManagementsByAdjustments.Where(i => i.ReasonCode.Contains(item)));

                    denialManagement.DenialManagementsByAdjustments = forAdjustments.Distinct();
                    charges.AddRange((await this._chargeRespository.GetByIds(denialManagement.DenialManagementsByAdjustments.Select(i => i.AccountCount))).ToList());

                    break;

                case 3:
                    var filterRowQueue = filter.DenialQueues.Split(",");
                    denialManagement.DenialManagementsByDenialQueue = await base.ExecuteStoredProcedureAsync<DenialManagementDTO>("usp_DenialManagementForTotalAdjustmentCharges");
                    denialManagement.DenialManagementsByDenialQueue = denialManagement.DenialManagementsByDenialQueue.Where(i => filterRowQueue.Contains(i.Tag));

                    charges.AddRange((await this._chargeRespository.GetByIds(denialManagement.DenialManagementsByDenialQueue.Select(i => i.PatientCount))).ToList());

                    break;

                case 4:
                    var filterRowCompany = filter.InsuranceCompanies.Split(",");
                    denialManagement.DenialManagementsByCompany = await base.ExecuteStoredProcedureAsync<DenialManagementInsuranceTypeDTO>("usp_DenialManagementForInsuranceCompanyCharges");
                    denialManagement.DenialManagementsByCompany = denialManagement.DenialManagementsByCompany.Where(i => filterRowCompany.Contains(i.CompanyName));

                    charges.AddRange((await this._chargeRespository.GetByIds(denialManagement.DenialManagementsByCompany, false)).ToList());

                    break;

                case 5:
                    var filterRowCompanyType = filter.InsuranceCompanyTypes.Split(",");
                    denialManagement.DenialManagementsByCompanyType = await base.ExecuteStoredProcedureAsync<DenialManagementInsuranceTypeDTO>("usp_DenialManagementForCompanyTypeCharges");
                    denialManagement.DenialManagementsByCompanyType = denialManagement.DenialManagementsByCompanyType.Where(i => filterRowCompanyType.Contains(i.CompanyType));

                    charges.AddRange((await this._chargeRespository.GetByIds(denialManagement.DenialManagementsByCompanyType, false)).ToList());

                    break;
            }

            return charges.Distinct();
        }

        public async Task<IDenialQueue> GetByChargeId(int chargeId)
        {
            return await this.Connection.SingleAsync<DenialQueue>(i => i.ChargeId == chargeId && i.PracticeId == LoggedUser.PracticeId);
        }

        public async Task<int> UpdateFollowUp(IDenialQueue entity)
        {
            try
            {
                DenialQueue tEntity = entity as DenialQueue;

                var updateOnlyFields = this.Connection
                                           .From<DenialQueue>()
                                           .Update(x => new
                                           {
                                               x.HasFollowUp,
                                               x.FollowUpDate,
                                           })
                                           .Where(i => i.ChargeId == tEntity.ChargeId && i.LastNoteId == tEntity.LastNoteId && i.PracticeId == LoggedUser.PracticeId);

                var value = await base.UpdateOnlyAsync(tEntity, updateOnlyFields);
                return value;
            }
            catch
            {
                throw;
            }
        }

        public async Task<IDenialQueue> CheckDenialQueueExists(int chargeId)
        {
            DenialQueue entity = null;
            var denialQueues = await this.Connection.SelectAsync<DenialQueue>(i => i.ChargeId == chargeId && i.PracticeId == LoggedUser.PracticeId);
            if (denialQueues != null && denialQueues.Count() > 0)
            {
                entity = denialQueues.OrderByDescending(i => i.LastNoteId).FirstOrDefault();
            }
            return entity;
        }
    }
}
