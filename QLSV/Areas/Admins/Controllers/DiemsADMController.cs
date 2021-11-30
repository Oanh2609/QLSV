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
    public class DiemsADMController : Controller
    {
        private DBcontext db = new DBcontext();

        // GET: Admins/DiemsADM
        public async Task<ActionResult> Index()
        {
            var diems = db.Diems.Include(d => d.MonHoc);
            return View(await diems.ToListAsync());
        }

        // GET: Admins/DiemsADM/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Diem diem = await db.Diems.FindAsync(id);
            if (diem == null)
            {
                return HttpNotFound();
            }
            return View(diem);
        }

        // GET: Admins/DiemsADM/Create
        public ActionResult Create()
        {
            ViewBag.MaMonHoc = new SelectList(db.MonHocs, "MaMonHoc", "TenMonHoc");
            return View();
        }

        // POST: Admins/DiemsADM/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,MaSinhVien,MaMonHoc,HocKi,DiemA,DiemB,DiemC,DiemTB")] Diem diem)
        {
            if (ModelState.IsValid)
            {
                db.Diems.Add(diem);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.MaMonHoc = new SelectList(db.MonHocs, "MaMonHoc", "TenMonHoc", diem.MaMonHoc);
            return View(diem);
        }

        // GET: Admins/DiemsADM/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Diem diem = await db.Diems.FindAsync(id);
            if (diem == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaMonHoc = new SelectList(db.MonHocs, "MaMonHoc", "TenMonHoc", diem.MaMonHoc);
            return View(diem);
        }

        // POST: Admins/DiemsADM/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,MaSinhVien,MaMonHoc,HocKi,DiemA,DiemB,DiemC,DiemTB")] Diem diem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(diem).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.MaMonHoc = new SelectList(db.MonHocs, "MaMonHoc", "TenMonHoc", diem.MaMonHoc);
            return View(diem);
        }

        // GET: Admins/DiemsADM/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Diem diem = await db.Diems.FindAsync(id);
            if (diem == null)
            {
                return HttpNotFound();
            }
            return View(diem);
        }

        // POST: Admins/DiemsADM/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Diem diem = await db.Diems.FindAsync(id);
            db.Diems.Remove(diem);
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
