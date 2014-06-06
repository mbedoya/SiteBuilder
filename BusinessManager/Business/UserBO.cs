using BusinessManager.Data;
using BusinessManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessManager.Business
{
    public class UserBO : BaseUserBO
    {
        public static bool CheckUser(string email, string password)
        {
            return UserDAL.CheckUser(email, password) != null ? true : false;
        }
    }
}
