using BusinessManager.Data;
using BusinessManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilities;

namespace BusinessManager.Business
{
    public class PageBO : BasePageBO
    {
        public static List<PageDataModel> GetBlogPages()
        {
            return PageDAL.GetBlogPages();
        }
    }
}


