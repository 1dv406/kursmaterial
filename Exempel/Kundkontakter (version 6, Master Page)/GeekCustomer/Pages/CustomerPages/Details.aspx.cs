using System;
using System.Web.ModelBinding;
using System.Web.UI;
using GeekCustomer.Model;

namespace GeekCustomer.Pages.CustomerPages
{
    public partial class Details : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Hämta och visa (rätt)meddelande, om det finns något meddelande. (Meddelandet hämtas 
            // från en "temporär" sessionsvariabel som kapslas in av en "extension method" 
            // i App_Infrastructure/PageExtensions.)
            // Del av designmönstret Post-Redirect-Get (PRG, http://en.wikipedia.org/wiki/Post/Redirect/Get).
            SuccessMessageLiteral.Text = Page.GetTempData("SuccessMessage") as string;
            SuccessMessagePanel.Visible = !String.IsNullOrWhiteSpace(SuccessMessageLiteral.Text);
        }

        public Customer CustomerFormView_GetItem([RouteData] int id)
        {
            try
            {
                Service service = new Service();
                return service.GetCustomer(id);
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Fel inträffade då kunden hämtades.");
                return null;
            }
        }
    }
}