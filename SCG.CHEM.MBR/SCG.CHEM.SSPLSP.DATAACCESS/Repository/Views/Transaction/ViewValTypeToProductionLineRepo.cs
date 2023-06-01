using SCG.CHEM.SSPLSP.DATAACCESS.AppModels.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Entities.View.Transaction;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Views.Transaction.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Views.Transaction
{
    public class ViewValTypeToProductionLineRepo : RepositoryBase<vSSP_MST_VAL_TYPE_TO_PRODUCTION_LINE>, IViewValTypeToProductionLineRepo
    {
        #region Inject

        public ViewValTypeToProductionLineRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        public vSSP_MST_VAL_TYPE_TO_PRODUCTION_LINE GetByValuationTypeCode(string data)
        {
            var result = _context.vSSP_MST_VAL_TYPE_TO_PRODUCTION_LINEs.Where(w => w.ValuationTypeCode == data).FirstOrDefault();
            return result;
        }
    }
}