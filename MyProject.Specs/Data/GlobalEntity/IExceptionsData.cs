using System.Collections.Generic;
using MyProject.Specs.Entity;

namespace MyProject.Specs.Data.GlobalEntity
{
    public interface IExceptionsData
    {
        IList<Exceptions> ReturnMatchingExceptions(string govID);
    }
}
