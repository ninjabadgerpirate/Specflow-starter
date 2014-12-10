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
    /// This model contains the business logic around the management of merchants.
    /// </summary>
    public class MerchModel : IMerchModel
    {
        private IMerchData _merchData;

        /// <summary>
        /// This is the default constructor.
        /// </summary>
        public MerchModel()
        {
            _merchData = new MerchData();
        }

        /// <summary>
        /// The constructor that takes in the database repository.
        /// </summary>
        /// <param name="merchData">A database repository that inherits the IMerchData interface.</param>
        public MerchModel(IMerchData merchData)
        {
            _merchData = merchData;
        }

        /// <summary>
        /// This method wraps up the Merch Code Validity/Existence/Active validation methods.
        /// </summary>
        /// <param name="merchCode">The merch code you are validating</param>
        /// <returns>An office view model containing the validity response.</returns>
        public MerchViewModel ValidateMerchCode(string merchCode)
        {
            var merchViewModel = MerchCodeIsValid(merchCode);
            if (!merchViewModel.IsValid)
            {
                return merchViewModel;
            }

            merchViewModel = MerchCodeExists(merchCode);
            if (!merchViewModel.IsValid)
            {
                return merchViewModel;
            }

            merchViewModel = MerchCodeIsActive(merchCode);
            if (!merchViewModel.IsValid)
            {
                return merchViewModel;
            }
            merchViewModel.MerchCodeValidationResponse = MerchCodeValidationResponseEnum.Valid;
            return merchViewModel;
        }

        /// <summary>
        /// This method checks to see if the merch code that you have entered is a valid merch code.
        /// </summary>
        /// <param name="merchCode">The merch code that you want to check validity for.</param>
        /// <returns>A boolean value indicating whether the merch code is valid.</returns>
        public MerchViewModel MerchCodeIsValid(string merchCode)
        {
            MerchViewModel merchViewModel = new MerchViewModel();
            bool result = false;

            try
            {
                if (string.IsNullOrEmpty(merchCode))
                {
                    merchViewModel.MerchCodeValidationResponse = MerchCodeValidationResponseEnum.NoMerchCode;
                }
                else
                {
                    result = merchCode.Length == 6;

                    if (result)
                    {
                        int n;
                        if (!int.TryParse(merchCode, out n))
                        {
                            merchViewModel.MerchCodeValidationResponse = MerchCodeValidationResponseEnum.InvalidMerchCode;
                            result = false;
                        }
                    }
                    else
                    {
                        merchViewModel.MerchCodeValidationResponse = MerchCodeValidationResponseEnum.InvalidMerchCode;
                    }
                }

                merchViewModel.ResponseStatus = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                merchViewModel.ResponseStatus = ResponseStatus.Failed;
                merchViewModel.ResponseMessage = ex.ToString();
            }

            merchViewModel.IsValid = result;
            merchViewModel.ResponseDateTime = DateTime.Now;

            return merchViewModel;
        }

        /// <summary>
        /// This method checks to see if the merch code that you have entered exists.
        /// </summary>
        /// <param name="merchCode">The merch code that you want to check.</param>
        /// <returns>A boolean value indicating whether the merch exists.</returns>
        public MerchViewModel MerchCodeExists(string merchCode)
        {
            MerchViewModel merchViewModel = new MerchViewModel();
            bool result = false;
            string errorMessage = string.Empty;
            
            try
            {
                List<MerchCode> data = _merchData.FindMatchingMerchCodes(merchCode, ref errorMessage);
                result = data.Any(x => x.MerchCode1 == merchCode);
                if (!result)
                {
                    merchViewModel.MerchCodeValidationResponse = MerchCodeValidationResponseEnum.MerchCodeDoesNotExist;
                }
                merchViewModel.ResponseStatus = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                errorMessage = ex.ToString();

                merchViewModel.ResponseStatus = ResponseStatus.Failed;
                merchViewModel.ResponseMessage = errorMessage;
                //ToDo Add error logging.
            }

            merchViewModel.IsValid = result;
            merchViewModel.ResponseDateTime = DateTime.Now;

            return merchViewModel;
        }

        /// <summary>
        /// This method checks to see if the merch code that you have entered is valid and exists
        /// </summary>
        /// <param name="merchCode">The merch code that you want to check.</param>
        /// <returns>A boolean value indicating whether the merch exists.</returns>
        public MerchViewModel MerchCodeIsActive(string merchCode)
        {
            MerchViewModel merchViewModel = new MerchViewModel();
            bool result = false;
            string errorMessage = string.Empty;
            
            try
            {
                List<MerchCode> data = _merchData.FindMatchingMerchCodes(merchCode, ref errorMessage);
                result = data.Any(x => x.MerchCode1 == merchCode && x.LUCMerchStatus == "Active");

                if (!result)
                {
                    merchViewModel.MerchCodeValidationResponse = MerchCodeValidationResponseEnum.InactiveMerchCode;
                }
                else
                {
                    merchViewModel.ResponseStatus = ResponseStatus.Success;
                }
            }
            catch (Exception ex)
            {
                merchViewModel.ResponseStatus = ResponseStatus.Failed;
                errorMessage = ex.ToString();
                merchViewModel.ResponseMessage = errorMessage;
                //ToDo Add error logging.
            }

            merchViewModel.IsValid = result;
            merchViewModel.ResponseDateTime = DateTime.Now;

            return merchViewModel;
        }
    }
}
