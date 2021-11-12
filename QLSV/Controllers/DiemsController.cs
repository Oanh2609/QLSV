using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QLSV.Models;

namespace QLSV.Controllers
{
    public class DiemsController : Controller
    {
        private DBcontext db = new DBcontext();

        // GET: Diems
        public ActionResult Index()
        {
            var diems = db.Diems.Include(d => d.MonHoc);
            return View(diems.ToList());
        }

        // GET: Diems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Diem diem = db.Diems.Find(id);
            if (diem == null)
            {
                return HttpNotFound();
            }
            return View(diem);
        }

        // GET: Diems/Create
        public ActionResult Create()
        {
            ViewBag.MaMonHoc = new SelectList(db.MonHocs, "MaMonHoc", "TenMonHoc");
            return View();
        }

        // POST: Diems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,MaSinhVien,MaMonHoc,HocKi,DiemA,DiemB,DiemC,DiemTB")] Diem diem)
        {
            if (ModelState.IsValid)
            {
                diem.DiemTB = (diem.DiemA * 0.6) + diem.DiemB * 0.3 + diem.DiemC * 0.1;
                db.Diems.Add(diem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaMonHoc = new SelectList(db.MonHocs, "MaMonHoc", "TenMonHoc", diem.MaMonHoc);
            return View(diem);
        }

        // GET: Diems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Diem diem = db.Diems.Find(id);
            if (diem == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaMonHoc = new SelectList(db.MonHocs, "MaMonHoc", "TenMonHoc", diem.MaMonHoc);
            return View(diem);
        }

        // POST: Diems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,MaSinhVien,MaMonHoc,HocKi,DiemA,DiemB,DiemC,DiemTB")] Diem diem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(diem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaMonHoc = new SelectList(db.MonHocs, "MaMonHoc", "TenMonHoc", diem.MaMonHoc);
            return View(diem);
        }

        // GET: Diems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Diem diem = db.Diems.Find(id);
            if (diem == null)
            {
                return HttpNotFound();
            }
            return View(diem);
        }

        // POST: Diems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Diem diem = db.Diems.Find(id);
            db.Diems.Remove(diem);
            db.SaveChanges();
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
