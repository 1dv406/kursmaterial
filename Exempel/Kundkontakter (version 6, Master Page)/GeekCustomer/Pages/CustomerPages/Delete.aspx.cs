using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GeekCustomer.Model;

namespace GeekCustomer.Pages.CustomerPages
{
    public partial class Delete : System.Web.UI.Page
    {
        private Service _service;

        private Service Service
        {
            // Ett Service-objekt skapas först då det behövs för första 
            // gången (lazy initialization, http://en.wikipedia.org/wiki/Lazy_initialization).
            get { return _service ?? (_service = new Service()); }
        }

        protected int Id
        {
            get { return int.Parse(RouteData.Values["id"].ToString()); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            CancelHyperLink.NavigateUrl = GetRouteUrl("CustomerDetails", new { id = Id });

            if (!IsPostBack)
            {
                try
                {
                    var customer = Service.GetCustomer(Id);
                    if (customer != null)
                    {
                        CustomerName.Text = customer.Name;
                        return;
                    }

                    // Hittade inte kunden.
                    ModelState.AddModelError(String.Empty,
                        String.Format("Kunden med kundnummer {0} hittades inte.", Id));
                }
                catch (Exception)
                {
                    ModelState.AddModelError(String.Empty, "Fel inträffade då kunden hämtades inför borttagning.");
                }

                ConfirmationPlaceHolder.Visible = false;
                DeleteLinkButton.Visible = false;
            }
        }

        protected void DeleteLinkButton_Command(object sender, CommandEventArgs e)
        {
            try
            {
                var id = int.Parse(e.CommandArgument.ToString());
                Service.DeleteCustomer(id);

                Page.SetTempData("SuccessMessage", "Kunden togs bort.");
                Response.RedirectToRoute("Customers", null);
                Context.ApplicationInstance.CompleteRequest();
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Fel inträffade då kunden skulle tas bort.");
            }
        }
    }
}