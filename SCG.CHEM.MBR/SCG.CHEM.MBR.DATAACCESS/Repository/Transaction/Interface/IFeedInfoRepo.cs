using SCG.CHEM.MBR.DATAACCESS.AppModels.Transaction;
using SCG.CHEM.MBR.DATAACCESS.Entities.Temp;
using SCG.CHEM.MBR.DATAACCESS.Entities.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.MBR.DATAACCESS.Repository.Transaction.Interface
{
    public interface IFeedInfoRepo : IRepositoryBase<MRB_TRN_FEED_INFO>
    {
        List<MRB_TRN_FEED_INFO> FindByCriterias(string mergePlaneType, string mergeCase, string mergeCycle);

        List<MRB_TRN_FEED_INFO> FindByCriteriasAll(string planType, string @case, string cycle, List<string> Company, List<string>? FeedGeoCategoryKey, List<string>? FeedNameKey, List<string>? ProductGroup);

        List<MRB_TRN_FEED_INFO> FindByCriteriasAll(string planType, string @case, List<string> cycle, List<string> Company, List<string>? FeedGeoCategoryKey, List<string>? FeedNameKey, List<string>? ProductGroup);

        public List<MRB_TRN_FEED_INFO> FindByCriteriasAll(string planType, string @case, string cycle, List<string> Company, List<string>? FeedGeoCategoryKey, List<string>? FeedNameKey, List<string>? ProductGroup, List<string>? MaterialCode);

        FeedInfoMergeScenarioModel GetMergeScenario();
    }
}