using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Temp.Interface
{
    public interface IMasterTempWaxViscosityPercentRepo : IRepositoryBase<SSP_TMP_WAX_VISCOSITY_PERCENT>
    {
        List<SSP_TMP_WAX_VISCOSITY_PERCENT> GetByKey(string planType, string matPrefix, string grade, string gradeComp, string plant, string productionLine, string startMonth);

        public void Truncate();
    }
}