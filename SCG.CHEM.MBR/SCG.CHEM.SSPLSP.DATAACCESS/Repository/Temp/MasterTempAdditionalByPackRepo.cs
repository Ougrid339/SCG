using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Template;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Temp.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Temp
{
    public class MasterTempAdditionalByPackRepo : RepositoryBase<SSP_TMP_ADDITIONAL_BY_PACK>, IMasterTempAdditionalByPackRepo
    {
        #region Inject

        public MasterTempAdditionalByPackRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        public List<SSP_TMP_ADDITIONAL_BY_PACK> GetByKey(string productionSite, string planType, string matPrefix, string product, string productSub, string package, string channelGroup, string startMonth)
        {
            var result = _context.SSP_TMP_ADDITIONAL_BY_PACKs.Where(s => s.ProductionSite == productionSite && s.PlanType == planType && s.MatPrefix == matPrefix && s.Product == product && s.ProductSub == productSub && s.Package == package && s.ChannelGroup == channelGroup && s.StartMonth == startMonth).ToList();
            return result;
        }

        public void Truncate()
        {
            var data = _context.SSP_TMP_ADDITIONAL_BY_PACKs.ToList();
            _context.RemoveRange(data);
        }
    }
}