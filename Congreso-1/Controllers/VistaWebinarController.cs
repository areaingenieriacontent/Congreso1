using Congreso_1.Models;
using Congreso_1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Congreso_1.Controllers
{
    public class VistaWebinarController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult CargarDetallesWebinar(int idWebinar)
        {

            var consulta = (from webinar in db.Tb_Webinar
                            where webinar.WebinarId == idWebinar
                            select new VistaWebinar
                            {
                                Tema = webinar.WebinarTheme,
                                DiaInicio = webinar.WebinarInitialDate,
                                DiaFinal = webinar.WebinarEndDate,
                                BannerPrincipal = webinar.WebinarBannerPrincipal,
                                ImagenWebinar = webinar.WebinarImagen,
                                LinkWebinar = webinar.LinkWebinar
                            }).ToList();



            return View(consulta);


        }
        public ActionResult VistaPruebaGrande()
        {
            return View();
        }
    }
}
