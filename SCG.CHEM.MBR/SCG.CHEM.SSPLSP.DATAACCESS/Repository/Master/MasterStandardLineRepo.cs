using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master
{
    public class MasterStandardLineRepo : RepositoryBase<SSP_MST_STANDARD_LINE>, IMasterStandardLineRepo
    {
        #region Inject

        public MasterStandardLineRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        public List<SSP_MST_STANDARD_LINE> GetByKey(string productionSite, string matPrefix, string grade)
        {
            var result = _context.SSP_MST_STANDARD_LINEs.Where(s => s.DeletedFlag != APPCONSTANT.DELETE_FLAG.YES && s.ProductionSite == productionSite && s.MatPrefix == matPrefix && s.Grade == grade).ToList();
            return result;
        }

        public List<SSP_MST_STANDARD_LINE> GetAllByKeyAndVersion(string productionSite, string matPrefix, string grade, string productionline, string plant, int versionNo)
        {
            var result = _context.SSP_MST_STANDARD_LINEs.Where(s => s.VersionNo == versionNo && s.ProductionSite == productionSite && s.MatPrefix == matPrefix && s.Grade == grade && s.ProductionLine == productionline && s.Plant == plant).ToList();
            return result;
        }
    }
}