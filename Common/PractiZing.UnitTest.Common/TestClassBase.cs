using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using PractiZing.BusinessLogic.Common;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PractiZing.UnitTest.Common
{
    /// <summary>
    /// These tests only succeed if you run all tests in the class.
    /// </summary>
    [TestCaseOrderer(CustomTestCaseOrderer.TypeName, CustomTestCaseOrderer.AssembyName)]
    public class TestClassBase
    {
        protected static int I;
        public IServiceProvider Services;
        protected void AssertTestName(string testName)
        {
            var type = GetType();
            var queue = CustomTestCaseOrderer.QueuedTests[type.FullName];
            string dequeuedName;
            var result = queue.TryDequeue(out dequeuedName);
            Assert.True(result);
            Assert.Equal(testName, dequeuedName);
        }
        public TestClassBase()
        {
            var builder = new WebHostBuilder().UseStartup<TestStartUp>().Build();
            Services = new WebHostBuilder().UseStartup<TestStartUp>().Build().Services;            
        }
    }
}
