using BusinessManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Configuration;

using MySql.Data.MySqlClient;

namespace BusinessManager.Data
{
    public class PageDAL : BasePageDAL
    {
        public static List<PageDataModel> GetBlogPages()
        {
            List<PageDataModel> pages = new List<PageDataModel>();

            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[BusinessUtilies.Const.Database.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("GetBlogPages", connection);
            DataTable results = new DataTable();

            adapter.Fill(results);

            foreach (DataRow item in results.Rows)
            {
                PageDataModel page = new PageDataModel();

                page.ID = Convert.ToInt32(item["ID"]);
                page.Name = Convert.ToString(item["Name"]);
                page.Content = Convert.ToString(item["Content"]);
                page.FeaturedImage = Convert.ToString(item["FeaturedImage"]);
                page.MainImage = Convert.ToString(item["MainImage"]);
                if (item["Blog"].GetType() != typeof(DBNull))
                {
                    page.Blog = Convert.ToBoolean(item["Blog"]);
                }
                page.Metakeywords = Convert.ToString(item["Metakeywords"]);
                page.MetaDescription = Convert.ToString(item["MetaDescription"]);

                pages.Add(page);
            }

            return pages;
        }

        
    }
}
