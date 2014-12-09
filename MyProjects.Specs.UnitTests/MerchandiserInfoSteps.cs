﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyProject.Specs.Models.GlobalEntity;
using MyProject.Specs.Models.Product;
using MyProjects.Specs.UnitTests.Models.GlobalEntity.Mock;
using MyProjects.Specs.UnitTests.Models.Product.Mock;
using TechTalk.SpecFlow;

namespace MyProjects.Specs.UnitTests.Features
{
    /// <summary>
    /// This Dto is used to store the test results
    /// </summary>
    public class MerchandiserInfoDto
    {
        public string OfficeCode { get; set; }
        public string MerchCode { get; set; }
        public string Response { get; set; }
        public int BouquetCount { get; set; }
        public bool IsValid { get; set; }
        public bool OfficeCodeIsValid { get; set; }
        public bool OfficeCodeExists { get; set; }
        public bool OfficeCodeIsActive { get; set; }

        public bool MerchCodeIsValid { get; set; }
        public bool MerchCodeExists { get; set; }
        public bool MerchCodeIsActive { get; set; }
    }

    [Binding]
    public class MerchandiserInfoSteps
    {
        /// <summary>
        /// Dto to hold the results of the business logic tests below.
        /// </summary>
        private MerchandiserInfoDto _testResult = new MerchandiserInfoDto();

        [Given(@"that the user is logged in")]
        public void GivenThatTheUserIsLoggedIn()
        {
            Assert.IsTrue(true);
        }

        [When(@"user enters the '(.*)' '(.*)'")]
        public void WhenUserEntersThe(string officeCode, string merchCode)
        {
            var officeDataMock = new OfficeDataMock();
            var officeModel = new OfficeModel(officeDataMock);

            var merchDataMock = new MerchDataMock();
            var merchModel = new MerchModel(merchDataMock);

            var bouquetOfficeDataMock = new BouquetOfficeDataMock();
            var bouquetOfficeModel = new BouquetOfficeModel(bouquetOfficeDataMock);

            string errorMessage = string.Empty;

            _testResult.OfficeCode = officeCode;
            _testResult.MerchCode = merchCode;        

            _testResult.OfficeCodeIsValid = officeModel.OfficeCodeIsValid(officeCode, ref errorMessage);
            _testResult.OfficeCodeExists = officeModel.OfficeCodeExists(officeCode, ref errorMessage);
            _testResult.OfficeCodeIsActive = officeModel.OfficeCodeIsActive(officeCode, ref errorMessage);

            _testResult.MerchCodeIsValid = merchModel.MerchCodeIsValid(merchCode, ref errorMessage);
            _testResult.MerchCodeExists = merchModel.MerchCodeExists(merchCode, ref errorMessage);
            _testResult.MerchCodeIsActive = merchModel.MerchCodeIsActive(merchCode, ref errorMessage);

            if (_testResult.OfficeCodeIsValid && _testResult.OfficeCodeExists && _testResult.OfficeCodeIsActive &&
                _testResult.MerchCodeIsValid && _testResult.MerchCodeExists && _testResult.MerchCodeIsActive)
            {
                _testResult.BouquetCount = bouquetOfficeModel.ReturnBouquetsForOfficeCode(officeCode, ref errorMessage).Count;
            }
        }

        /// <summary>
        /// This is where the results from the model tests in the WhenUserEntersThe method 
        /// are checked for their accuracy against the Table defined as the example in the .features file.
        /// </summary>
        /// <param name="Response">The expected response based on the data entered.</param>
        /// <param name="BouquetCount">The number of bouquets that is expected to be returned.</param>
        /// <param name="OfficeCodeIsValid">Boolean value indicating whether the </param>
        /// <param name="MerchCodeIsValid"></param>
        /// <param name="OfficeCodeExists"></param>
        /// <param name="MerchCodeExists"></param>
        /// <param name="OfficeCodeIsActive"></param>
        /// <param name="MerchCodeIsActive"></param>
        [Then(@"the result should match '(.*)' (.*) (.*) (.*) (.*) (.*) (.*) (.*)")]
        public void ThenTheResultShouldMatchFalseFalseFalseFalseFalseFalse(string Response, int BouquetCount, bool OfficeCodeIsValid, bool MerchCodeIsValid, bool OfficeCodeExists, bool MerchCodeExists, bool OfficeCodeIsActive, bool MerchCodeIsActive)
        {
            Assert.AreEqual(_testResult.BouquetCount, BouquetCount);
            Assert.AreEqual(_testResult.OfficeCodeIsValid, OfficeCodeIsValid);
            Assert.AreEqual(_testResult.OfficeCodeExists, OfficeCodeExists);
            Assert.AreEqual(_testResult.OfficeCodeIsActive, OfficeCodeIsActive);

            Assert.AreEqual(_testResult.MerchCodeIsValid, MerchCodeIsValid);
            Assert.AreEqual(_testResult.MerchCodeExists, MerchCodeExists);
            Assert.AreEqual(_testResult.MerchCodeIsActive, MerchCodeIsActive);
        }
    }
}