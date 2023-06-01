using SCG.CHEM.SSPLSP.DATAACCESS.AppModels.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Entities.View.Transaction;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Views.Transaction.Interface;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Views.Transaction
{
    public class ViewTransactionCalculatePriceSaleRepo : RepositoryBase<vSSP_TRN_CALCULATE_PRICE_SALE>, IViewTransactionCalculatePriceSaleRepo
    {
        #region Inject

        public ViewTransactionCalculatePriceSaleRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject
    }
}