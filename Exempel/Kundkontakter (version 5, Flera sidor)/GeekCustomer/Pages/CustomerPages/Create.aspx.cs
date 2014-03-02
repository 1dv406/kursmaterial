using System;
using System.Web.UI;
using GeekCustomer.Model;

namespace GeekCustomer.Pages.CustomerPages
{
    public partial class Create : System.Web.UI.Page
    {
        public void CustomerFormView_InsertItem(Customer customer)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Service service = new Service();
                    service.SaveCustomer(customer);

                    // Spara (rätt)meddelande och dirigera om klienten till lista med kunder.
                    // (Meddelandet sparas i en "temporär" sessionsvariabel som kapslas 
                    // in av en "extension method" i App_Infrastructure/PageExtensions.)
                    // Del av designmönstret Post-Redirect-Get (PRG, http://en.wikipedia.org/wiki/Post/Redirect/Get).
                    Page.SetTempData("SuccessMessage", "Kunden lades till.");
                    Response.RedirectToRoute("CustomerDetails", new { id = customer.CustomerId } );
                    Context.ApplicationInstance.CompleteRequest();
                }
                catch (Exception)
                {
                    ModelState.AddModelError(String.Empty, "Fel inträffade då kunden skulle läggas till.");
                }
            }
        }
    }
}