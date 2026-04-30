using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PractiZing.Api.Common.Controllers;
using PractiZing.Base.Common;
using PractiZing.Base.Object.MasterServcie;
using PractiZing.Base.Repositories.MasterService;
using PractiZing.Base.Service.MasterService;
using PractiZing.DataAccess.Common;
using PractiZing.DataAccess.MasterService.Objects;
using PractiZing.DataAccess.MasterService.Tables;

namespace PractiZing.Api.MasterService.Controllers
{
    [Route("api/[controller]")]
    public class ProviderController : SecuredRepositoryController<IProviderRepository>
    {
        private readonly IProviderService _providerService;

        public ProviderController(IProviderRepository ProviderRepository, IProviderService providerService) : base(ProviderRepository)
        {
            _providerService = providerService;
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await this.Repository.GetAll();
            return Ok(result);
        }

        [HttpGet("getForDDO")]
        public async Task<IActionResult> GetForDDO()
        {
            var result = await this.Repository.GetForDDO();
            return Ok(result);
        }

        [HttpGet("getByUId/{UId}")]
        public async Task<IActionResult> GetByUId(Guid UId)
        {
            var result = await this.Repository.GetByUId(UId);
            return Ok(result);
        }

        [HttpGet("getByNPI/{npi}")]
        public async Task<IActionResult> Get(string npi)
        {
            var result = await this.Repository.Get(npi);
            return Ok(result);
        }

        [HttpGet("getByFacility/{facilityUId}")]
        public async Task<IActionResult> GetByFacilityUId(Guid facilityUId)
        {
            var result = await this.Repository.GetByFacilityUId(facilityUId);
            return Ok(result);
        }

        [HttpGet("getProviderList")]
        public async Task<IActionResult> GetProviderList([FromQuery]SearchQuery<ProviderFilter> entity)
        {
            var queryInterface = SearchQuery.Map<ProviderFilter, IProviderFilter>(entity);
            var result = await this.Repository.GetProviderList(queryInterface);
            return Ok(result);
        }

        [HttpGet("getProviderDTO")]
        public async Task<IActionResult> GetProviderDTO()
        {
            var result = await this.Repository.GetProviderDTO();
            return Ok(result);
        }

        [HttpGet("getSupervisionProviderDTO")]
        public async Task<IActionResult> GetSupervisionProviderDTO()
        {
            var result = await this.Repository.GetSupervisionProviderDTO();
            return Ok(result);
        }

        [HttpGet("DefaultProvider")]
        public async Task<IActionResult> GetDefaultProvider()
        {
            var result = await this.Repository.GetDefaultProvider();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddNew([FromBody]Provider entity)
        {
            try
            {
                this.Repository.ValidateModel(ModelState.Values.SelectMany(v => v.Errors), ModelState.IsValid);
                var result = await this._providerService.AddProvider(entity);
                return Ok(result);
            }
            catch (EntityException ex)
            {
                return StatusCode(400, ex.ValidationCodeResult);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody]Provider entity)
        {
            try
            {
                //this.Repository.ValidateModel(ModelState.Values.SelectMany(v => v.Errors), ModelState.IsValid);
                var result = await this._providerService.Update(entity);
                return Ok(result);
            }
            catch (EntityException ex)
            {
                return StatusCode(400, ex.ValidationCodeResult);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
