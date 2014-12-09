using System.Collections.Generic;
using System.Linq;
using MyProject.Specs.Data.GlobalEntity;
using MyProject.Specs.Entity;

namespace MyProject.Specs.Models.GlobalEntity
{
    /// <summary>
    /// This model contains all of the business logic associated with Offices.
    /// </summary>
    public class OfficeModel : IOfficeModel
    {
        public IOfficeData db;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public OfficeModel()
        {
            db = new OfficeData();
        }

        /// <summary>
        /// Constructor method that allows you to inject database repository.
        /// </summary>
        /// <param name="_db"></param>
        public OfficeModel(IOfficeData _db)
        {
            db = _db;
        }

        /// <summary>
        /// This method checks to see if the office code that you have entered is a valid office code.
        /// </summary>
        /// <param name="officeCode">The office code that you want to check validity for.</param>
        /// <param name="errorMessage">Any errors that occurred while checking the validity of the office code.</param>
        /// <returns>A boolean value indicating whether the office code is valid.</returns>
        public bool OfficeCodeIsValid(string officeCode, ref string errorMessage)
        {
            bool result = false;
            if (!string.IsNullOrEmpty(officeCode))
            {
                result = officeCode.Length == 6;
                int n;
                if (!int.TryParse(officeCode, out n))
                {
                    result = false;
                }
            }
            return result;
        }

        /// <summary>
        /// This method checks to see if the office code that you have entered exists in the GlobalEntity.Office.
        /// </summary>
        /// <param name="officeCode">The office code that you want to check.</param>
        /// <param name="errorMessage">An error message that you want to return to the caller.</param>
        /// <returns>A boolean value indicating whether the office exists.</returns>
        public bool OfficeCodeExists(string officeCode, ref string errorMessage)
        {
            var result = false;
            if (!string.IsNullOrEmpty(officeCode))
            {
                IList<Office> data = db.FindMatchingOffices(officeCode, ref errorMessage);
                result = data.Any(x => x.OfficeCode == officeCode);
            }
            
            return result;
        }

        /// <summary>
        /// This method checks to see if the office code that you have entered is valid and exists
        /// </summary>
        /// <param name="officeCode">The office code that you want to check.</param>
        /// <param name="errorMessage">An error message that you want to return to the caller.</param>
        /// <returns>A boolean value indicating whether the office exists.</returns>
        public bool OfficeCodeIsActive(string officeCode, ref string errorMessage)
        {
            bool result = false;

            if (!string.IsNullOrEmpty(officeCode))
            {
                IList<Office> data = db.FindMatchingOffices(officeCode, ref errorMessage);
                result = data.Any(x => x.OfficeCode == officeCode && x.LUCOfficeStatus == "Active");
            }
            return result;
        }
    }

    public interface IOfficeModel
    {
        bool OfficeCodeExists(string officeCode, ref string errorMessage);
        bool OfficeCodeIsActive(string officeCode, ref string errorMessage);
        bool OfficeCodeIsValid(string officeCode, ref string errorMessage);
    }
}
