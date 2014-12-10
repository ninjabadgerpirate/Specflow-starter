using MyProject.Specs.Enums;
using MyProject.Specs.Models;
using MyProject.Specs.Models.GlobalEntity;

namespace MyProject.Specs.ViewModels
{
    /// <summary>
    /// This ViewModel stores the response from any calls and includes the actual data returned.
    /// </summary>
    public class OfficeViewModel : BaseResponse   
    {
        public OfficeModel OfficeModel { get; set; }
        public bool IsValid { get; set; }
        public OfficeCodeValidationResponseEnum OfficeCodeValidationResponse { get; set; }
    }
}
