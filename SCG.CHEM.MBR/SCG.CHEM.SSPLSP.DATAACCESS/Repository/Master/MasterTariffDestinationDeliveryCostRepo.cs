using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Template;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master
{
    public class MasterTariffDestinationDeliveryCostRepo : RepositoryBase<SSP_MST_TARIFF_DESTINATION_DELIVERY_COST>, IMasterTariffDestinationDeliveryCostRepo
    {
        #region Inject

        public MasterTariffDestinationDeliveryCostRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        public List<SSP_MST_TARIFF_DESTINATION_DELIVERY_COST> GetByKey(string planType, string productionSite, string region, string startMonth)
        {
            var result = _context.SSP_MST_TARIFF_DESTINATION_DELIVERY_COSTs.Where(s => s.PlanType == planType && s.ProductionSite == productionSite && s.Region == region && s.StartMonth == startMonth && s.DeletedFlag != APPCONSTANT.DELETE_FLAG.YES).ToList();
            return result;
        }

        public List<SSP_MST_TARIFF_DESTINATION_DELIVERY_COST> GetAllByKeyAndVersion(string planType, string productionSite, string region, string product, string productSub, string startMonth, int versionNo)
        {
            var result = _context.SSP_MST_TARIFF_DESTINATION_DELIVERY_COSTs.Where(s => s.VersionNo == versionNo && s.ProductionSite == productionSite && s.PlanType == planType && s.Region == region && s.Product == product && s.ProductSub == productSub && s.StartMonth == startMonth).ToList();
            return result;
        }
    }
}