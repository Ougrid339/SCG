using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface
{
    public interface IFCTMaterialRepo : IRepositoryBase<SSP_FCT_MATERIAL>
    {
        List<SSP_FCT_MATERIAL> GetByMaterialCode(List<string> data);

        List<string> GetMaterialCode(List<string> data);

        List<string> GetMaterialMatPrefix(List<string> data);

        List<string> GetMaterialProductSub(List<string> data);

        List<string> GetMaterialProduct(List<string> data);

        List<string> GetMaterialPackageQuantity(List<string> data);

        List<string> GetMaterialRotoMatCode(List<string> data);

        List<string> GetMaterialProductApplication(List<string> data);

        List<string> GetMaterialProductForm(List<string> data);

        List<string> GetMaterialGrade(List<string> data);

        List<string> GetMaterialProductColor(List<string> data);

        List<SSP_FCT_MATERIAL> GetMaterialGroupDDL();

        List<SSP_FCT_MATERIAL> GetMaterialProductDDL();

        List<SSP_FCT_MATERIAL> GetMaterialProductSubDDL();

        List<SSP_FCT_MATERIAL> GetMaterialStandardizeGradeDDL();

        List<string> GetMaterialByMaterialGroup(List<string> data);

        List<string> GetMaterialCodeForMBR(List<string> data);

        List<string> GetMaterialCodeForMBR();

        List<string> GetMaterialCodeForLSP();
    }
}