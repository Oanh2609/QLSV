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
        public string MaHeDT { get; set; }
        [Required(ErrorMessage = "Tên hệ đào tạo không được bỏ trống")]
        public string TenHeDT { get; set; }
    }
}