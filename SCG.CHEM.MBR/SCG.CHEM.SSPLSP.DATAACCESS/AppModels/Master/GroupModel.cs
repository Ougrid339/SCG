﻿using SCG.CHEM.SSPLSP.DATAACCESS.AppModels.Common;
using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCG.CHEM.SSPLSP.DATAACCESS.AppModels.Master
{
    public class GroupSearchReqModel
    {
        public short? Id { get; set; }
        public string? Name { get; set; }
    }

    public class GroupSearchResModel
    {
        public short Id { get; set; }
        public string Name { get; set; }

        public GroupSearchResModel()
        { }

        public GroupSearchResModel(MST_GROUP db)
        {
            this.Id = db.Id;
            this.Name = db.Name;
        }
    }
}