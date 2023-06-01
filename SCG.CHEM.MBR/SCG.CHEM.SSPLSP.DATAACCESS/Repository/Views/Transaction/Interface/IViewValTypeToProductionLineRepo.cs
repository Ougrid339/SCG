using SCG.CHEM.SSPLSP.DATAACCESS.AppModels.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Entities.View.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Views.Transaction.Interface
{
    public interface IViewValTypeToProductionLineRepo : IRepositoryBase<vSSP_MST_VAL_TYPE_TO_PRODUCTION_LINE>
    {
        vSSP_MST_VAL_TYPE_TO_PRODUCTION_LINE GetByValuationTypeCode(string data);
    }
}