using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace DataboundFiles.Model
{
    public class Service
    {
        private static readonly string WorkingDirectory;

        static Service()
        {
            WorkingDirectory = Path.Combine(
                AppDomain.CurrentDomain.GetData("APPBASE").ToString(),
                @"Content\files");
        }

        public IEnumerable<FileData> GetFiles()
        {
            var regex = new Regex("(.pdf|.txt)", RegexOptions.IgnoreCase);
            var di = new DirectoryInfo(WorkingDirectory);
            return (from fi in di.GetFiles()
                    select new FileData
                    {
                        Name = fi.Name,
                        Css = regex.IsMatch(fi.Extension) ? fi.Extension.Substring(1) : String.Empty
                    }).AsEnumerable();
        }

        public IEnumerable<FileData> GetCachedFiles()
        {
            var files = HttpContext.Current.Cache["files"] as IEnumerable<FileData>;
            if (files == null)
            {
                files = GetFiles();
                HttpContext.Current.Cache.Insert("files", files, null, DateTime.Now.AddMinutes(1), TimeSpan.Zero);
            }
            return files;
        }
    }
}