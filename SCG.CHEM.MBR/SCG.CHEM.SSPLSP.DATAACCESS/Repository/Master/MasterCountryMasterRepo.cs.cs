using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master
{
    internal class MasterCountryMasterRepo : RepositoryBase<SSP_MST_COUNTRYMASTER>, IMasterCountryMasterRepo
    {
        public MasterCountryMasterRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
        {
        }

        public List<SSP_MST_COUNTRYMASTER> GetByCountryCode(List<string> sountryCode)
        {
            var data = sountryCode.Where(w => !string.IsNullOrEmpty(w)).Select(s => s.ToLower());
            var result = _context.SSP_MST_COUNTRYMASTERs.Where(w =>data!=null && data.Contains(w.CountryCode)).ToList();
            return result;
        }
    }
}
