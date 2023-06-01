using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface
{
    public interface IMasterProjectStatusRepo : IRepositoryBase<SSP_MST_PROJECT_STATUS>
    {
        SSP_MST_PROJECT_STATUS GetById(int id);
    }
}