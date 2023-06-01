using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SCG.CHEM.MBR.DATAACCESS.Entities.Logging;
using SCG.CHEM.MBR.TRANSACTION.API.BusinessLogic.Services;

namespace SCG.CHEM.MBR.TRANSACTION.API.BusinessLogic.Logging.Interface
{
    public interface ILogService : IBaseService
    {
        long CreateLog(string servicePath, string inboundMessage);

        long CreateLog(string servicePath, string inboundMessage, int? type, string planType, string cycle, string caseName);

        long CreateLogMove(string servicePath, string inboundMessage);

        long CreateLogMove(string servicePath, string inboundMessage, int? type, string planType, string cycle, string caseName);

        LOG_API LogSuccess(long id, string message, string customMessage = null);

        LOG_API LogSuccessPassValidate(long id, string message, string customMessage = null);

        LOG_API LogError(long id, string message, string customMessage = null);

        long UpdateLog(long id, string servicePath, string inboundMessage);

        long UpdateLog(long id, string servicePath, string inboundMessage, int? type, string planType, string cycle, string caseName);

        long UpdateLogMove(long id, string servicePath);

        void UpdateLogMoveOnError(long id, string errorMessage);

    }
}