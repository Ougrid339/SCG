using System;
using System.Collections.Generic;
using System.Text;

namespace SCG.CHEM.SSPLSP.DATAACCESS.AppModels.Master
{
    public class MenuModel : MenuBaseModel
    {
        public bool? ShowItems { get; set; }
        public List<MenuBaseModel> Items { get; set; }
    }

    public class MenuBaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Action { get; set; }
        public string Icon { get; set; }
    }
}