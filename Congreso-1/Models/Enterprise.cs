using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Congreso_1.Models
{
    public class Enterprise
    {
        [Key]
        public int EnterpriseId {get; set;}
        public int EnterpiseNit { get; set; }
        public string EnterpriseName { get; set; }
        public string EnterprisePhoneNumber { get; set; }
        public string EnterpriseEmail { get; set; }
        public int Available { get; set; }
    }
}
