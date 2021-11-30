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
    public class MonHocsADMController : Controller
    {
        private DBcontext db = new DBcontext();

        // GET: Admins/MonHocsADM
        public async Task<ActionResult> Index()
        {
            return View(await db.MonHocs.ToListAsync());
        }

        // GET: Admins/MonHocsADM/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MonHoc monHoc = await db.MonHocs.FindAsync(id);
            if (monHoc == null)
            {
                return HttpNotFound();
            }
            return View(monHoc);
        }

        // GET: Admins/MonHocsADM/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admins/MonHocsADM/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "MaMonHoc,TenMonHoc,SoTin")] MonHoc monHoc)
        {
            if (ModelState.IsValid)
            {
                db.MonHocs.Add(monHoc);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(monHoc);
        }

        // GET: Admins/MonHocsADM/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MonHoc monHoc = await db.MonHocs.FindAsync(id);
            if (monHoc == null)
            {
                return HttpNotFound();
            }
            return View(monHoc);
        }

        // POST: Admins/MonHocsADM/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "MaMonHoc,TenMonHoc,SoTin")] MonHoc monHoc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(monHoc).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(monHoc);
        }

        // GET: Admins/MonHocsADM/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MonHoc monHoc = await db.MonHocs.FindAsync(id);
            if (monHoc == null)
            {
                return HttpNotFound();
            }
            return View(monHoc);
        }

        // POST: Admins/MonHocsADM/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            MonHoc monHoc = await db.MonHocs.FindAsync(id);
            db.MonHocs.Remove(monHoc);
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
