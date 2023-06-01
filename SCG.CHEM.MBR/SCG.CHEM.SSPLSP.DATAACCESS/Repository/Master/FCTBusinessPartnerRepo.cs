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
    public class FCTBusinessPartnerRepo : RepositoryBase<SSP_FCT_BUSINESS_PARTNER>, IFCTBusinessPartnerRepo
    {
        #region Inject

        public FCTBusinessPartnerRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        public List<CustomerModel> GetCustomers()
        {
            //var accountGroup = new  List<string>(new string[] { "Z101", "Z102", "'Z105", "Z106", "DREP" });
            var result = _context.SSP_FCT_BUSINESS_PARTNERs.Where(w => w.ActiveStatus != "X"
            && !w.Description.Contains("canca") && !w.Description.Contains("cance") && !w.Description.Contains("cancal") && !w.Description.Contains("cancel")
            && !w.Description.Contains("ยกเลิ") && !w.Description.Contains("ยกเลิก")).Select(s => new CustomerModel()
            {
                BusinessPartnerDisplay = s.BusinessPartnerDisplay,
                Description = s.Description,
                HVACode = s.IndustrySector,
                HVAName = s.IndustryDesc,
                SalesRegion = s.SalesRegion,
            }).ToList();

            return result;
        }

        public List<SSP_FCT_BUSINESS_PARTNER> GetByBusinessPartners(List<string> data)
        {
            var result = _context.SSP_FCT_BUSINESS_PARTNERs.Where(w => w.ActiveStatus != "X" && data.Contains(w.BusinessPartner)).ToList();

            return result;
        }

        public List<SSP_FCT_BUSINESS_PARTNER> GetCustomersSelect()
        {
            var accountGroup = new List<string>(new string[] { "Z101", "Z102", "'Z105", "Z106", "DREP" });
            var result = _context.SSP_FCT_BUSINESS_PARTNERs.Where(w => w.ActiveStatus != "X" && accountGroup.Contains(w.AccountGroup)
            && !w.Description.Contains("canca") && !w.Description.Contains("cance") && !w.Description.Contains("cancal") && !w.Description.Contains("cancel")
            && !w.Description.Contains("ยกเลิ") && !w.Description.Contains("ยกเลิก")).ToList();

            return result;
        }

        public List<SSP_FCT_BUSINESS_PARTNER> GetByShortnamepriceweb(List<string> list)
        {
            var result = _context.SSP_FCT_BUSINESS_PARTNERs.Where(w => w.ActiveStatus != "X" && list.Select(s=>s.ToLower()).Contains(w.ShortNamePriceWeb.ToLower())).ToList();

            return result;
        }
    }
}