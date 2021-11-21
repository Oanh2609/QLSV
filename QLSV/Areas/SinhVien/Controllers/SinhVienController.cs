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
        // GET: SinhVien/SinhVien
        public ActionResult Index()
        {
            return View();
        }
    }
}