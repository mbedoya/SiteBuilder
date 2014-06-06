using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace BusinessManager.Models
{
    public class PageDataModel
    {
        
	public int ID  { get; set; }
	public string Name  { get; set; }
	public string Content  { get; set; }
	public string FeaturedImage  { get; set; }
	public string MainImage  { get; set; }
	public bool Blog  { get; set; }
	public string Metakeywords  { get; set; }
	public string MetaDescription  { get; set; }
	 public HttpPostedFileBase fileFeaturedImage { get; set; }
	 public HttpPostedFileBase fileMainImage { get; set; }        
    }
}