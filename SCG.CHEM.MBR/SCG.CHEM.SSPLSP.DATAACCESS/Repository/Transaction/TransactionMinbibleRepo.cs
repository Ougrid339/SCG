using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Transaction;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Transaction.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Transaction
{
    public class TransactionMinbibleRepo : RepositoryBase<SSP_TRN_MINBIBLE>, ITransactionMinbibleRepo
    {
        #region Inject

        public TransactionMinbibleRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        public List<SSP_TRN_MINBIBLE> GetMinbibleDB()
        {
            //var result = _context.SSP_TRN_MINBIBLEs.Where(w => w.DeletedFlag != APPCONSTANT.DELETE_FLAG.YES).ToList();
            var result = (from MIN in _context.SSP_TRN_MINBIBLEs
                          where MIN.DeletedFlag != APPCONSTANT.DELETE_FLAG.YES
                          orderby MIN.PlanningGroup, MIN.SalesGroupCode, MIN.Channel, MIN.Region, MIN.CustomerCode, MIN.Grade, MIN.Package, MIN.StartMonth
                          select MIN).ToList();
            return result;
        }

        public SSP_TRN_MINBIBLE GetLastActiveVersionByKey(string planType, string startMonth, int scenarioId, string customerCode, string channel, string matCodeMst, string matCodeTrn, int newProductId, string salesGroupCode, string planningGroup, string region, string reqProductSite, string unit)
        {
            var result = _context.SSP_TRN_MINBIBLEs.Where(w => w.DeletedFlag != APPCONSTANT.DELETE_FLAG.YES
                                                            && w.PlanType == planType
                                                            && w.StartMonth == startMonth
                                                            && w.ScenarioId == scenarioId
                                                            && w.CustomerCode == customerCode
                                                            && w.Channel == channel
                                                            && w.MatCodeMst == matCodeMst
                                                            && w.MatCodeTrn == matCodeTrn
                                                            && w.NewProductId == newProductId
                                                            && w.SalesGroupCode == salesGroupCode
                                                            && w.PlanningGroup == planningGroup
                                                            && w.Region == region
                                                            && w.ReqProductSite == reqProductSite
                                                            && w.Unit == unit).OrderByDescending(o => o.VersionNo).FirstOrDefault();
            return result;
        }

        public SSP_TRN_MINBIBLE GetLastVersionByKey(string planType, string startMonth, int scenarioId, string customerCode, string channel, string matCodeMst, string matCodeTrn, int newProductId, string salesGroupCode, string planningGroup, string region, string reqProductSite, string unit)
        {
            var result = _context.SSP_TRN_MINBIBLEs.Where(w => w.PlanType == planType
                                                            && w.StartMonth == startMonth
                                                            && w.ScenarioId == scenarioId
                                                            && w.CustomerCode == customerCode
                                                            && w.Channel == channel
                                                            && w.MatCodeMst == matCodeMst
                                                            && w.MatCodeTrn == matCodeTrn
                                                            && w.NewProductId == newProductId
                                                            && w.SalesGroupCode == salesGroupCode
                                                            && w.PlanningGroup == planningGroup
                                                            && w.Region == region
                                                            && w.ReqProductSite == reqProductSite
                                                            && w.Unit == unit).OrderByDescending(o => o.VersionNo).FirstOrDefault();
            return result;
        }
    }
}