using SCG.CHEM.MBR.DATAACCESS;
using SCG.CHEM.MBR.DATAACCESS.AppModels.Common;
using SCG.CHEM.MBR.DATAACCESS.Entities.Logging;
using SCG.CHEM.MBR.DATAACCESS.UnitOfWork;
using SCG.CHEM.MBR.COMMON.API.BusinessLogic.Logging.Interface;
using Newtonsoft.Json.Linq;
using SCG.CHEM.MBR.COMMON.Utilities;
using Newtonsoft.Json;

namespace SCG.CHEM.MBR.COMMON.API.BusinessLogic.Logging
{
    public sealed class LogService : ILogService
    {
        private readonly UnitOfWork _unit;

        public LogService(UnitOfWork unitOfWork)
        {
            this._unit = unitOfWork;
        }

        public long CreateLog(string servicePath, string inboundMessage)
        {
            long logId = 0;

            DateTime? inboundTime = DateTime.Now;
            DateTime? outboundTime = null;
            string outboundMessage = null;
            int? type = null;
            string planType = null;
            string cycle = null;
            string caseName = null;

            LOG_API data = new LOG_API(servicePath, inboundTime, outboundTime, inboundMessage, outboundMessage, type, planType, cycle, caseName);
            data.UpdateCriteria(GetCriteriaFromInboundMessage(inboundMessage));

            _unit.LogApiRepo.Add(data);
            _unit.SaveTransaction();

            logId = data.InterfaceId;

            return logId;
        }

        public long CreateLog(string servicePath, string inboundMessage, int? type, string planType, string cycle, string caseName)
        {
            long logId = 0;

            DateTime? inboundTime = DateTime.Now;
            DateTime? outboundTime = null;
            string outboundMessage = null;

            LOG_API data = new LOG_API(servicePath, inboundTime, outboundTime, inboundMessage, outboundMessage, type, planType, cycle, caseName);
            data.UpdateCriteria(GetCriteriaFromInboundMessage(inboundMessage));

            _unit.LogApiRepo.Add(data);
            _unit.SaveTransaction();

            logId = data.InterfaceId;

            return logId;
        }

        public LOG_API LogSuccess(long id, string message, string customMessage = null)
        {
            LOG_API result;

            int status = APPCONSTANT.RESPONSE_STATUS.OK;
            result = _unit.LogApiRepo.FindbyId(id);

            if (result != null)
            {
                result.UpdateStatusAndOutboundMessage(status, message, customMessage);
                result.UpdateValidationStatus(GetValidationStatus(customMessage));
                _unit.SaveTransaction();
            }

            return result;
        }

        public LOG_API LogSuccessPassValidate(long id, string message, string customMessage = null)
        {
            LOG_API result;

            int status = APPCONSTANT.RESPONSE_STATUS.OK;
            result = _unit.LogApiRepo.FindbyId(id);

            if (result != null)
            {
                result.UpdateStatusAndOutboundMessage(status, message, customMessage);
                result.UpdateValidationStatus(true);
                _unit.SaveTransaction();
            }

            return result;
        }

        public LOG_API LogError(long id, string message, string customMessage = null)
        {
            LOG_API result;

            int status = APPCONSTANT.RESPONSE_STATUS.BAD_REQUEST;
            result = _unit.LogApiRepo.FindbyId(id);

            if (result != null)
            {
                result.UpdateStatusAndErrorMessage(status, message, customMessage);
                _unit.SaveTransaction();
            }

            return result;
        }

        public bool? GetValidationStatus(string customMessage)
        {
            if (!String.IsNullOrEmpty(customMessage))
            {
                try
                {
                    var parsedMessage = JObject.Parse(customMessage).Property("Data");
                    if (parsedMessage != null)
                    {
                        bool isValidationSuccess = true;
                        foreach (var item in parsedMessage.Value)
                        {
                            var errorMsg = item["ErrorMsg"];
                            if (errorMsg != null)
                            {
                                var count = errorMsg.Count();
                                if (count > 0)
                                {
                                    isValidationSuccess = false;
                                    break;
                                }
                            }
                        }
                        return isValidationSuccess;
                    }
                    return null; // Cannot parse data from customMessage or there's no Data property
                }
                catch
                {
                    return null;
                }
            }
            return null;
        }

        public string? GetCriteriaFromInboundMessage(string inboundMessage)
        {
            // Criteria
            // e.g., PlanType, Cycle, Planning Group, Sales Group, Produt, Product Sub, etc.

            var parsedMessage = JsonUtil.StringToJsonObject(inboundMessage);
            if (parsedMessage == null)
            {
                return null;
            }

            try
            {
                return parsedMessage.Property("Criteria")?.Value.ToString(Formatting.None);
            }
            catch
            {
                return null;
            }
        }

        public long UpdateLog(long id, string servicePath, string inboundMessage)
        {
            long logId = 0;

            DateTime? inboundTime = DateTime.Now;
            DateTime? outboundTime = null;
            string outboundMessage = null;
            int? type = null;
            string planType = null;
            string cycle = null;
            string caseName = null;

            LOG_API data = _unit.LogApiRepo.FindbyId(id);
            data.UpdateLog(servicePath, inboundTime, outboundTime, inboundMessage, outboundMessage, type, planType, cycle, caseName);
            data.UpdateCriteria(GetCriteriaFromInboundMessage(inboundMessage));

            //_unit.LogApiRepo.Add(data);
            _unit.SaveTransaction();

            logId = data.InterfaceId;

            return logId;
        }

        public long UpdateLog(long id, string servicePath, string inboundMessage, int? type, string planType, string cycle, string caseName)
        {
            long logId = 0;

            DateTime? inboundTime = DateTime.Now;
            DateTime? outboundTime = null;
            string outboundMessage = null;

            LOG_API data = _unit.LogApiRepo.FindbyId(id);
            data.UpdateLog(servicePath, inboundTime, outboundTime, inboundMessage, outboundMessage, type, planType, cycle, caseName);
            data.UpdateCriteria(GetCriteriaFromInboundMessage(inboundMessage));

            _unit.SaveTransaction();

            logId = data.InterfaceId;

            return logId;
        }
    }
}