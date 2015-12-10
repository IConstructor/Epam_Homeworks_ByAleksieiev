using System.Web;
using System.Web.Mvc;

namespace Epam_MVCTask1_ByAleksieiev_WEB
{
    public class FilterConfig
    {
        public static void RegisterWebApiFilters(System.Web.Http.Filters.HttpFilterCollection filters)
        {
            filters.Add(new IpLogger());
        }
    }
}
