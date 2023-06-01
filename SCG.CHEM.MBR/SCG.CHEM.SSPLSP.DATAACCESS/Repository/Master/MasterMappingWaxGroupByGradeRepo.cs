using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master
{
    public class MasterMappingWaxGroupByGradeRepo : RepositoryBase<SSP_MST_MAPPING_WAX_GROUP_BY_GRADE>, IMasterMappingWaxGroupByGradeRepo
    {
        #region Inject

        public MasterMappingWaxGroupByGradeRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        public List<SSP_MST_MAPPING_WAX_GROUP_BY_GRADE> GetByKey(string grade, string waxGroup)
        {
            var result = _context.SSP_MST_MAPPING_WAX_GROUP_BY_GRADEs.Where(s => s.DeletedFlag != APPCONSTANT.DELETE_FLAG.YES && s.Grade == grade && s.WaxGroup == waxGroup).ToList();
            return result;
        }

        public List<SSP_MST_MAPPING_WAX_GROUP_BY_GRADE> GetAllByKeyAndVersion(string grade, string waxGroup, int versionNo)
        {
            var result = _context.SSP_MST_MAPPING_WAX_GROUP_BY_GRADEs.Where(s => s.VersionNo == versionNo && s.Grade == grade && s.WaxGroup == waxGroup).ToList();
            return result;
        }
    }
}