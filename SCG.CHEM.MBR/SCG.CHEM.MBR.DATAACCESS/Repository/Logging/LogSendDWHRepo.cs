using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SCG.CHEM.MBR.DATAACCESS;
using SCG.CHEM.MBR.DATAACCESS.AppModels.Common;
using SCG.CHEM.MBR.DATAACCESS.AppModels.Master;
using SCG.CHEM.MBR.DATAACCESS.Entities.Logging;
using SCG.CHEM.MBR.DATAACCESS.Repository.Logging.Interface;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.MBR.DATAACCESS.Repository.Logging
{
    public class LogSendDWHRepo : RepositoryBase<LOG_SEND_DWH>, ILogSendDWHRepo
    {
        #region Inject

        public LogSendDWHRepo(EntitiesMBRContext context, EntitiesMBRReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        public LOG_SEND_DWH FindbyId(long id)
        {
            var result = _context.LOG_SEND_DWHs.Where(w => w.InterfaceId == id).FirstOrDefault();
            return result;
        }
    }
}