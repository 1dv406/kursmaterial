using System;

namespace NextBirthday
{
    public partial class Default : System.Web.UI.Page
    {
        /// <summary>
        /// Bestämmer antalet dagar till nästa födelsedag, samt vilken
        /// veckodag den infaller. Ålder som uppnås i och med nästa 
        /// födelsedag bestäms också.
        /// </summary>
        protected void SendButton_Click(object sender, EventArgs e)
        {
            var birthdate = DateTime.Parse(Birthdate.Text);
            var nextBirthday = new DateTime(DateTime.Today.Year, birthdate.Month, birthdate.Day);
            if (nextBirthday < DateTime.Today)
            {
                nextBirthday = nextBirthday.AddYears(1);
            }

            DayOfWeekLabel.Text = nextBirthday.ToString("dddd");
            DaysUntilBirthdayLabel.Text = (nextBirthday - DateTime.Today).Days.ToString();
            AgeOnLabel.Text = (nextBirthday.Year - birthdate.Year).ToString();
            OutputPlaceHolder.Visible = true;
        }
    }
}