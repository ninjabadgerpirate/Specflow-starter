using MyProject.Specs.ViewModels;

namespace MyProject.Specs.Models.GlobalEntity
{
    public interface IGlobalEntityModel
    {
        GlobalEntityViewModel ValidateGovID(string govID);
        GlobalEntityViewModel FindByGovID(string govID);
        GlobalEntityViewModel GovIDIsValid(string govID);
    }
}
