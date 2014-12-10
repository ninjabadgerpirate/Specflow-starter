using MyProject.Specs.Enums;
using MyProject.Specs.Models;
using MyProject.Specs.Models.GlobalEntity;

namespace MyProject.Specs.ViewModels
{
    /// <summary>
    /// This ViewModel stores the response from any calls and includes the actual data returned.
    /// </summary>
    public class MerchViewModel : BaseResponse
    {
        public MerchModel MerchModel = new MerchModel();
        public bool IsValid { get; set; }
        public MerchCodeValidationResponseEnum MerchCodeValidationResponse { get; set; }
    }
}
