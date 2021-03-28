using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace E_Pharmacy.Models
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }
        public DateTime Date_time { get; set; }
        public string Status { get; set; }
        public string Status2 { get; set; }
        public string PharmacyName { get; set; }
        public string CustomerName { get; set; }
        public string PatientName { get; set; }
        public int PatientAge { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public int TeleNo { get; set; }
        public int Customer_id { get; set; }

        //[ForeignKey("Pharmacy")]
        public int Pharmacy_id { get; set; }
        //public Pharmacy Pharmacy { get; set; }
    }
}
