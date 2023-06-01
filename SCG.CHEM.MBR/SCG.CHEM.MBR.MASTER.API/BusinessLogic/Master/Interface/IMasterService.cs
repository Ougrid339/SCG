using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SCG.CHEM.MBR.DATAACCESS.Entities.Master;
using SCG.CHEM.MBR.MASTER.API.AppModels.Maintain;
using SCG.CHEM.MBR.MASTER.API.AppModels.Master;
using SCG.CHEM.MBR.MASTER.API.BusinessLogic.Services;

namespace SCG.CHEM.MBR.MASTER.API.BusinessLogic.Master.Interface
{
    public interface IMasterService : IBaseService
    {
        IEnumerable<MBR_MST_MASTER> GetAllMasters();

        List<MBR_MST_MASTER> GetMasters(string username);

        MBR_MST_MASTER GetMastersByName(string masterName);

        List<MBR_MST_MASTER_MAPPING> GetMasterMapping(int masterId);

        List<MBR_MST_EXPORT_MAPPING> GetExportMapping(int masterId);

        bool MasterMapping(RequestMaintainModel data);

        //List<vSSP_MST_FREIGHT_EXPORT> Test();
        int MoveMasterProductMapping();

        int MoveMasterCustomerVendorMapping();

        int MoveMasterMarketPriceMapping();

        int MoveMasterLSPPriceFormula();

        string UploadMasterProductMapping(DataWIthInterface<ValidateProductMappingTempModel> data, out int total);

        string UploadMasterCustomerVendorMapping(DataWIthInterface<ValidateCustomerVendorMappingTempModel> data, out int total);

        string UploadMasterLSPPriceFormula(DataWIthInterface<ValidateLSPPriceFormulaTempModel> data, out int total);

        string UploadMasterMarketPriceMapping(DataWIthInterface<ValidateMarketPriceMappingTempModel> data, out int total);
    }
}