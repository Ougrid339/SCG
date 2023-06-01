using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master
{
    public class MasterCustomerRepo : RepositoryBase<SSP_FCT_BUSINESS_PARTNER>, IMasterCustomerRepo
    {
        #region Inject

        public MasterCustomerRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        public List<SSP_FCT_BUSINESS_PARTNER> GetCustomer(List<string> data)
        {
            var result = _context.SSP_FCT_BUSINESS_PARTNERs.Where(w => data.Contains(w.BusinessPartner) && w.ActiveStatus != "X").ToList();
            return result;
        }
    }
}