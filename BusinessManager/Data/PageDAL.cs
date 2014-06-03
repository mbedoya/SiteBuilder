using BusinessManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;
using System.Configuration;

namespace BusinessManager.Data
{
    public class PageDAL
    {
        public static List<PageDataModel> GetAll()
        {
            List<PageDataModel> pages = new List<PageDataModel>();

            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[BusinessUtilies.Const.Database.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter(BusinessUtilies.Const.Database.Procedure_GetAllPages, connection);
            DataTable results = new DataTable();

            adapter.Fill(results);

            foreach (DataRow item in results.Rows)
            {
                pages.Add(
                    new PageDataModel()
                    {
                        ID = Convert.ToInt32(item["ID"]),
                        Name = item["Name"].ToString(),
                        Content = item["Content"].ToString()
                    }
                );
                 
            }

            

            return pages;
        }

        public static PageDataModel Get(int id)
        {
            PageDataModel page = null;

            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[BusinessUtilies.Const.Database.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter(BusinessUtilies.Const.Database.Procedure_GetPage, connection);
            MySqlParameter paramID = new MySqlParameter("id", id);
            paramID.Direction = ParameterDirection.Input;
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.Add(paramID);

            DataTable results = new DataTable();

            adapter.Fill(results);

            if(results.Rows.Count > 0)
            {
                DataRow item = results.Rows[0];
                page = new PageDataModel()
                {
                    Name = item["Name"].ToString(),
                    Content = item["Content"].ToString()
                };
            }

            return page;
        }

        public static void Update(PageDataModel page)
        {
            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[BusinessUtilies.Const.Database.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter(BusinessUtilies.Const.Database.Procedure_UpdatePage, connection);
            MySqlParameter paramID = new MySqlParameter("id", page.ID);
            paramID.Direction = ParameterDirection.Input;
            MySqlParameter paramName = new MySqlParameter("name", page.Name);
            paramName.Direction = ParameterDirection.Input;
            MySqlParameter paramContent = new MySqlParameter("content", page.Content);
            paramContent.Direction = ParameterDirection.Input;

            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.Add(paramID);
            adapter.SelectCommand.Parameters.Add(paramName);
            adapter.SelectCommand.Parameters.Add(paramContent);

            DataTable results = new DataTable();

            adapter.Fill(results);
        }

        public static void Create(PageDataModel page)
        {
            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[BusinessUtilies.Const.Database.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter(BusinessUtilies.Const.Database.Procedure_CreatePage, connection);            
            MySqlParameter paramName = new MySqlParameter("name", page.Name);
            paramName.Direction = ParameterDirection.Input;
            MySqlParameter paramContent = new MySqlParameter("content", page.Content);
            paramContent.Direction = ParameterDirection.Input;

            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;            
            adapter.SelectCommand.Parameters.Add(paramName);
            adapter.SelectCommand.Parameters.Add(paramContent);

            DataTable results = new DataTable();

            adapter.Fill(results);
        }
    }
}
