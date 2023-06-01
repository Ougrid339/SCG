using SCG.CHEM.MBR.MASTER.API.AppModels.Master;
using SCG.CHEM.MBR.MASTER.API.AppModels.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.MBR.MASTER.API.BusinessLogic.Services.Validation.Interface
{
    public interface IValidateMasterService : IBaseService
    {
        DataWIthInterface<ValidateProductMappingTempModel> ValidateMasterProductMapping(DataWIthInterface<ValidateProductMappingTempModel> data);

        DataWIthInterface<ValidateCustomerVendorMappingTempModel> ValidateMasterCustomerVendorMapping(DataWIthInterface<ValidateCustomerVendorMappingTempModel> data);

        DataWIthInterface<ValidateLSPPriceFormulaTempModel> ValidateMasterLSPPriceFormula(DataWIthInterface<ValidateLSPPriceFormulaTempModel> data);

        DataWIthInterface<ValidateMarketPriceMappingTempModel> ValidateMasterMarketPriceMapping(DataWIthInterface<ValidateMarketPriceMappingTempModel> data);

        List<string> checkErrorList(int? Id, List<MaterialCodeValidationModel> errorList, out bool isError);
    }
}