using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ADS.APP.Models
{
    public class _Category
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Trường ký tự không được để trống")]
        public string Name { get; set; }
        public string Status { get; set; }
        public Nullable<int> CategoryId { get; set; }
        public Nullable<int> ArticleId { get; set; }
    }
}