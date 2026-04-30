using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace PractiZing.UnitTest.Common
{
    /// <summary>
    /// Custom xUnit test case orderer that uses the OrderAttribute
    /// </summary>
    public class CustomTestCaseOrderer : ITestCaseOrderer
    {
        public const string TypeName = "PractiZing.UnitTest.Common.CustomTestCaseOrderer";
        public const string AssembyName = "PractiZing.UnitTest.Common";
        public static readonly ConcurrentDictionary<string, ConcurrentQueue<string>>
            QueuedTests = new ConcurrentDictionary<string, ConcurrentQueue<string>>();

        public IEnumerable<TTestCase> OrderTestCases<TTestCase>(IEnumerable<TTestCase> testCases)
            where TTestCase : ITestCase
        {
            var orderedCases= testCases.OrderBy(GetOrder);
            foreach(var testCase in orderedCases)
            {
                // Enqueue the test name.
                QueuedTests
                    .GetOrAdd(testCase
                             .TestMethod
                             .TestClass
                             .Class
                             .Name,
                             key => new ConcurrentQueue<string>())
                            .Enqueue(testCase.TestMethod.Method.Name);
            }

            return orderedCases;
        }

        private static int GetOrder<TTestCase>(TTestCase testCase)
            where TTestCase : ITestCase
        {
            

            // Order the test based on the attribute.
            var attr = testCase.TestMethod
                               .Method
                               .ToRuntimeMethod()
                               .GetCustomAttribute<OrderAttribute>();
            return attr?.I ?? 0;
        }
    }
}
