using System;
using System.Collections.Generic;
using GeekTallStory.Model;
using GeekTallStory.Model.DAL;

namespace GeekTallStory
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IEnumerable<TallStory> TallStoryRepeater_GetData()
        {
            var dal = new TallStoryDAL();
            return dal.GetTallStories();
        }
    }
}