using System;
using System.Collections.Generic;
using System.Linq;
using MyProject.Specs.Data.GlobalEntity;

namespace MyProjects.Specs.UnitTests.Data.Exceptions
{
    public class ExceptionsDataMock : IExceptionsData
    {
        public IList<MyProject.Specs.Entity.Exceptions> dataToUse { get; set; }

        public ExceptionsDataMock()
        {
            dataToUse = new List<MyProject.Specs.Entity.Exceptions>();
            dataToUse.Add(new MyProject.Specs.Entity.Exceptions
            {
                ExceptionID = new Guid("83DD38BD-8D46-41D7-810B-04BD06CAE1FE"),
                LUCExceptionType = "BlackList",
                PolicyNo = "SP1103068",
                GovID = "8611230945087",
                AccountNumber = "70241759",
                FirstNames = "ZAKHONA DESREE",
                SurName = "TSHABALALA",
                Details = "CLIENT'S MEMBERSHIP TERMINATED  ON POLICY SP1103068 & PR106979 DUE TO MULITPLE CLAIMS OF THE SAME NATURE AND CLAIM NUMBER 4 ON SOS PROTECT POLICY.  CLIENT POLICIES ARE BOTH CANCELLED AND CLIENT IS BLACKLISTED.",
                InsertedOn = DateTime.Now,
                InsertedBy = new Guid("053F9A35-3E99-45DB-B1B9-ECBFDBE31A73"),
                InsertedByName = "Lee-ann Farmer"
            });

            dataToUse.Add(new MyProject.Specs.Entity.Exceptions
            {
                ExceptionID = new Guid("9BD0AF10-68CE-4BE0-A4DD-002ACB3D152D"),
                LUCExceptionType = "Pre-Cancel",
                PolicyNo = null,
                GovID = "7103085396088",
                AccountNumber = "",
                FirstNames = "ZAAYMAN",
                SurName = "IAN",
                Details = "no longer needing the policy",
                InsertedOn = DateTime.Now,
                InsertedBy = new Guid("D6122C00-2DF5-44B9-B902-C1AE3C605987"),
                InsertedByName = "Mavis Naidoo"
            });
        }

        public IList<MyProject.Specs.Entity.Exceptions> ReturnMatchingExceptions(string govID)
        {
            return dataToUse.Where(x => x.GovID == govID).ToList();
        }
    }
}
