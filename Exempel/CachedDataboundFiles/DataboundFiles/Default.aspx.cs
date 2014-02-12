using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using DataboundFiles.Model;

namespace DataboundFiles
{
    public partial class Default : System.Web.UI.Page
    {
        private Service _service;

        public Service Service 
        {
            get { return _service ?? (_service = new Service()); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
                OldSchoolFileRepeater.DataSource = Service.GetCachedFiles();
                OldSchoolFileRepeater.DataBind();
            //}
        }

        protected void OldSchoolFileRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            var fileData = e.Item.DataItem as FileData;
            if (fileData != null && !String.IsNullOrWhiteSpace(fileData.Css))
            {
                    var hyperLink = (HyperLink)e.Item.FindControl("FileHyperLink");
                    hyperLink.CssClass = fileData.Css;
            }
        }

        public IEnumerable<FileData> Repeater_GetData()
        {
            return Service.GetCachedFiles();
        }
    }
}