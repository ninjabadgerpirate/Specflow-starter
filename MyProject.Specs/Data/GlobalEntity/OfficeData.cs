using System;
using System.Collections.Generic;
using System.Linq;
using MyProject.Specs.Entity;

namespace MyProject.Specs.Data.GlobalEntity
{
    /// <summary>
    /// This is the data access class for the GlobalEntity.Office table in Genisys.
    /// </summary>
    public class OfficeData : IOfficeData
    {
        public GeniSysEntities db;

        /// <summary>
        /// The default constructor for the OfficeData class.
        /// </summary>
        public OfficeData()
        {
            db = new GeniSysEntities();
        }

        /// <summary>
        /// This method checks to see if the office code that you have entered exists in the GlobalEntity.Office.
        /// </summary>
        /// <param name="officeCode">The office code that you want to check.</param>
        /// <param name="errorMessage">An error message that you want to return to the caller.</param>
        /// <returns>A boolean value indicating whether the office exists.</returns>
        public IList<Office> FindMatchingOffices(string officeCode, ref string errorMessage)
        {
            List<Office> result = new List<Office>();
            
            try
            {
                result = db.Office.Where(x => x.OfficeCode == officeCode).ToList();
            }
            catch (Exception ex)
            {
                errorMessage = ex.ToString();
                //ToDo Add error logging.
            }

            return result;
        }
    }
}
