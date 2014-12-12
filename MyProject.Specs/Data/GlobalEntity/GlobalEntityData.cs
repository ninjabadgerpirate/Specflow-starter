using System;
using System.Linq;
using MyProject.Specs.Entity;

namespace MyProject.Specs.Data.GlobalEntity
{
    public class GlobalEntityData : IGlobalEntityData
    {
        private GeniSysEntities db;

        /// <summary>
        /// This is the default constructor.
        /// </summary>
        public GlobalEntityData()
        {
            db = new GeniSysEntities();
        }

        /// <summary>
        /// This method retrieves any GlobalEntity records that match the GovID passed in.
        /// </summary>
        /// <param name="govID">The GovID you are wanting to retrieve records for.</param>
        /// <returns>An office view model containing the validity response.</returns>
        public Entity.GlobalEntity FindByGovID(string govID)
        {
            var result = new Entity.GlobalEntity();;

            try
            {
                result = db.GlobalEntity.SingleOrDefault(x => x.GovID == govID);
            }
            catch (Exception ex)
            {
                //ToDo add logging.
            }

            return result;
        }
    }
}
