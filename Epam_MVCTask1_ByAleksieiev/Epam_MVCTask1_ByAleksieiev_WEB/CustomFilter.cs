using log4net;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;



namespace Epam_MVCTask1_ByAleksieiev_WEB
{
    public class IpLogger : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext filterContext)
        {
            string ip = ((HttpContextBase)filterContext.Request.Properties["MS_HttpContext"]).Request.UserHostAddress;
            ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            Log.InfoFormat("Client ip is {0}", ip);
        }
      
    }
}
