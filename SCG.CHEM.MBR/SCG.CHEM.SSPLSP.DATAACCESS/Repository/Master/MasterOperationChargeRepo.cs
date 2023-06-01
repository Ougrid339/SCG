using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Template;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master
{
    public class MasterOperationChargeRepo : RepositoryBase<SSP_MST_OPERATION_CHARGE>, IMasterOperationChargeRepo
    {
        #region Inject

        public MasterOperationChargeRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        public List<SSP_MST_OPERATION_CHARGE> GetByKey(string planType, string sourceCompany, string product, string productSub, string channel, string saleOrg, string startMonth)
        {
            var result = _context.SSP_MST_OPERATION_CHARGEs.Where(s => s.DeletedFlag != APPCONSTANT.DELETE_FLAG.YES && s.PlanType == planType
                          && s.SourceCompany == sourceCompany && s.Product == product && s.ProductSub == productSub && s.ChannelCode == channel && s.SalesOrg == saleOrg && s.StartMonth == startMonth).ToList();
            return result;
        }

        public List<SSP_MST_OPERATION_CHARGE> GetAllByKeyAndVersion(string planType, string sourceCompany, string product, string productSub, string channel, string saleOrg, string startMonth, int versionNo)
        {
            var result = _context.SSP_MST_OPERATION_CHARGEs.Where(s => s.VersionNo == versionNo && s.PlanType == planType
                          && s.SourceCompany == sourceCompany && s.Product == product && s.ProductSub == productSub && s.ChannelCode == channel && s.SalesOrg == saleOrg && s.StartMonth == startMonth).ToList();
            return result;
        }
    }
}