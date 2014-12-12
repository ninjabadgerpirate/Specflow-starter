using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyProject.Specs.Entity;
using MyProject.Specs.Models.Product;
using MyProjects.Specs.UnitTests.Models.Product.Mock;
using System.Collections.Generic;

namespace MyProjects.Specs.UnitTests.Models.Product
{
    /// <summary>
    /// Summary description for BouquetOfficeUnitTest
    /// </summary>
    [TestClass]
    public class BouquetOfficeUnitTest
    {
        public BouquetOfficeUnitTest()
        {
            BouquetOfficeModel = new BouquetOfficeModel();
        }

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public IBouquetOfficeModel BouquetOfficeModel { get; set; }

        [TestMethod]
        public void ReturnBouquetsForOfficeCodeTest()
        {
            const string officeCode = "000000";
            string errorMessage = string.Empty;
            const int expectedResultCount = 2;
            var mockData = new BouquetOfficeDataMock();
            var model = new BouquetOfficeModel(mockData);

            var result = model.ReturnBouquetsForOfficeCode(officeCode, ref errorMessage);
            Assert.AreEqual(result.Count, expectedResultCount);
        }

        [TestMethod]
        public IList<BouquetOffice> ReturnBouquetsForOfficeCodeVariantTest(string officeCode)
        {
            string errorMessage = string.Empty;
            var mockData = new BouquetOfficeDataMock();
            var model = new BouquetOfficeModel(mockData);

            var result = model.ReturnBouquetsForOfficeCode(officeCode, ref errorMessage);
            return result;
        }
    }
}
