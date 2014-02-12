using System;
using System.Collections.Generic;
using GeekNames.Model;

namespace GeekNames
{
    public partial class BulletedList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IEnumerable<string> GirlsNamesBulletedList_Get()
        {
            var service = new Service();
            return service.GetPopularGirlNames();
        }
    }
}