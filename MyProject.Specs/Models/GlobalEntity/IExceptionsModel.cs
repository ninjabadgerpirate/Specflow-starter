using MyProject.Specs.ViewModels;

namespace MyProject.Specs.Models.GlobalEntity
{
    public interface IExceptionsModel
    {
        ExceptionsViewModel IsException(string govID);
    }
}
