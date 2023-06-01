using SCG.CHEM.SSPLSP.DATAACCESS.Entities.View.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Views.Template.Interface
{
    public interface IViewFreightTemplateRepo : IRepositoryBase<vSSP_MST_FREIGHT_TEMPLATE>
    {
        List<vSSP_MST_FREIGHT_TEMPLATE> GetByPlanTypeAndDate(List<string> planTypeList, DateTime startdate);

        List<vSSP_MST_FREIGHT_TEMPLATE> GetByPlanType(List<string> planTypeList);
    }
}