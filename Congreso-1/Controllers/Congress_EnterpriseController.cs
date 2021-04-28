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
    public class Congress_EnterpriseController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Congress_Enterprise
        public ActionResult Index()
        {
            var tb_Congress_Enterprise = db.Tb_Congress_Enterprise.Include(c => c.Congress).Include(c => c.Enterprise).Include(c => c.Stand);
            return View(tb_Congress_Enterprise.ToList());
        }



        // GET: Congress_Enterprise/Create
        public ActionResult Create()
        {
            ViewBag.CongressId = new SelectList(db.Tb_Congress, "CongressId", "CongressName");
            ViewBag.EnterpriseId = new SelectList(db.Tb_Enterprise, "EnterpriseId", "EnterpriseName");
            ViewBag.StandId = new SelectList(db.Tb_Stand, "Stand_id", "StandName");
            return View();
        }

        // POST: Congress_Enterprise/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CongressId,EnterpriseId,StandId")] Congress_Enterprise congress_Enterprise)
        {
            if (ModelState.IsValid)
            {
                db.Tb_Congress_Enterprise.Add(congress_Enterprise);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CongressId = new SelectList(db.Tb_Congress, "CongressId", "CongressName", congress_Enterprise.CongressId);
            ViewBag.EnterpriseId = new SelectList(db.Tb_Enterprise, "EnterpriseId", "EnterpriseName", congress_Enterprise.EnterpriseId);
            ViewBag.StandId = new SelectList(db.Tb_Stand, "Stand_id", "StandName", congress_Enterprise.StandId);
            return View(congress_Enterprise);
        }

        

        // GET: Congress_Enterprise/Delete/5
        public ActionResult Delete(int? idCongreso, int? idStand, int? idEmpresa)
        {
            if (idCongreso == null && idStand == null && idEmpresa == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Congress_Enterprise congress_Enterprise = db.Tb_Congress_Enterprise.Where(x => x.StandId == idStand && x.CongressId == idCongreso && x.EnterpriseId == idEmpresa).FirstOrDefault();
            if (congress_Enterprise == null)
            {
                return HttpNotFound();
            }
            return View(congress_Enterprise);
        }

        // POST: Congress_Enterprise/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? idCongreso, int? idStand, int? idEmpresa)
        {
            Congress_Enterprise congress_Enterprise = db.Tb_Congress_Enterprise.Where(x => x.StandId == idStand && x.CongressId == idCongreso && x.EnterpriseId == idEmpresa).FirstOrDefault();
            db.Tb_Congress_Enterprise.Remove(congress_Enterprise);
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
