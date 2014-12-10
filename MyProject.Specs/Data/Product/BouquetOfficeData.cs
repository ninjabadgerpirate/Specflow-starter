using System;
using System.Collections.Generic;
using System.Linq;
using MyProject.Specs.Entity;

namespace MyProject.Specs.Data.Product
{
    /// <summary>
    /// This class controls all the data access for the Product.BouquetOffice table.
    /// </summary>
    public class BouquetOfficeData : IBouquetOfficeData
    {
        private GeniSysEntities db;

        public BouquetOfficeData()
        {
            db = new GeniSysEntities();
        }

        /// <summary>
        /// This method returns all the Bouquets that match the office code.
        /// </summary>
        /// <param name="officeCode">The office code that you want the bouquets for.</param>
        /// <param name="errorMessage">Any errors that may have occurred.</param>
        /// <returns>A list of all the Bouquets that match the office code</returns>
        public IList<BouquetOffice> ReturnBouquetsForOfficeCode(string officeCode, ref string errorMessage)
        {
            var result = new List<BouquetOffice>();

            try
            {
                result = db.BouquetOffice.Where(x => x.OfficeCode == officeCode).ToList();
            }
            catch (Exception ex)
            {
                errorMessage = ex.ToString();
            }

            return result;
        }
    }
}
