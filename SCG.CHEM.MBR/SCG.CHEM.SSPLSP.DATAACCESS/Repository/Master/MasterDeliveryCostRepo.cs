using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master
{
    public class MasterDeliveryCostRepo : RepositoryBase<SSP_MST_DELIVERY_COST>, IMasterDeliveryCostRepo
    {
        #region Inject

        public MasterDeliveryCostRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        public List<SSP_MST_DELIVERY_COST> GetByKey(string productionSite, string planType, string matPrefix, string product, string productSub, string channelGroup, string startMonth)
        {
            var result = _context.SSP_MST_DELIVERY_COSTs.Where(s => s.DeletedFlag != APPCONSTANT.DELETE_FLAG.YES && s.ProductionSite == productionSite && s.PlanType == planType && s.MatPrefix == matPrefix && s.Product == product && s.ProductSub == productSub && s.ChannelGroup == channelGroup && s.StartMonth == startMonth).ToList();
            return result;
        }

        public List<SSP_MST_DELIVERY_COST> GetAllByKeyAndVersion(string productionSite, string planType, string matPrefix, string product, string productSub, string channelGroup, string startMonth, int versionNo)
        {
            var result = _context.SSP_MST_DELIVERY_COSTs.Where(s => s.VersionNo == versionNo && s.ProductionSite == productionSite && s.PlanType == planType && s.MatPrefix == matPrefix && s.Product == product && s.ProductSub == productSub && s.ChannelGroup == channelGroup && s.StartMonth == startMonth).ToList();
            return result;
        }
    }
}