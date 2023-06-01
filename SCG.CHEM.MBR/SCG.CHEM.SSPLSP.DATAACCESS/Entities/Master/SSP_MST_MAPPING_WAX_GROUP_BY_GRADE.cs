using SCG.CHEM.MBR.COMMON.Utilities;
using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Template;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master
{
    [Table("SSP_MST_MappingWaxGroupByGrade")]
    public class SSP_MST_MAPPING_WAX_GROUP_BY_GRADE
    {
        [Key]
        [StringLength(10)]
        public string Grade { get; set; }

        [Key]
        [StringLength(4)]
        public string WaxGroup { get; set; }

        public string PolymerMKT { get; set; }
        public string MonomerMKT { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        [Key]
        public int VersionNo { get; set; }

        //[Key]
        [StringLength(1)]
        public string DeletedFlag { get; set; }

        [StringLength(50)]
        public string? DeletedBy { get; set; }

        public DateTime? DeletedDate { get; set; }

        public SSP_MST_MAPPING_WAX_GROUP_BY_GRADE()
        { }

        public SSP_MST_MAPPING_WAX_GROUP_BY_GRADE(SSP_TMP_MAPPING_WAX_GROUP_BY_GRADE data)
        {
            ObjectUtil.CopyProperties(data, this);

            //this.CreatedBy = UserUtilities.GetADAccount()?.UserId ?? "";
            this.CreatedDate = DateTime.Now;
        }

        public SSP_MST_MAPPING_WAX_GROUP_BY_GRADE(string grade, string waxGroup, string polymerMKT, string monomerMKT, int versionNo)
        {
            Grade = grade;
            WaxGroup = waxGroup;
            PolymerMKT = polymerMKT;
            MonomerMKT = monomerMKT;
            this.CreatedBy = UserUtilities.GetADAccount()?.UserId ?? "";
            this.CreatedDate = DateTime.Now;
            this.VersionNo = versionNo;
            this.DeletedFlag = APPCONSTANT.DELETE_FLAG.NO;
        }

        public void MarkDelete(string userName = null)
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