using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyProject.Specs.Data.GlobalEntity;
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
        private GlobalEntityTestDto _testResult;

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

        public GlobalEntitySteps()
        {
            _testResult = new GlobalEntityTestDto();
            _testResult.GovID = string.Empty;
            _testResult.FirstNames = string.Empty;
            _testResult.Surname = string.Empty;
            _testResult.PreferredName = string.Empty;
            _testResult.Passport = string.Empty;
            _testResult.CountryID = string.Empty;
            _testResult.LUCPreferredLanguage = string.Empty;
            _testResult.LUCMaritalStatus = string.Empty;
            _testResult.EmployerName = string.Empty;
            _testResult.EmployeeNo = string.Empty;
            _testResult.SalaryPayDay = string.Empty;
            _testResult.LUCIncomeCategory = string.Empty;
            _testResult.IsStaff = false;
            _testResult.LUCTitle = string.Empty;
        }

        [Given(@"that the user wants to load a customers account")]
        public void GivenThatTheUserWantsToLoadACustomersAccount()
        {
            Assert.IsTrue(true);
        }

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

        [Then(@"the result should be false")]
        public void ThenTheResultShouldBeFalse()
        {
            ScenarioContext.Current.Pending();
        }


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
