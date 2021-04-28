using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Congreso_1.Models
{
    public class Stand_Resource
    {
        [Key]
        [Column(Order = 0)]
        [ForeignKey("Stand")]
        public int StandId { get; set; }
        public virtual Stand Stand { get; set; }
        [Key]
        [Column(Order = 1)]
        [ForeignKey("Digital_Resource")]
        public int DResourceId {get; set;}
        public virtual Digital_Resource Digital_Resource { get; set; }

    }
}
