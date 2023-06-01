using SCG.CHEM.MBR.DATAACCESS.Entities.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.MBR.DATAACCESS.Repository.Master.Interface
{
    public interface ISaleConfirmRepo : IRepositoryBase<MBR_MST_SALECONFIRM>
    {
        MBR_MST_SALECONFIRM FindByCriteria(string planType, string cycle, string @case, string productGroup);

        List<MBR_MST_SALECONFIRM> FindByCriteria(string planType, string cycle, string @case);
    }
}