using SCG.CHEM.MBR.DATAACCESS.Entities.Master;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCG.CHEM.MBR.DATAACCESS.AppModels.Master
{
    public class UserDetailModel
    {
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; private set; }
        public List<string> DefaultCca { get; set; }
        public Byte? DefaultCountry { get; set; }
        public Byte? DefaultCreateDoc { get; set; }
        public List<string> DefaultSalesGroup { get; set; }
        public List<string> DefaultSalesOrg { get; set; }
        public List<string> DefaultSalesOffice { get; set; }
        public Byte? DefaultRelease { get; set; }
        public int? NextShippingDate { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? NextShippingDateFrom { get; set; }
        public DateTime? NextShippingDateTo { get; set; }
        public string NextShippingDateFromStr { get; set; }
        public string NextShippingDateToStr { get; set; }
        public bool? ActiveFlag { get; set; }
        public bool ShowActiveFlag { get; set; }

        public UserDetailModel()
        { }

        public UserDetailModel(MST_USER_PROFILE db)
        {
            this.UserId = db.UserId;
            this.FirstName = db.FirstName;
            this.LastName = db.LastName;
            this.Email = db.Email;
            this.UpdateBy = db.UpdateBy;
            this.ActiveFlag = !db.DeleteFlag;
        }

        public void SetDataList(List<string> cca, List<string> salesGroup, List<string> salesOrg, List<string> salesOffice)
        {
            this.DefaultCca = cca;
            this.DefaultSalesGroup = salesGroup;
            this.DefaultSalesOrg = salesOrg;
            this.DefaultSalesOffice = salesOffice;
        }
    }
}