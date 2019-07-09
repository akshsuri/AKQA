using Microsoft.VisualStudio.TestTools.UnitTesting;
using Application.NumToWords.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Http;
using System.Threading.Tasks;
using System.Web.Http.Results;

namespace Application.NumToWords.Controllers.Tests
{
    [TestClass()]
    public class NumToWordsAPIControllerTests
    {
        private NumToWordsAPIController controller;
        private TestContext testContextInstance;
        private static string number;
        private static string decimalNo;
        private static string negativeNo;
        private static string expectednumber;
        private static string expecteddecimalNo;
        private static string expectednegativeNo;
        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
            number = "12345";
            expectednumber = "TWELVE THOUSAND THREE HUNDRED FOURTY FIVE DOLLARS";
            decimalNo = "1234.5";
            expecteddecimalNo = "ONE THOUSAND TWO HUNDRED THIRTY FOUR DOLLARS AND FIVE CENTS";
            negativeNo = "-123";
            expectednegativeNo = "MINUS ONE HUNDRED TWENTY THREE DOLLARS";
        }
        [ClassCleanup()]
        public static void MyClassCleanup()
        {
            number = expectednumber = decimalNo = expecteddecimalNo = negativeNo = expectednegativeNo = string.Empty;
        }

        // Use TestInitialize to run code before running each test 
        [TestInitialize()]
        public void TestInit()
        {
            controller = new NumToWordsAPIController();
        }

        // Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void TestCleanup()
        {
            controller = null;
        }

        [TestMethod()]
        public void numberTest()    
        {
            IHttpActionResult actionResult = controller.convert(number);
            var contentResult = actionResult as OkNegotiatedContentResult<string>;            

            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(contentResult.Content.Trim(), expectednumber);
        }
        [TestMethod()]
        public void decimalTest()
        {
            IHttpActionResult actionResult = controller.convert(decimalNo);
            var contentResult = actionResult as OkNegotiatedContentResult<string>;

            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(contentResult.Content.Trim(), expecteddecimalNo);
        }
        [TestMethod()]
        public void negativeTest()
        {
            IHttpActionResult actionResult = controller.convert(negativeNo);
            var contentResult = actionResult as OkNegotiatedContentResult<string>;

            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(contentResult.Content.Trim(), expectednegativeNo);
        }
    }
}