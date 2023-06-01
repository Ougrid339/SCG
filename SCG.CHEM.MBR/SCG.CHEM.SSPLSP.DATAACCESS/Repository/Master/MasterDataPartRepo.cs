using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master
{
    public class MasterDataPartRepo : RepositoryBase<SSP_MST_DATAPART>, IMasterDataPartRepo
    {
        #region Inject

        public MasterDataPartRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        public List<SSP_MST_DATAPART> GetByCodes(List<string> data)
        {
            var result = _context.SSP_MST_DATAPARTs.Where(s => data.Contains(s.Code)).ToList();
            return result;
        }
    }
}