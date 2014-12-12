using System.Collections.Generic;

namespace MyProject.Specs.Data.GlobalEntity
{
    public interface IGlobalEntityData
    {
        IList<MyProject.Specs.Entity.GlobalEntity> FindByGovID(string govID);
    }
}
