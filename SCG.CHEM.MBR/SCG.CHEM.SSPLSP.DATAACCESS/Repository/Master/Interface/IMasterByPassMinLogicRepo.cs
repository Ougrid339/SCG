using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface
{
    public interface IMasterByPassMinLogicRepo : IRepositoryBase<SSP_MST_BYPASS_MIN_LOGIC>
    {
        SSP_MST_BYPASS_MIN_LOGIC GetById(int id);
    }
}