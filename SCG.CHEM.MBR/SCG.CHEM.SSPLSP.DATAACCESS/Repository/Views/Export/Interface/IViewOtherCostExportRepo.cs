using SCG.CHEM.SSPLSP.DATAACCESS.Entities.View.Export;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Views.Export.Interface
{
    public interface IViewOtherCostExportRepo : IRepositoryBase<vSSP_MST_OTHER_COST_EXPORT>
    {
        decimal GetTaxRefund(string channel, string saleOrg, string planType, DateTime yearMonth);
    }
}