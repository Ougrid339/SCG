using SCG.CHEM.MBR.DATAACCESS.Entities.Master;
using SCG.CHEM.MBR.DATAACCESS.Repository.Master.Interface;
using SCG.CHEM.SSPLSP.DATAACCESS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SCG.CHEM.MBR.DATAACCESS.APPCONSTANT;

namespace SCG.CHEM.MBR.DATAACCESS.Repository.Master
{
    public class MasterCustomerVendorMappingRepo : RepositoryBase<MBR_MST_CUSTOMER_VENDOR_MAPPING>, IMasterCustomerVendorMappingRepo
    {
        #region Inject

        public MasterCustomerVendorMappingRepo(EntitiesMBRContext context, EntitiesMBRReadContext readContext) : base(context, readContext)
        {
        }

        #endregion Inject

        public List<MBR_MST_CUSTOMER_VENDOR_MAPPING> GetAllByKeyAndVersion(string customerShortName, string type, string sourceSystem, int versionNo)
        {
            var result = _context.MBR_MST_CUSTOMER_VENDOR_MAPPINGs
                .Where(s => s.VersionNo == versionNo
                         && s.CustomerShortName.ToUpper() == customerShortName.ToUpper()
                         && s.Type.ToUpper() == type.ToUpper()
                         && s.SourceSystem.ToUpper() == sourceSystem.ToUpper())
                .ToList();

            return result;
        }

        public List<MBR_MST_CUSTOMER_VENDOR_MAPPING> GetCustomerShortName(List<string> data)
        {
            var result = _context.MBR_MST_CUSTOMER_VENDOR_MAPPINGs.Where(w => data.Select(s => s.ToLower()).Contains(w.CustomerShortName.ToLower())

                                                                            && w.DeletedFlag == APPCONSTANT.DELETE_FLAG.NO).ToList();
            return result;
        }

        public List<MBR_MST_CUSTOMER_VENDOR_MAPPING> GetCustomerShortNameByCustomerCode(List<string> data)
        {
            var result = _context.MBR_MST_CUSTOMER_VENDOR_MAPPINGs.Where(w => data.Select(s => s.ToLower()).Contains(w.CustomerCode.ToLower())

                                                                            && w.DeletedFlag == APPCONSTANT.DELETE_FLAG.NO).ToList();
            return result;
        }
    }
}