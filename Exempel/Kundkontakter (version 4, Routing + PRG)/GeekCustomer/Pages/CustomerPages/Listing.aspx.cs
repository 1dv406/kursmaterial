using System;
using System.Collections.Generic;
using System.Web.UI;
using GeekCustomer.Model;

namespace GeekCustomer.Pages.CustomerPages
{
    public partial class Listing : System.Web.UI.Page
    {
        private Service _service;

        private Service Service
        {
            // Ett Service-objekt skapas först då det behövs för första 
            // gången (lazy initialization, http://en.wikipedia.org/wiki/Lazy_initialization).
            get { return _service ?? (_service = new Service()); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            // Hämta och visa (rätt)meddelande, om det finns något meddelande. (Meddelandet hämtas 
            // från en "temporär" sessionsvariabel som kapslas in av en "extension method" 
            // i App_Infrastructure/PageExtensions.)
            // Del av designmönstret Post-Redirect-Get (PRG, http://en.wikipedia.org/wiki/Post/Redirect/Get).
            MessageLiteral.Text = Page.GetTempData("Message") as string;
            MessagePanel.Visible = !String.IsNullOrWhiteSpace(MessageLiteral.Text);
        }

        /// <summary>
        /// Hämtar alla kunder som finns lagrade i databasen.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Customer> CustomerListView_GetData()
        {
            try
            {
                return Service.GetCustomers();
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Ett oväntat fel inträffade då kunduppgifter skulle hämtas.");
                return null;
            }
        }

        /// <summary>
        /// Lägger till en kunds kunduppgifter i databasen.
        /// </summary>
        /// <param name="customer"></param>
        public void CustomerListView_InsertItem(Customer customer)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Service.SaveCustomer(customer);
                }
                catch (Exception)
                {
                    ModelState.AddModelError(String.Empty, "Ett oväntat fel inträffade då kunduppgiften skulle läggas till.");
                }
            }
        }

        /// <summary>
        /// Uppdaterar en kunds kunduppgifter i databasen.
        /// </summary>
        /// <param name="customerId"></param>
        public void CustomerListView_UpdateItem(int customerId) // Parameterns namn måste överrensstämma med värdet DataKeyNames har.
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
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Ett oväntat fel inträffade då kunduppgiften skulle uppdateras.");
            }
        }

        /// <summary>
        /// Tar bort specifierad kund ur databasen.
        /// </summary>
        /// <param name="customerId"></param>
        public void CustomerListView_DeleteItem(int customerId) // Parameterns namn måste överrensstämma med värdet DataKeyNames har.
        {
            try
            {
                Service.DeleteCustomer(customerId);
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Ett oväntat fel inträffade då kunduppgiften skulle tas bort.");
            }
        }
    }
}