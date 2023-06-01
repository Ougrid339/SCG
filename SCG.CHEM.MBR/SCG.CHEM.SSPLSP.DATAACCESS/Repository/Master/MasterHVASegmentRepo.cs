using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master
{
    public class MasterHVASegmentRepo : RepositoryBase<SSP_MST_HVA_SEGMENT>, IMasterHVASegmentRepo
    {
        #region Inject

        public MasterHVASegmentRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        public SSP_MST_HVA_SEGMENT GetByHVACode(string code)
        {
            var result = _context.SSP_MST_HVA_SEGMENTs.Where(w => w.HVACode == code).FirstOrDefault();
            return result;
        }

        public List<SSP_MST_HVA_SEGMENT> GetByHVACodes(List<string> data)
        {
            var result = _context.SSP_MST_HVA_SEGMENTs.Where(w => data.Contains(w.HVACode)).ToList();
            return result;
        }
    }
}