using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Congreso_1.Models
{
    public class Schedule
    {
        [Key]
        public int ScheduleId { get; set; }
        // Activa o descativa el Schedule
        public bool Available { get; set; }
        // FK a Webinar
        [ForeignKey("Webinar")]
        public int Webinar_Id { get; set; }
        public virtual Webinar Webinar { get; set; }
    }
        
}
