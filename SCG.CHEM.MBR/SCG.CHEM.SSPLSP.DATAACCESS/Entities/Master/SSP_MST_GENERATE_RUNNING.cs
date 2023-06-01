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
    [Table("SSP_MST_GenerateRunning")]
    public class SSP_MST_GENERATE_RUNNING : BaseContext
    {
        [Key]
        [StringLength(50)]
        public string Id { get; set; }

        public int RunningNo { get; set; }

        public SSP_MST_GENERATE_RUNNING()
        { }

        public SSP_MST_GENERATE_RUNNING(string id, int runningNo)
        {
            Id = id;
            RunningNo = runningNo;

            this.CreatedBy = UserUtilities.GetADAccount()?.UserId ?? "";
            this.CreatedDate = DateTime.Now;
        }

        public void Update(int runningNo)
        {
            RunningNo = runningNo;
        }

        public void IncreaseRunning()
        {
            RunningNo = RunningNo + 1;
        }
    }
}