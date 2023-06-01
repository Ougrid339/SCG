using SCG.CHEM.MBR.DATAACCESS.AppModels.Common;
using SCG.CHEM.MBR.DATAACCESS.Repository.Master.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.MBR.DATAACCESS.Repository.Master
{
    public class MasterCompanyRepo : IMasterCompanyRepo
    {
        #region Inject

        public MasterCompanyRepo(EntitiesMBRContext context, EntitiesMBRReadContext readConext)
        {
        }

        public List<DropdownModel> GetCompany()
        {
            var dropdownModel = new List<DropdownModel>();
            dropdownModel.Add(new DropdownModel { value = APPCONSTANT.DROPDOWN.ALL, text = APPCONSTANT.DROPDOWN.ALL });
            dropdownModel.Add(new DropdownModel { value = APPCONSTANT.COMPANY.MOC, text = APPCONSTANT.COMPANY.MOC });
            dropdownModel.Add(new DropdownModel { value = APPCONSTANT.COMPANY.ROC, text = APPCONSTANT.COMPANY.ROC });
            dropdownModel.Add(new DropdownModel { value = APPCONSTANT.COMPANY.LSP, text = APPCONSTANT.COMPANY.LSP });
            return dropdownModel;
        }

        #endregion Inject
    }
}
