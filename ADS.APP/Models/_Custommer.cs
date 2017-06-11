using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ADS.APP.Models
{
    public class _Custommer
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Trường ký tự không được để trống")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Trường ký tự không được để trống")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Trường ký tự không được để trống")]
        public string PassWord { get; set; }
        public Nullable<int> ArticleId { get; set; }
        public Nullable<int> TypeUser { get; set; }
        public string Status { get; set; }
        [Required(ErrorMessage = "Trường ký tự là số điện thoại")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Nhập đúng số điện thoại")]
        public string PhoneNumber { get; set; }
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Trường ký tự không được để trống")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Vui lòng nhập đúng địa chỉ Email")]
        public string EmailUser { get; set; }
        public Nullable<int> Free_Article_Id { get; set; }
        [Required(ErrorMessage = "Trường ký tự không được để trống")]
        public string Address { get; set; }
    }
}