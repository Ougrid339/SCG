using SCG.CHEM.MBR.DATAACCESS.Entities.Temp;
using SCG.CHEM.MBR.DATAACCESS.Repository.Temp.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.MBR.DATAACCESS.Repository.Temp
{
    public class FeedInfoTempRepo : RepositoryBase<MRB_TMP_FEED_INFO>, IFeedInfoTempRepo
    {
        public FeedInfoTempRepo(EntitiesMBRContext context, EntitiesMBRReadContext readConext) : base(context, readConext)
        {
        }
        public List<MRB_TMP_FEED_INFO> FindByCriterias(string planType, string @case, string cycle)
        {
            return _context.MRB_TMP_FEED_INFOs.Where(w => w.PlanType.ToLower() == planType.ToLower() && w.Case.ToLower() == @case.ToLower() && w.Cycle.ToLower() == cycle.ToLower()).ToList();
        }
        public List<MRB_TMP_FEED_INFO> FindByCriteriasAll(string planType, string @case, string cycle, List<string> Company, List<string> FeedGeoCategoryKey, List<string> FeedNameKey, List<string> ProductGroup)
        {
            var resultValue = _context.MRB_TMP_FEED_INFOs.Where(w => w.PlanType.ToLower() == planType.ToLower() && w.Case.ToLower() == @case.ToLower() && w.Cycle.ToLower() == cycle.ToLower()).ToList();
            if (Company != null && Company.Count > 0) { resultValue = resultValue.Where(o => Company.Contains(o.Company)).ToList(); }
            if (FeedGeoCategoryKey != null && FeedGeoCategoryKey.Count > 0) { resultValue = resultValue.Where(o => FeedGeoCategoryKey.Contains(o.FeedGeoCategoryKey)).ToList(); }
            if (FeedNameKey != null && FeedNameKey.Count > 0) { resultValue = resultValue.Where(o => FeedNameKey.Contains(o.FeedNameKey)).ToList(); }
            if (ProductGroup != null && ProductGroup.Count > 0) { resultValue = resultValue.Where(o => ProductGroup.Contains(o.ProductGroup)).ToList(); }
            return resultValue;
        }
    }
}
