using System;
using MyProject.Specs.Data.GlobalEntity;
using MyProject.Specs.Enums;
using MyProject.Specs.ViewModels;

namespace MyProject.Specs.Models.GlobalEntity
{
    /// <summary>
    /// This class handles all of the behaviours around GovIDs with exceptions.
    /// </summary>
    public class ExceptionsModel : IExceptionsModel
    {
        private IExceptionsData _exceptionsData;

        /// <summary>
        /// Default constructor for this model.
        /// </summary>
        public ExceptionsModel()
        {
            _exceptionsData = new ExceptionsData();
        }

        /// <summary>
        /// The constructor for the Exceptions data access class. 
        /// </summary>
        /// <param name="exceptionsData">A data access class that inherits the IException interface.</param>
        public ExceptionsModel(IExceptionsData exceptionsData)
        {
            _exceptionsData = exceptionsData;
        }

        /// <summary>
        /// This method is used to check if the GovID entered is an exception.
        /// Possible exception types are found in the GovIDExceptionStatusEnum class.
        /// </summary>
        /// <param name="govID">The GovID that you are looking for an exception for.</param>
        /// <returns>The ExceptionsViewModel that contains the Exception state for GovID that you have returned.</returns>
        public ExceptionsViewModel IsException(string govID)
        {
            var exceptionsViewModel = new ExceptionsViewModel();
            exceptionsViewModel.GovIDExceptionStatus = GovIDExceptionStatusEnum.NoException;

            try
            {
                exceptionsViewModel.Exceptions = _exceptionsData.ReturnMatchingExceptions(govID);
                for (int i = 0; i < exceptionsViewModel.Exceptions.Count; i++)
                {
                    switch (exceptionsViewModel.Exceptions[i].LUCExceptionType)
                    {
                        case "BlackList":
                            exceptionsViewModel.GovIDExceptionStatus = GovIDExceptionStatusEnum.Blacklisted;
                            break;
                        case "MerchBlackList":
                            exceptionsViewModel.GovIDExceptionStatus = GovIDExceptionStatusEnum.MerchBlacklist;
                            break;
                        case "Client Opt-out":
                            exceptionsViewModel.GovIDExceptionStatus = GovIDExceptionStatusEnum.ClientOptOut;
                            break;
                        case "Pre-Cancel":
                            exceptionsViewModel.GovIDExceptionStatus = GovIDExceptionStatusEnum.PreCancel;
                            break;
                    }
                }

                exceptionsViewModel.ResponseStatus = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                exceptionsViewModel.ResponseMessage = ex.ToString();
                exceptionsViewModel.ResponseStatus = ResponseStatus.Failed;

                //ToDo Integrate logging service.
            }

            exceptionsViewModel.ResponseDateTime = DateTime.Now;

            return exceptionsViewModel;
        }
    }
}
