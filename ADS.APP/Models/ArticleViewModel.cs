using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ADS.APP.Models
{
    public class ArticleViewModel
    {
        public Custommer Cus { get; set; }
        public Category Cate { get; set; }
        public Card Card { get; set; }
        public Article AdvandeArticle { get; set; }
        

    }
}