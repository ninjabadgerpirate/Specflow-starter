using System.Collections.Generic;
using MyProject.Specs.Entity;
using MyProject.Specs.Enums;
using MyProject.Specs.Models;

namespace MyProject.Specs.ViewModels
{
    public class GlobalEntityViewModel : BaseResponse
    {
        public IList<GlobalEntity> GlobalEntity { get; set; }
        public bool IsValid { get; set; }
        public GovIDValidationResponseEnum GovIDValidationResponse { get; set; }
        public GovIDExceptionStatusEnum GovIDExceptionStatus { get; set; }
    }
}
