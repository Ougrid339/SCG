using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Template;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Temp.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Temp
{
    public class MasterTempMoveMappingByGradeRepo : RepositoryBase<SSP_TMP_MOVE_MAPPING_BY_GRADE>, IMasterTempMoveMappingByGradeRepo
    {
        #region Inject

        public MasterTempMoveMappingByGradeRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        public List<SSP_TMP_MOVE_MAPPING_BY_GRADE> GetByKey(string productionSite, string grade)
        {
            var result = _context.SSP_TMP_MOVE_MAPPING_BY_GRADEs.Where(s => s.ProductionSite == productionSite && s.Grade == grade).ToList();
            return result;
        }

        public void Truncate()
        {
            var data = _context.SSP_TMP_MOVE_MAPPING_BY_GRADEs.ToList();
            _context.RemoveRange(data);
        }
    }
}