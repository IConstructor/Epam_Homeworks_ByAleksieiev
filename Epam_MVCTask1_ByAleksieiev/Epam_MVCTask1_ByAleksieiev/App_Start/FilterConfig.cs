using System.Web;
using System.Web.Mvc;

namespace Epam_MVCTask1_ByAleksieiev
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
