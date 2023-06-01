using Microsoft.EntityFrameworkCore;
using SCG.CHEM.MBR.COMMON.Constants;
using SCG.CHEM.MBR.COMMON.Utilities;
using SCG.CHEM.MBR.DATAACCESS.Entities.Master;
using SCG.CHEM.MBR.DATAACCESS.Repository.Master.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SCG.CHEM.MBR.DATAACCESS.Repository.Master
{
    public class MasterConfigRepo : RepositoryBase<MST_CONFIG>, IMasterConfigRepo
    {
        #region Inject

        public MasterConfigRepo(EntitiesMBRContext context, EntitiesMBRReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        ///----------------------- MAINTAIN --------------------------

        public MST_CONFIG FindById(string id)
        {
            return _context.MST_CONFIGs.Where(x => x.ConfigId == id).FirstOrDefault();
        }

        ///----------------------- READER --------------------------
        private string ReadValue(MST_CONFIG c)
        {
            var cValue = c.ConfigValue;
            if (c.FlagDecrypt)
            {
                cValue = EncryptionUtil.DecryptData(cValue);
            }
            return cValue;
        }

        public Dictionary<AppConstant.CONFIG, string> ReadConfigs(params AppConstant.CONFIG[] key)
        {
            var keyStr = key.Select(x => x.ToString()).ToList();
            var result = new Dictionary<AppConstant.CONFIG, string>();
            var mConfigs = _readContext.MST_CONFIGs.Where(x => keyStr.Contains(x.ConfigId)).ToList();
            foreach (var c in mConfigs)
            {
                result.Add(Enum.Parse<AppConstant.CONFIG>(c.ConfigId), ReadValue(c));
            }
            return result;
        }
    }
}