using SCG.CHEM.MBR.DATAACCESS.Entities.Master;
using SCG.CHEM.MBR.DATAACCESS.Repository.Master.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.MBR.DATAACCESS.Repository.Master
{
    public class MasterPlanTypeRepo : RepositoryBase<MBR_MST_PLANTYPE>, IMasterPlanTypeRepo
    {
        public MasterPlanTypeRepo(EntitiesMBRContext context, EntitiesMBRReadContext readConext) : base(context, readConext)
        {
        }

        public List<MBR_MST_PLANTYPE> GetPlanTypeWithActual()
        {
            var result =  _context.MBR_MST_PLANTYPE.Where(w => w.PlanTypeName.ToUpper() != "ACTUAL").ToList();
            var actual = _context.MBR_MST_PLANTYPE.Where(w => w.PlanTypeName.ToUpper() == "ACTUAL").FirstOrDefault();
            if (actual != null)
            {
                result.Add(actual);
            }
            return result;

        }

        public List<MBR_MST_PLANTYPE> GetPlanType()
        {
            return _context.MBR_MST_PLANTYPE.Where(w => w.PlanTypeName.ToUpper() != "ACTUAL").ToList();
        }

    }
}
