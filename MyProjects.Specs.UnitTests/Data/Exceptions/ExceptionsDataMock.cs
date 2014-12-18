using System;
using System.Collections.Generic;
using System.Linq;
using MyProject.Specs.Data.GlobalEntity;

namespace MyProjects.Specs.UnitTests.Data.Exceptions
{
    /// <summary>
    /// This is the mocked data class for the Exceptions model.
    /// </summary>
    public class ExceptionsDataMock : IExceptionsData
    {
        /// <summary>
        /// This public property allows you to inject your own Data to use.
        /// </summary>
        public IList<MyProject.Specs.Entity.Exceptions> dataToUse { get; set; }
        
        /// <summary>
        /// The default constructor for the Exceptions data class.
        /// </summary>
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

        /// <summary>
        /// The method that matches the GovID inputted to the data that exists in the dataToUse object.
        /// </summary>
        /// <param name="govID">The GovID record to find.</param>
        /// <returns>A list of exceptions that match the GovID that you have inputted.</returns>
        public IList<MyProject.Specs.Entity.Exceptions> ReturnMatchingExceptions(string govID)
        {
            return dataToUse.Where(x => x.GovID == govID).ToList();
        }
    }
}
