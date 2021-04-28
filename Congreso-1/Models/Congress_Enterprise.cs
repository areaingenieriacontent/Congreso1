using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Congreso_1.Models
{
    public class Congress_Enterprise
    {
        [Key]
        [Column(Order = 0)]
        [ForeignKey("Congress")]
        public int CongressId { get; set; }
        public virtual Congress Congress { get; set; }
        [Key]
        [Column(Order = 1)]
        [ForeignKey("Enterprise")]
        public int EnterpriseId { get; set; }
        public virtual Enterprise Enterprise { get; set; }
        [Key]
        [Column(Order = 2)]
        [ForeignKey("Stand")]
        public int StandId { get; set; }
        public virtual Stand Stand { get; set; }
    }
}
