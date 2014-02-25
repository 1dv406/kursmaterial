 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;

namespace GeekCustomer
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapPageRoute("Customers", "kunder", "~/Pages/CustomerPages/Listing.aspx");
            routes.MapPageRoute("CustomersCreate", "kunder/ny", "~/Pages/CustomerPages/Create.aspx");
            //routes.MapPageRoute("CustomersEdit", "kunder/{id}", "~/Pages/CustomerPages/Edit.aspx");
            //routes.MapPageRoute("CustomersDelete", "kunder/{id}/radera", "~/Pages/CustomerPages/Delete.aspx");

            routes.MapPageRoute("Error", "serverfel", "~/Pages/Shared/Error.aspx");

            routes.MapPageRoute("Default", "", "~/Pages/CustomerPages/Listing.aspx");
        }
    }
}