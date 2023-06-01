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
    public class MasterTempOperationChargeRepo : RepositoryBase<SSP_TMP_OPERATION_CHARGE>, IMasterTempOperationChargeRepo
    {
        #region Inject

        public MasterTempOperationChargeRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        public List<SSP_TMP_OPERATION_CHARGE> GetByKey(string planType, string sourceCompany, string product, string productSub, string channel, string saleOrg, string startMonth)
        {
            var result = _context.SSP_TMP_OPERATION_CHARGEs.Where(s => s.DeletedFlag != APPCONSTANT.DELETE_FLAG.YES && s.PlanType == planType
                          && s.SourceCompany == sourceCompany && s.Product == product && s.ProductSub == productSub && s.ChannelCode == channel && s.SalesOrg == saleOrg && s.StartMonth == startMonth).ToList();
            return result;
        }

        public void Truncate()
        {
            var data = _context.SSP_TMP_OPERATION_CHARGEs.ToList();
            _context.RemoveRange(data);
        }
    }
}