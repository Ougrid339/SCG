using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Transaction;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Transaction.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Transaction
{
    public class TransactionLockUnlockCycleRepo : RepositoryBase<SSP_TRN_LOCK_UNLOCK_CYCLE>, ITransactionLockUnlockCycleRepo
    {
        #region Inject

        public TransactionLockUnlockCycleRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject
    }
}