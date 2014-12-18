using System.Collections.Generic;
using MyProject.Specs.Data.GlobalEntity;
using MyProject.Specs.Entity;

namespace MyProjects.Specs.UnitTests.Data.GlobalEntity
{
    /// <summary>
    /// This class contains the MockData to be used when testing models that involve the MerchCode table.
    /// </summary>
    public class MerchDataMock : IMerchData
    {
        /// <summary>
        /// This public property allows you to inject your own Data to use.
        /// </summary>
        public List<MerchCode> dataToUse { get; set; }

        /// <summary>
        /// The default constructor.
        /// </summary>
        public MerchDataMock()
        {
            dataToUse = new List<MerchCode>
                {
                    new MerchCode
                    {
                        MerchCode1 = "000000",
                        LUCMerchStatus = "Active"
                    },
                    new MerchCode
                    {
                        MerchCode1 = "000001",
                        LUCMerchStatus = "Inactive"
                    }
                };
        }

        /// <summary>
        /// This method returns the data passed in via the dataToUse property.
        /// </summary>
        /// <param name="merchCode">The merch code that you are want to find. Doesn't do anything, and is only there to match the delegate definition.</param>
        /// <param name="errorMessage">The error message string that contains any exceptions that may have occurred.</param>
        /// <returns>A list of MerchCodes that match.</returns>
        public List<MerchCode> FindMatchingMerchCodes(string merchCode, ref string errorMessage)
        {
            return dataToUse;
        }
    }
}
