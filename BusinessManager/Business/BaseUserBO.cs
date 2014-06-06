using BusinessManager.Data;
using BusinessManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessManager.Business
{
    public class BaseUserBO
    {
        public static List<UserDataModel> GetAll()
        {
            return UserDAL.GetAll();
        }

        public static UserDataModel Get(int id)
        {
            return UserDAL.Get(id);
        }

        public static void Update(UserDataModel user)
        {
            if (user.ID > 0)
            {
                UserDAL.Update(user);
            }
            else
            {
                throw new Exception("Page not found");
            }

        }

        public static void Create(UserDataModel user)
        {
            UserDAL.Create(user);
        }
    }
}
