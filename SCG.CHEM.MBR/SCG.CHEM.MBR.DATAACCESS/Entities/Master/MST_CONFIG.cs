using SCG.CHEM.MBR.COMMON.Utilities;
using SCG.CHEM.MBR.DATAACCESS.AppModels.Master;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SCG.CHEM.MBR.DATAACCESS.Entities.Master
{
    [Table("MST_CONFIG")]
    public class MST_CONFIG
    {
        [Key]
        [Column("CONFIG_ID")]
        [StringLength(100)]
        public string ConfigId { get; set; }

        [Column("CONFIG_VALUE")]
        [StringLength(500)]
        public string ConfigValue { get; set; }

        [Column("CONFIG_DESC")]
        [StringLength(500)]
        public string ConfigDesc { get; set; }

        [Column("FLAG_DECRYPT")]
        public bool FlagDecrypt { get; set; }

        [Column("FLAG_ADMIN_ONLY")]
        public bool FlagAdminOnly { get; set; }

        [Column("CREATED_DATE")]
        public DateTime CreatedDate { get; set; }

        [Column("UPDATED_DATE")]
        public DateTime? UpdatedDate { get; set; }

        [Column("CREATED_BY")]
        [StringLength(255)]
        public string CreatedBy { get; set; }

        [Column("UPDATED_BY")]
        [StringLength(255)]
        public string? UpdateBy { get; set; }

        public MST_CONFIG()
        { }

        public MST_CONFIG(ConfigModel config, string user)
        {
            this.ConfigId = config.ConfigId;
            this.ConfigValue = config.ConfigValue;
            this.ConfigDesc = config.ConfigDescription;
            this.FlagAdminOnly = config.AdminOnly;
            this.FlagDecrypt = config.Decrypt;
            this.CreatedBy = user;
            this.UpdateBy = user;
            this.CreatedDate = DateTime.Now;
            this.UpdatedDate = DateTime.Now;
        }

        public void UpdateConfig(ConfigModel config, string user)
        {
            this.FlagAdminOnly = config.AdminOnly;
            this.FlagDecrypt = config.Decrypt;
            this.ConfigDesc = config.ConfigDescription;
            this.ConfigValue = config.ConfigValue;
            this.UpdateBy = user;
            this.UpdatedDate = DateTime.Now;
        }
    }
}