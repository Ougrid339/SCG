using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master
{
    public class MasterHVASalesGroupDummyCustomerRepo : RepositoryBase<SSP_MST_HVA_SALES_GROUP_DUMMT_CUSTOMER>, IMasterHVASalesGroupDummyCustomerRepo
    {
        public MasterHVASalesGroupDummyCustomerRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
        {
        }
    }
}