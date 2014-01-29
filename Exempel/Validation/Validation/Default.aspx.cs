using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Validation
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SendButton_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                // Gör något med formulärdatat.
                ViewMessage();
            }
        }

        protected void SendWithoutValidationButton_Click(object sender, EventArgs e)
        {
            // OBS! DETTA ÄR HÖGST OLÄMPLIGT!

            // Gör något med OVALIDERAT formulärdata.
            ViewMessage();
        }

        protected void SendServerValidationButton_Click(object sender, EventArgs e)
        {
            Validate();
            if (IsValid)
            {
                try
                {
                    // Gör något med formulärdatat.

                    // Simulera misslyckad hantering av formulärdatat.
                    throw new NotImplementedException();

                    ViewMessage(); // Kommer inte att anropas pga throw-satsen!
                }
                catch (Exception)
                {
                    // ASP.NET 4.5
                    ModelState.AddModelError(String.Empty, "Ett fel inträffade då e-postaddressen skulle hanteras.");

                    // "OLD SCHOOL": Skapar ett eget felmeddelande programmatiskt och använder
                    // ValidationSummary för att visa det.
                    //var validator = new CustomValidator
                    //{
                    //    IsValid = false,
                    //    ErrorMessage = "Ett fel inträffade då e-postaddressen skulle hanteras."
                    //};
                    //Page.Validators.Add(validator);
                }
            }
        }

        private void ViewMessage()
        {
            MessageLiteral.Text = String.Format(MessageLiteral.Text, EmailTextBox.Text);
            MessagePlaceHolder.Visible = true;
        }
    }
}