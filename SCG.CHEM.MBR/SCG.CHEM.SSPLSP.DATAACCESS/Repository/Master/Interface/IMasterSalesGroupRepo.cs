using SCG.CHEM.SSPLSP.DATAACCESS.AppModels.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface
{
    public interface IMasterSalesGroupRepo : IRepositoryBase<SSP_MST_SALES_GROUP>
    {
        List<SSP_MST_SALES_GROUP> GetSalesGroup(List<string> data);

        List<SSP_MST_SALES_GROUP> GetSalesOrg(List<string> data);

        List<SSP_MST_SALES_GROUP> GetByCompanyCodes(List<string> data);

        List<SSP_MST_SALES_GROUP> GetByCompanyCode(string data);

        List<SalesGroupMasterSheet> GetSalesGroupForMasterSheet();
    }
}