using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GeekCustomer.Model;

namespace GeekCustomer.Pages.ContactPages
{
    public partial class Delete : System.Web.UI.Page
    {
        private Contact _contact;
        private Contact Contact
        {
            get { return _contact ?? (_contact = Service.GetContact(Id)); }
        }

        private Customer _customer;
        private Customer Customer
        {
            get { return _customer ?? (_customer = Service.GetCustomer(Contact.CustomerId)); }
        }

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
            CancelHyperLink.NavigateUrl = GetRouteUrl("CustomerDetails", new { id = Customer.CustomerId });

            if (!IsPostBack)
            {
                try
                {
                    if (Contact != null)
                    {
                        ContactValue.Text = Contact.Value;
                        CustomerName.Text = Customer.Name;
                        return;
                    }

                    // Hittade inte kunden.
                    ModelState.AddModelError(String.Empty,
                        String.Format("Kontaktuppgiften med nummer {0} hittades inte.", Id));
                }
                catch (Exception)
                {
                    ModelState.AddModelError(String.Empty, "Fel inträffade då kontaktuppgiften hämtades inför borttagning.");
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
                Service.DeleteContact(id);

                Page.SetTempData("SuccessMessage", "Kontaktuppgiften togs bort.");
                Response.RedirectToRoute("CustomerDetails", new { id = Customer.CustomerId });
                Context.ApplicationInstance.CompleteRequest();
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Fel inträffade då kontaktuppgiften skulle tas bort.");
            }
        }
    }
}