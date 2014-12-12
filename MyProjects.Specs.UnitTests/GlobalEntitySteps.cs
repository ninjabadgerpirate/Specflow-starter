using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyProject.Specs.Enums;
using MyProject.Specs.Models.GlobalEntity;
using MyProject.Specs.ViewModels;
using MyProjects.Specs.UnitTests.Data.GlobalEntity;
using TechTalk.SpecFlow;

namespace MyProjects.Specs.UnitTests
{
    [Binding]
    public class GlobalEntitySteps
    {
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
            public int SalaryPayDay { get; set; }
            public string LUCIncomeCategory { get; set; }
            public bool IsStaff { get; set; }
            public string LUCTitle { get; set; }

            public string Status { get; set; }
            public bool IsValid { get; set; }
            public GovIDValidationResponseEnum GovIDValidationResponse { get; set; }
            public GovIDExceptionStatusEnum GovIDExceptionStatus { get; set; }
        }

        private GlobalEntityTestDto _testResult = new GlobalEntityTestDto();


        [Given(@"that the user wants to load a customers account")]
        public void GivenThatTheUserWantsToLoadACustomersAccount()
        {
            Assert.IsTrue(true);
        }

        [When(@"the user enters this (.*)")]
        public void WhenTheUserEntersThis(string GovID)
        {
            var globalEntityDataMock = new GlobalEntityDataMock();
            var globalEntityModel = new GlobalEntityModel(globalEntityDataMock);

            _testResult.GovID = GovID;
            GlobalEntityViewModel globalEntityViewModel = globalEntityModel.ValidateGovID(GovID);

            if (globalEntityViewModel.GlobalEntity != null)
            {
                _testResult.GovIDValidationResponse = globalEntityViewModel.GovIDValidationResponse;
                _testResult.GovIDExceptionStatus = globalEntityViewModel.GovIDExceptionStatus;
                _testResult.FirstNames = globalEntityViewModel.GlobalEntity.FirstNames;
                _testResult.Surname = globalEntityViewModel.GlobalEntity.Surname;
                _testResult.PreferredName = globalEntityViewModel.GlobalEntity.PreferredName;
                _testResult.Passport = globalEntityViewModel.GlobalEntity.Passport;
                _testResult.CountryID = globalEntityViewModel.GlobalEntity.CountryID;
                _testResult.LUCPreferredLanguage = globalEntityViewModel.GlobalEntity.LUCPreferredLanguage;
                _testResult.LUCMaritalStatus = globalEntityViewModel.GlobalEntity.LUCMaritalStatus;
                _testResult.EmployerName = globalEntityViewModel.GlobalEntity.EmployerName;
                _testResult.LUCIncomeCategory = globalEntityViewModel.GlobalEntity.LUCIncomeCategory;
                _testResult.LUCTitle = globalEntityViewModel.GlobalEntity.LUCTitle;

                switch (globalEntityViewModel.GovIDValidationResponse)
                {
                        
                }

                if (globalEntityViewModel.GlobalEntity.IsStaff != null)
                    _testResult.IsStaff = globalEntityViewModel.GlobalEntity.IsStaff.Value;

                if (globalEntityViewModel.GlobalEntity.SalaryPayDay != null)
                    _testResult.SalaryPayDay = globalEntityViewModel.GlobalEntity.SalaryPayDay.Value;
                
            }
        }

        [Then(@"the account (.*)")]
        public void ThenTheAccount(string p0)
        {
            //ScenarioContext.Current.Pending();
        }

        [Then(@"the account details are (.*) (.*) (.*) (.*) (.*) (.*) (.*) (.*) (.*) (.*) (.*) (.*) (.*) (.*)")]
        public void ThenTheAccountDetailsAre(string Status, string FirstNames, string Surname, string PreferredName, string Passport, string CountryID, string LUCPreferredLanguage, string LUCMaritalStatus, string EmployerName, string SalaryPayDay, string LUCIncomeCategory, string IsStaff, string LUCTitle)
        {
            Assert.AreEqual(_testResult.Status, Status);
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

            Assert.AreEqual(_testResult.Status, Status);
        }
    }
}
