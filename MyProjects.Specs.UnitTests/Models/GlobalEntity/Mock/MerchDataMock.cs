using System.Collections.Generic;
using MyProject.Specs.Data.GlobalEntity;
using MyProject.Specs.Entity;

namespace MyProjects.Specs.UnitTests.Models.GlobalEntity.Mock
{
    public class MerchDataMock : IMerchData
    {
        public List<MerchCode> dataToUse;

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

        public List<MerchCode> FindMatchingMerchCodes(string merchCode, ref string errorMessage)
        {
            return dataToUse;
        }
    }
}
