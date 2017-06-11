using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ADS.APP.Models
{
    public class ArticleViewModel
    {
        public _Custommer Cus { get; set; }
        public _Category Cate { get; set; }
        public Card Card { get; set; }
        public _Article AdvandeArticle { get; set; }
    }
}