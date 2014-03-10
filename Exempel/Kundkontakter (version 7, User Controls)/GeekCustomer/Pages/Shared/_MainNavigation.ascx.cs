using System;
using System.Web.Routing;
using System.Web.UI;

namespace GeekCustomer.Pages.Shared
{
    public partial class _MainNavigation : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // TODO: Fixa så att det fungerar med "routes".

            // Ser till att en navigeringstabb aktiveras om sidan den är 
            // assoccierad med är den aktuella sidan.
            if (String.Compare(HomeHyperLink.NavigateUrl, Page.AppRelativeVirtualPath,
                StringComparison.CurrentCultureIgnoreCase) == 0)
            {
                HomeLi.Attributes["class"] = "selected";
            }
            else if (String.Compare(CreateHyperLink.NavigateUrl, Page.AppRelativeVirtualPath,
                StringComparison.CurrentCultureIgnoreCase) == 0)
            {
                CreateLi.Attributes["class"] = "selected";
            }
        }
    }
}