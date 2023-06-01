using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface
{
    public interface IMasterRefGradeByProductGroupRepo : IRepositoryBase<SSP_MST_REF_GRADE_BY_PRODUCT_GROUP>
    {
        List<SSP_MST_REF_GRADE_BY_PRODUCT_GROUP> GetByProductGroupDesc(List<string> data);
    }
}