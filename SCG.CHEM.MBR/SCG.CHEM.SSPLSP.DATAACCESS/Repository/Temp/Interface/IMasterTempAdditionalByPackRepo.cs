using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Temp.Interface
{
    public interface IMasterTempAdditionalByPackRepo : IRepositoryBase<SSP_TMP_ADDITIONAL_BY_PACK>
    {
        List<SSP_TMP_ADDITIONAL_BY_PACK> GetByKey(string productionSite, string planType, string matPrefix, string product, string productSub, string package, string channelGroup, string startMonth);

        void Truncate();
    }
}