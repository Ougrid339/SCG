using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface
{
    public interface IMasterCompanyRepo : IRepositoryBase<SSP_MST_COMPANY_CODE>
    {
        List<SSP_MST_COMPANY_CODE> GetByCompanyCode(List<string> data);
        List<SSP_MST_COMPANY_CODE> GetByShortName(List<string> shortNames);
    }
}