using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Temp.Interface
{
    public interface IMasterTempMonomerPriceRepo : IRepositoryBase<SSP_TMP_MONOMER_PRICE>
    {
        List<SSP_TMP_MONOMER_PRICE> GetByKey(string planType, string inputM1, string versionName, string monomer, int priceUnitId, string monthNo);

        public void Truncate();
    }
}