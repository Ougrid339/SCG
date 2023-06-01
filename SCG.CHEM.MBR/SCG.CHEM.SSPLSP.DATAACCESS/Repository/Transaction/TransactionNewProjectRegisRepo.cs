using SCG.CHEM.SSPLSP.DATAACCESS.AppModels.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Transaction;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Transaction.Interface;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Transaction
{
    public class TransactionNewProjectRegisRepo : RepositoryBase<SSP_TRN_NEW_PROJECT_REGIS>, ITransactionNewProjectRegisRepo
    {
        #region Inject

        public TransactionNewProjectRegisRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        public SSP_TRN_NEW_PROJECT_REGIS GeyById(string id)
        {
            var result = _context.SSP_TRN_NEW_PROJECT_REGISs.Where(w => w.ProjectID == id).FirstOrDefault();
            return result;
        }

        public List<SSP_TRN_NEW_PROJECT_REGIS> GeyByIds(List<string> data)
        {
            var result = _context.SSP_TRN_NEW_PROJECT_REGISs.Where(w => data.Contains(w.ProjectID)).ToList();
            return result;
        }
    }
}