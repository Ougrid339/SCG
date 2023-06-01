using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master
{
    public class MasterNewProductFlagRepo : RepositoryBase<SSP_MST_NEW_PRODUCT_FLAG>, IMasterNewProductFlagRepo
    {
        #region Inject

        public MasterNewProductFlagRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        public List<SSP_MST_NEW_PRODUCT_FLAG> GetByNewProductDesc(List<string> data)
        {
            var result = _context.SSP_MST_NEW_PRODUCT_FLAGs.Where(w => data.Contains(w.NewProductLDesc)).ToList();
            return result;
        }
    }
}