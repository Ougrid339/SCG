using SCG.CHEM.SSPLSP.DATAACCESS.AppModels.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master
{
    public class MasterSalesGroupRepo : RepositoryBase<SSP_MST_SALES_GROUP>, IMasterSalesGroupRepo
    {
        #region Inject

        public MasterSalesGroupRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        public List<SSP_MST_SALES_GROUP> GetSalesGroup(List<string> data)
        {
            var result = _context.SSP_MST_SALES_GROUPs.Where(s => data.Contains(s.SalesGroupCode)).ToList();
            return result;
        }

        public List<SSP_MST_SALES_GROUP> GetSalesOrg(List<string> data)
        {
            var result = _context.SSP_MST_SALES_GROUPs.Where(s => data.Contains(s.SalesOrg)).ToList();
            return result;
        }

        public List<SSP_MST_SALES_GROUP> GetByCompanyCodes(List<string> data)
        {
            var result = _context.SSP_MST_SALES_GROUPs.Where(s => data.Contains(s.CompanyCode)).ToList();
            return result;
        }

        public List<SSP_MST_SALES_GROUP> GetByCompanyCode(string data)
        {
            var result = _context.SSP_MST_SALES_GROUPs.Where(s => s.CompanyCode == data).ToList();
            return result;
        }

        public List<SalesGroupMasterSheet> GetSalesGroupForMasterSheet()
        {
            return GetAll().Select(c => new SalesGroupMasterSheet
            {
                SalesGroupCode = c.SalesGroupCode,
                SalesGroupDesc = c.SalesGroupSDesc,
                SalesOrg = c.SalesOrg,
                CompanyCode = c.CompanyCode,
            }).ToList();
        }
    }
}