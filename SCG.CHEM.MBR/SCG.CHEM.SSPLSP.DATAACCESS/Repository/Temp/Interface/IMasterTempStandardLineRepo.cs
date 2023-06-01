using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Temp.Interface
{
    public interface IMasterTempStandardLineRepo : IRepositoryBase<SSP_TMP_STANDARD_LINE>
    {
        List<SSP_TMP_STANDARD_LINE> GetByKey(string productionSite, string matPrefix, string grade);

        void Truncate();
    }
}