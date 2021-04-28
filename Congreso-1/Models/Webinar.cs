using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Congreso_1.Models
{
    public class Webinar
    {
        [Key]
        public int WebinarId { get; set; }
        // Sirve para poner el tema del Webinar

        [Display(Name = "Nombre")]
        public string WebinarTheme { get; set; }
        [Display(Name = "Banner Principal")]
        public string WebinarBannerPrincipal { get; set; }
        [Display(Name = "Imagen")]
        public string WebinarImagen { get; set; }
        [Display(Name = "Link")]
        public string LinkWebinar { get; set; }

        [Display(Name = "Fecha y hora de inicio")]
        [DataType(DataType.DateTime)]
        public DateTime WebinarInitialDate { get; set; }

        [Display(Name = "Fecha y hora de finalización")]
        [DataType(DataType.DateTime)]
        public DateTime WebinarEndDate { get; set; }

        [Display(Name = "Disponible")]
        public bool available { get; set; }

        [ForeignKey("Congress")]
        public int CongressId { get; set; }

        public virtual Congress Congress { get; set; }


    }
}
