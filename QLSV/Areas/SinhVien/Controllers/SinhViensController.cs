using QLSV.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLSV.Areas.SinhVien.Controllers
{
    [Authorize(Roles = "Student")]
    public class SinhVienController : Controller
    {
        private readonly DBcontext _db = new DBcontext();
        //public HomeAdminController(DBcontext db)
   
 
        
        // GET: Admins/HomeAdmin
        public ActionResult Index(string KeyWords)
        {
            if (string.IsNullOrEmpty(KeyWords))
            {
                var result1 = from sv in _db.SinhViens
                              join point in _db.Diems on sv.MaSinhVien equals point.MaSinhVien
                              join lop in _db.Lops on sv.MaLop equals lop.MaLop
                              // kh.TenKhoa.Contains(KeyWords)

                              select new ViewIndex
                              {
                                  Msv = sv.MaSinhVien,
                                  Hvt = sv.TenSinhVien,
                                  //MaKhoa = kh.TenKhoa,
                                  DiemTB = point.DiemTB,
                                  Lop = lop.TenLop,
                                  //TenMH= mh.MaMonHoc
                              };

                return View(result1);
            }
            var result = from sv in _db.SinhViens
                         join point in _db.Diems on sv.MaSinhVien equals point.MaSinhVien
                         join lop in _db.Lops on sv.MaLop equals lop.MaLop
                         //join kh in _db.Khoas on lop.MaKhoa equals kh.MaKhoa
                         where sv.MaSinhVien.Contains(KeyWords) ||
                         sv.TenSinhVien.Contains(KeyWords)
                         // kh.TenKhoa.Contains(KeyWords)
                         select new ViewIndex
                         {
                             Msv = sv.MaSinhVien,
                             Hvt = sv.TenSinhVien,
                             //MaKhoa = kh.TenKhoa,
                             DiemTB = point.DiemTB,
                             Lop = lop.TenLop
                         };
            return View(result);
        }

    }
}