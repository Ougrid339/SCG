using SCG.CHEM.MBR.DATAACCESS.AppModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.MBR.DATAACCESS.Repository.Master.Interface
{
    public interface IMasterCompanyRepo
    {
        List<DropdownModel> GetCompany();
    }
}
