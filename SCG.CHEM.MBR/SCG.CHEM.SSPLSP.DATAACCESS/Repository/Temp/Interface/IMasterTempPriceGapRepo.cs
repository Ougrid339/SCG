using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Temp.Interface
{
    public interface IMasterTempPriceGapRepo : IRepositoryBase<SSP_TMP_PRICE_GAP>
    {
        List<SSP_TMP_PRICE_GAP> GetByKey(string planType, string rawMatCode, string startMonth);

        void Truncate();
    }
}