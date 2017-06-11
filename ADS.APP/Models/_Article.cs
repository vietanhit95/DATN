using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ADS.APP.Models
{
    public class _Article
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Trường ký tự không được để trống")]
        public string Decreption { get; set; }
        [Required(ErrorMessage = "Trường ký tự không được để trống")]
        public string Title { get; set; }
        public Nullable<int> ImageId { get; set; }
        public Nullable<int> ProvinceId { get; set; }
        public string Article_Type { get; set; }
        [DataType(DataType.Currency)]
        public string Price { get; set; }
        [Required(ErrorMessage = "Trường ký tự không được để trống")]
        public string PhoneNumber { get; set; }
        public string Create_Date { get; set; }
        public string Status { get; set; }
        public Nullable<int> CategoryId { get; set; }
        public Nullable<int> CardId { get; set; }
        [Required(ErrorMessage = "Trường ký tự không được để trống")]
        public string UserNameFree { get; set; }
        [Required(ErrorMessage = "Trường ký tự không được để trống")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Nhập đúng email")]
        public string EmailFree { get; set; }
        public Nullable<int> CommentId { get; set; }
        public Nullable<int> CustommerId { get; set; }
        public Nullable<int> DistrictId { get; set; }
        public IEnumerable<Image> img { get; set; }
    }
}