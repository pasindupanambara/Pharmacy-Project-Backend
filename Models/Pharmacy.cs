using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_Pharmacy.Models
{
    public class Pharmacy
  
    {
        [Key]
        public int Id { get; set; }
        public string RegNo { get; set; }
        public string Pharmacyname { get; set; }
        public string Address { get; set; }
        public string District { get; set; }
        public string Email { get; set; }
        public string TeleNo { get; set; }
        public string Password { get; set; }
    }
}
