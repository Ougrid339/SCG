using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SCG.CHEM.SSPLSP.DATAACCESS.AppModels.Common;
using SCG.CHEM.SSPLSP.DATAACCESS.AppModels.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Logging;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Logging.Interface;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Logging
{
    public class LogSendDWHRepo : RepositoryBase<LOG_SEND_DWH>, ILogSendDWHRepo
    {
        #region Inject

        public LogSendDWHRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
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