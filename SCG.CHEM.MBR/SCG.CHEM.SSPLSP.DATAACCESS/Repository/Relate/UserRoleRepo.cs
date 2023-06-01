using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Relate;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Relate.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Relate
{
    public class UserRoleRepo : RepositoryBase<REL_USER_ROLE>, IUserRoleRepo
    {
        public UserRoleRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
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