using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master
{
    public class MasterHVASalesGroupGradeRepo : RepositoryBase<SSP_MST_HVA_SALES_GROUP_GRADE>, IMasterHVASalesGroupGradeRepo
    {
        public MasterHVASalesGroupGradeRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
        {
        }
    }
}