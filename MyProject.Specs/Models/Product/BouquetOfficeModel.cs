using System.Collections.Generic;
using System.Linq;
using MyProject.Specs.Data.Product;
using MyProject.Specs.Entity;

namespace MyProject.Specs.Models.Product
{
    /// <summary>
    /// This model contains all the business logic around Bouquets and Offices
    /// </summary>
    public class BouquetOfficeModel : IBouquetOfficeModel
    {
        private IBouquetOfficeData db;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public BouquetOfficeModel()
        {
            db = new BouquetOfficeData();
        }

        /// <summary>
        /// Constructor that takes in a repository class that interfaces IBouquetOfficeData
        /// </summary>
        /// <param name="_db">The database repostiory that you would like to use.</param>
        public BouquetOfficeModel(IBouquetOfficeData _db)
        {
            db = _db;
        }

        public IList<BouquetOffice> ReturnBouquetsForOfficeCode(string officeCode, ref string errorMessage)
        {
            var result = db.ReturnBouquetsForOfficeCode(officeCode, ref errorMessage);
            return result.Where(x => x.DeletedOn == null).ToList();
        }
    }

    public interface IBouquetOfficeModel
    {
        IList<BouquetOffice> ReturnBouquetsForOfficeCode(string officeCode, ref string errorMessage);
    }
}
