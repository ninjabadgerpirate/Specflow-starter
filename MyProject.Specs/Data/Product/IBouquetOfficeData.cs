using System.Collections.Generic;
using MyProject.Specs.Entity;

namespace MyProject.Specs.Data.Product
{
    public interface IBouquetOfficeData
    {
        IList<BouquetOffice> ReturnBouquetsForOfficeCode(string officeCode, ref string errorMessage);
    }
}
