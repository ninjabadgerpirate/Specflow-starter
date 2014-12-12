using MyProject.Specs.ViewModels;

namespace MyProject.Specs.Data.GlobalEntity
{
    public interface IExceptionsData
    {
        ExceptionsViewModel IsException(string govID);
    }
}
