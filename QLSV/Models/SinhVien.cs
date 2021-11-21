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
        [Display(Name = "Mã Sinh Viên")]
        public string MaSinhVien { get; set; }
        [Required(ErrorMessage = "Tên Sinh Viên không được bỏ trống ")]
        [Display(Name = "Tên Sinh Viên")]
        public string TenSinhVien { get; set; }
        [Display(Name = "Giới Tính")]

        public string GioiTinh { get; set; }
        [Required(ErrorMessage = "Ngày Sinh không được bỏ trống ")]
        [Display(Name = "Ngày sinh")]
        public string NgaySinh { get; set; }
        [Required(ErrorMessage = "Địa chỉ không được bỏ trống ")]
        [Display(Name = "Địa Chỉ")]
        public string DiaChi { get; set; }
        [Required(ErrorMessage = "Email không được bỏ trống ")]
        
        public string Email { get; set; }


        public string SVimages { get; set; }
        [NotMapped]
        public HttpPostedFileBase SVImagesFile { get; set; }


        [Display(Name = "Tên Lớp")]
        public string MaLop { get; set; }
        [ForeignKey("MaLop")]
        public virtual Lop Lop { get; set; }
    }
}