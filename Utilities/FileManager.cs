using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.IO;

namespace Utilities
{
    public class FileManager
    {
        public static string SaveFile(string name, string content)
        {
            File.WriteAllText(HttpContext.Current.Server.MapPath("~/files/") + name, content);
            return "/files/" + name;
        }

        public static string SaveFile(HttpPostedFileBase file)
        {
            file.SaveAs(HttpContext.Current.Server.MapPath("~/files/") + file.FileName);
            return "/files/" + file.FileName;
        }
    }
}
