using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface
{
    public interface IMasterMonomerExportExpenseRepo : IRepositoryBase<SSP_MST_MONOMER_EXPORT_EXPENSE>
    {
        List<SSP_MST_MONOMER_EXPORT_EXPENSE> GetByKey(string productionSite, string planType, string matPrefix, string product, string productSub, string startMonth);

        List<SSP_MST_MONOMER_EXPORT_EXPENSE> GetAllByKeyAndVersion(string productionSite, string planType, string matPrefix, string product, string productSub, string startMonth, int versionNo);
    }
}