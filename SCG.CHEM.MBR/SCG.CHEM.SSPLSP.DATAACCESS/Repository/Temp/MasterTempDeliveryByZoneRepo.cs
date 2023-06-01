using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Template;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Temp.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master
{
    public class MasterTempDeliveryByZoneRepo : RepositoryBase<SSP_TMP_DELIVERY_BY_ZONE>, IMasterTempDeliveryByZoneRepo
    {
        #region Inject

        public MasterTempDeliveryByZoneRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        public List<SSP_TMP_DELIVERY_BY_ZONE> GetByKey(string productionSite, string plantType, string channelGroup, string Zone, string product, string productSub, string startMonth)
        {
            var result = _context.SSP_TMP_DELIVERY_BY_ZONEs.Where(s => s.DeletedFlag != APPCONSTANT.DELETE_FLAG.YES && s.ProductionSite == productionSite
                            && s.PlanType == plantType && s.ChannelGroup == channelGroup && s.Zone == Zone && s.Product == product && s.ProductSub == productSub && s.StartMonth == startMonth).ToList();
            return result;
        }

        public void Truncate()
        {
            var data = _context.SSP_TMP_DELIVERY_BY_ZONEs.ToList();
            _context.RemoveRange(data);
        }
    }
}