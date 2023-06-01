using NLog;
using NLog.Config;
using NLog.LayoutRenderers;
using NLog.Web.LayoutRenderers;
using SCG.CHEM.MBR.COMMON.Utilities;
using System.Text;

namespace SCG.CHEM.MBR.AUTH.API.Logger
{
    /// <summary>
    /// Current date and time.
    /// </summary>
    [LayoutRenderer("localdate")]
    [ThreadAgnostic]
    public class LocalDateLayoutRenderer : AspNetLayoutRendererBase
    {
        protected override void DoAppend(StringBuilder builder, LogEventInfo logEvent)
        {
            var ts = logEvent.TimeStamp.GetLocalDate();
            builder.Append(ts.ToString("yyyy-MM-dd HH:mm:ss.ffffZ"));
        }
    }
}
