using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Congreso_1.ViewModels
{
    public class VistaWebinar
    {
        public string Tema { get; set; }
        public DateTime DiaInicio { get; set; }
        public DateTime DiaFinal { get; set; }
        public string BannerPrincipal { get; set; }
        public string ImagenWebinar { get; set; }
        public string LinkWebinar { get; set; }
    }
}