using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master
{
    public class MasterCPDGradeAttrRepo : RepositoryBase<SSP_MST_CPD_GRADE_ATTR>, IMasterCPDGradeAttrRepo
    {
        #region Inject

        public MasterCPDGradeAttrRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        public List<SSP_MST_CPD_GRADE_ATTR> GetByKey(string productionSite, string matPrefix, string grade, string startMonth)
        {
            var result = _context.SSP_MST_CPD_GRADE_ATTRs.Where(s => s.ProductionSite == productionSite && s.MatPrefix == matPrefix && s.Grade == grade && s.StartMonth == startMonth && s.DeletedFlag != APPCONSTANT.DELETE_FLAG.YES).ToList();
            return result;
        }

        public List<SSP_MST_CPD_GRADE_ATTR> GetAllByKeyAndVersion(string productionSite, string matPrefix, string grade, string startMonth, int versionNo)
        {
            var result = _context.SSP_MST_CPD_GRADE_ATTRs.Where(s => s.ProductionSite == productionSite && s.MatPrefix == matPrefix && s.Grade == grade && s.StartMonth == startMonth && s.VersionNo == versionNo).ToList();
            return result;
        }
    }
}