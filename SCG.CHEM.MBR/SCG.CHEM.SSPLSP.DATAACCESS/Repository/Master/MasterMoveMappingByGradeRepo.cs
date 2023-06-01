using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master
{
    public class MasterMoveMappingByGradeRepo : RepositoryBase<SSP_MST_MOVE_MAPPING_BY_GRADE>, IMasterMoveMappingByGradeRepo
    {
        #region Inject

        public MasterMoveMappingByGradeRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        public List<SSP_MST_MOVE_MAPPING_BY_GRADE> GetByKey(string productionSite, string grade)
        {
            var result = _context.SSP_MST_MOVE_MAPPING_BY_GRADEs.Where(s => s.DeletedFlag != APPCONSTANT.DELETE_FLAG.YES && s.ProductionSite == productionSite && s.Grade == grade).ToList();
            return result;
        }

        public List<SSP_MST_MOVE_MAPPING_BY_GRADE> GetAllByKeyAndVersion(string productionSite, string grade, int versionNo)
        {
            var result = _context.SSP_MST_MOVE_MAPPING_BY_GRADEs.Where(s => s.VersionNo == versionNo && s.ProductionSite == productionSite && s.Grade == grade).ToList();
            return result;
        }
    }
}