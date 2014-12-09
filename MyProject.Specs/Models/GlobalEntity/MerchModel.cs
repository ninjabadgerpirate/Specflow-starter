using System;
using System.Collections.Generic;
using System.Linq;
using MyProject.Specs.Data.GlobalEntity;
using MyProject.Specs.Entity;

namespace MyProject.Specs.Models.GlobalEntity
{
    /// <summary>
    /// This model contains the business logic around the management of merchants.
    /// </summary>
    public class MerchModel : IMerchModel
    {
        private IMerchData db;

        /// <summary>
        /// This is the default constructor.
        /// </summary>
        public MerchModel()
        {
            db = new MerchData();
        }

        /// <summary>
        /// The constructor that takes in the database repository.
        /// </summary>
        /// <param name="_db">A database repository that inherits the IMerchData interface.</param>
        public MerchModel(IMerchData _db)
        {
            db = _db;
        }

        /// <summary>
        /// This method checks to see if the merch code that you have entered is a valid merch code.
        /// </summary>
        /// <param name="merchCode">The merch code that you want to check validity for.</param>
        /// <param name="errorMessage">Any errors that occurred while checking the validity of the merch code.</param>
        /// <returns>A boolean value indicating whether the merch code is valid.</returns>
        public bool MerchCodeIsValid(string merchCode, ref string errorMessage)
        {
            bool result = false;

            if (!string.IsNullOrEmpty(merchCode))
            {
                result = merchCode.Length == 6;

                int n;
                if (!int.TryParse(merchCode, out n))
                {
                    result = false;
                }
            }

            return result;
        }

        /// <summary>
        /// This method checks to see if the merch code that you have entered exists.
        /// </summary>
        /// <param name="merchCode">The merch code that you want to check.</param>
        /// <param name="errorMessage">An error message that you want to return to the caller.</param>
        /// <returns>A boolean value indicating whether the merch exists.</returns>
        public bool MerchCodeExists(string merchCode, ref string errorMessage)
        {
            bool result = false;
            List<MerchCode> data = db.FindMatchingMerchCodes(merchCode, ref errorMessage);
            try
            {
                result = data.Any(x => x.MerchCode1 == merchCode);
            }
            catch (Exception ex)
            {
                errorMessage = ex.ToString();
                //ToDo Add error logging.
            }

            return result;
        }

        /// <summary>
        /// This method checks to see if the merch code that you have entered is valid and exists
        /// </summary>
        /// <param name="merchCode">The merch code that you want to check.</param>
        /// <param name="errorMessage">An error message that you want to return to the caller.</param>
        /// <returns>A boolean value indicating whether the merch exists.</returns>
        public bool MerchCodeIsActive(string merchCode, ref string errorMessage)
        {
            bool result = false;
            List<MerchCode> data = db.FindMatchingMerchCodes(merchCode, ref errorMessage);
            try
            {
                result = data.Any(x => x.MerchCode1 == merchCode && x.LUCMerchStatus == "Active");
            }
            catch (Exception ex)
            {
                errorMessage = ex.ToString();
                //ToDo Add error logging.
            }

            return result;
        }
    }

    public interface IMerchModel
    {
        bool MerchCodeIsValid(string merchCode, ref string errorMessage);
        bool MerchCodeExists(string merchCode, ref string errorMessage);
        bool MerchCodeIsActive(string merchCode, ref string errorMessage);
    }
}
