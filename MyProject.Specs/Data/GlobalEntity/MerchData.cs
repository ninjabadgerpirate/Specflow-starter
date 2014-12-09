using System;
using System.Collections.Generic;
using System.Linq;
using MyProject.Specs.Entity;

namespace MyProject.Specs.Data.GlobalEntity
{
    /// <summary>
    /// This is the data access layer for the GlobalEntity.MerchCode table.
    /// </summary>
    public class MerchData : IMerchData
    {
        private GeniSysEntities db = new GeniSysEntities();

        /// <summary>
        /// This method checks to see if the merch code that you have entered exists in the GlobalEntity.MerchCode table.
        /// </summary>
        /// <param name="merchCode">The merch code that you want to check.</param>
        /// <param name="errorMessage">An error message that you want to return to the caller.</param>
        /// <returns>A boolean value indicating whether the merch exists.</returns>
        public List<MerchCode> FindMatchingMerchCodes(string merchCode, ref string errorMessage)
        {
            List<MerchCode> result = new List<MerchCode>();

            try
            {
                result = db.MerchCode.Where(x => x.MerchCode1 == merchCode).ToList();
            }
            catch (Exception ex)
            {
                errorMessage = ex.ToString();
                //ToDo Add error logging.
            }

            return result;
        }
    }

    public interface IMerchData
    {
        List<MerchCode> FindMatchingMerchCodes(string merchCode, ref string errorMessage);
    }
}
