using SCG.CHEM.MBR.DATAACCESS.Entities.Master;
using SCG.CHEM.MBR.DATAACCESS.Repository.Master.Interface;
using SCG.CHEM.SSPLSP.DATAACCESS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.MBR.DATAACCESS.Repository.Master
{
    public class MasterProductMappingRepo : RepositoryBase<MBR_MST_PRODUCT_MAPPING>, IMasterProductMappingRepo
    {
        #region Inject

        public MasterProductMappingRepo(EntitiesMBRContext context, EntitiesMBRReadContext readContext) : base(context, readContext)
        {
        }

        #endregion Inject

        public List<MBR_MST_PRODUCT_MAPPING> GetProductMapping(List<string> data)
        {
            var result = _context.MBR_MST_PRODUCT_MAPPINGs.Where(w => data.Contains(w.ProductShortName) && w.DeletedFlag == APPCONSTANT.DELETE_FLAG.NO).ToList();
            return result;
        }

        public List<MBR_MST_PRODUCT_MAPPING> GetAllByKeyAndVersion(string materialCode, string sourceSystem, int versionNo)
        {
            var result = _context.MBR_MST_PRODUCT_MAPPINGs.Where(s => s.VersionNo == versionNo && s.SourceSystem.ToUpper() == sourceSystem.ToUpper() && s.MaterialCode == materialCode).ToList();
            return result;
        }

        public List<MBR_MST_PRODUCT_MAPPING> GetProductShortName(List<string> data)
        {
            var result = _context.MBR_MST_PRODUCT_MAPPINGs.Where(w => data.Select(s => s.ToLower()).Contains(w.ProductShortName.ToLower()) && w.DeletedFlag == APPCONSTANT.DELETE_FLAG.NO).ToList();
            return result;
        }

        public List<MBR_MST_PRODUCT_MAPPING> GetMaterialCode(List<string> data)
        {
            var result = _context.MBR_MST_PRODUCT_MAPPINGs.Where(w => data.Select(s => s.ToLower()).Contains(w.MaterialCode.ToLower()) && w.DeletedFlag == APPCONSTANT.DELETE_FLAG.NO).ToList();
            return result;
        }

        public List<MBR_MST_PRODUCT_MAPPING> GetProductGroup(string data)
        {
            var result = _context.MBR_MST_PRODUCT_MAPPINGs.Where(w => w.ProductShortName.ToLower() == data.ToLower() && w.DeletedFlag == APPCONSTANT.DELETE_FLAG.NO).ToList();
            return result;
        }
    }
}