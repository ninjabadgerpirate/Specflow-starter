using System.Collections.Generic;

namespace MyProject.Specs.Data.GlobalEntity
{
    public interface IGlobalEntityData
    {
        IList<Entity.GlobalEntity> FindByGovID(string govID);
    }
}
