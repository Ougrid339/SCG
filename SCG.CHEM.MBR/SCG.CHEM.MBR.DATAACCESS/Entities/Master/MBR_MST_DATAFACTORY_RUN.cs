using SCG.CHEM.MBR.COMMON.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.MBR.DATAACCESS.Entities.Master
{
    [Table("MBR_MST_DataFactoryRun")]
    public class MBR_MST_DATAFACTORY_RUN
    {
        [Key]
        public string RunId { get; set; }

        public string Status { get; set; }
        public string MasterName { get; set; }
        public string? Plantype { get; set; }
        public string? Cycle { get; set; }
        public string? Case { get; set; }
        public bool? IsMerge { get; set; }

        public string? MergedWithPlantype { get; set; }
        public string? MergedWithCycle { get; set; }
        public string? MergedWithCase { get; set; }

        //[StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        [StringLength(100)]
        public string? UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public MBR_MST_DATAFACTORY_RUN()
        { }

        public MBR_MST_DATAFACTORY_RUN(string runId, string status, string masterName, string createdBy)
        {
            RunId = runId;
            Status = status;
            MasterName = masterName;
            CreatedBy = UserUtilities.GetADAccount()?.UserId ?? "";
            CreatedDate = DateTime.Now;
        }

        public MBR_MST_DATAFACTORY_RUN(string runId, string status, string masterName, string? planType, string? cycle, string? caseName, bool? ismerge, string createdBy, string MergedWithplanType = "", string MergedWithcycle = "", string MergedWithcase = "")
        {
            RunId = runId;
            Status = status;
            MasterName = masterName;
            Plantype = planType;
            Cycle = cycle;
            Case = caseName;
            IsMerge = ismerge;

            MergedWithPlantype = String.IsNullOrEmpty(MergedWithplanType) ? null : MergedWithplanType;
            MergedWithCycle = String.IsNullOrEmpty(MergedWithcycle) ? null : MergedWithcycle;
            MergedWithCase = String.IsNullOrEmpty(MergedWithcase) ? null : MergedWithcase;
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