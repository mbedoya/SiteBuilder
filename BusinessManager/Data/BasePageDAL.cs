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
    public class BasePageDAL
    {
        public static List<PageDataModel> GetAll()
        {
            List<PageDataModel> pages = new List<PageDataModel>();

            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[BusinessUtilies.Const.Database.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("GetPages", connection);
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

        public static PageDataModel Get(int id)
        {
            PageDataModel page = null;

            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[BusinessUtilies.Const.Database.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("GetPageByID", connection);
            MySqlParameter paramID = new MySqlParameter("pId", id);
            paramID.Direction = ParameterDirection.Input;
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.Add(paramID);

            DataTable results = new DataTable();

            adapter.Fill(results);

            if (results.Rows.Count > 0)
            {
                DataRow item = results.Rows[0];
                page = new PageDataModel();

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
            }

            return page;
        }

        public static void Update(PageDataModel page)
        {
            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[BusinessUtilies.Const.Database.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("UpdatePage", connection);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;


            MySqlParameter paramID = new MySqlParameter("pID", page.ID);
            paramID.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramID);
            MySqlParameter paramName = new MySqlParameter("pName", page.Name);
            paramName.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramName);
            MySqlParameter paramContent = new MySqlParameter("pContent", page.Content);
            paramContent.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramContent);
            MySqlParameter paramFeaturedImage = new MySqlParameter("pFeaturedImage", page.FeaturedImage);
            paramFeaturedImage.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramFeaturedImage);
            MySqlParameter paramMainImage = new MySqlParameter("pMainImage", page.MainImage);
            paramMainImage.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramMainImage);
            MySqlParameter paramBlog = new MySqlParameter("pBlog", page.Blog);
            paramBlog.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramBlog);
            MySqlParameter paramMetakeywords = new MySqlParameter("pMetakeywords", page.Metakeywords);
            paramMetakeywords.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramMetakeywords);
            MySqlParameter paramMetaDescription = new MySqlParameter("pMetaDescription", page.MetaDescription);
            paramMetaDescription.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramMetaDescription);

            DataTable results = new DataTable();
            adapter.Fill(results);
        }

        public static void Create(PageDataModel page)
        {
            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[BusinessUtilies.Const.Database.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("CreatePage", connection);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;


            MySqlParameter paramID = new MySqlParameter("pID", page.ID);
            paramID.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramID);
            MySqlParameter paramName = new MySqlParameter("pName", page.Name);
            paramName.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramName);
            MySqlParameter paramContent = new MySqlParameter("pContent", page.Content);
            paramContent.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramContent);
            MySqlParameter paramFeaturedImage = new MySqlParameter("pFeaturedImage", page.FeaturedImage);
            paramFeaturedImage.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramFeaturedImage);
            MySqlParameter paramMainImage = new MySqlParameter("pMainImage", page.MainImage);
            paramMainImage.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramMainImage);
            MySqlParameter paramBlog = new MySqlParameter("pBlog", page.Blog);
            paramBlog.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramBlog);
            MySqlParameter paramMetakeywords = new MySqlParameter("pMetakeywords", page.Metakeywords);
            paramMetakeywords.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramMetakeywords);
            MySqlParameter paramMetaDescription = new MySqlParameter("pMetaDescription", page.MetaDescription);
            paramMetaDescription.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramMetaDescription);

            DataTable results = new DataTable();
            adapter.Fill(results);
        }
    }
}
