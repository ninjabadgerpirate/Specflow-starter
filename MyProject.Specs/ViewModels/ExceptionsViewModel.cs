using System.Collections.Generic;
using MyProject.Specs.Entity;
using MyProject.Specs.Enums;
using MyProject.Specs.Models;

namespace MyProject.Specs.ViewModels
{
    public class ExceptionsViewModel : BaseResponse
    {
        public List<Exceptions> Exceptions { get; set; }
        public GovIDExceptionStatusEnum GovIDExceptionStatus { get; set; }
    }
}
