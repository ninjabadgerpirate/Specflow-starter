using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyProject.Specs.Models.GlobalEntity;
using MyProjects.Specs.UnitTests.Models.GlobalEntity.Mock;

namespace MyProjects.Specs.UnitTests.Models.GlobalEntity
{
    /// <summary>
    /// Summary description for OfficeModelUnitTest
    /// </summary>
    [TestClass]
    public class OfficeModelUnitTest
    {
        public OfficeModelUnitTest()
        {
            OfficeModel = new OfficeModel();
        }

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public IOfficeModel OfficeModel { get; set; }

        [TestMethod]
        public void OfficeCodeIsValidTest()
        {
            const string officeCode = "000000";
            string errorMessage = string.Empty;
            bool result = OfficeModel.OfficeCodeIsValid(officeCode, ref errorMessage);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public bool OfficeCodeIsValidVariantTest(string officeCode, bool expectedResult)
        {
            string errorMessage = string.Empty;
            bool result = OfficeModel.OfficeCodeIsValid(officeCode, ref errorMessage);

            Assert.AreEqual(result, expectedResult);

            return result;
        }

        [TestMethod]
        public void OfficeCodeIsNotValidTest()
        {
            const string officeCode = "00";
            string errorMessage = string.Empty;
            bool result = OfficeModel.OfficeCodeIsValid(officeCode, ref errorMessage);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void OfficeCodeExistsTest()
        {
            const string officeCode = "000000";
            string errorMessage = string.Empty;
            var officeDataMock = new OfficeDataMock();
            OfficeModel = new OfficeModel(officeDataMock);
            bool result = OfficeModel.OfficeCodeExists(officeCode, ref errorMessage);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public bool OfficeCodeExistsVariantTest(string officeCode, bool isValid)
        {
            string errorMessage = string.Empty;
            var officeDataMock = new OfficeDataMock();
            OfficeModel = new OfficeModel(officeDataMock);
            bool result = OfficeModel.OfficeCodeExists(officeCode, ref errorMessage);

            Assert.AreEqual(result,isValid);
            return result;
        }

        [TestMethod]
        public bool OfficeCodeIsActiveVariantTest(string officeCode, bool isValid)
        {
            string errorMessage = string.Empty;
            var officeDataMock = new OfficeDataMock();
            OfficeModel = new OfficeModel(officeDataMock);
            bool result = OfficeModel.OfficeCodeIsActive(officeCode, ref errorMessage);

            Assert.AreEqual(result, isValid);

            return result;
        }
        
        [TestMethod]
        public void OfficeCodeDoesntExistTest()
        {
            const string officeCode = "867546";
            string errorMessage = string.Empty;
            var officeDataMock = new OfficeDataMock();
            OfficeModel = new OfficeModel(officeDataMock);
            bool result = OfficeModel.OfficeCodeExists(officeCode, ref errorMessage);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void OfficeCodeIsActiveTest()
        {
            const string officeCode = "000000";
            string errorMessage = string.Empty;
            var officeDataMock = new OfficeDataMock();
            OfficeModel = new OfficeModel(officeDataMock);
            bool result = OfficeModel.OfficeCodeIsActive(officeCode, ref errorMessage);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void OfficeCodeIsInactiveTest()
        {
            const string officeCode = "867546";
            string errorMessage = string.Empty;
            var officeDataMock = new OfficeDataMock();
            OfficeModel = new OfficeModel(officeDataMock);
            bool result = OfficeModel.OfficeCodeIsActive(officeCode, ref errorMessage);

            Assert.IsFalse(result);
        }
    }
}
