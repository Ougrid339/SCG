using SCG.CHEM.MBR.DATAACCESS.AppModels.Transaction;
using SCG.CHEM.MBR.DATAACCESS.Entities.Transaction;
using SCG.CHEM.MBR.DATAACCESS.Repository.Transaction.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SCG.CHEM.MBR.DATAACCESS.APPCONSTANT;

namespace SCG.CHEM.MBR.DATAACCESS.Repository.Transaction
{
    internal class MergeHistoryRepo : RepositoryBase<MBR_TRN_MERGE_HISTORY>, IMergeHistoryRepo
    {
        public MergeHistoryRepo(EntitiesMBRContext context, EntitiesMBRReadContext readConext) : base(context, readConext)
        {
        }

        public MBR_TRN_MERGE_HISTORY? GetDataByCriteria(MergeHistoryRequestModel criteria, int excelId)
        {
            return _context.MBR_TRN_MERGE_HISTORYs.Where(
                            x => x.ExcelId == excelId
                            && x.Cycle.ToUpper() == criteria.Cycle.ToUpper()
                            && x.Case.ToUpper() == criteria.Case.ToUpper()
                        ).OrderByDescending(s => s.CreatedDate).FirstOrDefault();
        }
    }
}