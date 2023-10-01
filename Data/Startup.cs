using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

[assembly: OwinStartup(typeof(CoursesManagementSystem.Data.Startup))]

namespace CoursesManagementSystem.Data
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var CookieAuthOptions = new CookieAuthenticationOptions();
            CookieAuthOptions.AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie;
            CookieAuthOptions.LoginPath = new PathString("/account/login");
            app.UseCookieAuthentication(CookieAuthOptions);
        }
    }
}