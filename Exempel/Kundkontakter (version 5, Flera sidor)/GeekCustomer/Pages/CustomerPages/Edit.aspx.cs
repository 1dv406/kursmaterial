using System;
using System.Web.ModelBinding;
using System.Web.UI;
using GeekCustomer.Model;

namespace GeekCustomer.Pages.CustomerPages
{
    public partial class Edit : System.Web.UI.Page
    {
        private Service _service;

        private Service Service
        {
            // Ett Service-objekt skapas först då det behövs för första 
            // gången (lazy initialization, http://en.wikipedia.org/wiki/Lazy_initialization).
            get { return _service ?? (_service = new Service()); }
        }

        // The id parameter should match the DataKeyNames value set on the control
        // or be decorated with a value provider attribute, e.g. [QueryString]int id
        public GeekCustomer.Model.Customer CustomerFormView_GetItem([RouteData]int id)
        {
            try
            {
                return Service.GetCustomer(id);
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Fel inträffade då kunden hämtades vid redigering.");
                return null;
            }
        }

        /// <summary>
        /// Uppdaterar en kunds kunduppgifter i databasen.
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
                    ModelState.AddModelError(String.Empty,
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
                ModelState.AddModelError(String.Empty, "Fel inträffade då kunden skulle uppdateras.");
            }
        }
    }
}