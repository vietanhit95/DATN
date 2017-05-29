using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ADS.APP.Models
{
    public class ListArticle
    {
        public List<Article> lstFree { get; set; }
        public List<Image> lstImage { get; set; }
        public ListArticle()
        {

        }

    }
}