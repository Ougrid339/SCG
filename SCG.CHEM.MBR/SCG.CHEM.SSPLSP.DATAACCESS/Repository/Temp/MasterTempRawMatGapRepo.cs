using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Template;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Temp.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Temp
{
    public class MasterTempRawMatGapRepo : RepositoryBase<SSP_TMP_RAW_MAT_GAP>, IMasterTempRawMatGapRepo
    {
        #region Inject

        public MasterTempRawMatGapRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        public List<SSP_TMP_RAW_MAT_GAP> GetByKey(string productionSite, string planType, string company, string matCode, string startMonth)
        {
            var result = _context.SSP_TMP_RAW_MAT_GAPs.Where(s => s.ProductionSite == productionSite && s.PlanType == planType && s.Company == company && s.MatCode == matCode
                                                               && s.StartMonth == startMonth && s.DeletedFlag != APPCONSTANT.DELETE_FLAG.YES).ToList();
            return result;
        }

        public void Truncate()
        {
            var data = _context.SSP_TMP_RAW_MAT_GAPs.ToList();
            _context.RemoveRange(data);
        }
    }
}