using System;
using TemperatureDifference.Model;

namespace TemperatureDifference
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SendButton_Click(object sender, EventArgs e)
        {
            // Om formulärdatat klarar valideringen...
            if (IsValid)
            {
                // ...instansiera ett objekt av typen TemperaturCalculator, 
                // tolka texten i textfälten till heltal,...
                var temp = new TemperatureCalculator
                {
                    Min = int.Parse(Min.Text),
                    Max = int.Parse(Max.Text)
                };

                // ...ta reda på och presentera temperaturskillnaden, och...
                OutputLiteral.Text = String.Format(OutputLiteral.Text, temp.Difference);

                // ...se till att resultatet renderas till klienten.
                OuputPlaceHolder.Visible = true;
            }
        }
    }
}