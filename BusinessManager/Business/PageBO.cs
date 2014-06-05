using BusinessManager.Data;
using BusinessManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessManager.Business
{
    public static class PageBO
    {
        public static List<PageDataModel> GetAll()
        {
            return PageDAL.GetAll();
        }

        public static PageDataModel Get(int id)
        {
            return PageDAL.Get(id);
        }

        public static void Update(PageDataModel page)
        {
            if (page.ID > 0)
            {
                PageDAL.Update(page);
            }
            else
            {
                throw new Exception("Page not found");
            }

        }

        public static void Create(PageDataModel page)
        {
            PageDAL.Create(page);
        }
    }
}
