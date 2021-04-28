using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Congreso_1.Models
{
    public class Stand
    {
        [Key]
        public int Stand_id { get; set; }
        public string StandName { get; set; }

        [ForeignKey("Stand_Type")]
        public int StandTypeId { get; set; }
        public virtual Stand_Type Stand_Type { get; set; }
        public string EnterpriseLogo { get; set; }
        public string EnterpriseBanner { get; set; }
        public string StandColorA { get; set; }
        public string StandColorB { get; set; }
        public string StandColorC { get; set; }
        public bool Available { get; set; }
    }
}
