using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Epam_homeworkDI_ByAleksieiev_WEB_UI_.Startup))]
namespace Epam_homeworkDI_ByAleksieiev_WEB_UI_
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
