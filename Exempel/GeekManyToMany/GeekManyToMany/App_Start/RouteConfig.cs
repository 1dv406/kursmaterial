using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Routing;
using Microsoft.AspNet.FriendlyUrls;

namespace GeekManyToMany
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapPageRoute("CourseDateDetails", "kurstillfalle/{id}", "~/Pages/ManyToManyPages/READ_FormViewWithNestedListView.aspx");
            //routes.MapPageRoute("CourseDateDetails2", "kurstillfalle/enkelt", "~/Pages/ManyToManyPages/READ_Simple.aspx");

            routes.MapPageRoute("Default",  "",        "~/Pages/Start/Default.aspx");
            routes.MapPageRoute("About",    "om",      "~/Pages/Start/About.aspx");
            routes.MapPageRoute("Contact",  "kontakt", "~/Pages/Start/Contact.aspx");

            routes.EnableFriendlyUrls();
        }
    }
}
