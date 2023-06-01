using SCG.CHEM.MBR.COMMON.Utilities;
using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Template;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master
{
    [Table("SSP_MST_CPDGradeAttr")]
    public class SSP_MST_CPD_GRADE_ATTR : BaseDatabaseContext
    {
        [Key]
        [StringLength(2)]
        public string ProductionSite { get; set; }

        [Key]
        [StringLength(3)]
        public string MatPrefix { get; set; }

        [Key]
        [StringLength(20)]
        public string Grade { get; set; }

        [StringLength(20)]
        public string MainGrade { get; set; }

        [StringLength(1)]
        public string MTSFlag { get; set; }

        [StringLength(50)]
        public string Formula { get; set; }

        [StringLength(50)]
        public string CPDApplication { get; set; }

        [StringLength(50)]
        public string CPDGroup { get; set; }

        [StringLength(4)]
        public string STDPlant { get; set; }

        [StringLength(10)]
        public string STDProductionLine { get; set; }

        [StringLength(10)]
        public string STDPackage { get; set; }

        public SSP_MST_CPD_GRADE_ATTR()
        { }

        public SSP_MST_CPD_GRADE_ATTR(SSP_TMP_CPD_GRADE_ATTR data)
        {
            ObjectUtil.CopyProperties(data, this);

            //this.CreatedBy = UserUtilities.GetADAccount()?.UserId ?? "";
            this.CreatedDate = DateTime.Now;
        }

        public SSP_MST_CPD_GRADE_ATTR(string productionSite, string matPrefix, string grade, string mainGrade, string mTSFlag, string formula, string cPDApplication, string cPDGroup, string sTDPlant, string sTDProductionLine, string sTDPackage, string startMonth, int versionNo)
        {
            ProductionSite = productionSite;
            MatPrefix = matPrefix;
            Grade = grade;
            MainGrade = mainGrade;
            MTSFlag = mTSFlag;
            Formula = formula;
            CPDApplication = cPDApplication;
            CPDGroup = cPDGroup;
            STDPlant = sTDPlant;
            STDProductionLine = sTDProductionLine;
            STDPackage = sTDPackage;
            StartMonth = startMonth;

            DateTime dt;
            var isValid = DateTime.TryParseExact(startMonth, APPCONSTANT.FORMAT.YEAR_MONTH, CultureInfo.InvariantCulture, DateTimeStyles.None, out dt);
            if (isValid)
                this.FirstDate = dt;

            this.CreatedBy = UserUtilities.GetADAccount()?.UserId ?? "";
            this.CreatedDate = DateTime.Now;
            this.VersionNo = versionNo;
            this.DeletedFlag = APPCONSTANT.DELETE_FLAG.NO;
        }

        public void MarkDelete(string userName)
        {
            if (this.DeletedFlag != APPCONSTANT.DELETE_FLAG.YES)
            {
                this.DeletedFlag = APPCONSTANT.DELETE_FLAG.YES;
                this.DeletedBy = userName ?? UserUtilities.GetADAccount()?.UserId ?? "";
                this.DeletedDate = DateTime.Now;
            }
        }
    }
}