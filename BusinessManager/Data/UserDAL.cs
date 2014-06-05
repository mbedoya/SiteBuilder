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
    public class UserDAL
    {
        public static List<UserDataModel> GetAll()
        {
            List<UserDataModel> users = new List<UserDataModel>();

            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[BusinessUtilies.Const.Database.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("GetUsers", connection);
            DataTable results = new DataTable();

            adapter.Fill(results);

            foreach (DataRow item in results.Rows)
            {
                UserDataModel user = new UserDataModel();

                user.ID = Convert.ToInt32(item["ID"]);
                user.Name = Convert.ToString(item["Name"]);
                user.Email = Convert.ToString(item["Email"]);
                user.Password = Convert.ToString(item["Password"]);

                users.Add(user);
            }

            return users;
        }

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

        public static UserDataModel Get(int id)
        {
            UserDataModel user = null;

            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[BusinessUtilies.Const.Database.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("GetUserByID", connection);
            MySqlParameter paramID = new MySqlParameter("pId", id);
            paramID.Direction = ParameterDirection.Input;
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.Add(paramID);

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

        public static void Update(UserDataModel user)
        {
            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[BusinessUtilies.Const.Database.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("UpdateUser", connection);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;


            MySqlParameter paramID = new MySqlParameter("pID", user.ID);
            paramID.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramID);
            MySqlParameter paramName = new MySqlParameter("pName", user.Name);
            paramName.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramName);
            MySqlParameter paramEmail = new MySqlParameter("pEmail", user.Email);
            paramEmail.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramEmail);
            MySqlParameter paramPassword = new MySqlParameter("pPassword", user.Password);
            paramPassword.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramPassword);

            DataTable results = new DataTable();
            adapter.Fill(results);
        }

        public static void Create(UserDataModel user)
        {
            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[BusinessUtilies.Const.Database.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("CreateUser", connection);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;


            MySqlParameter paramID = new MySqlParameter("pID", user.ID);
            paramID.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramID);
            MySqlParameter paramName = new MySqlParameter("pName", user.Name);
            paramName.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramName);
            MySqlParameter paramEmail = new MySqlParameter("pEmail", user.Email);
            paramEmail.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramEmail);
            MySqlParameter paramPassword = new MySqlParameter("pPassword", user.Password);
            paramPassword.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramPassword);

            DataTable results = new DataTable();
            adapter.Fill(results);
        }
    }
}
