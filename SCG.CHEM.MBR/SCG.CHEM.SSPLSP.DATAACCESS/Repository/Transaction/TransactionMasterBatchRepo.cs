using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Transaction;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Transaction.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Transaction
{
    public class TransactionMasterBatchRepo : RepositoryBase<SSP_TRN_MASTER_BATCH>, ITransactionMasterBatchRepo
    {
        #region Inject

        public TransactionMasterBatchRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        public List<SSP_TRN_MASTER_BATCH> GetMasterBatchDB()
        {
            var result = _context.SSP_TRN_MASTER_BATCHs.Where(w => w.DeletedFlag != APPCONSTANT.DELETE_FLAG.YES).ToList();
            return result;
        }

        public SSP_TRN_MASTER_BATCH GetLastActiveVersionByKey(string planType, string startMonth, int scenarioId, string customerCode, string channel, string matCodeMst, string matCodeTrn, int newProductId, string salesGroupCode, string planningGroup, string region, string reqProductSite, string subRegion, string salesDistrict, string unit, string projectId, int priceUnitId)
        {
            var result = _context.SSP_TRN_MASTER_BATCHs.Where(w => w.DeletedFlag != APPCONSTANT.DELETE_FLAG.YES
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
                                                            && w.SubRegion == subRegion
                                                            && w.SalesDistrict == salesDistrict
                                                            && w.Unit == unit
                                                            && w.ProjectID == projectId
                                                            && w.PriceUnitId == priceUnitId).OrderByDescending(o => o.VersionNo).FirstOrDefault();
            return result;
        }

        public SSP_TRN_MASTER_BATCH GetLastVersionByKey(string planType, string startMonth, int scenarioId, string customerCode, string channel, string matCodeMst, string matCodeTrn, int newProductId, string salesGroupCode, string planningGroup, string region, string reqProductSite, string subRegion, string salesDistrict, string unit, string projectId, int priceUnitId)
        {
            var result = _context.SSP_TRN_MASTER_BATCHs.Where(w => w.PlanType == planType
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
                                                            && w.SubRegion == subRegion
                                                            && w.SalesDistrict == salesDistrict
                                                            && w.Unit == unit
                                                            && w.ProjectID == projectId
                                                            && w.PriceUnitId == priceUnitId).OrderByDescending(o => o.VersionNo).FirstOrDefault();
            return result;
        }
    }
}