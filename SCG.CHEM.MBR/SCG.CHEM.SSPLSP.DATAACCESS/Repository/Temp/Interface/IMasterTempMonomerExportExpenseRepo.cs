using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Temp.Interface
{
    public interface IMasterTempMonomerExportExpenseRepo : IRepositoryBase<SSP_TMP_MONOMER_EXPORT_EXPENSE>
    {
        List<SSP_TMP_MONOMER_EXPORT_EXPENSE> GetByKey(string productionSite, string planType, string matPrefix, string product, string productSub, string startMonth);

        public void Truncate();
    }
}