using SCG.CHEM.SSPLSP.DATAACCESS.AppModels.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface
{
    public interface IMasterValTypeToProductionLineRepo : IRepositoryBase<SSP_MST_VAL_TYPE_TO_PRODUCTION_LINE>
    {
        SSP_MST_VAL_TYPE_TO_PRODUCTION_LINE GetByValuationTypeCode(string data);

        List<SSP_MST_VAL_TYPE_TO_PRODUCTION_LINE> GetByValuationTypeCodes(List<string> data);

        SSP_MST_VAL_TYPE_TO_PRODUCTION_LINE GetByProductionLineCode(string data);

        List<SSP_MST_VAL_TYPE_TO_PRODUCTION_LINE> GetByProductionLineCodes(List<string> data);

        List<SSP_MST_VAL_TYPE_TO_PRODUCTION_LINE> GetByCompanyCode(string data);

        List<SSP_MST_VAL_TYPE_TO_PRODUCTION_LINE> GetByProductionLineCodesAndPlantCodes(List<string> lines, List<string> plants);

        List<SSP_MST_VAL_TYPE_TO_PRODUCTION_LINE> GetByCompanyCodes(List<string> company);
    }
}