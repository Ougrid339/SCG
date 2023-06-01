using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master
{
    public class MasterAdditionalByPackRepo : RepositoryBase<SSP_MST_ADDITIONAL_BY_PACK>, IMasterAdditionalByPackRepo
    {
        #region Inject

        public MasterAdditionalByPackRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        public List<SSP_MST_ADDITIONAL_BY_PACK> GetByKey(string productionSite, string planType, string matPrefix, string product, string productSub, string package, string channelGroup, string startMonth)
        {
            var result = _context.SSP_MST_ADDITIONAL_BY_PACKs.Where(s => s.DeletedFlag != APPCONSTANT.DELETE_FLAG.YES && s.ProductionSite == productionSite && s.PlanType == planType && s.MatPrefix == matPrefix && s.Product == product && s.ProductSub == productSub && s.Package == package && s.ChannelGroup == channelGroup && s.StartMonth == startMonth).ToList();
            return result;
        }

        public List<SSP_MST_ADDITIONAL_BY_PACK> GetAllByKeyAndVersion(string productionSite, string planType, string matPrefix, string product, string productSub, string package, string channelGroup, string startMonth, int versionNo)
        {
            var result = _context.SSP_MST_ADDITIONAL_BY_PACKs.Where(s => s.VersionNo == versionNo && s.ProductionSite == productionSite && s.PlanType == planType && s.MatPrefix == matPrefix && s.Product == product && s.ProductSub == productSub && s.Package == package && s.ChannelGroup == channelGroup && s.StartMonth == startMonth).ToList();
            return result;
        }
    }
}