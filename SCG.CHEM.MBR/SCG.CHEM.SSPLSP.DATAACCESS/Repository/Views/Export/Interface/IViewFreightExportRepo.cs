using SCG.CHEM.SSPLSP.DATAACCESS.AppModels.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Entities.View.Export;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Views.Export.Interface
{
    public interface IViewFreightExportRepo : IRepositoryBase<vSSP_MST_FREIGHT_EXPORT>
    {
        List<vSSP_MST_FREIGHT_EXPORT> GetByPlanTypeAndDate(List<string> planTypeList, DateTime startdate);

        List<vSSP_MST_FREIGHT_EXPORT> GetByPlanType(List<string> planTypeList);

        FreigthCodeAndSubRegionModel GetFreigthCodeAndSubRegion(string planType, DateTime yearMonth);
    }
}