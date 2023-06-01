using SCG.CHEM.MBR.DATAACCESS.AppModels.Transaction;
using SCG.CHEM.MBR.DATAACCESS.Entities.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.MBR.DATAACCESS.Repository.Transaction.Interface
{
    public interface IMergeHistoryRepo : IRepositoryBase<MBR_TRN_MERGE_HISTORY>
    {
        MBR_TRN_MERGE_HISTORY? GetDataByCriteria(MergeHistoryRequestModel criteria, int excelId);
    }
}
