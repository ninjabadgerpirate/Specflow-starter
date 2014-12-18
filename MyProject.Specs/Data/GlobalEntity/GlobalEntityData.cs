using System;
using System.Collections.Generic;
using System.Linq;
using MyProject.Specs.Entity;

namespace MyProject.Specs.Data.GlobalEntity
{
    /// <summary>
    /// This class acts as the source of data required for the business rules in the GlobalEntity model.
    /// </summary>
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
        public IList<Entity.GlobalEntity> FindByGovID(string govID)
        {
            var result = new List<Entity.GlobalEntity>();

            try
            {
                result = db.GlobalEntity.Where(x => x.GovID == govID).ToList();
            }
            catch (Exception ex)
            {
                //ToDo add logging.
            }

            return result;
        }
    }
}
