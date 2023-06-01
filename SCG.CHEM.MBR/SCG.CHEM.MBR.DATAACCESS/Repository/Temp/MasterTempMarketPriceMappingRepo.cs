using SCG.CHEM.MBR.DATAACCESS.Entities.Master;
using SCG.CHEM.MBR.DATAACCESS.Entities.Temp;
using SCG.CHEM.MBR.DATAACCESS.Repository.Temp.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.MBR.DATAACCESS.Repository.Temp
{
    public class MasterTempMarketPriceMappingRepo : RepositoryBase<MBR_TMP_MARKET_PRICE_MAPPING>, IMasterTempMarketPriceMappingRepo
    {
        #region Inject

        public MasterTempMarketPriceMappingRepo(EntitiesMBRContext context, EntitiesMBRReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        public void Truncate()
        {
            var data = _context.MBR_TMP_PRODUCT_MAPPINGs.ToList();
            _context.RemoveRange(data);
        }
       
    }
}