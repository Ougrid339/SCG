using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Template;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Temp.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Temp
{
    public class MasterTempMonomerPriceRepo : RepositoryBase<SSP_TMP_MONOMER_PRICE>, IMasterTempMonomerPriceRepo
    {
        #region Inject

        public MasterTempMonomerPriceRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        public List<SSP_TMP_MONOMER_PRICE> GetByKey(string planType, string inputM1, string versionName, string monomer, int priceUnitId, string monthNo)
        {
            var result = _context.SSP_TMP_MONOMER_PRICEs.Where(s => s.PlanType == planType && s.InputM1 == inputM1 && s.VersionName == versionName && s.Monomer == monomer && s.PriceUnitId == priceUnitId && s.MonthNo == monthNo).ToList();
            return result;
        }

        public void Truncate()
        {
            var data = _context.SSP_TMP_MONOMER_PRICEs.ToList();
            _context.RemoveRange(data);
        }
    }
}