﻿using SCG.CHEM.MBR.DATAACCESS.Entities.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.MBR.DATAACCESS.Repository.Master.Interface
{
    public interface IMasterScenarioRepo : IRepositoryBase<MBR_MST_SCENARIO>
    {
        List<MBR_MST_SCENARIO> GetScenario();
    }
}
