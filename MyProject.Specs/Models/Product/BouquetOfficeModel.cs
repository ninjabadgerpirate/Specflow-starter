using System;
using System.Collections.Generic;
using System.Linq;
using MyProject.Specs.Data.Product;
using MyProject.Specs.Entity;
using MyProject.Specs.ViewModels;

namespace MyProject.Specs.Models.Product
{
    /// <summary>
    /// This model contains all the business logic around Bouquets and Offices
    /// </summary>
    public class BouquetOfficeModel : IBouquetOfficeModel
    {
        private IBouquetOfficeData _bouquetOfficeData;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public BouquetOfficeModel()
        {
            _bouquetOfficeData = new BouquetOfficeData();
        }

        /// <summary>
        /// Constructor that takes in a repository class that interfaces IBouquetOfficeData
        /// </summary>
        /// <param name="bouquetOfficeData">The database repostiory that you would like to use.</param>
        public BouquetOfficeModel(IBouquetOfficeData bouquetOfficeData)
        {
            _bouquetOfficeData = bouquetOfficeData;
        }

        /// <summary>
        /// Return all the non-deleted bouquets for a particular office.
        /// </summary>
        /// <param name="officeCode">The office code to retrieve the Bouquets for.</param>
        /// <returns>A IList of Bouquet Offices that match the officeCode inputed.</returns>
        public BouquetOfficeViewModel ReturnBouquetsForOfficeCode(string officeCode)
        {
            string errorMessage = string.Empty;
            var bouquetOfficeViewModel = new BouquetOfficeViewModel();

            try
            {
                IList<BouquetOffice> result = _bouquetOfficeData.ReturnBouquetsForOfficeCode(officeCode, ref errorMessage).ToList();
                bouquetOfficeViewModel.ResponseMessage = string.Empty;

                if (string.IsNullOrEmpty(errorMessage))
                {
                    bouquetOfficeViewModel.ResponseStatus = ResponseStatus.Success;
                    bouquetOfficeViewModel.BouquetOffice = result.Where(x => x.DeletedOn == null).ToList();
                }
                else
                {
                    bouquetOfficeViewModel.ResponseStatus = ResponseStatus.Failed;
                    bouquetOfficeViewModel.ResponseMessage = errorMessage;
                }
            }
            catch (Exception ex)
            {
                bouquetOfficeViewModel.ResponseStatus = ResponseStatus.Failed;
                bouquetOfficeViewModel.ResponseMessage = ex.ToString();
            }
           
            bouquetOfficeViewModel.ResponseDateTime = DateTime.Now;

            return bouquetOfficeViewModel;
        }
    }
}
