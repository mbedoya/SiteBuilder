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
    public class UserDAL : BaseUserDAL
    {
        public static UserDataModel CheckUser(string email, string password)
        {
            UserDataModel user = null;

            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[BusinessUtilies.Const.Database.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("CheckUser", connection);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            MySqlParameter paramID = new MySqlParameter("pEmail", email);
            paramID.Direction = ParameterDirection.Input;            
            adapter.SelectCommand.Parameters.Add(paramID);

            MySqlParameter paramPassword = new MySqlParameter("pPassword", password);
            paramPassword.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramPassword);

            DataTable results = new DataTable();

            adapter.Fill(results);

            if (results.Rows.Count > 0)
            {
                DataRow item = results.Rows[0];
                user = new UserDataModel();

                user.ID = Convert.ToInt32(item["ID"]);
                user.Name = Convert.ToString(item["Name"]);
                user.Email = Convert.ToString(item["Email"]);
                user.Password = Convert.ToString(item["Password"]);
            }

            return user;
        }
    }
}
