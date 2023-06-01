using SCG.CHEM.MBR.DATAACCESS;
using SCG.CHEM.MBR.DATAACCESS.Entities.Master;
using SCG.CHEM.MBR.DATAACCESS.Repository.Master.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.MBR.DATAACCESS.Repository.Master
{
    public class MasterDeleteFlagRepo : RepositoryBase<MBR_MST_DELETE_FLAG>, IMasterDeleteFlagRepo
    {
        #region Inject

        public MasterDeleteFlagRepo(EntitiesMBRContext context, EntitiesMBRReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        public MBR_MST_DELETE_FLAG GetById(string id)
        {
            var result = _context.MBR_MST_DELETE_FLAGs.Where(w => w.Id == id).FirstOrDefault();
            return result;
        }
    }
}