using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master
{
    public class FCTMaterialRepo : RepositoryBase<SSP_FCT_MATERIAL>, IFCTMaterialRepo
    {
        #region Inject

        public FCTMaterialRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        public List<SSP_FCT_MATERIAL> GetByMaterialCode(List<string> data)
        {
            var result = _context.SSP_FCT_MATERIALs.Where(o => o.FlagDelete != APPCONSTANT.DELETE_FLAG.YES && data.Contains(o.Material)).ToList();
            return result;
        }

        public List<string> GetMaterialCodeForMBR(List<string> data)
        {
            var result = _context.SSP_FCT_MATERIALs.Where(o =>
                        o.MaterialGroup != null
                     && (o.Material.StartsWith("z13") || o.Material.StartsWith("W7"))
                     && new[] { "FG", "RM" }.Contains(o.MaterialGroup)
                     && o.FlagDelete != APPCONSTANT.DELETE_FLAG.YES && data.Contains(o.Material)).Select(o => o.Material).Distinct().ToList();
            return result;
        }

        public List<string> GetMaterialCodeForMBR()
        {
            var result = _context.SSP_FCT_MATERIALs.Where(m =>
                         m.MaterialGroup != null
                     && (m.Material.StartsWith("z13") || m.Material.StartsWith("W7"))
                     && (m.MaterialGroup.Equals("FG") || m.MaterialGroup.Equals("RM"))
                     && m.FlagDelete != APPCONSTANT.DELETE_FLAG.YES).Select(o => o.Material).Distinct().ToList();
            return result;
        }

        public List<string> GetMaterialCodeForLSP()
        {
            var result = _context.SSP_FCT_MATERIALs.Where(m =>
                        m.Material.StartsWith("JJ")
                     && m.FlagDelete != APPCONSTANT.DELETE_FLAG.YES).Select(o => o.Material).Distinct().ToList();
            return result;
        }

        public List<SSP_FCT_MATERIAL> GetMaterialGroupDDL()
        {
            var result = _context.SSP_FCT_MATERIALs.Where(w => w.MaterialGroup != null
                                                                && (w.MaterialGroup.StartsWith("FG") || w.MaterialGroup.StartsWith("TG"))).Select(s => new SSP_FCT_MATERIAL()
                                                                {
                                                                    MaterialGroup = s.MaterialGroup,
                                                                    MaterialGroupDesc = s.MaterialGroup,
                                                                }).Distinct().ToList();
            return result;
        }

        public List<SSP_FCT_MATERIAL> GetMaterialProductDDL()
        {
            var result = _context.SSP_FCT_MATERIALs.Where(w => w.Product != null
                                                                && w.MaterialGroup != null && (w.MaterialGroup.StartsWith("FG") || w.MaterialGroup.StartsWith("TG"))
                                                                && (w.Class == "P" || w.Class == "N" || w.Class == "O")
                                                                && w.Material.StartsWith("Z1") && w.Material.Length > 10 && w.ECC6Flag == "X" && w.ProductLevel == "P").Select(s => new SSP_FCT_MATERIAL()
                                                                {
                                                                    Product = s.Product,
                                                                }).Distinct().ToList();
            return result;
        }

        public List<SSP_FCT_MATERIAL> GetMaterialProductSubDDL()
        {
            var result = _context.SSP_FCT_MATERIALs.Where(w => w.ProductSub != null
                                                                && w.MaterialGroup != null && (w.MaterialGroup.StartsWith("FG") || w.MaterialGroup.StartsWith("TG"))
                                                                && (w.Class == "P" || w.Class == "N" || w.Class == "O")
                                                                && w.Material.StartsWith("Z1") && w.Material.Length > 10 && w.ECC6Flag == "X" && w.ProductLevel == "P").Select(s => new SSP_FCT_MATERIAL()
                                                                {
                                                                    ProductSub = s.ProductSub,
                                                                    ProductSubDesc = s.ProductSubDesc,
                                                                }).Distinct().ToList();
            return result;
        }

        public List<SSP_FCT_MATERIAL> GetMaterialStandardizeGradeDDL()
        {
            var result = _context.SSP_FCT_MATERIALs.Where(w => w.Grade != null
                                                                && w.MaterialGroup != null && (w.MaterialGroup.StartsWith("FG") || w.MaterialGroup.StartsWith("TG"))
                                                                && (w.Class == "P" || w.Class == "N" || w.Class == "O")
                                                                && w.Material.StartsWith("Z1") && w.Material.Length > 10 && w.ECC6Flag == "X" && w.ProductLevel == "P").GroupBy(g => g.Grade).Select(s => new SSP_FCT_MATERIAL
                                                                {
                                                                    Grade = s.Key
                                                                }).ToList();
            return result;
        }

        public List<string> GetMaterialByMaterialGroup(List<string> data)
        {
            var result = _context.SSP_FCT_MATERIALs.Where(w => data.Contains(w.MaterialGroup)).Select(s => s.Material).Distinct().ToList();
            return result;
        }

        public List<string> GetMaterialCode(List<string> data)
        {
            var result = _context.SSP_FCT_MATERIALs.Where(o => o.FlagDelete != APPCONSTANT.DELETE_FLAG.YES && data.Contains(o.Material)).Select(o => o.Material).Distinct().ToList();
            return result;
        }

        public List<string> GetMaterialMatPrefix(List<string> data)
        {
            var result = _context.SSP_FCT_MATERIALs.Where(o => o.FlagDelete != APPCONSTANT.DELETE_FLAG.YES && data.Contains(o.MappingCompany) && (o.MaterialGroup.StartsWith("TG") || o.MaterialGroup.StartsWith("FG")) && o.Material.StartsWith("Z1")
                         && o.ECC6Flag == "X" && o.ProductLevel.Contains("P") && o.Material.Length > 10 && o.Product != "").Select(o => o.MappingCompany).Distinct().ToList();
            return result;
        }

        public List<string> GetMaterialProductSub(List<string> data)
        {
            var result = _context.SSP_FCT_MATERIALs.Where(o => o.FlagDelete != APPCONSTANT.DELETE_FLAG.YES && data.Contains(o.ProductSub) && (o.MaterialGroup.StartsWith("TG") || o.MaterialGroup.StartsWith("FG")) && o.Material.StartsWith("Z1")
                         && o.ECC6Flag == "X" && o.ProductLevel.Contains("P") && o.Material.Length > 10 && o.Product != "").Select(o => o.ProductSub).Distinct().ToList();
            return result;
        }

        public List<string> GetMaterialProduct(List<string> data)
        {
            var result = _context.SSP_FCT_MATERIALs.Where(o => o.FlagDelete != APPCONSTANT.DELETE_FLAG.YES && data.Contains(o.Product) && (o.MaterialGroup.StartsWith("TG") || o.MaterialGroup.StartsWith("FG")) && o.Material.StartsWith("Z1")
                         && o.ECC6Flag == "X" && o.ProductLevel.Contains("P") && o.Material.Length > 10 && o.Product != "").Select(o => o.Product).Distinct().ToList();
            return result;
        }

        public List<string> GetMaterialPackageQuantity(List<string> data)
        {
            var result = _context.SSP_FCT_MATERIALs.Where(o => o.FlagDelete != APPCONSTANT.DELETE_FLAG.YES && data.Contains(o.PackageQuantity) && (o.MaterialGroup.StartsWith("TG") || o.MaterialGroup.StartsWith("FG")) && o.Material.StartsWith("Z1")
                         && o.ECC6Flag == "X" && o.ProductLevel.Contains("P") && o.Material.Length > 10 && o.Product != "").Select(o => o.PackageQuantity).Distinct().ToList();
            return result;
        }

        public List<string> GetMaterialRotoMatCode(List<string> data)
        {
            var result = _context.SSP_FCT_MATERIALs.Where(o => o.FlagDelete != APPCONSTANT.DELETE_FLAG.YES && data.Contains(o.Material)
                        && o.ECC6Flag == "X" && (o.Material.StartsWith("GU") || o.Material.StartsWith("10"))).Select(o => o.Material).Distinct().ToList();
            return result;
        }

        public List<string> GetMaterialProductApplication(List<string> data)
        {
            var result = _context.SSP_FCT_MATERIALs.Where(o => o.FlagDelete != APPCONSTANT.DELETE_FLAG.YES && data.Contains(o.ProductApplication)
                        && o.ECC6Flag == "X" && (o.Material.StartsWith("GU") || o.Material.StartsWith("10"))).Select(o => o.ProductApplication).Distinct().ToList();
            return result;
        }

        public List<string> GetMaterialProductForm(List<string> data)
        {
            var result = _context.SSP_FCT_MATERIALs.Where(o => o.FlagDelete != APPCONSTANT.DELETE_FLAG.YES && data.Contains(o.ProductForm) && (o.MaterialGroup.StartsWith("TG") || o.MaterialGroup.StartsWith("FG")) && o.Material.StartsWith("Z1")
                         && o.ECC6Flag == "X" && o.ProductLevel.Contains("P") && o.Material.Length > 10 && o.Product != "").Select(o => o.ProductForm).Distinct().ToList();
            return result;
        }

        public List<string> GetMaterialGrade(List<string> data)
        {
            var result = _context.SSP_FCT_MATERIALs.Where(o => o.FlagDelete != APPCONSTANT.DELETE_FLAG.YES && data.Contains(o.GradeCustomization) && (o.MaterialGroup.StartsWith("TG") || o.MaterialGroup.StartsWith("FG")) && o.Material.StartsWith("Z1")
                         && o.ECC6Flag == "X" && o.ProductLevel.Contains("P") && o.Material.Length > 10 && o.Product != "").Select(o => o.GradeCustomization).Distinct().ToList();
            return result;
        }

        public List<string> GetMaterialProductColor(List<string> data)
        {
            var result = _context.SSP_FCT_MATERIALs.Where(o => o.FlagDelete != APPCONSTANT.DELETE_FLAG.YES && data.Contains(o.ProductColor) && (o.MaterialGroup.StartsWith("TG") || o.MaterialGroup.StartsWith("FG")) && o.Material.StartsWith("Z1")
                         && o.ECC6Flag == "X" && o.ProductLevel.Contains("P") && o.Material.Length > 10 && o.Product != "").Select(o => o.ProductColor).Distinct().ToList();
            return result;
        }
    }
}