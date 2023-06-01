using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master
{
    public class MasterDeliveryMethodRepo : RepositoryBase<SSP_MST_DELIVERY_METHOD>, IMasterDeliveryMethodRepo
    {
        #region Inject

        public MasterDeliveryMethodRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        public List<SSP_MST_DELIVERY_METHOD> GetDelivertMethod(List<string> data)
        {
            var result = _context.SSP_MST_DELIVERY_METHODs.Where(s => data.Contains(s.DeliveryMethod)).ToList();
            return result;
        }
    }
}