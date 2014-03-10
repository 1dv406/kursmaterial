using System;
using System.Collections.Generic;
using System.Web.ModelBinding;
using System.Web.UI.WebControls;
using GeekManyToMany.Model;

namespace GeekManyToMany.Pages.ManyToManyPages
{
    public partial class READ_FormViewWithNestedListView : System.Web.UI.Page
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
            return Service.GetCourseDate(1);
        }

        public IEnumerable<Participant> StudentsListView_GetData()
        {
            var courseDateId = ((CourseDate)(CourseDateFormView.DataItem)).Id;
            return Service.GetParticipantsOfCourseDate(courseDateId);
        }

        protected void StudentsListView_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            var participant = e.Item.DataItem as Participant;
            if (participant != null)
            {
                var student = Service.GetStudent(participant.StudentId);
                var literal = e.Item.FindControl("NameLiteral") as Literal;
                literal.Text = String.Format("{0}, {1}", student.LastName, student.FirstName);
            }
        }
    }
}