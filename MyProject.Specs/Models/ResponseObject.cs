using System;

namespace MyProject.Specs.Models
{
    public enum ResponseStatus
    {
        Failed = 0,
        Success = 1,
        Pending = 2
    }
    public class BaseResponse
    {
        public ResponseStatus ResponseStatus { get; set; }
        public string ResponseMessage { get; set; }
        public DateTime ResponseDateTime { get; set; }
    }
}
