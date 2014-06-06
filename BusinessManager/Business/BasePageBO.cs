using BusinessManager.Data;
using BusinessManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilities;

namespace BusinessManager.Business
{
    public class BasePageBO
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

                if (page.fileFeaturedImage != null)
                {
                    page.FeaturedImage = FileManager.SaveFile(page.fileFeaturedImage);
                }
                if (page.fileMainImage != null)
                {
                    page.MainImage = FileManager.SaveFile(page.fileMainImage);
                }

                PageDAL.Update(page);
            }
            else
            {
                throw new Exception("Page not found");
            }

        }

        public static void Create(PageDataModel page)
        {

            if (page.fileFeaturedImage != null)
            {
                page.FeaturedImage = FileManager.SaveFile(page.fileFeaturedImage);
            }
            if (page.fileMainImage != null)
            {
                page.MainImage = FileManager.SaveFile(page.fileMainImage);
            }

            PageDAL.Create(page);
        }
    }
}
