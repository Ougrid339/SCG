using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master
{
    public class MasterRepo : RepositoryBase<SSP_MST_MASTER>, IMasterRepo
    {
        #region Inject

        public MasterRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        public List<SSP_MST_MASTER> GetPlanType(List<string> data)
        {
            var result = _context.SSP_MST_MASTERs.Where(s => data.Contains(s.PlanType)).ToList();
            return result;
        }

        public List<SSP_MST_MASTER> GetMaster(int masterId)
        {
            var result = _context.SSP_MST_MASTERs.Where(s => masterId == s.MasterId).ToList();
            return result;
        }

        public List<SSP_MST_MASTER> GetMasterFromName(string masterName)
        {
            var result = _context.SSP_MST_MASTERs.Where(s => s.MasterName == masterName).ToList();
            return result;
        }
    }
}