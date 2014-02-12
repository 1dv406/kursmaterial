using System;
using GeekNames.Model;

namespace GeekNames
{
    public partial class RadioButtonList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var service = new Service();
                GirlsNamesRadioButtonList.DataSource = service.GetPopularGirlNamesOrderedByName();
                GirlsNamesRadioButtonList.DataBind();
            }
        }
    }
}