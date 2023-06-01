using SCG.CHEM.SSPLSP.DATAACCESS.Entities.View.Export;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Views.Export.Interface;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Views.Interface;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Views.Export
{
    public class ViewRMRollingExportRepo : RepositoryBase<vSSP_MST_RM_ROLLING_EXPORT>, IViewRMRollingExportRepo, IDownloadRepo
    {
        #region Inject

        public ViewRMRollingExportRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        public List<Object> DownloadMaster(List<string> planTypeList = null, string startdate = null, string cycle = null)
        {
            var query = _context.vSSP_MST_RM_ROLLING_EXPORTs.AsQueryable();
            //if (startdate != null)
            //{
            //    var date = DateTime.ParseExact(string.Concat(startdate, "-01"), "yyyy-MM-dd", CultureInfo.InvariantCulture);
            //    query.Where(d => date <= d.FirstDate);
            //}
            //if (planTypeList != null)
            //{
            //    query.Where(p => planTypeList.Contains(p.PlanType));
            //}
            if (cycle != null)
            {
                query = query.Where(p => cycle == p.VersionName);
            }
            var result = query.ToList<Object>();
            return result;
        }
    }
}