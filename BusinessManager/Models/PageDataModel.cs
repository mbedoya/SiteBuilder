using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessManager.Models
{
    public class PageDataModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public string FeaturedImage { get; set; }
        public string MainImage { get; set; }
    }
}
