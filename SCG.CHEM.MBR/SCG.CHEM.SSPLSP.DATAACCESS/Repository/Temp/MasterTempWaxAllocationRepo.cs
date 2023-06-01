using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Template;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Temp.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Temp
{
    public class MasterTempWaxAllocationRepo : RepositoryBase<SSP_TMP_WAX_ALLOCATION>, IMasterTempWaxAllocationRepo
    {
        #region Inject

        public MasterTempWaxAllocationRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        public List<SSP_TMP_WAX_ALLOCATION> GetByKey(string planType, string waxGroupId, string fromProductionLine, string toProductionLine, string startMonth)
        {
            var result = _context.SSP_TMP_WAX_ALLOCATIONs.Where(s => s.PlanType == planType && s.WaxGroupId == waxGroupId && s.FromProductionLine == fromProductionLine && s.ToProductionLine == toProductionLine
                         && s.StartMonth == startMonth).ToList();
            return result;
        }

        public void Truncate()
        {
            var data = _context.SSP_TMP_WAX_ALLOCATIONs.ToList();
            _context.RemoveRange(data);
        }
    }
}