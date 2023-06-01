using SCG.CHEM.MBR.DATAACCESS.Entities.Master;
using SCG.CHEM.MBR.DATAACCESS.Repository.Master.Interface;
using SCG.CHEM.SSPLSP.DATAACCESS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.MBR.DATAACCESS.Repository.Master
{
    public class MasterRepo : RepositoryBase<MBR_MST_MASTER>, IMasterRepo
    {
        #region Inject

        public MasterRepo(EntitiesMBRContext context, EntitiesMBRReadContext readContext) : base(context, readContext)
        {
        }

        #endregion Inject

        public List<MBR_MST_MASTER> GetPlanType(List<string> data)
        {
            var result = _context.MBR_MST_MASTERs.Where(s => data.Contains(s.PlanType)).ToList();
            return result;
        }

        public List<MBR_MST_MASTER> GetMaster(int masterId)
        {
            var result = _context.MBR_MST_MASTERs.Where(s => masterId == s.MasterId).ToList();
            return result;
        }

        public List<MBR_MST_MASTER> GetMasterFromName(string masterName)
        {
            var result = _context.MBR_MST_MASTERs.Where(s => s.MasterName == masterName).ToList();
            return result;
        }
    }
}