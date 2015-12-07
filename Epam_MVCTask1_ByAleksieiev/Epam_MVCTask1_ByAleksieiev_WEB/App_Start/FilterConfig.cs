using System.Web;
using System.Web.Mvc;

namespace Epam_MVCTask1_ByAleksieiev_WEB
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
