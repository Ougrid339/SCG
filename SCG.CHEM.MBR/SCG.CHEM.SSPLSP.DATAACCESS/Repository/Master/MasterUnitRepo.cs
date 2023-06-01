﻿using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master
{
    public class MasterUnitRepo : RepositoryBase<SSP_MST_UNIT>, IMasterUnitRepo
    {
        #region Inject

        public MasterUnitRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        public List<SSP_MST_UNIT> GetByUnit(List<string> data)
        {
            var result = _context.SSP_MST_UNITs.Where(s => data.Contains(s.Unit)).ToList();
            return result;
        }
    }
}