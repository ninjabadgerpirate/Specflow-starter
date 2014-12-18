using System.Collections.Generic;
using MyProject.Specs.Data.GlobalEntity;
using MyProject.Specs.Entity;

namespace MyProjects.Specs.UnitTests.Data.GlobalEntity
{
    /// <summary>
    /// This is the mocked data class for the Office model.
    /// </summary>
    public class OfficeDataMock : IOfficeData
    {
        /// <summary>
        /// This public property allows you to inject your own Data to use.
        /// </summary>
        public List<Office> dataToUse { get; set; }

        /// <summary>
        /// The default constructor that populates the dataToUse object above.
        /// </summary>
        public OfficeDataMock()
        {
            dataToUse = new List<Office>
                {
                    new Office
                    {
                        OfficeCode = "000000",
                        LUCOfficeStatus = "Active"
                    },
                    new Office
                    {
                        OfficeCode = "000002",
                        LUCOfficeStatus = "Inactive"
                    }
                };
        }

        /// <summary>
        /// The method that finds all offices that match the officeCode inputed.
        /// </summary>
        /// <param name="officeCode">The office record to find that matches the officeCode inputted.</param>
        /// <param name="errorMessage">A string containing any errors that may have occurred.</param>
        /// <returns>A list of Offices that match the officeCode that you have entered.</returns>
        public IList<Office> FindMatchingOffices(string officeCode, ref string errorMessage)
        {
            return dataToUse;
        }
    }
}
