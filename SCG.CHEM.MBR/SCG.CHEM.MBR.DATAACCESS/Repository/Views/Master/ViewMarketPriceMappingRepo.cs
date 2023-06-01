﻿using SCG.CHEM.MBR.DATAACCESS.Entities.Views.Master;
using SCG.CHEM.MBR.DATAACCESS.Repository.Views.Master.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.MBR.DATAACCESS.Repository.Views.Master
{
    public class ViewMarketPriceMappingRepo : RepositoryBase<vMBR_MST_MarketPriceMapping>, IViewMarketPriceMappingRepo
    {
        public ViewMarketPriceMappingRepo(EntitiesMBRContext context, EntitiesMBRReadContext readConext) : base(context, readConext)
        {
        }
    }
}
