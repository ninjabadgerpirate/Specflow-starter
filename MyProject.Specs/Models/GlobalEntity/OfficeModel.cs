using System;
using System.Collections.Generic;
using System.Linq;
using MyProject.Specs.Data.GlobalEntity;
using MyProject.Specs.Entity;
using MyProject.Specs.Enums;
using MyProject.Specs.ViewModels;

namespace MyProject.Specs.Models.GlobalEntity
{
    /// <summary>
    /// This model contains all of the business logic associated with Offices.
    /// </summary>
    public class OfficeModel : IOfficeModel
    {
        public IOfficeData _OfficeData;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public OfficeModel()
        {
            _OfficeData = new OfficeData();
        }

        /// <summary>
        /// Constructor method that allows you to inject database repository.
        /// </summary>
        /// <param name="officeData">Any class that inherits the IOfficeData</param>
        public OfficeModel(IOfficeData officeData)
        {
            _OfficeData = officeData;
        }

        /// <summary>
        /// This method wraps up the Office Code Validity/Existence/Active validation methods.
        /// </summary>
        /// <param name="officeCode">The office code you are validating</param>
        /// <returns>An office view model containing the validity response.</returns>
        public OfficeViewModel ValidateOfficeCode(string officeCode)
        {
            var officeViewModel  = OfficeCodeIsValid(officeCode);
            if (!officeViewModel.IsValid)
            {
                return officeViewModel;
            }

            officeViewModel = OfficeCodeExists(officeCode);
            if (!officeViewModel.IsValid)
            {
                return officeViewModel;
            }

            officeViewModel = OfficeCodeIsActive(officeCode);
            if (!officeViewModel.IsValid)
            {
                return officeViewModel;
            }
            officeViewModel.OfficeCodeValidationResponse = OfficeCodeValidationResponseEnum.Valid;
            return officeViewModel;
        }

        /// <summary>
        /// This method checks to see if the office code that you have entered is a valid office code.
        /// </summary>
        /// <param name="officeCode">The office code that you want to check validity for.</param>
        /// <returns>An office view model containing the validity response.</returns>
        public OfficeViewModel OfficeCodeIsValid(string officeCode)
        {
            bool result = false;
            OfficeViewModel officeViewModel = new OfficeViewModel();
            string errorMessage = string.Empty;

            try
            {
                if (!string.IsNullOrEmpty(officeCode))
                {
                    result = officeCode.Length == 6;
                    int n;

                    if (result)
                    {
                        if (!int.TryParse(officeCode, out n))
                        {
                            officeViewModel.OfficeCodeValidationResponse =
                                OfficeCodeValidationResponseEnum.InvalidOfficeCode;
                            result = false;
                        }
                    }
                    else
                    {
                        officeViewModel.OfficeCodeValidationResponse = OfficeCodeValidationResponseEnum.InvalidOfficeCode;
                    }
                }
                else
                {
                    officeViewModel.OfficeCodeValidationResponse = OfficeCodeValidationResponseEnum.NoOfficeCode;
                }
                officeViewModel.IsValid = result;
            }
            catch (Exception ex)
            {
                errorMessage = ex.ToString();
                //ToDO Add Logging.
            }

            if (!string.IsNullOrEmpty(errorMessage))
            {
                officeViewModel.ResponseStatus = ResponseStatus.Failed;
                officeViewModel.ResponseMessage = errorMessage;
            }
            else
            {
                officeViewModel.ResponseStatus = ResponseStatus.Success;
            }
            
            officeViewModel.ResponseDateTime = DateTime.Now;

            return officeViewModel;
        }

        /// <summary>
        /// This method checks to see if the office code that you have entered exists in the GlobalEntity.Office.
        /// </summary>
        /// <param name="officeCode">The office code that you want to check.</param>
        /// <returns>An office view model containing the validity response.</returns>
        public OfficeViewModel OfficeCodeExists(string officeCode)
        {
            OfficeViewModel officeViewModel = new OfficeViewModel();
            string errorMessage = string.Empty;
            bool result = false;

            try
            {
                if (!string.IsNullOrEmpty(officeCode))
                {
                    IList<Office> data = _OfficeData.FindMatchingOffices(officeCode, ref errorMessage);
                    result = data.Any(x => x.OfficeCode == officeCode);
                }
            }
            catch (Exception ex)
            {
                //ToDO Add Logging.
                errorMessage = ex.ToString();
            }

            if (string.IsNullOrEmpty(errorMessage))
            {
                if (result)
                {
                    //officeViewModel.OfficeCodeValidationResponse = OfficeCodeValidationResponseEnum.Valid;
                }
                else
                {
                    officeViewModel.OfficeCodeValidationResponse = OfficeCodeValidationResponseEnum.OfficeCodeDoesNotExist;
                }

                
                officeViewModel.ResponseStatus = ResponseStatus.Success;
            }
            else
            {
                officeViewModel.ResponseStatus = ResponseStatus.Failed;
            }

            officeViewModel.IsValid = result;
            officeViewModel.ResponseMessage = errorMessage;
            officeViewModel.ResponseDateTime = DateTime.Now;

            return officeViewModel;
        }

        /// <summary>
        /// This method checks to see if the office code that you have entered is valid and exists
        /// </summary>
        /// <param name="officeCode">The office code that you want to check.</param>
        /// <returns>A boolean value indicating whether the office exists.</returns>
        public OfficeViewModel OfficeCodeIsActive(string officeCode)
        {
            OfficeViewModel officeViewModel = new OfficeViewModel();
            bool result = false;
            string errorMessage = string.Empty;

            try
            {
                if (!string.IsNullOrEmpty(officeCode))
                {
                    IList<Office> data = _OfficeData.FindMatchingOffices(officeCode, ref errorMessage);
                    result = data.Any(x => x.OfficeCode == officeCode && x.LUCOfficeStatus == "Active");
                    officeViewModel.IsValid = result;
                }
            }
            catch (Exception ex)
            {
                //ToDO Add Logging.
                errorMessage = ex.ToString();
            }

            if (string.IsNullOrEmpty(errorMessage))
            {
                if (result)
                {
                    //officeViewModel.OfficeCodeValidationResponse = OfficeCodeValidationResponseEnum.Valid;
                }
                else
                {
                    officeViewModel.OfficeCodeValidationResponse = OfficeCodeValidationResponseEnum.InactiveOfficeCode;
                }

                officeViewModel.ResponseStatus = ResponseStatus.Success;
            }
            else
            {
                officeViewModel.ResponseStatus = ResponseStatus.Failed;
            }

            officeViewModel.ResponseMessage = errorMessage;
            officeViewModel.ResponseDateTime = DateTime.Now;
            officeViewModel.IsValid = result;

            return officeViewModel;
        }
    }
}
