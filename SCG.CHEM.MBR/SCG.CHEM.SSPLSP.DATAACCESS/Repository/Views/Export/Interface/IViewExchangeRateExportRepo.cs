using SCG.CHEM.SSPLSP.DATAACCESS.Entities.View.Export;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Views.Export.Interface
{
    public interface IViewExchangeRateExportRepo : IRepositoryBase<vSSP_MST_EXCHANGE_RATE_EXPORT>
    {
        List<vSSP_MST_EXCHANGE_RATE_EXPORT> GetByFirstDate(List<DateTime> firstDate);
    }
}