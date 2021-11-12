using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QLSV.Models
{
    public class SinhVien
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "Mã Sinh Viên không được bỏ trống ")]
        public string MaSinhVien { get; set; }
        [Required(ErrorMessage = "Tên Sinh Viên không được bỏ trống ")]
        public string TenSinhVien { get; set; }

        public string GioiTinh { get; set; }
        [Required(ErrorMessage = "Ngày Sinh không được bỏ trống ")]
        public string NgaySinh { get; set; }
        [Required(ErrorMessage = "Địa chỉ không được bỏ trống ")]
        public string DiaChi { get; set; }
        [Required(ErrorMessage = "Email không được bỏ trống ")]
        public string Email { get; set; }
        public string MaLop { get; set; }
        [ForeignKey("MaLop")]
        public virtual Lop Lop { get; set; }
    }
}