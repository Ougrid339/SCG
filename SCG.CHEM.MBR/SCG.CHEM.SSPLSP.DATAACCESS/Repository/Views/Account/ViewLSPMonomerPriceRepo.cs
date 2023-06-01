﻿using SCG.CHEM.SSPLSP.DATAACCESS.Entities.View.Account;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Views.Account.Interface;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Views.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Views.Account
{
    public class ViewLSPMonomerPriceRepo : RepositoryBase<vSSP_INF_LSP_MONOMER_PRICE>, IViewLSPMonomerPriceRepo, IDownloadAccountReportRepo
    {
        #region Inject

        public ViewLSPMonomerPriceRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        public List<object> DownloadAccountReports(List<string> plantypes = null, string startdate = null, string cycle = null, List<string> planningGroup = null)
        {
            var query = _context.vSSP_INF_LSP_MONOMER_PRICEs.AsQueryable();
            //if (startdate != null)
            //{
            //    query.Where(d => startdate == d.START_MONTH);
            //}
            //if (plantypes != null)
            //{
            //    query = query.Where(p => plantypes.Contains(p.));
            //}
            if (cycle != null)
            {
                query = query.Where(p => cycle == p.CycleName);
            }
            var result = query.ToList<Object>();
            return result;
        }
    }
}