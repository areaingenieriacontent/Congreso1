using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Congreso_1.Models;
using Microsoft.AspNet.Identity;

namespace Congreso_1.Controllers
{
    public class WebinarsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Webinars
        //Controlador para el acceso de usuario y adminitrador a la vista Index de los webinars obtiene el rol registrado y le carga los datos dependiendo el Rol, en la vista maneja la misma logica de mostrar datos por rol
        public ActionResult Index(int? IdCongreso)
        {

            ViewBag.Rol = ObtenerRol().ToString();
            var consulta = new List<Webinar>();
            if (ViewBag.Rol == "Usuario")
            {
                consulta = (from webinars in db.Tb_Webinar
                            where webinars.CongressId == IdCongreso
                            select webinars).ToList();
            }
            else if (ViewBag.rol == "Admin")
            {
                consulta = (from webinars in db.Tb_Webinar
                            select webinars).ToList();
            }

            return View(consulta);
        }

            // GET: Webinars/Details/5
            public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Webinar webinar = db.Tb_Webinar.Find(id);
            if (webinar == null)
            {
                return HttpNotFound();
            }
            return View(webinar);
        }

        // GET: Webinars/Create
        public ActionResult Create()
        {
            ViewBag.CongressId = new SelectList(db.Tb_Congress, "CongressId", "CongressName");
            return View();
        }

        // POST: Webinars/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        //Controlador para recibir y guardar los datos e imagenes que sean cargador desde la vista Create guarda las fototografias en /Archivos/Subidos y el link en la base de datos 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HttpPostedFileBase WebinarBannerPrincipal, HttpPostedFileBase WebinarImagen, [Bind(Include = "WebinarId,WebinarTheme,WebinarBannerPrincipal,WebinarImagen,WebinarInitialDate,WebinarEndDate,available,CongressId")] Webinar webinar)
        {
            if (ModelState.IsValid)
            {
                if (WebinarBannerPrincipal != null)
                {
                    var fecha = DateTime.Now.ToString().Replace(" ", "-");
                    String ruta = Server.MapPath("~/Archivos/Subidos/");
                    var rutaLink = ("../../Archivos/Subidos/" + (DateTime.Now.ToString("yyyyMMddHHmmss") + "-" + WebinarBannerPrincipal.FileName).ToLower());
                    ruta += (DateTime.Now.ToString("yyyyMMddHHmmss") + "-" + WebinarBannerPrincipal.FileName).ToLower();
                    WebinarBannerPrincipal.SaveAs(ruta);
                    webinar.WebinarBannerPrincipal = rutaLink;
                }
                if (WebinarImagen != null)
                {
                    String ruta = Server.MapPath("~/Archivos/Subidos/");
                    var rutaLink = ("../../Archivos/Subidos/" + (DateTime.Now.ToString("yyyyMMddHHmmss") + "-" + WebinarImagen.FileName).ToLower());
                    ruta += (DateTime.Now.ToString("yyyyMMddHHmmss") + "-" + WebinarImagen.FileName).ToLower();
                    WebinarImagen.SaveAs(ruta);
                    webinar.WebinarImagen = rutaLink;
                }
                db.Tb_Webinar.Add(webinar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CongressId = new SelectList(db.Tb_Congress, "CongressId", "CongressName", webinar.CongressId);
            return View(webinar);
        }

        // GET: Webinars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Webinar webinar = db.Tb_Webinar.Find(id);
            if (webinar == null)
            {
                return HttpNotFound();
            }
            ViewBag.CongressId = new SelectList(db.Tb_Congress, "CongressId", "CongressName", webinar.CongressId);
            return View(webinar);
        }

        // POST: Webinars/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WebinarId,WebinarTheme,WebinarBannerPrincipal,WebinarImagen,WebinarInitialDate,WebinarEndDate,available,CongressId")] Webinar webinar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(webinar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CongressId = new SelectList(db.Tb_Congress, "CongressId", "CongressName", webinar.CongressId);
            return View(webinar);
        }

        // GET: Webinars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Webinar webinar = db.Tb_Webinar.Find(id);
            if (webinar == null)
            {
                return HttpNotFound();
            }
            return View(webinar);
        }

        // POST: Webinars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Webinar webinar = db.Tb_Webinar.Find(id);
            db.Tb_Webinar.Remove(webinar);
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
        public string ObtenerRol()
        {
            string userId = User.Identity.GetUserId();
            ApplicationDbContext db = new ApplicationDbContext();
            string rol = db.Users.Where(x => x.Id == userId).FirstOrDefault().Rol.ToString();
            return rol;
        }
    }
}
