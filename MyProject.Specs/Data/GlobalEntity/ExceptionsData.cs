using System;
using System.Linq;
using MyProject.Specs.Entity;
using MyProject.Specs.Enums;
using MyProject.Specs.Models;
using MyProject.Specs.ViewModels;

namespace MyProject.Specs.Data.GlobalEntity
{
    public class ExceptionsData : IExceptionsData
    {
        private GeniSysEntities _db;

        public ExceptionsData()
        {
            _db = new GeniSysEntities();    
        }

        public ExceptionsViewModel IsException(string govID)
        {
            var exceptionsViewModel = new ExceptionsViewModel();
            exceptionsViewModel.GovIDExceptionStatus = GovIDExceptionStatusEnum.NoException;

            try
            {
                exceptionsViewModel.Exceptions = _db.Exceptions.Where(x => x.GovID == govID).ToList();
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
