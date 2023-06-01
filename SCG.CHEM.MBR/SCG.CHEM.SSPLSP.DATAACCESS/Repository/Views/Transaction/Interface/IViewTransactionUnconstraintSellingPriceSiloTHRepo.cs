using SCG.CHEM.SSPLSP.DATAACCESS.AppModels.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Entities.View.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Views.Transaction.Interface
{
    public interface IViewTransactionUnconstraintSellingPriceSiloTHRepo : IRepositoryBase<vSSP_TRN_UNCONSTRAINT_SELLING_PRICE_SILO_TH>
    {
        //List<MonthModel> GetUnconstraintsSellingPriceSiloTH(string planType, string inputM1, string name);
    }
}