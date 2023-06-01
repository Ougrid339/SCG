using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Template;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Temp.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Temp
{
    public class MasterTempTariffDestinationDeliveryCostRepo : RepositoryBase<SSP_TMP_TARIFF_DESTINATION_DELIVERY_COST>, IMasterTempTariffDestinationDeliveryCostRepo
    {
        #region Inject

        public MasterTempTariffDestinationDeliveryCostRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        public List<SSP_TMP_TARIFF_DESTINATION_DELIVERY_COST> GetByKey(string planType, string productionSite, string region, string startMonth)
        {
            var result = _context.SSP_TMP_TARIFF_DESTINATION_DELIVERY_COSTs.Where(s => s.PlanType == planType && s.ProductionSite == productionSite && s.Region == region && s.StartMonth == startMonth && s.DeletedFlag != APPCONSTANT.DELETE_FLAG.YES).ToList();
            return result;
        }

        public void Truncate()
        {
            var data = _context.SSP_TMP_TARIFF_DESTINATION_DELIVERY_COSTs.ToList();
            _context.RemoveRange(data);
        }
    }
}