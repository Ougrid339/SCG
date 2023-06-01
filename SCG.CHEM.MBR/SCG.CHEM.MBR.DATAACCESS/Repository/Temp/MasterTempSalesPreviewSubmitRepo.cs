using Microsoft.EntityFrameworkCore;
using SCG.CHEM.MBR.DATAACCESS.Entities.Temp;
using SCG.CHEM.MBR.DATAACCESS.Repository.Temp.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SCG.CHEM.MBR.DATAACCESS.APPCONSTANT;

namespace SCG.CHEM.MBR.DATAACCESS.Repository.Temp
{
    internal class MasterTempSalesPreviewSubmitRepo : RepositoryBase<MBR_TMP_SALES_PREVIEW_SUBMIT>, IMasterTempSalesPreviewSubmitRepo
    {
        public MasterTempSalesPreviewSubmitRepo(EntitiesMBRContext context, EntitiesMBRReadContext readConext) : base(context, readConext)
        {
        }

        public MBR_TMP_SALES_PREVIEW_SUBMIT GetByPreviewOrSubmitRunId(string previewOrSubmitRunId, bool IsPreview)
        {
            return _context.MBR_TMP_SALES_PREVIEW_SUBMITs.FirstOrDefault(w => (IsPreview && w.PriviewRunId == previewOrSubmitRunId) || (!IsPreview&&w.SubmitRunId == previewOrSubmitRunId));
        }

        public MBR_TMP_SALES_PREVIEW_SUBMIT GetByPreviewOrSubmitRunIdNoTracking(string previewOrSubmitRunId, bool IsPreview)
        {
            return _context.MBR_TMP_SALES_PREVIEW_SUBMITs.AsNoTracking().FirstOrDefault(w => (IsPreview && w.PriviewRunId == previewOrSubmitRunId) || (!IsPreview && w.SubmitRunId == previewOrSubmitRunId));
        }

        public MBR_TMP_SALES_PREVIEW_SUBMIT GetByWebUUID(Guid webUUID)
        {
            return _context.MBR_TMP_SALES_PREVIEW_SUBMITs.FirstOrDefault(w => w.WebUUID == webUUID);
        }

        public async Task<MBR_TMP_SALES_PREVIEW_SUBMIT> GetByWebUUIDNoTrackingAsync(Guid webUUID)
        {
            return await _context.MBR_TMP_SALES_PREVIEW_SUBMITs.AsNoTracking().FirstOrDefaultAsync(w => w.WebUUID == webUUID);
        }
    }
}
