using System.Collections.Generic;
using MyProject.Specs.Entity;

namespace MyProject.Specs.Data.GlobalEntity
{
    public interface IMerchData
    {
        List<MerchCode> FindMatchingMerchCodes(string merchCode, ref string errorMessage);
    }
}
