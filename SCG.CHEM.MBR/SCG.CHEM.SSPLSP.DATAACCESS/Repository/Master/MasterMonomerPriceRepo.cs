using SCG.CHEM.SSPLSP.DATAACCESS.AppModels.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master
{
    public class MasterMonomerPriceRepo : RepositoryBase<SSP_MST_MONOMER_PRICE>, IMasterMonomerPriceRepo
    {
        #region Inject

        public MasterMonomerPriceRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        public List<SSP_MST_MONOMER_PRICE> GetAllByKeyAndVersion(string planType, string inputM1, string versionName, string monomer, int priceUnitId, string monthNo, int versionNo)
        {
            var result = _context.SSP_MST_MONOMER_PRICEs.Where(s => s.PlanType == planType && s.InputM1 == inputM1 && s.VersionName == versionName && s.Monomer == monomer && s.PriceUnitId == priceUnitId && s.MonthNo == monthNo && s.VersionNo == versionNo).ToList();
            return result;
        }

        public List<SSP_MST_MONOMER_PRICE> GetByKey(string planType, string inputM1, string versionName, string monomer, int priceUnitId, string monthNo)
        {
            var result = _context.SSP_MST_MONOMER_PRICEs.Where(s => s.DeletedFlag != APPCONSTANT.DELETE_FLAG.YES && s.PlanType == planType && s.InputM1 == inputM1 && s.VersionName == versionName && s.Monomer == monomer && s.PriceUnitId == priceUnitId && s.MonthNo == monthNo).ToList();
            return result;
        }
    }
}