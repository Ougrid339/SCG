using SCG.CHEM.SSPLSP.DATAACCESS.AppModels.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Transaction.Interface
{
    public interface ITransactionCalculatePriceSaleRepo : IRepositoryBase<SSP_TRN_CALCULATE_PRICE_SALE>
    {
        List<MonthModel> GetUnconstraintsSellingPriceSiloTH(string planType, string inputM1, string name, List<string> planningGroups);

        List<MonthModel> GetUnconstraintsSellingPriceSiloVN(string planType, string inputM1, string name, List<string> planningGroups);

        List<MonthModel> GetConstraintsSellingPriceSiloTH(string planType, string inputM1, List<string> planningGroups);

        List<MonthModel> GetConstraintsSellingPriceSiloVN(string planType, string inputM1, List<string> planningGroups);

        List<MonthGroupModel> GetConstraintsSellingPriceSilo(string planType, string inputM1, List<string> planningGroups);
    }
}