using SCG.CHEM.MBR.TRANSACTION.API.AppModels.Master;
using SCG.CHEM.MBR.TRANSACTION.API.AppModels.Sales;
using SCG.CHEM.MBR.TRANSACTION.API.AppModels.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.MBR.TRANSACTION.API.BusinessLogic.Services.Validation.Interface
{
    public interface IValidateShareService : IBaseService
    {
        List<DataValidationModel> ValidateYearMonth(List<DataValidationModel> data);

        List<DecimalValidationModel> ValidateDecimal(List<DecimalValidationModel> data);

        List<DecimalValidationModel> ValidateDecimalQty(List<DecimalValidationModel> data);

        List<DataValidationModel> ValidateStringLength(List<DataValidationModel> data, int stringLegth);

        List<MaterialCodeValidationModel> ValidateMaterialCode(List<MaterialCodeValidationModel> data);

        List<string> ValidateDecimal(SalesDataModel model, List<ValidateDecimalConfiguration> configuration);
    }
}