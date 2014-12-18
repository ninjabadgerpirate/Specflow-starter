using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyProject.Specs.Enums;
using MyProject.Specs.Models.GlobalEntity;
using MyProject.Specs.ViewModels;
using MyProjects.Specs.UnitTests.Data.Exceptions;
using MyProjects.Specs.UnitTests.Data.GlobalEntity;
using TechTalk.SpecFlow;

namespace MyProjects.Specs.UnitTests
{
    [Binding]
    public class GlobalEntitySteps
    {
        /// <summary>
        /// The Dto used to contain the expected results of the tests.
        /// </summary>
        private GlobalEntityTestDto _testResult;

        /// <summary>
        /// The DTO to contain the test results of the GlobalEntity tests.
        /// </summary>
        public class GlobalEntityTestDto
        {
            public string GovID { get; set; }
            public string FirstNames { get; set; }
            public string Surname { get; set; }
            public string PreferredName { get; set; }
            public string Passport { get; set; }
            public string CountryID { get; set; }
            public string LUCPreferredLanguage { get; set; }
            public string LUCMaritalStatus { get; set; }
            public string EmployerName { get; set; }
            public string EmployeeNo { get; set; }
            public string SalaryPayDay { get; set; }
            public string LUCIncomeCategory { get; set; }
            public bool? IsStaff { get; set; }
            public string LUCTitle { get; set; }
            public GovIDValidationResponseEnum GovIDValidationResponse { get; set; }
            public GovIDExceptionStatusEnum GovIDExceptionStatus { get; set; }
        }

        /// <summary>
        /// Default constructor used to setup the test.
        /// </summary>
        public GlobalEntitySteps()
        {
            _testResult = new GlobalEntityTestDto
            {
                GovID = string.Empty,
                FirstNames = string.Empty,
                Surname = string.Empty,
                PreferredName = string.Empty,
                Passport = string.Empty,
                CountryID = string.Empty,
                LUCPreferredLanguage = string.Empty,
                LUCMaritalStatus = string.Empty,
                EmployerName = string.Empty,
                EmployeeNo = string.Empty,
                SalaryPayDay = string.Empty,
                LUCIncomeCategory = string.Empty,
                IsStaff = false,
                LUCTitle = string.Empty
            };
        }

        [Given(@"that the user wants to load a customers account")]
        public void GivenThatTheUserWantsToLoadACustomersAccount()
        {
            Assert.IsTrue(true);
        }

        /// <summary>
        /// This method actual calls all of the implementation for the When step in the GlobalEntity.feature file.
        /// </summary>
        /// <param name="GovID">The GovID that is being tested.</param>
        [When(@"the user enters '(.*)'")]
        public void WhenTheUserEntersThis(string GovID)
        {
            var globalEntityDataMock = new GlobalEntityDataMock();
            var globalEntityModel = new GlobalEntityModel(globalEntityDataMock);

            var exceptionsDataMock = new ExceptionsDataMock();
            var exceptionsModel = new ExceptionsModel(exceptionsDataMock);

            _testResult.GovID = GovID;
            GlobalEntityViewModel globalEntityViewModel = globalEntityModel.ValidateGovID(GovID);
            ExceptionsViewModel exceptionsViewModel = exceptionsModel.IsException(GovID);

            if (globalEntityViewModel.GlobalEntity != null)
            {
                if (globalEntityViewModel.GlobalEntity.Count > 0)
                {
                    _testResult.FirstNames = globalEntityViewModel.GlobalEntity[0].FirstNames;
                    _testResult.Surname = globalEntityViewModel.GlobalEntity[0].Surname;
                    _testResult.PreferredName = globalEntityViewModel.GlobalEntity[0].PreferredName;
                    _testResult.Passport = globalEntityViewModel.GlobalEntity[0].Passport;
                    _testResult.CountryID = globalEntityViewModel.GlobalEntity[0].CountryID;
                    _testResult.LUCPreferredLanguage = globalEntityViewModel.GlobalEntity[0].LUCPreferredLanguage;
                    _testResult.LUCMaritalStatus = globalEntityViewModel.GlobalEntity[0].LUCMaritalStatus;
                    _testResult.EmployerName = globalEntityViewModel.GlobalEntity[0].EmployerName;
                    _testResult.LUCIncomeCategory = globalEntityViewModel.GlobalEntity[0].LUCIncomeCategory;
                    _testResult.LUCTitle = globalEntityViewModel.GlobalEntity[0].LUCTitle;
                    var isStaff = globalEntityViewModel.GlobalEntity[0].IsStaff;
                    _testResult.IsStaff = isStaff != null && isStaff.Value;
                    var salaryPayDay = globalEntityViewModel.GlobalEntity[0].SalaryPayDay;
                    _testResult.SalaryPayDay = salaryPayDay.ToString();
                }
            }

            _testResult.GovIDValidationResponse = globalEntityViewModel.GovIDValidationResponse;
            _testResult.GovIDExceptionStatus = exceptionsViewModel.GovIDExceptionStatus;
        }
        
        /// <summary>
        /// This method checks that the results of the methods in the When step are match the expected responses contained
        /// in the GlobalEntity.Feature test cases.
        /// </summary>
        /// <param name="GovIDValidationResponse">The validation ENUM response for the GovID that was tested.</param>
        /// <param name="GovIDExceptionStatus">The exception ENUM associated with that GovID</param>
        /// <param name="FirstNames">The expected FirstName response.</param>
        /// <param name="Surname">The exepected Surname response.</param>
        /// <param name="PreferredName">The expcted Preferred Name response.</param>
        /// <param name="Passport">The expcted Passport response.</param>
        /// <param name="CountryID">The expcted CountryID response.</param>
        /// <param name="LUCPreferredLanguage">The expected Language response.</param>
        /// <param name="LUCMaritalStatus">The expected Marital Status response.</param>
        /// <param name="EmployerName">The expected Employer Name response.</param>
        /// <param name="EmployerNo">The expected Employer Number response.</param>
        /// <param name="LUCIncomeCategory">The expected income category response.</param>
        /// <param name="IsStaff">The expected Is Staff response.</param>
        /// <param name="LUCTitle">The expected Title response.</param>
        /// <param name="SalaryPayDay">The expected Salary Pay Day response.</param>
        [Then(@"the result should be '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' (.*) '(.*)' '(.*)'")]
        public void ThenTheResultShouldBe(string GovIDValidationResponse, string GovIDExceptionStatus, string FirstNames, string Surname, string PreferredName, string Passport, string CountryID, string LUCPreferredLanguage, string LUCMaritalStatus, string EmployerName, string EmployerNo, string LUCIncomeCategory, bool IsStaff, string LUCTitle, string SalaryPayDay)
        {
            Assert.AreEqual(_testResult.FirstNames, FirstNames);
            Assert.AreEqual(_testResult.Surname, Surname);
            Assert.AreEqual(_testResult.PreferredName, PreferredName);
            Assert.AreEqual(_testResult.Passport, Passport);
            Assert.AreEqual(_testResult.CountryID, CountryID);
            Assert.AreEqual(_testResult.LUCPreferredLanguage, LUCPreferredLanguage);
            Assert.AreEqual(_testResult.LUCMaritalStatus, LUCMaritalStatus);
            Assert.AreEqual(_testResult.EmployerName, EmployerName);
            Assert.AreEqual(_testResult.SalaryPayDay, SalaryPayDay);
            Assert.AreEqual(_testResult.LUCIncomeCategory, LUCIncomeCategory);
            Assert.AreEqual(_testResult.IsStaff, IsStaff);
            Assert.AreEqual(_testResult.LUCTitle, LUCTitle);

            Assert.AreEqual(_testResult.GovIDValidationResponse.ToString(), GovIDValidationResponse);
            Assert.AreEqual(_testResult.GovIDExceptionStatus.ToString(), GovIDExceptionStatus);
        }

    }
}
