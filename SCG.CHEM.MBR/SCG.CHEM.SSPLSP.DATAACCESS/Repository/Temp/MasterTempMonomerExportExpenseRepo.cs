using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Template;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Temp.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Temp
{
    public class MasterTempMonomerExportExpenseRepo : RepositoryBase<SSP_TMP_MONOMER_EXPORT_EXPENSE>, IMasterTempMonomerExportExpenseRepo
    {
        #region Inject

        public MasterTempMonomerExportExpenseRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        public List<SSP_TMP_MONOMER_EXPORT_EXPENSE> GetByKey(string productionSite, string planType, string matPrefix, string product, string productSub, string startMonth)
        {
            var result = _context.SSP_TMP_MONOMER_EXPORT_EXPENSEs.Where(s => s.ProductionSite == productionSite && s.PlanType == planType && s.MatPrefix == matPrefix && s.Product == product && s.ProductSub == productSub && s.StartMonth == startMonth).ToList();
            return result;
        }

        public void Truncate()
        {
            var data = _context.SSP_TMP_MONOMER_EXPORT_EXPENSEs.ToList();
            _context.RemoveRange(data);
        }
    }
}