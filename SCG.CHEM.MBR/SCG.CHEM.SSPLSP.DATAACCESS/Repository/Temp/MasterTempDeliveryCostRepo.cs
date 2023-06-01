using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Template;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Temp.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Temp
{
    public class MasterTempDeliveryCostRepo : RepositoryBase<SSP_TMP_DELIVERY_COST>, IMasterTempDeliveryCostRepo
    {
        #region Inject

        public MasterTempDeliveryCostRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        public List<SSP_TMP_DELIVERY_COST> GetByKey(string productionSite, string planType, string matPrefix, string product, string productSub, string channelGroup, string startMonth)
        {
            var result = _context.SSP_TMP_DELIVERY_COSTs.Where(s => s.ProductionSite == productionSite && s.PlanType == planType && s.MatPrefix == matPrefix && s.Product == product && s.ProductSub == productSub && s.ChannelGroup == channelGroup && s.StartMonth == startMonth).ToList();
            return result;
        }

        public void Truncate()
        {
            var data = _context.SSP_TMP_DELIVERY_COSTs.ToList();
            _context.RemoveRange(data);
        }
    }
}