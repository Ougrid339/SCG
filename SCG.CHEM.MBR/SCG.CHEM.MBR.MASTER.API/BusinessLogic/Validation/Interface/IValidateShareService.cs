using SCG.CHEM.MBR.MASTER.API.AppModels.Master;
using SCG.CHEM.MBR.MASTER.API.AppModels.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.MBR.MASTER.API.BusinessLogic.Services.Validation.Interface
{
    public interface IValidateShareService : IBaseService
    {
        List<DataValidationModel> ValidateYearMonth(List<DataValidationModel> data);

        List<DecimalValidationModel> ValidateDecimal(List<DecimalValidationModel> data);

        List<DecimalValidationModel> ValidateDecimalQty(List<DecimalValidationModel> data);

        List<DataValidationModel> ValidateStringLength(List<DataValidationModel> data, int stringLegth);

        List<MaterialCodeValidationModel> ValidateMaterialCode(List<MaterialCodeValidationModel> data, string errorMessage);

        List<CustomerCodeValidationModel> ValidateCustomer(List<CustomerCodeValidationModel> data);

        List<ProductMappingValidationModel> ValidateProductShortName(List<ProductMappingValidationModel> data);

        List<DataValidationModel> ValidateType(List<DataValidationModel> data);

        List<ProductShortNameValidationModel> CheckDuplicateProductShortName(List<ProductShortNameValidationModel> data);

        List<CustomerCodeValidationModel> CheckDuplicateCustomer(List<CustomerCodeValidationModel> data, string errorMessage);

        List<MarketPriceMappingValidationModel> CheckDuplicateEBACode(List<MarketPriceMappingValidationModel> data);

        List<MaterialCodeValidationModel> ValidateMaterialCodeForLSP(List<MaterialCodeValidationModel> data, string errorMessage);
    }
}