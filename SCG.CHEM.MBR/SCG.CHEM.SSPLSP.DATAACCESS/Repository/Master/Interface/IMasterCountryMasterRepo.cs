using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface
{
    public interface IMasterCountryMasterRepo : IRepositoryBase<SSP_MST_COUNTRYMASTER>
    {
        public List<SSP_MST_COUNTRYMASTER> GetByCountryCode(List<string> sountryCode);
    }
}
