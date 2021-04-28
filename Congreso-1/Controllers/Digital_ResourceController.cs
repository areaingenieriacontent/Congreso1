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
    public class Digital_ResourceController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Digital_Resource
        //Controlador para el acceso de administrador para subir crear editar o borrar Recursos de los stands
        public ActionResult Index(int? stand)
        {
            if (stand != null)
            {
                var consulta = (from Resource in db.Tb_Digitar_Resource
                                join StandResource in db.Tb_Stand_Resource on Resource.ResourceId equals StandResource.DResourceId
                                where StandResource.StandId == stand
                                select Resource).ToList();
                ViewData["Stand"] = stand;
                return View(consulta);

            }
            else
            {
                return RedirectToAction("Index", "Stands");
            }

        }

        // GET: Digital_Resource/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Digital_Resource digital_Resource = db.Tb_Digitar_Resource.Find(id);
            if (digital_Resource == null)
            {
                return HttpNotFound();
            }
            return View(digital_Resource);
        }

        // GET: Digital_Resource/Create
        public ActionResult Create(int stand)
        {
            ViewData["Stand"] = stand;
            return View();
        }

        // POST: Digital_Resource/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ResourceId,ResourceUrl,ResourceHtml,Available,Index")] Digital_Resource digital_Resource, int stand)
        {
            if (ModelState.IsValid)
            {
                db.Tb_Digitar_Resource.Add(digital_Resource);

                Stand_Resource stand_Resource = new Stand_Resource();
                stand_Resource.StandId = stand;
                db.SaveChanges();
                stand_Resource.DResourceId = digital_Resource.ResourceId;
                db.Tb_Stand_Resource.Add(stand_Resource);
                db.SaveChanges();

                return RedirectToAction("Index", new { stand = stand});
            }

            return View(digital_Resource);
        }

        // GET: Digital_Resource/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Digital_Resource digital_Resource = db.Tb_Digitar_Resource.Find(id);
            if (digital_Resource == null)
            {
                return HttpNotFound();
            }
            return View(digital_Resource);
        }

        // POST: Digital_Resource/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ResourceId,ResourceUrl,ResourceHtml,Available,Index")] Digital_Resource digital_Resource)
        {
            if (ModelState.IsValid)
            {
                db.Entry(digital_Resource).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(digital_Resource);
        }

        // GET: Digital_Resource/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Digital_Resource digital_Resource = db.Tb_Digitar_Resource.Find(id);
            if (digital_Resource == null)
            {
                return HttpNotFound();
            }
            return View(digital_Resource);
        }

        // POST: Digital_Resource/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Digital_Resource digital_Resource = db.Tb_Digitar_Resource.Find(id);
            db.Tb_Digitar_Resource.Remove(digital_Resource);
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
