using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master
{
    public class MasterCompanyRepo : RepositoryBase<SSP_MST_COMPANY_CODE>, IMasterCompanyRepo
    {
        #region Inject

        public MasterCompanyRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        public List<SSP_MST_COMPANY_CODE> GetByCompanyCode(List<string> data)
        {
            var result = _context.SSP_MST_COMPANY_CODEs.Where(s => data.Contains(s.CompanyCode)).ToList();
            return result;
        }
        public List<SSP_MST_COMPANY_CODE> GetByShortName(List<string> shortNames)
        {
            var result = _context.SSP_MST_COMPANY_CODEs.Where(s => shortNames.Select(s=>s.ToLower()).Contains(s.CompanyShortName.ToLower())).ToList();
            return result;
        }
    }
}