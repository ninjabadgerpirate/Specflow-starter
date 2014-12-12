namespace MyProject.Specs.Data.GlobalEntity
{
    public interface IGlobalEntityData
    {
        Entity.GlobalEntity FindByGovID(string govID);
    }
}
