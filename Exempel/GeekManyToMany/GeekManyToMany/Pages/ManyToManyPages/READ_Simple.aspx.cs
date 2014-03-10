using System;
using System.Linq;
using GeekManyToMany.Model;

namespace GeekManyToMany.Pages.ManyToManyPages
{
    public partial class READ_Simple : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var service = new Service();

            // Hämta kurstillfälle.
            var courseDate = service.GetCourseDate(1);

            // Hämta alla deltagare, slå upp varje ensklid student och transformera till fullständigt namn.
            var participants =  from participant in service.GetParticipantsOfCourseDate(courseDate.Id)
                                let student = service.GetStudent(participant.StudentId)
                                select String.Format("{0} {1}", student.FirstName, student.LastName);

            // Populera kontroller.
            CourseDateNameLiteral.Text = courseDate.Name;
            ParticipantLiteral.Text = String.Join(", ", participants);
        }
    }
}