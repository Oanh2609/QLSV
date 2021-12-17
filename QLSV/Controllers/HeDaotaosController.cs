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
    public class HeDaotaosController : Controller
    {
        private DBcontext db = new DBcontext();


        // GET: HeDaotaos
        public ActionResult Index()
        {
            return View(db.HeDaotaos.ToList());
        }

        // GET: HeDaotaos/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HeDaotao heDaotao = db.HeDaotaos.Find(id);
            if (heDaotao == null)
            {
                return HttpNotFound();
            }
            return View(heDaotao);
        }

        // GET: HeDaotaos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HeDaotaos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaHeDT,TenHeDT")] HeDaotao heDaotao)
        {
            if (ModelState.IsValid)
            {
                db.HeDaotaos.Add(heDaotao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(heDaotao);
        }

        // GET: HeDaotaos/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HeDaotao heDaotao = db.HeDaotaos.Find(id);
            if (heDaotao == null)
            {
                return HttpNotFound();
            }
            return View(heDaotao);
        }

        // POST: HeDaotaos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaHeDT,TenHeDT")] HeDaotao heDaotao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(heDaotao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(heDaotao);
        }

        // GET: HeDaotaos/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HeDaotao heDaotao = db.HeDaotaos.Find(id);
            if (heDaotao == null)
            {
                return HttpNotFound();
            }
            return View(heDaotao);
        }

        // POST: HeDaotaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            HeDaotao heDaotao = db.HeDaotaos.Find(id);
            db.HeDaotaos.Remove(heDaotao);
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
