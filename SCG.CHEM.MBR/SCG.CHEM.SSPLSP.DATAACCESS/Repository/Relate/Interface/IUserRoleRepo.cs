using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Relate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Relate.Interface
{
    public interface IUserRoleRepo : IRepositoryBase<REL_USER_ROLE>
    {
        public List<REL_USER_ROLE> FindAll();

        public List<REL_USER_ROLE> FindByUser(List<MST_USER_PROFILE> userList);
    }
}