using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataboundFiles.Model;

namespace DataboundFiles
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
                var di = new DirectoryInfo(Server.MapPath("~/Content/files"));
                var files = di.GetFiles();
                OldSchoolFileRepeater.DataSource = files;
                OldSchoolFileRepeater.DataBind();
            //}
        }

        protected void OldSchoolFileRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item ||
                e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var fileInfo = (FileInfo)e.Item.DataItem;
                var hyperLink = (HyperLink)e.Item.FindControl("FileHyperLink");
                switch (fileInfo.Extension.ToLower())
                {
                    case ".pdf":
                        hyperLink.CssClass = "pdf";
                        break;

                    case ".txt":
                        hyperLink.CssClass = "txt";
                        break;
                }
            }
        }

        public IEnumerable<dynamic> Repeater_GetData()
        {
            var regex = new Regex("(.pdf|.txt)", RegexOptions.IgnoreCase);
            var di = new DirectoryInfo(Server.MapPath("~/Content/files"));
            return (from fi in di.GetFiles()
                    select new FileData 
                    {
                        Name = fi.Name, 
                        CssClass = regex.IsMatch(fi.Extension) ? fi.Extension.Substring(1) : String.Empty
                    }).AsEnumerable();
        }
    }
}