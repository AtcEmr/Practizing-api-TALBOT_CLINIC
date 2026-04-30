using Newtonsoft.Json;
using PractiZing.Base.Entities.ChargePaymentService;
using PractiZing.Base.Entities.SecurityService;
using PractiZing.Base.Object.ChargePaymentService;
using PractiZing.Base.Repositories.ChargePaymentService;
using PractiZing.BusinessLogic.Common;
using PractiZing.DataAccess.ChargePaymentService;
using PractiZing.DataAccess.ChargePaymentService.Objects;
using PractiZing.DataAccess.ChargePaymentService.Tables;
using PractiZing.DataAccess.Common;
using PractiZing.DataAccess.Common.Object;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PractiZing.BusinessLogic.ChargePaymentService.Repositories
{
    public class ScrubErrorRepository : ModuleBaseRepository<ScrubError>, IScrubErrorRepository
    {
        public ScrubErrorRepository(ValidationErrorCodes errorCodes,
                                            DataBaseContext dbContext,
                                            ILoginUser loggedUser
                                            ) : base(errorCodes, dbContext, loggedUser)
        {

        }

        public async Task<IEnumerable<IScrubErrorDTO>> GetAll()
        {
            try
            {
                List<IScrubErrorDTO> scrubErrors = new List<IScrubErrorDTO>();
                List<IScrubErrorDTO> chargeErrorMessages = new List<IScrubErrorDTO>();
                var query = this.Connection.From<ScrubError>()
                                .Join<ScrubError, Invoice>((c, i) => c.InvoiceId == i.Id)
                                .Select<ScrubError, Invoice>((s, inv) => new
                                {
                                    s,
                                    inv.AccessionNumber
                                });

                var queryResult = await this.Connection.SelectAsync<dynamic>(query);
                var result = Mapper<ScrubError>.MapList(queryResult);
                foreach (var item in result)
                {
                    //var error = JsonConvert.DeserializeObject<ScrubErrorJSON>(item.ErrorJson);
                    if (!string.IsNullOrEmpty(item.ErrorMessage))
                    {
                        var errorArray = item.ErrorMessage.Split("<br>");
                        for (int i = 0; i < errorArray.Length; i++)
                        {
                            ScrubErrorDTO scrubError = new ScrubErrorDTO();
                            scrubError.AccessionNumber = item.AccessionNumber;                            
                            var cptAndIcdArray = errorArray[i].Split("|");
                            if (cptAndIcdArray.Length > 0)
                            {
                                scrubError.ErrorMessage = errorArray[0]; // error message
                                scrubError.CPTCode = cptAndIcdArray[1]; // cpt code
                                scrubError.ICDCode = cptAndIcdArray[2]; // icd code
                                scrubError.Modifier = cptAndIcdArray[3]; // modifier
                            }
                            scrubErrors.Add(scrubError);
                        }
                    }

                    //if (error.ChargeErrors != null)
                    //{
                    //    foreach (var chargeError in error.ChargeErrors)
                    //    {
                    //        ScrubErrorDTO scrubError = new ScrubErrorDTO();
                    //        scrubError.AccessionNumber = item.AccessionNumber;
                    //        scrubError.ErrorMessage = chargeError.ErrorMessage;
                    //        chargeErrorMessages.Add(scrubError);
                    //    }
                    //}
                    scrubErrors.AddRange(chargeErrorMessages);
                }

                return scrubErrors;
            }
            catch
            {
                throw;
            }

        }

        public async Task<IEnumerable<IScrubError>> GetByClaimId(int claimId)
        {
            try
            {
                //var scrubError = await this.Connection.SelectAsync<ScrubError>(i => i.ClaimId == claimId);
                var query = this.Connection.From<ScrubError>()
                            .Join<ScrubError, Invoice>((c, i) => c.InvoiceId == i.Id)                           
                            .Select<ScrubError, Invoice>((s, inv) => new
                            {
                                s,
                                inv.AccessionNumber
                            })
                            .Where<ScrubError>(i => i.ClaimId == claimId);

            var queryResult = await this.Connection.SelectAsync<dynamic>(query);
            var scrubError = Mapper<ScrubError>.MapList(queryResult);
            return scrubError;
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<IScrubError>> GetByClaimId(IEnumerable<int> claimIds)
        {
            try
            {
                //var scrubError = await this.Connection.SelectAsync<ScrubError>(i => i.ClaimId == claimId);
                var query = this.Connection.From<ScrubError>()
                            .Join<ScrubError, Invoice>((c, i) => c.InvoiceId == i.Id)
                            .Select<ScrubError, Invoice>((s, inv) => new
                            {
                                s,
                                inv.AccessionNumber
                            })
                            .Where<ScrubError>(i => claimIds.Contains(i.ClaimId));

                var queryResult = await this.Connection.SelectAsync<dynamic>(query);
                var scrubError = Mapper<ScrubError>.MapList(queryResult);

                return scrubError;
            }
            catch
            {
                throw;
            }
        }

        public async Task<IScrubError> AddNew(IScrubError entity)
        {
            try
            {
                ScrubError tEntity = entity as ScrubError;
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

        public async Task DeleteByClaimId(int claimId)
        {
            await this.Connection.DeleteAsync<ScrubError>(i => i.ClaimId == claimId);
            
        }
    }
}
