using SCG.CHEM.SSPLSP.DATAACCESS.AppModels.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Transaction.Interface
{
    public interface ITransactionMonomerAvailableConspRepo : IRepositoryBase<SSP_TRN_MONOMER_AVAILABLE_CONSP>
    {
        //List<SSP_TRN_MONOMER_AVAILABLE_CONSP> GetByKey(string versionName,  string tier, int monomerType, string companyCode, string matCodeMst, string inputM1, string monthNo);
        List<SSP_TRN_MONOMER_AVAILABLE_CONSP> GetByKeyWithoutDataPart(string versionName, string tier, int monomerType, int priceUnitId, string matCodeMst, string inputM1, string monthNo);

        List<MonomerAvailableConsModel> GetMonomerAvailable(string planType, string versionname, int monomerType);
    }
}