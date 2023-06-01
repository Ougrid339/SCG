using SCG.CHEM.MBR.DATAACCESS.Entities.Master;
using SCG.CHEM.MBR.DATAACCESS.Entities.Relate;
using SCG.CHEM.MBR.DATAACCESS.Repository.Relate.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.MBR.DATAACCESS.Repository.Relate
{
    public class UserRoleRepo : RepositoryBase<REL_USER_ROLE>, IUserRoleRepo
    {
        public UserRoleRepo(EntitiesMBRContext context, EntitiesMBRReadContext readConext) : base(context, readConext)
        {
        }

        public List<REL_USER_ROLE> FindAll()
        {
            return _context.REL_USER_ROLEs.ToList();
        }

        public List<REL_USER_ROLE> FindByUser(List<MST_USER_PROFILE> userList)
        {
            var userRelList = _context.REL_USER_ROLEs.ToList();
            var resuleUserRel = (from user in userList
                                 join userRel in userRelList on user.UserId equals userRel.UserId
                                 select userRel).ToList();
            return resuleUserRel;
        }
    }
}