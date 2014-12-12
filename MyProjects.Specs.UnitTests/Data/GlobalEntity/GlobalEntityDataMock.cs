using System;
using MyProject.Specs.Data.GlobalEntity;

namespace MyProjects.Specs.UnitTests.Data.GlobalEntity{

    public class GlobalEntityDataMock : IGlobalEntityData
    {
        public MyProject.Specs.Entity.GlobalEntity dataToUse { get; set; }

        public GlobalEntityDataMock()
        {
            dataToUse = new MyProject.Specs.Entity.GlobalEntity
            {
                CompanyRegNo = string.Empty,
                CountryID = "ZA",
                DateOfBirth = new DateTime(1980,9,13),
                GovID = "8009135069089",
                FirstNames = "GianPiero",
                Surname = "Bresolin",
                EmployeeNo = "812",
                EmployerName = "The Unlimited",
                Gender = "M",
                LUCTitle = "Mr",
                LUCPreferredLanguage = "en",
                LUCMaritalStatus = "Single"
            };
        }

        public MyProject.Specs.Entity.GlobalEntity FindByGovID(string govID)
        {
            return dataToUse;
        }
    }
}
