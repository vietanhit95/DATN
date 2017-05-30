using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ADS.APP.Models
{
    public class ListViewArticle
    {
        public List<Article> lstArticle { get; set; }
        public List<Custommer> lstCus { get; set; }
        public List<Card> lstCard { get; set; }
        public List<Province> lstPro { get; set; }
    }
}