using SCG.CHEM.SSPLSP.DATAACCESS.AppModels.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Entities.View.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Views.Transaction.Interface
{
    public interface IViewTransactionConstraintSellingPriceSiloTHRepo : IRepositoryBase<vSSP_TRN_CONSTRAINT_SELLING_PRICE_SILO_TH>
    {
        //List<MonthModel> GetConstraintsSellingPriceSiloTH(string planType, string inputM1);
    }
}