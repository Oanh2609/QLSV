using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QLSV.Models
{
    public class MonHoc
    {
        [Key]
        [Required(ErrorMessage = "Mã môn học không được bỏ trống")]
        public string MaMonHoc { get; set; }
        [Required(ErrorMessage = "Tên môn hoc không được bỏ trống")]
        public string TenMonHoc { get; set; }
        [Required(ErrorMessage = "Số tín chỉ không được bỏ trống")]
        public int SoTin { get; set; }
    }
}