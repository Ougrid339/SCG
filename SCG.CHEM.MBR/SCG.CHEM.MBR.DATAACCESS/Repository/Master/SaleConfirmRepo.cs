using SCG.CHEM.MBR.DATAACCESS.Entities.Master;
using SCG.CHEM.MBR.DATAACCESS.Repository.Master.Interface;

namespace SCG.CHEM.MBR.DATAACCESS.Repository.Master
{
    public class SaleConfirmRepo : RepositoryBase<MBR_MST_SALECONFIRM>, ISaleConfirmRepo
    {
        #region Inject

        public SaleConfirmRepo(EntitiesMBRContext context, EntitiesMBRReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        public MBR_MST_SALECONFIRM FindByCriteria(string planType, string cycle, string @case, string productGroup)
        {
            var result = _context.MBR_MST_SALECONFIRMs.Where(w => w.PlanType == planType && w.Cycle == cycle && w.Case == @case && w.ProductGroup == productGroup).FirstOrDefault();
            return result;
        }

        public List<MBR_MST_SALECONFIRM> FindByCriteria(string planType, string cycle, string @case)
        {
            var result = _context.MBR_MST_SALECONFIRMs.Where(w => w.PlanType == planType && w.Cycle == cycle && w.Case == @case).ToList();
            return result;
        }
    }
}