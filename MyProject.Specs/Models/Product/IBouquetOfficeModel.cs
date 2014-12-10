using MyProject.Specs.ViewModels;

namespace MyProject.Specs.Models.Product
{
    public interface IBouquetOfficeModel
    {
        BouquetOfficeViewModel ReturnBouquetsForOfficeCode(string officeCode);
    }
}
