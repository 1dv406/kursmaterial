using System;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls;

namespace VowelCount
{
    public partial class Default : System.Web.UI.Page
    {
        /// <summary>
        /// Egenskapen använder sig av en sessionsvariabel för att
        /// lagra det seanste antalet vokaler mellan "postbacks".
        /// </summary>
        private int? PrevCount
        {
            get { return Session["prevCount"] as int?; }
            set { Session["prevCount"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Bestämmer antalet vokaler i en TextBox-kontroll samt beräknar
        /// skillnaden mellan antalet vokaler jämfört med föregående postning.
        /// </summary>
        protected void SendButton_Click(object sender, EventArgs e)
        {
            // Räkna antalet vokaler...
            var regex = new Regex("(a|e|i|o|u|y|å|ä|ö)", RegexOptions.IgnoreCase);
            var count = regex.Matches(InputTextBox.Text).Count;

            // ...och presentera resulatet.
            CountLiteral.Text = String.Format(CountLiteral.Text, count);
            ResultPlaceHolder.Visible = true;

            // Om föregående antal vokaler finns tillgängligt...
            // (egenskapen PrevCount kapslar in hanteringen av sessionsvariabeln)
            if (PrevCount.HasValue)
            {
                // ...bestäm skillnaden och...
                var diffCount = count - PrevCount.Value;

                // ...fastställ om det är fler, färre eller lika många.
                if (diffCount > 0)
                {
                    DifferenceLiteral.Text = String.Format(DifferenceLiteral.Text, diffCount, " fler");
                }
                else if (diffCount < 0)
                {
                    DifferenceLiteral.Text = String.Format(DifferenceLiteral.Text, -diffCount, " färre");
                }
                else
                {
                    DifferenceLiteral.Text = String.Format(DifferenceLiteral.Text, String.Empty, "lika många");
                }

                DifferenceLiteral.Visible = true;
            }

            // Spara aktuellt antal vokaler.
            PrevCount = count;
        }
    }
}