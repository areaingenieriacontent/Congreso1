using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Congreso_1.Models;

namespace Congreso_1.Controllers
{
    public class Stand_TypeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Stand_Type
        public ActionResult Index()
        {
            return View(db.Tb_Stand_Type.ToList());
        }

        // GET: Stand_Type/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stand_Type stand_Type = db.Tb_Stand_Type.Find(id);
            if (stand_Type == null)
            {
                return HttpNotFound();
            }
            return View(stand_Type);
        }

        // GET: Stand_Type/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Stand_Type/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StandType,StandName,StandDescription,ResourceQuantity")] Stand_Type stand_Type)
        {
            if (ModelState.IsValid)
            {
                db.Tb_Stand_Type.Add(stand_Type);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(stand_Type);
        }

        // GET: Stand_Type/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stand_Type stand_Type = db.Tb_Stand_Type.Find(id);
            if (stand_Type == null)
            {
                return HttpNotFound();
            }
            return View(stand_Type);
        }

        // POST: Stand_Type/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StandType,StandName,StandDescription,ResourceQuantity")] Stand_Type stand_Type)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stand_Type).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(stand_Type);
        }

        // GET: Stand_Type/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stand_Type stand_Type = db.Tb_Stand_Type.Find(id);
            if (stand_Type == null)
            {
                return HttpNotFound();
            }
            return View(stand_Type);
        }

        // POST: Stand_Type/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Stand_Type stand_Type = db.Tb_Stand_Type.Find(id);
            db.Tb_Stand_Type.Remove(stand_Type);
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
