using BusinessManager.Data;
using BusinessManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessManager.Business
{
    public class BaseMenuBO
    {
        public static List<MenuDataModel> GetAll()
        {
            return MenuDAL.GetAll();
        }

        public static MenuDataModel Get(int id)
        {
            return MenuDAL.Get(id);
        }

        public static void Update(MenuDataModel menu)
        {
            if (menu.ID > 0)
            {
                MenuDAL.Update(menu);
            }
            else
            {
                throw new Exception("Page not found");
            }

        }

        public static void Create(MenuDataModel menu)
        {
            MenuDAL.Create(menu);
        }
    }
}
