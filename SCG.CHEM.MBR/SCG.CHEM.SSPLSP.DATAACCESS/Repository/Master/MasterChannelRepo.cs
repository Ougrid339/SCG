using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master
{
    public class MasterChannelRepo : RepositoryBase<SSP_MST_CHANNEL>, IMasterChannelRepo
    {
        #region Inject

        public MasterChannelRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        public List<SSP_MST_CHANNEL> GetChannelCodes(List<string> data)
        {
            var result = _context.SSP_MST_CHANNELs.Where(s => data.Contains(s.ChannelCode)).ToList();
            return result;
        }

        public List<SSP_MST_CHANNEL> GetChannelNames(List<string> data)
        {
            var result = _context.SSP_MST_CHANNELs.Where(s => data.Contains(s.ChannelName)).ToList();
            return result;
        }

        public List<SSP_MST_CHANNEL> GetChannelGroups(List<string> data)
        {
            var result = _context.SSP_MST_CHANNELs.Where(s => data.Contains(s.ChannelGroup)).ToList();
            return result;
        }
    }
}