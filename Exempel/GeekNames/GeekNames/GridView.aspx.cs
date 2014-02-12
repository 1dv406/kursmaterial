using System;
using System.Web.UI.WebControls;
using GeekNames.Model;

namespace GeekNames
{
    public partial class GridView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BabyNamesGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var babyName = e.Row.DataItem as BabyName;

                if (babyName.Gender == Gender.Female)
                {
                    e.Row.CssClass = "female";
                }
                else
                {
                    e.Row.CssClass = "male";
                }
            }
        }
    }
}