using SCG.CHEM.MBR.COMMON.Utilities;
using SCG.CHEM.SSPLSP.DATAACCESS.AppModels.Common;
using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using SCG.CHEM.SSPLSP.DATAACCESS;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCG.CHEM.MBR.MASTER.API.AppModels.Master
{
    public class FreightTempModel
    {
        public string? ProductionSite { get; set; }
        public string? RegionCode { get; set; }
        public string? Unit { get; set; }
        public string? STDFreight { get; set; }

        //public string? PlanType { get; set; }
        public string? FreightAmtAdjTPE { get; set; }

        public string? FreightAmtAdjLSP { get; set; }
        public string? StartMonth { get; set; }

        public void SetModel(FreightTempModel model)
        {
            ObjectUtil.CopyProperties(model, this);
        }

        public FreightModel TryConvertToModel(out List<string> errList)
        {
            var model = new FreightModel();
            errList = new List<string>();

            #region Temp Variable

            bool isParsed = true;
            int tempInt;
            decimal tempDecimal;
            DateTime tempDateTime;

            #endregion Temp Variable

            // ---------------------- Try to convert model ----------------------
            if (String.IsNullOrEmpty(this.ProductionSite))
            {
                errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_REQUIRED_FIELD, "ProductionSite"));
            }
            else
            {
                model.ProductionSite = this.ProductionSite;
            }

            if (String.IsNullOrEmpty(this.RegionCode))
            {
                errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_REQUIRED_FIELD, "RegionCode"));
            }
            else
            {
                model.RegionCode = this.RegionCode;
            }

            model.Unit = this.Unit;

            if (String.IsNullOrEmpty(this.STDFreight))
            {
                model.STDFreight = 0;
            }
            else if (isParsed = decimal.TryParse(this.STDFreight, out tempDecimal))
            {
                model.STDFreight = Math.Round(tempDecimal, 5);
            }
            else
            {
                errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_CONVERT_STR_TO_DECIMAL, "STDFreight"));
            }

            //model.PlanType = this.PlanType;

            if (String.IsNullOrEmpty(this.FreightAmtAdjTPE))
            {
                model.FreightAmtAdjTPE = 0;
            }
            else if (isParsed = decimal.TryParse(this.FreightAmtAdjTPE, out tempDecimal))
            {
                model.FreightAmtAdjTPE = Math.Round(tempDecimal, 5);
            }
            else
            {
                errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_CONVERT_STR_TO_DECIMAL, "FreightAmtAdjTPE"));
            }

            if (String.IsNullOrEmpty(this.FreightAmtAdjLSP))
            {
                model.FreightAmtAdjLSP = 0;
            }
            else if (isParsed = decimal.TryParse(this.FreightAmtAdjLSP, out tempDecimal))
            {
                model.FreightAmtAdjLSP = Math.Round(tempDecimal, 5);
            }
            else
            {
                errList.Add(String.Format(APPCONSTANT.ERROR_MSG.ERROR_CONVERT_STR_TO_DECIMAL, "FreightAmtAdjLSP"));
            }

            model.StartMonth = this.StartMonth;

            return model;
        }
    }

    public class FreightModel
    {
        public string ProductionSite { get; set; }
        public string RegionCode { get; set; }
        public string Unit { get; set; }
        public decimal STDFreight { get; set; }

        //public string PlanType { get; set; }
        public decimal FreightAmtAdjTPE { get; set; }

        public decimal FreightAmtAdjLSP { get; set; }
        public string StartMonth { get; set; }

        public void SetModel(FreightModel model)
        {
            ObjectUtil.CopyProperties(model, this);
        }
    }

    //public class FreightResModel
    //{
    //    public string ProductionSite { get; set; }
    //    public string RegionCode { get; set; }
    //    public string? UnitId { get; set; }
    //    public decimal STDFreight { get; set; }
    //    public string PlanType { get; set; }
    //    public decimal FreightAmtAdjTPE { get; set; }
    //    public decimal FreightAmtAdjLSP { get; set; }
    //    public string StartMonth { get; set; }
    //    public string? EndMonth { get; set; }
    //    public DateTime? FirstDate { get; set; }
    //    public int? VersionNo { get; set; }
    //    public string? DeletedFlag { get; set; }
    //    public string? DeletedBy { get; set; }
    //    public DateTime? DeletedDate { get; set; }
    //    public string? CreatedBy { get; set; }
    //    public DateTime? CreatedDate { get; set; }

    //public FreightResModel() { }

    //public FreightResModel(SSP_MST_FREIGHT data)
    //{
    //    this.ProductionSite = data.ProductionSite;
    //    this.RegionCode = data.RegionCode;
    //    this.UnitId = data.UnitId;
    //    this.STDFreight = data.STDFreight;
    //    this.PlanType = data.PlanType;
    //    this.FreightAmtAdjTPE = data.FreightAmtAdjTPE;
    //    this.FreightAmtAdjLSP = data.FreightAmtAdjLSP;
    //    this.StartMonth = data.StartMonth;
    //    this.FirstDate = data.FirstDate;
    //    this.VersionNo = data.VersionNo;
    //    this.DeletedFlag = data.DeletedFlag;
    //    this.DeletedBy = data.DeletedBy;
    //    this.DeletedDate = data.DeletedDate;
    //    this.CreatedBy = data.CreatedBy;
    //    this.CreatedDate = data.CreatedDate;
    //}

    //    public void SetModel(FreightResModel model)
    //    {
    //        ObjectUtil.CopyProperties(model, this);
    //    }
    //}

    public class ValidateFreightTempModel : FreightTempModel
    {
        public int? Id { get; set; }
        public List<string> ErrorMsg { get; set; } = new List<string>();
    }

    public class ValidateFreightModel : FreightModel
    {
        public int? Id { get; set; }
        public List<string> ErrorMsg { get; set; } = new List<string>();
    }

    //public class ValidateFreightResModel : FreightResModel
    //{
    //    public int? Id { get; set; }
    //    public List<string> ErrorMsg { get; set; } = new List<string>();
    //}
}