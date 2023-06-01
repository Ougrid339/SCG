using Microsoft.EntityFrameworkCore;
using SCG.CHEM.MBR.DATAACCESS.Entities.Temp;
using SCG.CHEM.MBR.DATAACCESS.Entities.Transaction;
using SCG.CHEM.MBR.DATAACCESS.Repository.Temp.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.MBR.DATAACCESS.Repository.Temp
{
    public class SalesVoiumeTempRepo : RepositoryBase<MBR_TMP_SALES_VOLUME>, ISalesVoiumeTempRepo
    {
        public SalesVoiumeTempRepo(EntitiesMBRContext context, EntitiesMBRReadContext readConext) : base(context, readConext)
        {
        }
        public List<MBR_TMP_SALES_VOLUME> FindByCriteria(string scenario, string @case, string cycle)
        {
            return _context.MBR_TMP_SALES_VOLUMEs.Where(w => w.PlanType.ToLower() == scenario.ToLower() && w.Case.ToLower() == @case.ToLower() && w.Cycle.ToLower() == cycle.ToLower()).ToList();
        }

        public List<MBR_TMP_SALES_VOLUME> FindByRunId(string runId)
        {
            return _context.MBR_TMP_SALES_VOLUMEs.Where(w => w.RunId == runId).ToList();
        }

        public async Task<List<MBR_TMP_SALES_VOLUME>> FindByRunIdNoTrackingAsync(string runId)
        {
            return await _context.MBR_TMP_SALES_VOLUMEs.AsNoTracking().Where(w => w.RunId == runId).ToListAsync();
        }

        public List<MBR_TMP_SALES_VOLUME> FindByCriterias(string cycle, string @case, List<string>? company, List<string>? product, List<string>? productGroup, List<string>? channel)
        {
            var query = _context.MBR_TMP_SALES_VOLUMEs.Where(w => w.Case.ToLower() == @case.ToLower() &&
                                                                  w.Cycle.ToLower() == cycle.ToLower()).AsNoTracking();

            if (company != null && company.Count > 0)
            {
                query = query.Where(o => company.Contains(o.Company));
            }

            if (product != null && product.Count > 0)
            {
                query = query.Where(o => product.Contains(o.Product));
            }

            if (productGroup != null && productGroup.Count > 0)
            {
                query = query.Where(o => productGroup.Contains(o.ProductGroup));
            }

            if (channel != null && channel.Count > 0)
            {
                query = query.Where(o => channel.Contains(o.Channel));

            }
            return query.ToList();
        }

        public async Task<List<MBR_TMP_SALES_VOLUME>> FindOlderThanOneHourRecordAsync()
        {
            //var now = DateTime.Now.AddMinutes(-1.00);
            var now = DateTime.Now.AddHours(-1.00);

            var query = _context.MBR_TMP_SALES_VOLUMEs.Where(s=>s.CreatedDate <= now ).AsNoTracking();

            return await query.ToListAsync();

        }
    }
}
