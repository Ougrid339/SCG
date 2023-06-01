using SCG.CHEM.MBR.DATAACCESS.Entities.Temp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.MBR.DATAACCESS.Repository.Temp.Interface
{
    public interface IMasterTempSalesPreviewSubmitRepo : IRepositoryBase<MBR_TMP_SALES_PREVIEW_SUBMIT>
    {
        MBR_TMP_SALES_PREVIEW_SUBMIT GetByWebUUID(Guid webUUID);

        Task<MBR_TMP_SALES_PREVIEW_SUBMIT> GetByWebUUIDNoTrackingAsync(Guid webUUID);

        MBR_TMP_SALES_PREVIEW_SUBMIT GetByPreviewOrSubmitRunId(string previewOrSubmitRunId, bool isPreview);

        MBR_TMP_SALES_PREVIEW_SUBMIT GetByPreviewOrSubmitRunIdNoTracking(string previewOrSubmitRunId, bool IsPreview);

    }
}
