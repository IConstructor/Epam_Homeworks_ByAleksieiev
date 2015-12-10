using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using log4net;

namespace Epam_MVCTask1_ByAleksieiev_WEB
{
    public class PerformanceLogger : ActionFilterAttribute
    {
        readonly Stopwatch _timer = new Stopwatch();
        public override void OnActionExecuting(HttpActionContext filterContext)
        {
            _timer.Reset();
            _timer.Start();
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            _timer.Stop();
            ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            log.InfoFormat("Action method {0} has taken {1} milliseconds", actionExecutedContext.ActionContext.Request.RequestUri.ToString(), _timer.ElapsedMilliseconds);
        }
    }
}
