using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;
using GeekManyToMany.Model;

namespace GeekManyToMany.Pages.ManyToManyPages
{
    public partial class DELETE_FormViewWithNestedListView : System.Web.UI.Page
    {
        private Service _service;
        public Service Service
        {
            get { return _service ?? (_service = new Service()); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // The id parameter should match the DataKeyNames value set on the control
        // or be decorated with a value provider attribute, e.g. [QueryString]int id
        public CourseDate CourseDateFormView_GetItem([RouteData]int id)
        {
            return Service.GetCourseDate(id);
        }

        public IEnumerable<Participant> ParticipantListView_GetData()
        {
            var courseDateId = ((CourseDate)(CourseDateFormView.DataItem)).Id;
            return Service.GetParticipantsOfCourseDate(courseDateId);
        }

        protected void ParticipantListView_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            var participant = e.Item.DataItem as Participant;
            if (participant != null)
            {
                var student = Service.GetStudent(participant.StudentId);
                var literal = e.Item.FindControl("NameLiteral") as Literal;
                literal.Text = String.Format("{0}, {1}", student.LastName, student.FirstName);
            }
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void ParticipantListView_DeleteItem(int id)
        {
            Service.DeleteParticipant(id);
        }

        public IEnumerable<Student> StudentDropDownList_GetData()
        {
            var courseDateId = ((CourseDate)(CourseDateFormView.DataItem)).Id;
            var participatingStudents = Service.GetParticipantsOfCourseDate(courseDateId).Select(p => Service.GetStudent(p.StudentId));

            return Service.GetStudents().Except(participatingStudents);
        }
    }
}