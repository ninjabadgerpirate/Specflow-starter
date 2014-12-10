using System.Collections.Generic;
using MyProject.Specs.Entity;
using MyProject.Specs.Models;

namespace MyProject.Specs.ViewModels
{
    /// <summary>
    /// This ViewModel stores the response from any calls and includes the actual data returned.
    /// </summary>
    public class BouquetOfficeViewModel : BaseResponse
    {
        public IList<BouquetOffice> BouquetOffice { get; set; }
    }
}
