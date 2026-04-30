using PractiZing.Base.Entities.MasterService;
using PractiZing.Base.Entities.SecurityService;
using PractiZing.Base.Repositories.MasterService;
using PractiZing.DataAccess.Common;
using PractiZing.DataAccess.MasterService;
using PractiZing.DataAccess.MasterService.Tables;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using PractiZing.BusinessLogic.Common;
using AutoMapper;
using PractiZing.DataAccess.MasterService.Objects;
using PractiZing.Base.Object.MasterServcie;

namespace PractiZing.BusinessLogic.MasterService.Repositories
{
    public class ConfigAdjustmentReasonCodeRepository : ModuleBaseRepository<ConfigAdjustmentReasonCode>, IConfigAdjustmentReasonCodeRepository
    {
        
        public ConfigAdjustmentReasonCodeRepository(ValidationErrorCodes errorCodes,
                                                    DataBaseContext dbContext,
                                                    ILoginUser loggedUser)
       : base(errorCodes, dbContext, loggedUser)
        {
        }

        public async Task<IConfigAdjustmentReasonCode> AddNew(IConfigAdjustmentReasonCode entity)
        {
            try
            {
                ConfigAdjustmentReasonCode tEntity = entity as ConfigAdjustmentReasonCode;
                var errors = await this.ValidateEntityToAdd(tEntity);
                if (errors.Count() > 0)
                {
                    await this.ThrowEntityException(errors);
                }

                var result = await base.AddNewEntity(tEntity);
                return result;
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> Delete(string reasonCode)
        {
            try
            {
                var result = await this.Connection.DeleteAsync<ConfigAdjustmentReasonCode>(i => i.ReasonCode == reasonCode);
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IEnumerable<IConfigAdjustmentReasonCode>> GetAll()
        {
            var result = (await this.Connection.SelectAsync<ConfigAdjustmentReasonCode>()).OrderBy(i => i.ReasonCode);
            return result;
        }

        public async Task<IEnumerable<IConfigAdjustmentReasonCode>> GetAllWriteOff()
        {
            var result = (await this.Connection.SelectAsync<ConfigAdjustmentReasonCode>(i=>i.IsForWriteOff==true)).OrderBy(i => i.ReasonCode);
            return result;
        }

        public async Task<IEnumerable<IConfigAdjustmentReasonCode>> GetAll(string reasonCode)
        {
            reasonCode = reasonCode == null ? "" : reasonCode;
            var result = (await this.Connection.SelectAsync<ConfigAdjustmentReasonCode>(i => (reasonCode == "" || i.Code.Contains(reasonCode)) || (reasonCode == "" || i.ReasonCode.Contains(reasonCode)) || (reasonCode == "" || i.GroupCode.Contains(reasonCode)))).OrderBy(i => i.Code);
            return result.OrderBy(i => i.Code);
        }

        public async Task<IEnumerable<IConfigAdjustmentReasonCode>> Get(string reasonCode)
        {
            reasonCode = reasonCode == null ? "" : reasonCode;
            var result = (await this.Connection.SelectAsync<ConfigAdjustmentReasonCode>(i => i.ReasonCode == reasonCode)).OrderBy(i => i.Code);
            return result.OrderBy(i => i.Code);
        }

        public async Task<IConfigAdjustmentReasonCode> GetByReasonCode(string groupCode, string code)
        {
            var result = await this.Connection.SingleAsync<ConfigAdjustmentReasonCode>(i => i.GroupCode == groupCode && i.Code == code);
            return result;
        }

        /// <summary>
        /// get unselected codes list when new category is added and isARScategory is marked as selected
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<IConfigAdjustmentReasonCode>> GetRemarkCode()
        {
            try
            {
                var _configAdjustmentReasonCodes = await this.Connection.SelectAsync<ConfigAdjustmentReasonCode>();
                var _ars = await this.Connection.SelectAsync<ARSCategoryReasonCode>();
                var _arscategoryreasonCodes = _ars.Select(i => i.ReasonCode);

                var result = _configAdjustmentReasonCodes.Where(m => !_arscategoryreasonCodes.Contains(m.ReasonCode) && m.ActiveFlag == 1);

                _configAdjustmentReasonCodes.ToList().ForEach(x => x.Selected = false);
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        ///get left side reason code grid for editing
        /// </summary>
        /// <param name="NotesCategoryId"></param>
        /// <returns>
        /// codes on that notesCategoryId and unselected codes
        /// </returns>
        public async Task<IEnumerable<IConfigAdjustmentReasonCode>> Get(int NotesCategoryId)
        {
            try
            {
                var query = this.Connection.From<ConfigAdjustmentReasonCode>()
                    .LeftJoin<ConfigAdjustmentReasonCode, ARSCategoryReasonCode>((adj, ars) => adj.ReasonCode == ars.ReasonCode
                                                                                             && ars.NotesCategoryId == NotesCategoryId)
                    .Select<ConfigAdjustmentReasonCode, ARSCategoryReasonCode>((adj, ars) => new
                    {
                        RemarkQualifier = "",
                        adj.ReasonCode,
                        adj.Description,
                        NotesCategoryId = ars.NotesCategoryId
                    }
                    );

                var reasonCodes = (await this.Connection.SelectAsync<ARSCategoryReasonCode>(i => i.NotesCategoryId != NotesCategoryId)).Select(i => i.ReasonCode);
                var dynamicResult = await this.Connection.SelectAsync<dynamic>(query);

                var results = Mapper<ConfigAdjustmentReasonCode>.MapList(dynamicResult);
                results = results.Where(m => !reasonCodes.Contains(m.ReasonCode));
                results.ToList().ForEach(x => x.Selected = (x.NotesCategoryId > 0) ? true : false);

                return results;
            }
            catch
            {
                throw;
            }
        }

        public async Task<long> Update(IConfigAdjustmentReasonCode entity)
        {
            try
            {
                ConfigAdjustmentReasonCode tEntity = entity as ConfigAdjustmentReasonCode;

                var updateOnlyFields = this.Connection
                                      .From<ConfigAdjustmentReasonCode>()
                                      .Update(x => new
                                      {
                                          x.Description,
                                          x.ActiveFlag
                                      })
                                      .Where<ConfigAdjustmentReasonCode>(i => i.ReasonCode == tEntity.ReasonCode);

                var result = await this.Connection.UpdateOnlyAsync<ConfigAdjustmentReasonCode>(tEntity, updateOnlyFields);
                return result;
            }
            catch
            {
                throw;
            }
        }
    }
}
