using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QLSV.Models
{
    public class HeDaotao
    {
        [Key]
        //public int ID { get; set; }
        [Required(ErrorMessage = "Mã Hệ đào tạo không được bỏ trống")]
        [Display(Name = "Mã Hệ ĐT")]
        public string MaHeDT { get; set; }
        [Required(ErrorMessage = "Tên hệ đào tạo không được bỏ trống")]
        [Display(Name = "Tên Hệ ĐT")]
        public string TenHeDT { get; set; }
    }
}