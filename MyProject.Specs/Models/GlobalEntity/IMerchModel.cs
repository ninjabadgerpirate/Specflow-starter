using MyProject.Specs.ViewModels;

namespace MyProject.Specs.Models.GlobalEntity
{
    public interface IMerchModel
    {
        MerchViewModel ValidateMerchCode(string merchCode);
        MerchViewModel MerchCodeIsValid(string merchCode);
        MerchViewModel MerchCodeExists(string merchCode);
        MerchViewModel MerchCodeIsActive(string merchCode);
    }
}
