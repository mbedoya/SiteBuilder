using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace WebSite.WebUtilities
{
    public class Misc
    {
        public static string GetAppSetting(string name)
        {
            return ConfigurationManager.AppSettings[name];
        }
    }
}