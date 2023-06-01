using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface;
using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Relate;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master
{
    public class MasterMenuRepo : RepositoryBase<MST_MENU>, IMasterMenuRepo
    {
        #region Inject

        public MasterMenuRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        public List<MST_MENU> GetMenuByRoles(List<short> roles)
        {
            var allMenu = (from m in _readContext.MST_MENUs

                           join rel in _readContext.REL_MENU_ROLEs
                           on new { menuId = m.Id } equals new { menuId = rel.MenuId }

                           join r in _readContext.MST_ROLEs
                           on new { RoleId = rel.RoleId } equals new { RoleId = r.Id }

                           where roles.Contains(r.Id)

                           select m)
                           .Distinct().ToList();
            return allMenu;
        }
    }
}