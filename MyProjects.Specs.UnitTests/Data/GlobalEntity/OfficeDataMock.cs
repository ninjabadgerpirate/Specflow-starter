using System.Collections.Generic;
using MyProject.Specs.Data.GlobalEntity;
using MyProject.Specs.Entity;

namespace MyProjects.Specs.UnitTests.Data.GlobalEntity
{
    public class OfficeDataMock : IOfficeData
    {
        public List<Office> dataToUse;

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

        public IList<Office> FindMatchingOffices(string officeCode, ref string errorMessage)
        {
            return dataToUse;
        }
    }
}
