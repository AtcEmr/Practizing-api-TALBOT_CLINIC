using Microsoft.AspNetCore.Mvc;
using PractiZing.Api.Common.Controllers;
using PractiZing.Base.Repositories.MasterService;
using PractiZing.Base.Service.MasterService;
using PractiZing.DataAccess.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PractiZing.Api.MasterService.Controllers
{
    [Route("api/[controller]")]
    public class AttFileController : SecuredRepositoryController<IAttFileRepository>
    {
        private IReportService _reportService;
        private IAttService _attService;
        public AttFileController(IAttFileRepository attFileRepository, IReportService reportService, IAttService attService) : base(attFileRepository)
        {
            this._reportService = reportService;
            this._attService = attService;
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(IEnumerable<string> uids)
        {
            try
            {
                await this.Repository.Delete(uids);
                return Ok(1);
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

        [HttpGet("DownloadFile")]
        public async Task<IActionResult> DownloadFile(string uid)
        {
            try
            {
                //this.Repository.ValidateModel(ModelState.Values.SelectMany(v => v.Errors), ModelState.IsValid);
                var fileByte = await this._attService.DownloadFile(uid);
                return File(fileByte.Item1, fileByte.Item2);
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

        [HttpGet("DownloadStatement")]
        public async Task<IActionResult> DownloadStatement(string uid)
        {
            try
            {
                //this.Repository.ValidateModel(ModelState.Values.SelectMany(v => v.Errors), ModelState.IsValid);
                var fileByte = await this._reportService.DownloadFile(uid);
                return File(fileByte.Item1, fileByte.Item2);
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

        [HttpGet("DownloadBatchStatement")]
        public async Task<IActionResult> DownloadBatchStatement(string uid)
        {
            try
            {
                //this.Repository.ValidateModel(ModelState.Values.SelectMany(v => v.Errors), ModelState.IsValid);
                var fileByte = await this._reportService.DownloadBatchStatementFile(uid);
                return File(fileByte.Item1, fileByte.Item2);
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

        [HttpGet("UploadBatchStatement")]
        public async Task<IActionResult> UploadBatchStatement(string uid)
        {
            try
            {
                await this._reportService.UploadBatchStatementFile(uid);
                return Ok();
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

        [HttpGet("UploadBatchStatementOnly")]
        public async Task<IActionResult> UploadBatchStatementOnly(string uid)
        {
            try
            {
                await this._reportService.UploadBatchStatementOnly(uid);
                return Ok();
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
