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
    public class MasterAdditionalByCustomerRepo : RepositoryBase<SSP_MST_ADDITIONAL_BY_CUSTOMER>, IMasterAdditionalByCustomerRepo
    {
        #region Inject

        public MasterAdditionalByCustomerRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        public List<SSP_MST_ADDITIONAL_BY_CUSTOMER> GetByKey(string productionSite, string planType, string matPrefix, string product, string productSub, string customer, string startMonth)
        {
            var result = _context.SSP_MST_ADDITIONAL_BY_CUSTOMERs.Where(s => s.ProductionSite == productionSite && s.PlanType == planType && s.MatPrefix == matPrefix && s.Product == product
                        && s.ProductSub == productSub && s.Customer == customer && s.StartMonth == startMonth && s.DeletedFlag != APPCONSTANT.DELETE_FLAG.YES).ToList();
            return result;
        }

        public List<SSP_MST_ADDITIONAL_BY_CUSTOMER> GetAllByKeyAndVersion(string productionSite, string planType, string matPrefix, string product, string productSub, string customer, string startMonth, int versionNo)
        {
            var result = _context.SSP_MST_ADDITIONAL_BY_CUSTOMERs.Where(s => s.ProductionSite == productionSite && s.PlanType == planType && s.MatPrefix == matPrefix && s.Product == product
                        && s.ProductSub == productSub && s.Customer == customer && s.StartMonth == startMonth && s.VersionNo == versionNo).ToList();
            return result;
        }
    }
}