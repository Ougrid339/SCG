using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Template;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Temp.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Temp
{
    public class MasterTempStandardLineRepo : RepositoryBase<SSP_TMP_STANDARD_LINE>, IMasterTempStandardLineRepo
    {
        #region Inject

        public MasterTempStandardLineRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        public List<SSP_TMP_STANDARD_LINE> GetByKey(string productionSite, string matPrefix, string grade)
        {
            var result = _context.SSP_TMP_STANDARD_LINEs.Where(s => s.ProductionSite == productionSite && s.MatPrefix == matPrefix && s.Grade == grade).ToList();
            return result;
        }

        public void Truncate()
        {
            var data = _context.SSP_TMP_STANDARD_LINEs.ToList();
            _context.RemoveRange(data);
        }
    }
}