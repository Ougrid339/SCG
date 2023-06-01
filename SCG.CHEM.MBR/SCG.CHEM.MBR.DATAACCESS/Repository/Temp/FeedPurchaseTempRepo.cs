﻿using SCG.CHEM.MBR.DATAACCESS.Entities.Temp;
using SCG.CHEM.MBR.DATAACCESS.Entities.Transaction;
using SCG.CHEM.MBR.DATAACCESS.Repository.Temp.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.MBR.DATAACCESS.Repository.Temp
{
    internal class FeedPurchaseTempRepo : RepositoryBase<MBR_TMP_FEED_PURCHASE>, IFeedPurchaseTempRepo
    {
        public FeedPurchaseTempRepo(EntitiesMBRContext context, EntitiesMBRReadContext readConext) : base(context, readConext)
        {
        }

        public List<MBR_TMP_FEED_PURCHASE> FindByCriterias(string scenario, string @case, string cycle)
        {
            return _context.MBR_TMP_FEED_PURCHASEs.Where(w => w.PlanType.ToLower() == scenario.ToLower() && w.Case.ToLower() == @case.ToLower() && w.Cycle.ToLower() == cycle.ToLower()).ToList();
        }

        public List<MBR_TMP_FEED_PURCHASE> FindByRunId(string runId)
        {
            return _context.MBR_TMP_FEED_PURCHASEs.Where(w => w.RunId == runId).ToList();
        }

        public List<MBR_TMP_FEED_PURCHASE> FindAfter30minute()
        {
            var dateDel = DateTime.Now.AddMinutes(-30);
            return _context.MBR_TMP_FEED_PURCHASEs.Where(w => w.CreatedDate < dateDel).ToList();
        }
    }
}