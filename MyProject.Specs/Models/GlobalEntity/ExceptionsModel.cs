using System;
using MyProject.Specs.Data.GlobalEntity;
using MyProject.Specs.Enums;
using MyProject.Specs.ViewModels;

namespace MyProject.Specs.Models.GlobalEntity
{
    public class ExceptionsModel : IExceptionsModel
    {
        private IExceptionsData _exceptionsData;

        public ExceptionsModel()
        {
            _exceptionsData = new ExceptionsData();
        }

        public ExceptionsModel(IExceptionsData exceptionsData)
        {
            _exceptionsData = exceptionsData;
        }

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
            }

            exceptionsViewModel.ResponseDateTime = DateTime.Now;

            return exceptionsViewModel;
        }
    }
}
