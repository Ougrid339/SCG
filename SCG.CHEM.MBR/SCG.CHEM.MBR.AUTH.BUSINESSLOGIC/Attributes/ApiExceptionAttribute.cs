using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NLog;
using SCG.CHEM.MBR.AUTH.BUSINESSLOGIC.Authentication;
using SCG.CHEM.MBR.COMMON.AppException;
using SCG.CHEM.MBR.COMMON.Utilities;
using SCG.CHEM.MBR.DATAACCESS.AppModels.Common;
using System;
using System.Net;

namespace SCG.CHEM.MBR.AUTH.BUSINESSLOGIC.Attributes
{
    public class ApiExceptionAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext actionExecutedContext)
        {
            var _logger = NLog.LogManager.GetCurrentClassLogger();
            var controllerName = actionExecutedContext.RouteData.Values["controller"]?.ToString();
            var actionName = actionExecutedContext.RouteData.Values["action"]?.ToString();
            actionExecutedContext.HttpContext.Response.ContentType = "application/json";
            if (actionExecutedContext.Exception != null)
            {
                var exception = actionExecutedContext.Exception;
                var msg = actionExecutedContext.Exception.GetMessageErrorAll("<br>- ");
                var logType = NLog.LogLevel.Error;

                if (actionExecutedContext.Exception.GetType() == typeof(UnauthorizedAccessException))
                {
                    actionExecutedContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    actionExecutedContext.Result = new JsonResult(msg);
                    logType = NLog.LogLevel.Warn;
                }
                else if (actionExecutedContext.Exception.GetType() == typeof(UnauthorizedActionException))
                {
                    msg = $"Cannot access {actionName} : {msg}";
                    actionExecutedContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotAcceptable;
                    actionExecutedContext.Result = new JsonResult(msg);
                    logType = NLog.LogLevel.Warn;
                }
                else if (actionExecutedContext.Exception.GetType() == typeof(BusinessWarning))
                {
                    actionExecutedContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.PreconditionRequired;
                    actionExecutedContext.Result = new JsonResult(msg);
                    logType = NLog.LogLevel.Warn;
                }
                else if (actionExecutedContext.Exception.GetType() == typeof(BusinessException))
                {
                    actionExecutedContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    actionExecutedContext.Result = new BadRequestObjectResult(msg);
                    logType = NLog.LogLevel.Warn;
                }
                else
                {
                    actionExecutedContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    msg = $"Function Error : <br> {msg}";
                    actionExecutedContext.Result = new JsonResult(CommonResultModel<List<string>>.Fail(exception.Message, exception.StackTrace));
                }

                #region logger

                var httpActionType = actionExecutedContext.HttpContext.Request.Method;
                var queryString = actionExecutedContext.HttpContext.Request.QueryString.ToString();

                var currentUser = actionExecutedContext.HttpContext.GetAppLoggedInAccount();
                var currentUserId = currentUser?.UserId ?? "";

                var statusCode = actionExecutedContext.HttpContext.Response.StatusCode;
                var firstMsg = actionExecutedContext.Exception.Message;

                var logMsg = $"[{httpActionType}] /{controllerName}/{actionName}{queryString} - [{statusCode}][{currentUserId}] - {firstMsg ?? ""}";

                _logger.Log(logType, exception, logMsg);

                #endregion

                base.OnException(actionExecutedContext);
            }
        }
    }
}
