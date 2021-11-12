using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QLSV.Models
{
    public class KhoaHoc
    {
        [Key]
        //public int ID { get; set; }
        [Required(ErrorMessage = "Mã khoá học không được bỏ trống")]
        public string MaKhoaHoc { get; set; }
        [Required(ErrorMessage = "Tên khoá học không được bỏ trống")]
        public string TenKhoaHoc { get; set; }
    }
}