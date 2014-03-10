using System;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;
using GeekCustomer.Model;

namespace GeekCustomer.Pages.Shared
{
    public partial class _CustomerCreateReadUpdate : System.Web.UI.UserControl
    {
        /// <summary>
        /// 
        /// </summary>
        private Service _service;

        /// <summary>
        /// 
        /// </summary>
        private Service Service
        {
            // Ett Service-objekt skapas först då det behövs för första 
            // gången (lazy initialization, http://en.wikipedia.org/wiki/Lazy_initialization).
            get { return _service ?? (_service = new Service()); }
        }

        /// <summary>
        /// 
        /// </summary>
        public FormViewMode ViewMode
        {
            get { return CustomerFormView.DefaultMode; }
            set { CustomerFormView.DefaultMode = value; }
        }

        /// <summary>
        /// Ser till att samma mall används för redigering av befintliga kunder som för nya.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void CustomerFormView_Init(object sender, EventArgs e)
        {
            if (CustomerFormView.CurrentMode == FormViewMode.Edit)
            {
                CustomerFormView.EditItemTemplate = CustomerFormView.InsertItemTemplate;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void CustomerFormView_DataBound(object sender, EventArgs e)
        {
            if (CustomerFormView.CurrentMode == FormViewMode.Edit)
            {
                var saveLinkButton = (LinkButton)CustomerFormView.FindControl("SaveLinkButton");
                saveLinkButton.CommandName = "Update";

                var cancelHyperLink = (HyperLink)CustomerFormView.FindControl("CancelHyperLink");
                var customer = (Customer)CustomerFormView.DataItem;
                cancelHyperLink.NavigateUrl = GetRouteUrl("CustomerDetails", new { id = customer.CustomerId });
            }
        }

        /// <summary>
        /// Hämtar kund med angivet id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // The id parameter should match the DataKeyNames value set on the control
        // or be decorated with a value provider attribute, e.g. [QueryString]int id
        public Customer CustomerFormView_GetItem([RouteData]int id)
        {
            try
            {
                return Service.GetCustomer(id);
            }
            catch (Exception)
            {
                Page.ModelState.AddModelError(String.Empty, "Fel inträffade då kunden hämtades vid redigering.");
                return null;
            }
        }

        /// <summary>
        /// Lägger till en ny kund.
        /// </summary>
        /// <param name="customer"></param>
        public void CustomerFormView_InsertItem(Customer customer)
        {
            if (Page.ModelState.IsValid)
            {
                try
                {
                    Service.SaveCustomer(customer);

                    // Spara (rätt)meddelande och dirigera om klienten till lista med kunder.
                    // (Meddelandet sparas i en "temporär" sessionsvariabel som kapslas 
                    // in av en "extension method" i App_Infrastructure/PageExtensions.)
                    // Del av designmönstret Post-Redirect-Get (PRG, http://en.wikipedia.org/wiki/Post/Redirect/Get).
                    Page.SetTempData("SuccessMessage", "Kunden lades till.");
                    Response.RedirectToRoute("CustomerDetails", new { id = customer.CustomerId });
                    Context.ApplicationInstance.CompleteRequest();
                }
                catch (Exception)
                {
                    Page.ModelState.AddModelError(String.Empty, "Fel inträffade då kunden skulle läggas till.");
                }
            }
        }

        /// <summary>
        /// Uppdaterar kund.
        /// </summary>
        /// <param name="customerId"></param>
        public void CustomerFormView_UpdateItem(int customerId) // Parameterns namn måste överrensstämma med värdet DataKeyNames har.
        {
            try
            {
                var customer = Service.GetCustomer(customerId);
                if (customer == null)
                {
                    // Hittade inte kunden.
                    Page.ModelState.AddModelError(String.Empty,
                        String.Format("Kunden med kundnummer {0} hittades inte.", customerId));
                    return;
                }

                if (TryUpdateModel(customer))
                {
                    Service.SaveCustomer(customer);

                    Page.SetTempData("SuccessMessage", "Kunden uppdaterades.");
                    Response.RedirectToRoute("CustomerDetails", new { id = customer.CustomerId });
                    Context.ApplicationInstance.CompleteRequest();
                }
            }
            catch (Exception)
            {
                Page.ModelState.AddModelError(String.Empty, "Fel inträffade då kunden skulle uppdateras.");
            }
        }
    }
}