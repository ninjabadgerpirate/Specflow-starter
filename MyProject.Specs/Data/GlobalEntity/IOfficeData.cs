using System.Collections.Generic;
using MyProject.Specs.Entity;

namespace MyProject.Specs.Data.GlobalEntity
{
    public interface IOfficeData
    {
        IList<Office> FindMatchingOffices(string officeCode, ref string errorMessage);
    }
}
