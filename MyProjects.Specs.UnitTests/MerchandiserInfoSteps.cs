using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyProject.Specs.Enums;
using MyProject.Specs.Models.GlobalEntity;
using MyProject.Specs.Models.Product;
using MyProjects.Specs.UnitTests.Data.GlobalEntity;
using MyProjects.Specs.UnitTests.Data.Product;
using TechTalk.SpecFlow;

namespace MyProjects.Specs.UnitTests
{
    /// <summary>
    /// This Dto is used to store the test results
    /// </summary>
    public class MerchandiserInfoDto
    {
        public string OfficeCode { get; set; }
        public string MerchCode { get; set; }
        public int BouquetCount { get; set; }
        public bool OfficeCodeIsValid { get; set; }
        public bool OfficeCodeExists { get; set; }
        public bool OfficeCodeIsActive { get; set; }

        public bool MerchCodeIsValid { get; set; }
        public bool MerchCodeExists { get; set; }
        public bool MerchCodeIsActive { get; set; }
        public OfficeCodeValidationResponseEnum OfficeCodeValidationResponse { get; set; }
        public MerchCodeValidationResponseEnum MerchCodeValidationResponse { get; set; }
    }

    [Binding]
    public class MerchandiserInfoSteps
    {
        /// <summary>
        /// Dto to hold the results of the business logic tests below.
        /// </summary>
        private MerchandiserInfoDto _testResult = new MerchandiserInfoDto();

        /// <summary>
        /// This method is left as a Stub for later implementation.
        /// </summary>
        [Given(@"that the user is logged in")]
        public void GivenThatTheUserIsLoggedIn()
        {
            Assert.IsTrue(true);
        }

        /// <summary>
        /// This is where the data that is to be tested is "entered" in the system.
        /// </summary>
        /// <param name="officeCode">A string containing the office code to test.</param>
        /// <param name="merchCode">A string containing the merch code to test.</param>
        [When(@"user enters the '(.*)' '(.*)'")]
        public void WhenUserEntersThe(string officeCode, string merchCode)
        {
            var officeDataMock = new OfficeDataMock();
            var officeModel = new OfficeModel(officeDataMock);

            var merchDataMock = new MerchDataMock();
            var merchModel = new MerchModel(merchDataMock);

            var bouquetOfficeDataMock = new BouquetOfficeDataMock();
            var bouquetOfficeModel = new BouquetOfficeModel(bouquetOfficeDataMock);

            _testResult.OfficeCode = officeCode;
            _testResult.MerchCode = merchCode;

            #region Office Validation Tests
            _testResult.OfficeCodeIsValid = officeModel.OfficeCodeIsValid(officeCode).IsValid;
            _testResult.OfficeCodeExists = officeModel.OfficeCodeExists(officeCode).IsValid;
            _testResult.OfficeCodeIsActive = officeModel.OfficeCodeIsActive(officeCode).IsValid;
            _testResult.OfficeCodeValidationResponse = officeModel.ValidateOfficeCode(officeCode).OfficeCodeValidationResponse;

            //If all the above true, then the Office is valid?
            if (_testResult.OfficeCodeIsValid && _testResult.OfficeCodeExists && _testResult.OfficeCodeIsActive)
            {
                _testResult.OfficeCodeValidationResponse = OfficeCodeValidationResponseEnum.Valid;
            }
            #endregion

            #region MerchCode Validation Tests
            _testResult.MerchCodeIsValid = merchModel.MerchCodeIsValid(merchCode).IsValid;
            _testResult.MerchCodeExists = merchModel.MerchCodeExists(merchCode).IsValid;
            _testResult.MerchCodeIsActive = merchModel.MerchCodeIsActive(merchCode).IsValid;
            _testResult.MerchCodeValidationResponse = merchModel.ValidateMerchCode(merchCode).MerchCodeValidationResponse;

            if (_testResult.MerchCodeIsValid && _testResult.MerchCodeExists && _testResult.MerchCodeIsActive)
            {
                _testResult.MerchCodeValidationResponse = MerchCodeValidationResponseEnum.Valid;
            }
            #endregion
            

            //Get the Bouquets if no errors have occurred.
            if (_testResult.OfficeCodeIsValid && _testResult.OfficeCodeExists && _testResult.OfficeCodeIsActive &&
                _testResult.MerchCodeIsValid && _testResult.MerchCodeExists && _testResult.MerchCodeIsActive)
            {
                _testResult.BouquetCount = bouquetOfficeModel.ReturnBouquetsForOfficeCode(officeCode).BouquetOffice.Count;
            }
        }

        /// <summary>
        /// This is where the results from the model tests in the WhenUserEntersThe method 
        /// are checked for their accuracy against the Table defined as the example in the .features file.
        /// </summary>
        /// <param name="OfficeCodeValidationResponse">The expected office validation response based on the data entered.</param>
        /// <param name="MerchCodeValidationResponse">The expected merchant validation response based on the data entered.</param>
        /// <param name="BouquetCount">The number of bouquets that is expected to be returned.</param>
        /// <param name="OfficeCodeIsValid">Boolean value indicating whether the Office Code is valid.</param>
        /// <param name="MerchCodeIsValid">Boolean value indicating whether the Merch Code is valid.</param>
        /// <param name="OfficeCodeExists">Boolean value indicating whether the Office Code is exists.</param>
        /// <param name="MerchCodeExists">Boolean value indicating whether the Merch Code exists.</param>
        /// <param name="OfficeCodeIsActive">Boolean value indicating whether the Office Code is active.</param>
        /// <param name="MerchCodeIsActive">Boolean value indicating whether the Merch Code is active.</param>
        [Then(@"the result should match '(.*)' '(.*)' (.*) (.*) (.*) (.*) (.*) (.*) (.*)")]
        public void ThenTheResultShouldMatch(string OfficeCodeValidationResponse, string MerchCodeValidationResponse, int BouquetCount, bool OfficeCodeIsValid, bool MerchCodeIsValid, bool OfficeCodeExists, bool MerchCodeExists, bool OfficeCodeIsActive, bool MerchCodeIsActive)
        {
            Assert.AreEqual(_testResult.BouquetCount, BouquetCount);
            Assert.AreEqual(_testResult.OfficeCodeIsValid, OfficeCodeIsValid);
            Assert.AreEqual(_testResult.OfficeCodeExists, OfficeCodeExists);
            Assert.AreEqual(_testResult.OfficeCodeIsActive, OfficeCodeIsActive);
            Assert.AreEqual(_testResult.OfficeCodeValidationResponse.ToString(), OfficeCodeValidationResponse);

            Assert.AreEqual(_testResult.MerchCodeIsValid, MerchCodeIsValid);
            Assert.AreEqual(_testResult.MerchCodeExists, MerchCodeExists);
            Assert.AreEqual(_testResult.MerchCodeIsActive, MerchCodeIsActive);
            Assert.AreEqual(_testResult.MerchCodeValidationResponse.ToString(), MerchCodeValidationResponse);
        }
    }
}
