using SCG.CHEM.MBR.DATAACCESS.Entities.Temp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.MBR.DATAACCESS.Repository.Temp.Interface
{
    public interface IFeedInfoTempRepo : IRepositoryBase<MRB_TMP_FEED_INFO>
    {
        List<MRB_TMP_FEED_INFO> FindByCriterias(string mergePlaneType, string @case, string cycle);
        List<MRB_TMP_FEED_INFO> FindByCriteriasAll(string planType, string @case, string cycle, List<string> Company, List<string> FeedGeoCategoryKey, List<string> FeedNameKey, List<string> ProductGroup);
    }
}
