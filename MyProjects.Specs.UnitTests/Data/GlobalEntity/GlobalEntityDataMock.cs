using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using MyProject.Specs.Data.GlobalEntity;

namespace MyProjects.Specs.UnitTests.Data.GlobalEntity{

    public class GlobalEntityDataMock : IGlobalEntityData
    {
        public IList<MyProject.Specs.Entity.GlobalEntity> dataToUse { get; set; }

        public GlobalEntityDataMock()
        {
            dataToUse = new List<MyProject.Specs.Entity.GlobalEntity>();
            dataToUse.Add(new MyProject.Specs.Entity.GlobalEntity
            {
                CompanyRegNo = string.Empty,
                CountryID = "ZA",
                DateOfBirth = new DateTime(1986,11,23),
                GovID = "8611230945087",
                FirstNames = "PHUMZA",
                IsStaff = false,
                Surname = "GQOTSA",
                EmployeeNo = "",
                EmployerName = "DEPARTMENT OF ARLTICULTURE ANDFOREST FISHERIES",
                Gender = "M",
                LUCIncomeCategory = "5 001 - 10 000",
                LUCTitle = "Mrs.",
                LUCPreferredLanguage = "en",
                LUCMaritalStatus = "Married",
                Passport = string.Empty,
                PreferredName = string.Empty,
                SalaryPayDay = 31
            });
            dataToUse.Add(new MyProject.Specs.Entity.GlobalEntity
            {
                CompanyRegNo = string.Empty,
                CountryID = "ZA",
                DateOfBirth = new DateTime(1988, 1, 31),
                GovID = "8801315607088",
                FirstNames = "MABUTHESIZWE",
                IsStaff = false,
                Surname = "NXUMALO",
                EmployeeNo = "",
                EmployerName = "STUDENT",
                Gender = "M",
                LUCIncomeCategory = "Unknown",
                LUCTitle = "Mrs.",
                LUCPreferredLanguage = "en",
                LUCMaritalStatus = "Not Married",
                Passport = string.Empty,
                PreferredName = string.Empty,
                SalaryPayDay = 15
            });
        }

        public IList<MyProject.Specs.Entity.GlobalEntity> FindByGovID(string govID)
        {
            return dataToUse.Where(x => x.GovID == govID).ToList();
        }
    }
}
