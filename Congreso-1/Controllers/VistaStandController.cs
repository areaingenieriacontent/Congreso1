using Congreso_1.Models;
using Congreso_1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Congreso_1.Controllers
{
    public class VistaStandController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        //Controlador para cargar los datos e imagenes para usuario final en este controlador se cargan los tres tipos de congreso pero dependiendo el tamaño se muestra en la vista.
        public ActionResult CargarDetalles(int idStand)
        {

            var consulta = (from stands in db.Tb_Stand
                            join StandsResource in db.Tb_Stand_Resource on stands.Stand_id equals StandsResource.StandId
                            join Resouces in db.Tb_Digitar_Resource on StandsResource.DResourceId equals Resouces.ResourceId
                            where stands.Stand_id == idStand
                            select new VistaStand
                            {
                                Banner = stands.EnterpriseBanner,
                                Logo = stands.EnterpriseLogo,
                                Url = Resouces.ResourceUrl,
                                Recurse = Resouces.ResourceHtml,
                                //ColorA = stands.StandColorA,
                                //ColorB = stands.StandColorB,
                                //ColorC = stands.StandColorC,
                                Index = Resouces.Index,
                                Tamaño = stands.StandTypeId
                            }).ToList();



            return View(consulta);


        }
        public ActionResult VistaPruebaGrande()
        {
            return View();
        }
        public ActionResult VistaPruebaMediana()
        {
            return View();
        }
        public ActionResult VistaPruebaPequeño()
        {
            return View();
        }
    }
}