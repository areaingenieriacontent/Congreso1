using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Congreso_1.Models
{
    public class Congress
    {
        [Key]
        public int CongressId { get; set; }
        public string CongressName { get; set; }
        public string CongressBanner { get; set; }
        public string CongressTheme { get; set; }
        public string CongressColorA { get; set; }
        public string CongressColorB { get; set; }
        public DateTime CongressInitialDate { get; set; }
        public DateTime CongressFinalDate { get; set; }
        public bool Available { get; set; }

    }
}
