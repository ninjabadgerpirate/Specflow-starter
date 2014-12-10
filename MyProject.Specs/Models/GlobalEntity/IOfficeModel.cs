using MyProject.Specs.ViewModels;

namespace MyProject.Specs.Models.GlobalEntity
{
    public interface IOfficeModel
    {
        OfficeViewModel ValidateOfficeCode(string officeCode);
        OfficeViewModel OfficeCodeExists(string officeCode);
        OfficeViewModel OfficeCodeIsActive(string officeCode);
        OfficeViewModel OfficeCodeIsValid(string officeCode);
    }
}
