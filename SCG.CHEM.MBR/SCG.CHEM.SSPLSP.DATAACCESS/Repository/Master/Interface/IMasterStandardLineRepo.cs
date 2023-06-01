using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface
{
    public interface IMasterStandardLineRepo : IRepositoryBase<SSP_MST_STANDARD_LINE>
    {
        List<SSP_MST_STANDARD_LINE> GetByKey(string productionSite, string matPrefix, string grade);

        List<SSP_MST_STANDARD_LINE> GetAllByKeyAndVersion(string productionSite, string matPrefix, string grade, string productionline, string plant, int versionNo);
    }
}