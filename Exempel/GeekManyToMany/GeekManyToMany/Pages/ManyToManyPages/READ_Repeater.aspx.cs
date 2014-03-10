using System;
using System.Linq;
using System.Web.UI.WebControls;
using GeekManyToMany.Model;

namespace GeekManyToMany.Pages.ManyToManyPages
{
    public partial class READ_Repeater : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var service = new Service();

            // Hämta kurstillfälle.
            var courseDate = service.GetCourseDate(1);

            // Hämta alla deltagare, slå upp varje ensklid student och transformera till fullständigt namn.
            var participants = from participant in service.GetParticipantsOfCourseDate(courseDate.Id)
                               let student = service.GetStudent(participant.StudentId)
                               select new { Name = String.Format("{0}, {1}", student.LastName, student.FirstName) };

            ParticipantRepeater.DataSource = participants;
            DataBind();
        }
    }
}