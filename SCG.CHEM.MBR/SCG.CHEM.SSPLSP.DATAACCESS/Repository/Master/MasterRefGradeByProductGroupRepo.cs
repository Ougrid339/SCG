using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master
{
    public class MasterRefGradeByProductGroupRepo : RepositoryBase<SSP_MST_REF_GRADE_BY_PRODUCT_GROUP>, IMasterRefGradeByProductGroupRepo
    {
        #region Inject

        public MasterRefGradeByProductGroupRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        public List<SSP_MST_REF_GRADE_BY_PRODUCT_GROUP> GetByProductGroupDesc(List<string> data)
        {
            var result = _context.SSP_MST_REF_GRADE_BY_PRODUCT_GROUPs.Where(s => data.Contains(s.ProductGroupSDesc)).ToList();
            return result;
        }
    }
}