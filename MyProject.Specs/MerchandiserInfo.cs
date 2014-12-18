using MyProject.Specs.Models.GlobalEntity;
using MyProject.Specs.Models.Product;

namespace MyProject.Specs
{
    /// <summary>
    /// This class will contain the implementation required for the Merchandiser feature as a whole.
    /// </summary>
    public class MerchandiserInfo : IMerchandiserInfo
    {
        private IOfficeModel officeModel;
        private IBouquetOfficeModel bouquetOfficeModel;
        private IMerchModel merchModel;

        public MerchandiserInfo()
        {
            officeModel = new OfficeModel();
            bouquetOfficeModel = new BouquetOfficeModel();
            merchModel = new MerchModel();
        }
    }
}
