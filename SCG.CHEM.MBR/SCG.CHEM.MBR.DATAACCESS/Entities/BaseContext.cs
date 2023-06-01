using SCG.CHEM.MBR.COMMON.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.MBR.DATAACCESS.Entities
{
    public class BaseContext
    {
        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [StringLength(50)]
        public string? UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public void setCreate(string createdBy, DateTime createdDate)
        {
            this.CreatedBy = createdBy;
            this.CreatedDate = createdDate;
            this.UpdatedBy = UserUtilities.GetADAccount()?.UserId ?? "";
            this.UpdatedDate = DateTime.Now;
        }
    }
}