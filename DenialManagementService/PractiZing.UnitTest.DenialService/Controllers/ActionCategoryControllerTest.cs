
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;
using Newtonsoft.Json;
using PracticeInsight.Api.DenialService.Controllers;
using PracticeInsight.Base.Entities.DenialService;
using PracticeInsight.Base.Repositories.DenialService;
using PracticeInsight.Base.Repositories.MasterService;
using PracticeInsight.BusinessLogic.DenialService.Repositories;
using PracticeInsight.BusinessLogic.MasterService.Repositories;
using PracticeInsight.DataAccess.Common;
using PracticeInsight.DataAccess.DenialService;
using PracticeInsight.DataAccess.DenialService.Tables;
using PracticeInsight.UnitTest.Common;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using Xunit;

namespace PracticeInsight.UnitTest.MasterService.Controllers
{
    [Order(10)]
    public class ActionCategoryControllerTest : TestClassBase
    {
        private ActionCategoryController _actionCategoryController;
        private IActionCategoryRepository _actionCategoryRepository;
        private static Guid _uId;
        private static int _id;

        public ActionCategoryControllerTest()
        {
            var attFileTableRepository = new Mock<IAttFileTableRepository>();
            var configuration = new Mock<IConfiguration>();
            var attFileRepository = new AttFileRepository(
                                                       new DataAccess.MasterService.ValidationErrorCodes(),
                                                       DependencyResolverTest.DBConnection(),
                                                       DependencyResolverTest.User(),
                                                       configuration.Object,
                                                       attFileTableRepository.Object);
            _actionCategoryRepository = new ActionCategoryRepository(
                                                       new ValidationErrorCodes(),
                                                       DependencyResolverTest.DBConnection(),
                                                       DependencyResolverTest.User(),
                                                       attFileRepository);
            _actionCategoryController = new ActionCategoryController(_actionCategoryRepository);
        }

        [Fact, Order(0)]
        public async void SuccessGetAll()
        {
            AssertTestName("SuccessGetAll");
            var result = await this._actionCategoryController.GetAllCategorey();
            var okResult = result as OkObjectResult;
            Assert.Equal(200, okResult.StatusCode);
        }

        //[Fact, Order(1)]
        //public async void SuccessAddNew()
        //{
        //    AssertTestName("SuccessAddNew");
        //    ActionCategory actionCategory = new ActionCategory();
        //    actionCategory.PracticeId = 1;
        //    actionCategory.CategoryName = DateTime.Now.ToString("ddMMyyyyHHmmss");
        //    actionCategory.DefaultNote = DateTime.Now.ToString("ddMMyyyyHHmmss");
        //    var files = new List<IFormFile>();

        //    var okResult = await this._actionCategoryController.AddNew();
        //    var result = okResult as OkObjectResult;
        //    Assert.IsType<OkObjectResult>(okResult);
        //    Assert.IsType<ActionCategory>(result.Value);
        //    _id = (result.Value as ActionCategory).Id;
        //    _uId = (result.Value as ActionCategory).UId;
        //    Assert.NotEqual(0, (result.Value as ActionCategory).Id);
        //    assert.notequal(new guid(), (result.value as actioncategory).uid);
        //}


        //[Fact, Order(2)]
        //public async void FailedAddNewForRequiredFields()
        //{
        //    AssertTestName("FailedAddNewForRequiredFields");
        //    ActionCategory actionCategory = new ActionCategory();
        //    actionCategory.PracticeId = 1;
        //    var files = new List<IFormFile>();
        //    var okResult = await this._actionCategoryController.AddNew();

        //    var result = okResult as ObjectResult;
        //    var errors = (((EntityValidationCodeResult)result.Value).ValidationErrors).ToList();
        //    Assert.NotNull(errors.FirstOrDefault(i => i.ErrorCode == 0));
        //}

        //[Fact, Order(3)]
        //public async void SuccessUpdate()
        //{
        //    AssertTestName("SuccessUpdate");
        //    ActionCategory actionCategory = new ActionCategory();
        //    actionCategory.PracticeId = 1;
        //    actionCategory.CategoryName = DateTime.Now.ToString("ddMMyyyyHHmmss");
        //    actionCategory.DefaultNote = DateTime.Now.ToString("ddMMyyyyHHmmss");
        //    var files = new List<IFormFile>();
        //    var okResult = await this._actionCategoryController.Update();
        //    Assert.IsType<OkObjectResult>(okResult);
        //    var result = okResult as OkObjectResult;
        //    Assert.IsType<int>(result.Value);
        //    Assert.NotEqual(0, result.Value);
        //}

        //[Fact, Order(4)]
        //public async void FailedUpdateForRequiredFields()
        //{
        //    AssertTestName("FailedUpdateForRequiredFields");
        //    ActionCategory actionCategory = new ActionCategory();
        //    actionCategory.PracticeId = 1;
        //    var files = new List<IFormFile>();
        //    var okResult = await this._actionCategoryController.Update();
        //    var result = okResult as ObjectResult;
        //    var errors = (((EntityValidationCodeResult)result.Value).ValidationErrors).ToList();
        //    Assert.NotNull(errors.FirstOrDefault(i => i.ErrorCode == 0));
        //}

        //[Fact, Order(5)]
        //public async void SuccessGetByUId()
        //{
        //    AssertTestName("SuccessGetByUId");
        //    var okResult = await this._actionCategoryController.Get(_uId);
        //    Assert.IsType<OkObjectResult>(okResult);
        //    var result = okResult as OkObjectResult;
        //    Assert.IsType<ActionCategory>(result.Value);
        //    Assert.Equal(_uId, (result.Value as ActionCategory).UId);
        //}

        //[Fact, Order(6)]
        //public async void SuccessDeleteByUId()
        //{
        //    AssertTestName("SuccessDeleteByUId");
        //    var okResult = await this._actionCategoryController.Delete(_uId);
        //    var result = okResult as OkObjectResult;
        //    Assert.NotEqual(0, result.Value);
        //}

        [Fact, Order(7)]
        public async void FailedGetByUIdForWrongUId()
        {
            AssertTestName("FailedGetByUIdForWrongUId");
            var okResult = await this._actionCategoryController.Get(_uId);
            Assert.IsType<OkObjectResult>(okResult);
            var result = okResult as OkObjectResult;
            Assert.Null(result.Value);
        }
    }
}
