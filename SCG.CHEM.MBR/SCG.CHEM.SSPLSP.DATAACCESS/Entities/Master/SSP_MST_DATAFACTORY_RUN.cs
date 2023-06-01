using SCG.CHEM.MBR.COMMON.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master
{
    [Table("SSP_MST_DataFactoryRun")]
    public class SSP_MST_DATAFACTORY_RUN
    {
        [Key]
        public string RunId { get; set; }

        public string Status { get; set; }
        public string MasterName { get; set; }

        //[StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        [StringLength(100)]
        public string? UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public SSP_MST_DATAFACTORY_RUN()
        { }

        public SSP_MST_DATAFACTORY_RUN(string runId, string status, string masterName, string createdBy)
        {
            RunId = runId;
            Status = status;
            MasterName = masterName;
            CreatedBy = UserUtilities.GetADAccount()?.UserId ?? "";
            CreatedDate = DateTime.Now;
        }

        public void UpdateStatus(string status)
        {
            Status = status;

            UpdatedBy = UserUtilities.GetADAccount()?.UserId ?? "";
            UpdatedDate = DateTime.Now;
        }
    }
}