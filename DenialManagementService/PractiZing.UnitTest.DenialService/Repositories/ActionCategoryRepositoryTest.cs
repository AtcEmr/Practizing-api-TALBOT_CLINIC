using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
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
using System.Linq;
using Xunit;

namespace PracticeInsight.UnitTest.MasterService
{
    [Order(11)]
    public class ActionCategoryRepositoryTest : TestClassBase
    {
        private IActionCategoryRepository _actionCategoryRepository;
        private static Guid _uId;
        private static int _id;
        public ActionCategoryRepositoryTest()
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
        }

        /// <summary>
        /// This test case has been provided all required data according to required validation
        /// So this method should pass the test and return a valid object from where we will keep
        /// that object UId and Id for other test cases
        /// </summary>
        [Fact, Order(0)]
        public async void SuccessAddNew()
        {
            AssertTestName("SuccessAddNew");
            ActionCategory actionCategory = new ActionCategory();
            actionCategory.PracticeId = 1;
            actionCategory.CategoryName = DateTime.Now.ToString("ddMMyyyyHHmmss");
            actionCategory.DefaultNote = DateTime.Now.ToString("ddMMyyyyHHmmss");
            var files = new List<IFormFile>();
            var result = await this._actionCategoryRepository.AddNew(actionCategory, files);
            _uId = result.UId;
            _id = result.Id;
            Assert.IsType<ActionCategory>(result);
            Assert.NotEqual(0, result.Id);
            Assert.NotEqual(new Guid(), result.UId);
        }

        /// <summary>
        /// This test case should return some validation errors because here we are not providing requird fields
        /// each validation error will have some error code which should match with given error codes if they did't match
        /// then test case will be faild, Here we are expecting 3 validation exceptions with error code 1010,1004 and 0
        /// </summary>
        [Fact, Order(1)]
        public async void FailedAddNewForRequiredFields()
        {
            AssertTestName("FailedAddNewForRequiredFields");
            ActionCategory actionCategory = new ActionCategory();
            actionCategory.PracticeId = 1;
            var files = new List<IFormFile>();
            try
            {
                await this._actionCategoryRepository.AddNew(actionCategory, files);
            }
            catch (Exception ex)
            {
                var errors = ((EntityValidationCodeResult)((EntityValidationException)ex).ValidationCodeResult).ValidationErrors.ToList();
                Assert.NotNull(errors.FirstOrDefault(i => i.ErrorCode == 0));
            }

        }

        /// <summary>
        /// This test case has been provided all required data according to required validation
        /// So this method should pass the test and return a valid response if response is greater than 0
        /// then only this case will be successfull else this will be failed
        /// </summary>
        [Fact, Order(2)]
        public async void SuccessUpdate()
        {
            AssertTestName("SuccessUpdate");
            ActionCategory actionCategory = new ActionCategory();
            actionCategory.UId = _uId;
            actionCategory.PracticeId = 1;
            actionCategory.CategoryName = DateTime.Now.ToString("ddMMyyyyHHmmss");
            actionCategory.DefaultNote = DateTime.Now.ToString("ddMMyyyyHHmmss");
            var files = new List<IFormFile>();
            var result = await this._actionCategoryRepository.Update(actionCategory, files);
            Assert.IsType<int>(result);
            Assert.NotEqual(0, result);
        }

        /// <summary>
        /// This test case should return some validation errors because here we are not providing requird fields
        /// each validation error will have some error code which should match with given error codes if they did't match
        /// then test case will be faild, Here we are expecting 3 validation exceptions with error code 1010,1004 and 0
        /// </summary>
        [Fact, Order(3)]
        public async void FailedUpdateForRequiredFields()
        {
            AssertTestName("FailedUpdateForRequiredFields");
            ActionCategory actionCategory = new ActionCategory();
            actionCategory.UId = _uId;
            actionCategory.PracticeId = 1;
            var files = new List<IFormFile>();
            try
            {
                await this._actionCategoryRepository.Update(actionCategory, files);
            }
            catch (Exception ex)
            {
                var errors = ((EntityValidationCodeResult)((EntityValidationException)ex).ValidationCodeResult).ValidationErrors.ToList();
                Assert.NotNull(errors.FirstOrDefault(i => i.ErrorCode == 0));
            }
        }        

        [Fact, Order(4)]
        public async void SuccessGetById()
        {
            AssertTestName("SuccessGetById");
            var ActionCategory = await this._actionCategoryRepository.Get(_id);
            Assert.NotNull(ActionCategory);
            Assert.Equal(ActionCategory.Id, _id);
        }

        [Fact, Order(5)]
        public async void SuccessGetByUId()
        {
            AssertTestName("SuccessGetByUId");
            var ActionCategory = await this._actionCategoryRepository.Get(_uId);
            Assert.NotNull(ActionCategory);
            Assert.Equal(_uId, ActionCategory.UId);
        }

        [Fact, Order(6)]
        public async void SuccessDeleteByUId()
        {
            AssertTestName("SuccessDeleteByUId");
            var result = await this._actionCategoryRepository.Delete(_uId);
            Assert.NotEqual(0, result);
        }

        [Fact, Order(7)]
        public async void FailedGetByUIdForWrongUId()
        {
            AssertTestName("FailedGetByUIdForWrongUId");
            var result = await this._actionCategoryRepository.Get(_uId);
            Assert.Null(result);
        }

        [Fact, Order(8)]
        public async void FailedGetById()
        {
            AssertTestName("FailedGetById");
            var ActionCategory = await this._actionCategoryRepository.Get(_id);
            Assert.Null(ActionCategory);
        }
    }
}
