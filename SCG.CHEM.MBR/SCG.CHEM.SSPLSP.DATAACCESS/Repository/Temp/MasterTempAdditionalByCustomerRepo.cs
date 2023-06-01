using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Template;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Temp.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Temp
{
    public class MasterTempAdditionalByCustomerRepo : RepositoryBase<SSP_TMP_ADDITIONAL_BY_CUSTOMER>, IMasterTempAdditionalByCustomerRepo
    {
        #region Inject

        public MasterTempAdditionalByCustomerRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        public List<SSP_TMP_ADDITIONAL_BY_CUSTOMER> GetByKey(string productionSite, string planType, string matPrefix, string product, string productSub, string customer, string startMonth)
        {
            var result = _context.SSP_TMP_ADDITIONAL_BY_CUSTOMERs.Where(s => s.ProductionSite == productionSite && s.PlanType == planType && s.MatPrefix == matPrefix && s.Product == product
                        && s.ProductSub == productSub && s.Customer == customer && s.StartMonth == startMonth && s.DeletedFlag != APPCONSTANT.DELETE_FLAG.YES).ToList();
            return result;
        }

        public void Truncate()
        {
            var data = _context.SSP_TMP_ADDITIONAL_BY_CUSTOMERs.ToList();
            _context.RemoveRange(data);
        }
    }
}