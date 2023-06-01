using SCG.CHEM.MBR.DATAACCESS.Entities.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.MBR.DATAACCESS.Repository.Master.Interface
{
    public interface IMasterProductMappingRepo : IRepositoryBase<MBR_MST_PRODUCT_MAPPING>
    {
        List<MBR_MST_PRODUCT_MAPPING> GetProductMapping(List<string> data);

        List<MBR_MST_PRODUCT_MAPPING> GetAllByKeyAndVersion(string materialCode, string sourceSystem, int versionNo);

        List<MBR_MST_PRODUCT_MAPPING> GetProductShortName(List<string> data);

        List<MBR_MST_PRODUCT_MAPPING> GetProductGroup(string data);

        List<MBR_MST_PRODUCT_MAPPING> GetMaterialCode(List<string> data);
    }
}