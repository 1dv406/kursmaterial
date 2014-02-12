using System;
using GeekNames.Model;

namespace GeekNames
{
    public partial class CheckBoxList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var service = new Service();
                GirlsNamesCheckBoxList.DataSource = service.GetPopularGirlNamesOrderedByName();
                GirlsNamesCheckBoxList.DataBind();
            }
        }
    }
}