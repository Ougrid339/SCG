using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master
{
    public class MasterPriceTypeRepo : RepositoryBase<SSP_MST_PRICE_TYPE>, IMasterPriceTypeRepo
    {
        #region Inject

        public MasterPriceTypeRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        public List<SSP_MST_PRICE_TYPE> GetByPriceTypeDesc(List<string> priceType)
        {
            var result = _context.SSP_MST_PRICE_TYPEs.Where(s => priceType.Contains(s.PriceTypeDesc)).ToList();
            return result;
        }

        public List<SSP_MST_PRICE_TYPE> GetByPriceTypeDescAndCountry(List<string> priceType, List<string> country)
        {
            var result = _context.SSP_MST_PRICE_TYPEs.Where(s => priceType.Contains(s.PriceTypeDesc) && country.Contains(s.Country)).ToList();
            return result;
        }
    }
}