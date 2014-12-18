using System;

namespace MyProject.Specs.Models
{
    /// <summary>
    /// This is the ENUM that is used to indicate the success of each model call.
    /// All View Models should include one of the ENUM responses below to ensure that the caller knows if the request
    /// was successful or not.
    /// </summary>
    public enum ResponseStatus
    {
        Failed = 0,
        Success = 1,
        Pending = 2
    }

    /// <summary>
    /// This base abstract class is used to contain the most basic response from any of the models called.
    /// </summary>
    public abstract class BaseResponse
    {
        public ResponseStatus ResponseStatus { get; set; }
        public string ResponseMessage { get; set; }
        public DateTime ResponseDateTime { get; set; }
    }
}
