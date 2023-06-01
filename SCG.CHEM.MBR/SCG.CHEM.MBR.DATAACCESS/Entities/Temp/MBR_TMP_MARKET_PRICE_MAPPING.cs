using SCG.CHEM.MBR.COMMON.Utilities;
using SCG.CHEM.MBR.DATAACCESS.Entities.Master;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.MBR.DATAACCESS.Entities.Temp
{
    [Table("MBR_TMP_MarketPriceMapping")]
    public class MBR_TMP_MARKET_PRICE_MAPPING : BaseMasterContext
    {
        [StringLength(50)]
        public string MarketPriceShortName { get; set; }

        [Key]
        [StringLength(50)]
        public string MarketPriceMI { get; set; }

        [Key]
        [StringLength(50)]
        public string MarketPriceWebPricing { get; set; }

        [Key]
        [StringLength(50)]
        public string MarketPriceName { get; set; }

        [StringLength(15)]
        public string EBACode { get; set; }

        public MBR_TMP_MARKET_PRICE_MAPPING()
        { }

        public MBR_TMP_MARKET_PRICE_MAPPING(MBR_MST_MARKET_PRICE_MAPPING data)
        {
            ObjectUtil.CopyProperties(data, this);

            this.CreatedBy = UserUtilities.GetADAccount()?.UserId ?? "";
            this.CreatedDate = DateTime.Now;
        }

        public MBR_TMP_MARKET_PRICE_MAPPING(string marketPriceShortName, string marketPriceMI, string marketPriceWebPricing
            , string marketPriceName, string EBACode, int versionNo)
        {
            this.MarketPriceShortName = marketPriceShortName;
            this.MarketPriceMI = marketPriceMI;
            this.MarketPriceWebPricing = marketPriceWebPricing;
            this.MarketPriceName = marketPriceName;
            this.EBACode = EBACode;
            this.VersionNo = versionNo;

            this.CreatedBy = UserUtilities.GetADAccount()?.UserId ?? "";
            this.CreatedDate = DateTime.Now;
            this.DeletedFlag = APPCONSTANT.DELETE_FLAG.NO;
        }

        public void MarkDelete(string? userName)
        {
            if (this.DeletedFlag != APPCONSTANT.DELETE_FLAG.YES)
            {
                this.DeletedFlag = APPCONSTANT.DELETE_FLAG.YES;
                this.DeletedBy = !String.IsNullOrEmpty(userName) ? userName : (UserUtilities.GetADAccount()?.UserId ?? "");
                this.DeletedDate = DateTime.Now;
            }
        }
    }
}