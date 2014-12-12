using System;
using System.Collections.Generic;
using System.Linq;
using MyProject.Specs.Entity;
using MyProject.Specs.Enums;
using MyProject.Specs.Models;
using MyProject.Specs.ViewModels;

namespace MyProject.Specs.Data.GlobalEntity
{
    public class ExceptionsData : IExceptionsData
    {
        private GeniSysEntities _db;

        public ExceptionsData()
        {
            _db = new GeniSysEntities();    
        }

        public IList<Exceptions> ReturnMatchingExceptions(string govID)
        {
            var result = new List<Exceptions>();

            try
            {
                result = _db.Exceptions.Where(x => x.GovID == govID).ToList();
            }
            catch (Exception ex)
            {
                //ToDO Add Logging.
            }

            return result;
        }
    }
}
