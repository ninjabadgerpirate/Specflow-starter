using System;
using System.Text.RegularExpressions;
using MyProject.Specs.Data.GlobalEntity;
using MyProject.Specs.Enums;
using MyProject.Specs.ViewModels;

namespace MyProject.Specs.Models.GlobalEntity
{
    public class GlobalEntityModel : IGlobalEntityModel
    {
        private IGlobalEntityData _globalEntityData;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public GlobalEntityModel()
        {
            _globalEntityData = new GlobalEntityData();
        }

        public GlobalEntityModel(IGlobalEntityData globalEntityData)
        {
            _globalEntityData = globalEntityData;
        }

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
            }

            globalEntityViewModel.ResponseDateTime = DateTime.Now;

            return globalEntityViewModel;
        }

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
            }

            globalEntityViewModel.ResponseDateTime = DateTime.Now;

            return globalEntityViewModel;
        }

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
            }

            globalEntityViewModel.ResponseDateTime = DateTime.Now;

            return globalEntityViewModel;
        }
    }
}
