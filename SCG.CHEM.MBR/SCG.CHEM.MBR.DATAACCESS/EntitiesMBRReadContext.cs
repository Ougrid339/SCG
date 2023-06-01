using Microsoft.EntityFrameworkCore;
using SCG.CHEM.MBR.COMMON;
using SCG.CHEM.MBR.DATAACCESS;
using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Relate;
using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Template;
using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Transaction;
using SCG.CHEM.SSPLSP.DATAACCESS.Entities.View.Account;
using SCG.CHEM.SSPLSP.DATAACCESS.Entities.View.Export;
using SCG.CHEM.SSPLSP.DATAACCESS.Entities.View.Template;
using SCG.CHEM.SSPLSP.DATAACCESS.Entities.View.Transaction;

namespace SCG.CHEM.MBR.DATAACCESS
{
    public class EntitiesMBRReadContext : EntitiesMBRContext
    {
        public EntitiesMBRReadContext(DbContextOptions<EntitiesMBRReadContext> options, AppSettings appSettings) : base(options, appSettings)
        {
            _AppSettings = appSettings;
        }
    }
}