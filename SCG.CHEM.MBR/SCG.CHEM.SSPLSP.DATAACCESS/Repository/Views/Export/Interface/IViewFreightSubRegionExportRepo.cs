using SCG.CHEM.SSPLSP.DATAACCESS.Entities.View.Export;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Views.Export.Interface
{
    public interface IViewFreightSubRegionExportRepo : IRepositoryBase<vSSP_MST_FREIGHT_SUBREGION_EXPORT>
    {
        List<vSSP_MST_FREIGHT_SUBREGION_EXPORT> GetByPlanTypeAndDate(List<string> planTypeList, DateTime startdate);

        List<vSSP_MST_FREIGHT_SUBREGION_EXPORT> GetByPlanType(List<string> planTypeList);
    }
}