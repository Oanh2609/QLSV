using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QLSV.Models;

namespace QLSV.Areas.Admins.Controllers
{
    public class LopsADMController : Controller
    {
        private DBcontext db = new DBcontext();

        // GET: Admins/LopsADM
        public async Task<ActionResult> Index()
        {
            var lops = db.Lops.Include(l => l.HeDaotao).Include(l => l.Khoa).Include(l => l.KhoaHoc);
            return View(await lops.ToListAsync());
        }

        // GET: Admins/LopsADM/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lop lop = await db.Lops.FindAsync(id);
            if (lop == null)
            {
                return HttpNotFound();
            }
            return View(lop);
        }

        // GET: Admins/LopsADM/Create
        public ActionResult Create()
        {
            ViewBag.MaHeDT = new SelectList(db.HeDaotaos, "MaHeDT", "TenHeDT");
            ViewBag.MaKhoa = new SelectList(db.Khoas, "MaKhoa", "TenKhoa");
            ViewBag.MaKhoaHoc = new SelectList(db.KhoaHocs, "MaKhoaHoc", "TenKhoaHoc");
            return View();
        }

        // POST: Admins/LopsADM/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "MaLop,TenLop,MaKhoa,MaHeDT,MaKhoaHoc")] Lop lop)
        {
            if (ModelState.IsValid)
            {
                db.Lops.Add(lop);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.MaHeDT = new SelectList(db.HeDaotaos, "MaHeDT", "TenHeDT", lop.MaHeDT);
            ViewBag.MaKhoa = new SelectList(db.Khoas, "MaKhoa", "TenKhoa", lop.MaKhoa);
            ViewBag.MaKhoaHoc = new SelectList(db.KhoaHocs, "MaKhoaHoc", "TenKhoaHoc", lop.MaKhoaHoc);
            return View(lop);
        }

        // GET: Admins/LopsADM/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lop lop = await db.Lops.FindAsync(id);
            if (lop == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaHeDT = new SelectList(db.HeDaotaos, "MaHeDT", "TenHeDT", lop.MaHeDT);
            ViewBag.MaKhoa = new SelectList(db.Khoas, "MaKhoa", "TenKhoa", lop.MaKhoa);
            ViewBag.MaKhoaHoc = new SelectList(db.KhoaHocs, "MaKhoaHoc", "TenKhoaHoc", lop.MaKhoaHoc);
            return View(lop);
        }

        // POST: Admins/LopsADM/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "MaLop,TenLop,MaKhoa,MaHeDT,MaKhoaHoc")] Lop lop)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lop).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.MaHeDT = new SelectList(db.HeDaotaos, "MaHeDT", "TenHeDT", lop.MaHeDT);
            ViewBag.MaKhoa = new SelectList(db.Khoas, "MaKhoa", "TenKhoa", lop.MaKhoa);
            ViewBag.MaKhoaHoc = new SelectList(db.KhoaHocs, "MaKhoaHoc", "TenKhoaHoc", lop.MaKhoaHoc);
            return View(lop);
        }

        // GET: Admins/LopsADM/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lop lop = await db.Lops.FindAsync(id);
            if (lop == null)
            {
                return HttpNotFound();
            }
            return View(lop);
        }

        // POST: Admins/LopsADM/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            Lop lop = await db.Lops.FindAsync(id);
            db.Lops.Remove(lop);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
