using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCG.CHEM.SSPLSP.DATAACCESS.AppModels.Master
{
    public class ConfigModel
    {
        public string ConfigId { get; set; }
        public string ConfigValue { get; set; }
        public string ConfigDescription { get; set; }
        public bool Decrypt { get; set; }
        public bool AdminOnly { get; set; }

        public ConfigModel()
        { }

        public ConfigModel(MST_CONFIG db)
        {
            this.ConfigId = db.ConfigId;
            this.ConfigValue = db.ConfigValue;
            this.AdminOnly = db.FlagAdminOnly;
            this.Decrypt = db.FlagDecrypt;
            this.ConfigDescription = db.ConfigDesc;
        }
    }
}