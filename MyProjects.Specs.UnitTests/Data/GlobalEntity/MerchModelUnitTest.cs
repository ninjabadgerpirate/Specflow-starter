using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyProject.Specs.Models.GlobalEntity;
using MyProjects.Specs.UnitTests.Models.GlobalEntity.Mock;

namespace MyProjects.Specs.UnitTests.Models.GlobalEntity
{
    /// <summary>
    /// This class contains the unit tests for the merchant model class.
    /// </summary>
    [TestClass]
    public class MerchModelUnitTest
    {
        public MerchModelUnitTest()
        {
            MerchModel =  new MerchModel();
        }

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public IMerchModel MerchModel { get; set; }

        [TestMethod]
        public void MerchCodeIsValidTest()
        {
            const string merchCode = "000000";
            string errorMessage = string.Empty;

            var merchDataMock = new MerchDataMock();
            MerchModel = new MerchModel(merchDataMock);
            bool result = MerchModel.MerchCodeIsValid(merchCode, ref errorMessage);

            Assert.IsTrue(result);
        }        

        [TestMethod]
        public void MerchCodeIsValidTest(string merchCode)
        {
            string errorMessage = string.Empty;

            var merchDataMock = new MerchDataMock();
            MerchModel = new MerchModel(merchDataMock);
            bool result = MerchModel.MerchCodeIsValid(merchCode, ref errorMessage);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public bool MerchCodeIsValidVariantTest(string merchCode, bool expectedResult)
        {
            string errorMessage = string.Empty;

            var merchDataMock = new MerchDataMock();
            MerchModel = new MerchModel(merchDataMock);
            bool result = MerchModel.MerchCodeIsValid(merchCode, ref errorMessage);

            Assert.AreEqual(result, expectedResult);

            return result;
        }

        [TestMethod]
        public void MerchCodeIsNotValidTest()
        {
            const string merchCode = "00";
            string errorMessage = string.Empty;

            var merchDataMock = new MerchDataMock();
            MerchModel = new MerchModel(merchDataMock);
            bool result = MerchModel.MerchCodeIsValid(merchCode, ref errorMessage);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void MerchCodeExistsTest()
        {
            const string merchCode = "000000";
            string errorMessage = string.Empty;

            var merchDataMock = new MerchDataMock();
            MerchModel = new MerchModel(merchDataMock);
            bool result = MerchModel.MerchCodeExists(merchCode, ref errorMessage);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void MerchCodeExistsTest(string merchCode, bool expectedResults)
        {
            string errorMessage = string.Empty;

            var merchDataMock = new MerchDataMock();
            MerchModel = new MerchModel(merchDataMock);
            bool result = MerchModel.MerchCodeExists(merchCode, ref errorMessage);

            Assert.AreEqual(result, expectedResults);
        }

        [TestMethod]
        public bool MerchCodeIsActiveVariantTest(string merchCode, bool expectedResults)
        {
            string errorMessage = string.Empty;

            var merchDataMock = new MerchDataMock();
            MerchModel = new MerchModel(merchDataMock);
            bool result = MerchModel.MerchCodeIsActive(merchCode, ref errorMessage);

            Assert.AreEqual(result, expectedResults);

            return result;
        }        
    }
}
