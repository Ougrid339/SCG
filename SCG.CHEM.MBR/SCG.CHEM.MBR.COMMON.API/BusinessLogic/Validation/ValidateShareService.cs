using SCG.CHEM.MBR.DATAACCESS.UnitOfWork;
using SCG.CHEM.MBR.DATAACCESS;
using System.Globalization;
using SCG.CHEM.MBR.COMMON.API.AppModels.Validation;
using SCG.CHEM.MBR.COMMON.API.BusinessLogic.Services.Validation.Interface;

namespace SCG.CHEM.MBR.COMMON.API.BusinessLogic.Services.Validation
{
    public sealed class ValidateShareService : IValidateShareService
    {
        private readonly UnitOfWork _unit;
        private readonly SCG.CHEM.SSPLSP.DATAACCESS.UnitOfWork.UnitOfWork _unitLSP;

        public ValidateShareService(UnitOfWork unitOfWork, SSPLSP.DATAACCESS.UnitOfWork.UnitOfWork unitLSP)
        {
            this._unit = unitOfWork;
            this._unitLSP = unitLSP;
        }

        public List<DataValidationModel> ValidateYearMonth(List<DataValidationModel> data)
        {
            // set Error Msg format
            string ErrMsg1 = "Incorrect Year-Month format (" + APPCONSTANT.FORMAT.YEAR_MONTH + ")";

            // validate input data with DB_Data & set Error Msg
            data.ForEach(i =>
            {
                DateTime dt;
                var isValid = DateTime.TryParseExact(i.Data, APPCONSTANT.FORMAT.YEAR_MONTH, CultureInfo.InvariantCulture, DateTimeStyles.None, out dt);

                if (!isValid)
                {
                    string msg = String.Format(ErrMsg1, i.Id);
                    i.Message.Add(msg);
                }
            });

            // filter Error Record
            data = data.Where(w => w.Message.Count > 0).ToList();

            return data;
        }

        public List<DecimalValidationModel> ValidateDecimal(List<DecimalValidationModel> data)
        {
            // set Error Msg format
            string ErrMsg1 = "Incorrect number format.";
            string ErrMsg2 = "decimal not more than 5 places.";

            // validate input data with DB_Data & set Error Msg
            data.ForEach(i =>
            {
                try
                {
                    decimal chkDecimal = Convert.ToDecimal(i.Data);
                    var numDigit = i.Data.ToString().Split('.').ToList();
                    if (numDigit.Count > 1)
                    {
                        bool isValid = numDigit[1].Length <= 5;
                        if (!isValid)
                        {
                            string msg = String.Format(ErrMsg2, i.Id);
                            i.Message.Add(msg);
                        }
                    }
                }
                catch (Exception ex)
                {
                    string msg = String.Format(ErrMsg1, i.Id);
                    i.Message.Add(msg);
                }
            });

            // filter Error Record
            data = data.Where(w => w.Message.Count > 0).ToList();

            return data;
        }

        public List<DecimalValidationModel> ValidateDecimalQty(List<DecimalValidationModel> data)
        {
            // set Error Msg format
            string ErrMsg1 = "VOL INVALID: Qty must equal or more than 0";

            // validate input data with DB_Data & set Error Msg
            data.ForEach(i =>
            {
                if (i.Data < 0)
                {
                    string msg = String.Format(ErrMsg1, i.Id);
                    i.Message.Add(msg);
                }
            });

            // filter Error Record
            data = data.Where(w => w.Message.Count > 0).ToList();

            return data;
        }

        public List<DataValidationModel> ValidateStringLength(List<DataValidationModel> data, int stringLegth)
        {
            // set Error Msg format
            string ErrMsg1 = "invalid because StringLength not match " + stringLegth;

            // validate input data with DB_Data & set Error Msg
            data.ForEach(i =>
            {
                var isValid = i.Data.Length <= stringLegth;

                if (!isValid)
                {
                    string msg = String.Format(ErrMsg1, i.Id);
                    i.Message.Add(msg);
                }
            });

            // filter Error Record
            data = data.Where(w => w.Message.Count > 0).ToList();

            return data;
        }

        public List<MaterialCodeValidationModel> ValidateMaterialCode(List<MaterialCodeValidationModel> data)
        {
            // set Error Msg format
            string ErrMsg1 = "MaterialCode wasn't found.";

            // distinct key for search DB
            var codeList = data.Select(s => s.MaterialCode).Distinct().ToList();

            // pull DB only need
            var dataDB = _unitLSP.FCTMaterialRepo.GetMaterialCode(codeList);

            // validate input data with DB_Data & set Error Msg
            data.ForEach(i =>
            {
                bool isValid = dataDB.Any(a => String.Equals(a, i.MaterialCode, StringComparison.OrdinalIgnoreCase));

                if (!isValid)
                {
                    string msg = String.Format(ErrMsg1, i.Id);
                    i.Message.Add(msg);
                }
            });

            // filter Error Record
            data = data.Where(w => w.Message.Count > 0).ToList();

            return data;
        }
    }
}