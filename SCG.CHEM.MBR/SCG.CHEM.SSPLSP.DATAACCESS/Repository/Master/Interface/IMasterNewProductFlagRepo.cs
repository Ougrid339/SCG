using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface
{
    public interface IMasterNewProductFlagRepo : IRepositoryBase<SSP_MST_NEW_PRODUCT_FLAG>
    {
        List<SSP_MST_NEW_PRODUCT_FLAG> GetByNewProductDesc(List<string> data);
    }
}