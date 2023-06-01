using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface
{
    public interface IMasterChannelRepo : IRepositoryBase<SSP_MST_CHANNEL>
    {
        List<SSP_MST_CHANNEL> GetChannelCodes(List<string> data);

        List<SSP_MST_CHANNEL> GetChannelNames(List<string> data);

        List<SSP_MST_CHANNEL> GetChannelGroups(List<string> data);
    }
}