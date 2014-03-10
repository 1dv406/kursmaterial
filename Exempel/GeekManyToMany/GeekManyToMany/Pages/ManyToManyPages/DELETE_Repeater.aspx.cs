using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GeekManyToMany.Model;

namespace GeekManyToMany.Pages.ManyToManyPages
{
    public partial class DELETE_Repeater : Page
    {
        private Service _service;
        public Service Service
        {
            get { return _service ?? (_service = new Service()); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            // Hämta kurstillfälle.
            var courseDate = Service.GetCourseDate(1);

            // Hämta alla deltagare, slå upp varje ensklid student och transformera till fullständigt namn.
            var participants = from participant in Service.GetParticipantsOfCourseDate(courseDate.Id)
                               let student = Service.GetStudent(participant.StudentId)
                               select new { ParticipantId = participant.Id, Name = String.Format("{0}, {1}", student.LastName, student.FirstName) };

            ParticipantRepeater.DataSource = participants;
            DataBind();
        }

        protected void ParticipantRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                var participantId = int.Parse((string)e.CommandArgument);
                Service.DeleteParticipant(participantId);
                Response.Redirect(Request.RawUrl);
            }
        }
    }
}