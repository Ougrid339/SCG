using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface
{
    public interface IMasterMenuRepo : IRepositoryBase<MST_MENU>
    {
        List<MST_MENU> GetMenuByRoles(List<short> roles);
    }
}