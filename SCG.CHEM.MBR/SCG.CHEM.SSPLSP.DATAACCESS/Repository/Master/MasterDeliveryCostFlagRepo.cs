using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Temp.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master
{
    public class MasterDeliveryCostFlagRepo : RepositoryBase<SSP_MST_DELIVERY_COST_FLAG>, IMasterDeliveryCostFlagRepo
    {
        #region Inject

        public MasterDeliveryCostFlagRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        public List<SSP_MST_DELIVERY_COST_FLAG> GetByKey(string productionSite, string plantType, string matPrefix, string product, string productSub, string channelGroup, string deliveryMethod, string startMonth)
        {
            var result = _context.SSP_MST_DELIVERY_COST_FLAGs.Where(s => s.DeletedFlag != APPCONSTANT.DELETE_FLAG.YES && s.ProductionSite == productionSite && s.PlanType == plantType && s.MatPrefix == matPrefix && s.Product == product
                        && s.ProductSub == productSub && s.ChannelGroup == channelGroup && s.DeliveryMethod == deliveryMethod && s.StartMonth == startMonth).ToList();
            return result;
        }

        public List<SSP_MST_DELIVERY_COST_FLAG> GetAllByKeyAndVersion(string productionSite, string plantType, string matPrefix, string product, string productSub, string channelGroup, string deliveryMethod, string startMonth, int versionNo)
        {
            var result = _context.SSP_MST_DELIVERY_COST_FLAGs.Where(s => s.VersionNo == versionNo && s.ProductionSite == productionSite && s.PlanType == plantType && s.MatPrefix == matPrefix && s.Product == product
                        && s.ProductSub == productSub && s.ChannelGroup == channelGroup && s.DeliveryMethod == deliveryMethod && s.StartMonth == startMonth).ToList();
            return result;
        }
    }
}