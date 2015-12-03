using System.Web;
using System.Web.Mvc;

namespace Epam_homeworkDI_ByAleksieiev_WEB_UI_
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
