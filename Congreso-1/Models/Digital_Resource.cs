using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Congreso_1.Models
{
    public class Digital_Resource
    {
        [Key]
        public int ResourceId { get; set; }
        public string ResourceUrl { get; set; }
        public string ResourceHtml { get; set; }
        public bool Available { get; set; }
        public int Index { get; set; }

    }
}
