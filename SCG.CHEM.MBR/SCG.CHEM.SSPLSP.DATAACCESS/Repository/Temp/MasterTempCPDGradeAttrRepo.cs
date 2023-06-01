using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Template;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Temp.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Temp
{
    public class MasterTempCPDGradeAttrRepo : RepositoryBase<SSP_TMP_CPD_GRADE_ATTR>, IMasterTempCPDGradeAttrRepo
    {
        #region Inject

        public MasterTempCPDGradeAttrRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        public List<SSP_TMP_CPD_GRADE_ATTR> GetByKey(string productionSite, string matPrefix, string grade, string startMonth)
        {
            var result = _context.SSP_TMP_CPD_GRADE_ATTRs.Where(s => s.ProductionSite == productionSite && s.MatPrefix == matPrefix && s.Grade == grade
                                                                  && s.StartMonth == startMonth && s.DeletedFlag != APPCONSTANT.DELETE_FLAG.YES).ToList(); return result;
        }

        public void Truncate()
        {
            var data = _context.SSP_TMP_CPD_GRADE_ATTRs.ToList();
            _context.RemoveRange(data);
        }
    }
}