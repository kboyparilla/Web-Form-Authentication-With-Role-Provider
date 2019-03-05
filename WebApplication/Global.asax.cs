using Microsoft.AspNet.FriendlyUrls;
using System;
using System.Web.Routing;

namespace WebApplication
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            RegisterRoutes(RouteTable.Routes);
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            var settings = new FriendlyUrlSettings();
            settings.AutoRedirectMode = RedirectMode.Permanent;
            //settings.AutoRedirectMode = RedirectMode.Off;
            routes.EnableFriendlyUrls(settings);

            routes.RouteExistingFiles = false;
            routes.Ignore("{resource}.axd/{*pathInfo}");
            routes.Ignore("assets/contents/{*pathInfo}");

            routes.MapPageRoute("public_index", "login", "~/Public/Login.aspx");

            routes.MapPageRoute("public_registration", "registration", "~/Public/registration.aspx");
            routes.MapPageRoute("public_registration_id", "registration/{id}", "~/Public/registration.aspx");

            routes.MapPageRoute("private", "", "~/Private/Default.aspx");
            routes.MapPageRoute("private_profile", "profile", "~/Private/Profile.aspx");
        }
    }
}