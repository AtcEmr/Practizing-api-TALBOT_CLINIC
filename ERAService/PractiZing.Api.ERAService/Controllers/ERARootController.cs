using Microsoft.AspNetCore.Mvc;
using PractiZing.Api.Common.Controllers;
using PractiZing.Base.Repositories.ERAService;
using PractiZing.Base.Service.ChargePaymentService;
using PractiZing.Base.Service.ERAService;
using PractiZing.BussinessLogic.ERAService.Service;
using PractiZing.DataAccess.Common;
using System;
using System.Threading.Tasks;

namespace PractiZing.Api.ERAService.Controllers
{
    [Route("api/[controller]")]
    public class ERARootController : SecuredRepositoryController<IERARootRepository>
    {
        private readonly IERARootService _iERARootService;
        private readonly IERAPaymentService _iERAPaymentService;
        private readonly IPaymentObjectConverterService _paymentObjectConverter;

        public ERARootController(IERARootRepository repository, IERARootService iERARootService,
                                 IERAPaymentService iERAPaymentService,
                                 IPaymentObjectConverterService paymentObjectConverter) : base(repository)
        {
            this._iERARootService = iERARootService;
            this._iERAPaymentService = iERAPaymentService;
            this._paymentObjectConverter = paymentObjectConverter;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string checkNo)
        {
            var result = await this._iERARootService.GetStatus(checkNo);
            return Ok(result);
        }

        [HttpGet("DownloadERA/{checkNo}")]
        public async Task<IActionResult> DownloadERA(string checkNo)
        {
            try
            {
                var fileByte = await this.Repository.DownloadFile(checkNo);
                //return File(fileByte.Item1, fileByte.Item2);
                return Ok(fileByte);
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

        [HttpGet("get/{Id}")]
        public async Task<IActionResult> Get(int Id)
        {
            var result = await this._iERARootService.Get(Id);
            return Ok(result);
        }

        [HttpPost("CreatePaymentObject")]
        public async Task<IActionResult> CreateObject([FromBody]object eraClaim)
        {
            try
            {
                var result = await this._paymentObjectConverter.CreateObject(eraClaim);
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

        [HttpPut("UpdateRequest/{Id}")]
        public async Task<IActionResult> SendRequest(int Id)
        {
            try
            {
                var result = await this._paymentObjectConverter.SendRequestOnERAService(Id);
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

        [HttpPut("UpdateRequestwithPolicy/{Id}/{policyNumber}")]
        public async Task<IActionResult> SendRequestWithPolicyNumber(int Id, string policyNumber)
        {
            try
            {
                var result = await this._paymentObjectConverter.SendRequestOnERAServiceWithPolicy(Id, policyNumber);
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

        [HttpGet("errorrecords")]
        public async Task<IActionResult> GetErrorRecords()
        {
            var result = await this._iERARootService.GetErrorStatus();
            return Ok(result);
        }

        [HttpGet("get/errorclaims/{Id}")]
        public async Task<IActionResult> GetErrorclaims(int Id)
        {
            var result = await this._iERARootService.Get(Id, true);
            return Ok(result);
        }
    }
}

