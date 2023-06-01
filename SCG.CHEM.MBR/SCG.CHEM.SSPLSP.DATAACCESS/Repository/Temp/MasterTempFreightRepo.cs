using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Template;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Temp.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Temp
{
    public class MasterTempFreightRepo : RepositoryBase<SSP_TMP_FREIGHT>, IMasterTempFreightRepo
    {
        #region Inject

        public MasterTempFreightRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        public List<SSP_TMP_FREIGHT> GetByKey(string productionSite, string regionCode, string planType, string startMonth)
        {
            var result = _context.SSP_TMP_FREIGHTs.Where(s => s.ProductionSite == productionSite && s.RegionCode == regionCode && s.PlanType == planType && s.StartMonth == startMonth).ToList();
            return result;
        }

        public void Truncate()
        {
            var data = _context.SSP_TMP_FREIGHTs.ToList();
            _context.RemoveRange(data);
        }
    }
}