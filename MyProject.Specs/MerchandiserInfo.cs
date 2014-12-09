using MyProject.Specs.Models.GlobalEntity;
using MyProject.Specs.Models.Product;

namespace MyProject.Specs
{
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

    public interface IMerchandiserInfo
    {
        
    }
}
