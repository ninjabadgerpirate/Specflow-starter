using System;
using System.Collections.Generic;
using MyProject.Specs.Data.Product;
using MyProject.Specs.Entity;

namespace MyProjects.Specs.UnitTests.Models.Product.Mock
{
    public class BouquetOfficeDataMock : IBouquetOfficeData
    {
        public List<BouquetOffice> dataToUse { get; set; }

        public BouquetOfficeDataMock()
        {
            dataToUse = new List<BouquetOffice>
                {
                    new BouquetOffice
                    {
                        OfficeCode = "000000",
                        SalesChannelID = "ASA",
                        ParentSalesChannelID = "TS",
                        BouquetPrefix = "HPP",
                        CountryID = "ZA",
                        InsertedOn = DateTime.Now,
                        InsertedBy = Guid.NewGuid(),
                        InsertedByName = "Lynne Miller",
                        DeletedOn = null,
                        DeletedBy = null,
                        DeletedByName = null
                    },
                    new BouquetOffice
                    {
                        OfficeCode = "000000",
                        SalesChannelID = "ASA",
                        ParentSalesChannelID = "TS",
                        BouquetPrefix = "SD",
                        CountryID = "ZA",
                        InsertedOn = DateTime.Now,
                        InsertedBy = Guid.NewGuid(),
                        InsertedByName = "Lynne Miller",
                        DeletedOn = null,
                        DeletedBy = null,
                        DeletedByName = null
                    },
                    new BouquetOffice
                    {
                        OfficeCode = "000000",
                        SalesChannelID = "ASA",
                        ParentSalesChannelID = "TS",
                        BouquetPrefix = "SD",
                        CountryID = "ZA",
                        InsertedOn = DateTime.Now,
                        InsertedBy = Guid.NewGuid(),
                        InsertedByName = "Lynne Miller",
                        DeletedOn = DateTime.Now,
                        DeletedBy = new Guid("198556F9-DE41-47F4-B78C-40ABF0E8A735"),
                        DeletedByName = "Lettah Selomane"
                    }
                };
        }

        public IList<BouquetOffice> ReturnBouquetsForOfficeCode(string officeCode, ref string errorMessage)
        {
            return dataToUse;
        }
    }
}
