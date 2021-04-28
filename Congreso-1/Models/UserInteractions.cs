using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Congreso_1.Models
{
    public class UserInteractions
    {
        [Key]
        public int UserInteractionsId { get; set; }
        [ForeignKey("User_ID")]
        public string UserId { get; set; }
        public virtual ApplicationUser User_ID { get; set; }
        public int StandId { get; set; }
        public int StandCount { get; set; }
        public int ResourceId { get; set; }
        public int ResourceCount { get; set; }
        public int WebinarId { get; set; }
    }
}
