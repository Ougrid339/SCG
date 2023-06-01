using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Template;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Temp.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Temp
{
    public class MasterTempAFPStandardEarnRepo : RepositoryBase<SSP_TMP_AFP_STANDARD_EARN>, IMasterTempAFPStandardEarnRepo
    {
        #region Inject

        public MasterTempAFPStandardEarnRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        public List<SSP_TMP_AFP_STANDARD_EARN> GetByKey(string planType, string matPrefix, string grade, string productionLine, string startMonth)
        {
            var result = _context.SSP_TMP_AFP_STANDARD_EARNs.Where(s => s.PlanType == planType && s.MatPrefix == matPrefix && s.Grade == grade && s.ProductionLine == productionLine && s.StartMonth == startMonth).ToList();
            return result;
        }

        public void Truncate()
        {
            var data = _context.SSP_TMP_AFP_STANDARD_EARNs.ToList();
            _context.RemoveRange(data);
        }
    }
}