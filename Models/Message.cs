using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_Pharmacy.Models
{
    public class Message
    {
        [Key]
        public int MessageId { get; set; }
        public DateTime M_date_time { get; set; }
        public string Status { get; set; }
        public string Text { get; set; }
        public int Sender_id { get; set; }
        public int Reciever_id { get; set; }
    }
}
