using System;
using System.Text.RegularExpressions;
using MyProject.Specs.Data.GlobalEntity;
using MyProject.Specs.Enums;
using MyProject.Specs.ViewModels;

namespace MyProject.Specs.Models.GlobalEntity
{
    /// <summary>
    /// This model contains all of the business logic around the GlobalEntity.GlobalEntity entity.
    /// </summary>
    public class GlobalEntityModel : IGlobalEntityModel
    {
        private IGlobalEntityData _globalEntityData;

        /// <summary>
        /// Default Constructor for this class
        /// </summary>
        public GlobalEntityModel()
        {
            _globalEntityData = new GlobalEntityData();
        }

        /// <summary>
        /// This constructor takes in any class that interfaces with the IGlobalEntityData interface.
        /// </summary>
        /// <param name="globalEntityData">The class that you would like to use as the source of you GlobalEntity data.</param>
        public GlobalEntityModel(IGlobalEntityData globalEntityData)
        {
            _globalEntityData = globalEntityData;
        }

        /// <summary>
        /// This method first validates the SA GovID and then tries to find a GovID that matches in the Genisys database.
        /// </summary>
        /// <param name="govID">The GovID that you want to validate and look for matches for.</param>
        /// <returns>A GlobalEntityViewModel containing the response.</returns>
        public GlobalEntityViewModel ValidateGovID(string govID)
        {
            GlobalEntityViewModel globalEntityViewModel = new GlobalEntityViewModel();

            try
            {
                globalEntityViewModel = GovIDIsValid(govID);
                if (globalEntityViewModel.GovIDValidationResponse == GovIDValidationResponseEnum.Valid)
                {
                    globalEntityViewModel = FindByGovID(govID);
                }

                globalEntityViewModel.ResponseStatus = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                globalEntityViewModel.ResponseStatus = ResponseStatus.Failed;
                globalEntityViewModel.ResponseMessage = ex.ToString();

                //ToDo Integrate logging service.
            }

            globalEntityViewModel.ResponseDateTime = DateTime.Now;

            return globalEntityViewModel;
        }

        /// <summary>
        /// This method checks that the SA GovID that you have passed in matches the regex pattern for a SA GovID.
        /// </summary>
        /// <param name="govID">The GovID that you want to validate.</param>
        /// <returns>A GlobalEntityViewModel with the response from the validation request.</returns>
        public GlobalEntityViewModel GovIDIsValid(string govID)
        {
            bool isValid = false;
            GlobalEntityViewModel globalEntityViewModel = new GlobalEntityViewModel();

            try
            {
                if (string.IsNullOrEmpty(govID))
                {
                    globalEntityViewModel.GovIDValidationResponse = GovIDValidationResponseEnum.NoGovID;
                }
                else
                {
                    var govIDRegEx = new Regex("^([0-9]){2}([0-1][0-9])([0-3][0-9])([0-9]){4}([0-2])([0-9]){2}?$");
                    if (!govIDRegEx.Match(govID).Success)
                    {
                        globalEntityViewModel.GovIDValidationResponse = GovIDValidationResponseEnum.Invalid;
                    }
                    else
                    {
                        globalEntityViewModel.GovIDValidationResponse = GovIDValidationResponseEnum.Valid;
                        isValid = true;
                    }
                }
                globalEntityViewModel.IsValid = isValid;
                globalEntityViewModel.ResponseStatus = ResponseStatus.Success;
            }
            catch (Exception ex)
            {

                globalEntityViewModel.ResponseStatus = ResponseStatus.Failed;
                globalEntityViewModel.ResponseMessage = ex.ToString();

                //ToDo Integrate logging service.
            }

            globalEntityViewModel.ResponseDateTime = DateTime.Now;

            return globalEntityViewModel;
        }

        /// <summary>
        /// This method looks to see if matches can be found in the GlobalEntity.GlobalEntity in Genisys table for the GovID passed in.
        /// </summary>
        /// <param name="govID">The GovID that you are looking for matches for.</param>
        /// <returns>A GlobalEntityViewModel with the any potential matches found.</returns>
        public GlobalEntityViewModel FindByGovID(string govID)
        {
            GlobalEntityViewModel globalEntityViewModel = new GlobalEntityViewModel();

            try
            {
                globalEntityViewModel.IsValid = true;
                globalEntityViewModel.GovIDValidationResponse = GovIDValidationResponseEnum.Valid;
                globalEntityViewModel.GlobalEntity = _globalEntityData.FindByGovID(govID);
                globalEntityViewModel.ResponseStatus = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                globalEntityViewModel.ResponseStatus = ResponseStatus.Failed;
                globalEntityViewModel.ResponseMessage = ex.ToString();

                //ToDo Integrate logging service.
            }

            globalEntityViewModel.ResponseDateTime = DateTime.Now;

            return globalEntityViewModel;
        }
    }
}
