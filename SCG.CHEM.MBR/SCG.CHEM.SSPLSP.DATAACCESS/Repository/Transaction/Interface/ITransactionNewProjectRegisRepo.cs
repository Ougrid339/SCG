using SCG.CHEM.SSPLSP.DATAACCESS.AppModels.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Transaction.Interface
{
    public interface ITransactionNewProjectRegisRepo : IRepositoryBase<SSP_TRN_NEW_PROJECT_REGIS>
    {
        SSP_TRN_NEW_PROJECT_REGIS GeyById(string id);

        List<SSP_TRN_NEW_PROJECT_REGIS> GeyByIds(List<string> data);
    }
}