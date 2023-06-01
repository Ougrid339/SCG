using SCG.CHEM.SSPLSP.DATAACCESS.AppModels.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface
{
    public interface IMasterMonomerPriceRepo : IRepositoryBase<SSP_MST_MONOMER_PRICE>
    {
        List<SSP_MST_MONOMER_PRICE> GetAllByKeyAndVersion(string planType, string inputM1, string versionName, string monomer, int priceUnitId, string monthNo, int versionNo);

        List<SSP_MST_MONOMER_PRICE> GetByKey(string planType, string inputM1, string versionName, string monomer, int priceUnitId, string monthNo);
    }
}