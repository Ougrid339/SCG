using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Template;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Temp.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Temp
{
    internal class MasterTempDeliveryCostFlagRepo : RepositoryBase<SSP_TMP_DELIVERY_COST_FLAG>, IMasterTempDeliveryCostFlagRepo
    {
        #region Inject

        public MasterTempDeliveryCostFlagRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        public List<SSP_TMP_DELIVERY_COST_FLAG> GetByKey(string productionSite, string matPrefix, string product, string productSub, string channelGroup, string deliveryMethod, string startMonth)
        {
            var result = _context.SSP_TMP_DELIVERY_COST_FLAGs.Where(s => s.ProductionSite == productionSite && s.MatPrefix == matPrefix && s.Product == product
                        && s.ProductSub == productSub && s.ChannelGroup == channelGroup && s.DeliveryMethod == deliveryMethod && s.StartMonth == startMonth).ToList();
            return result;
        }

        public void Truncate()
        {
            var data = _context.SSP_TMP_DELIVERY_COST_FLAGs.ToList();
            _context.RemoveRange(data);
        }
    }
}