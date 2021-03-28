using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace E_Pharmacy.Models
{
    public class ProductModel
    {
        [Key]
        public int ProductID { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string ProductName { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string ProductPrice { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string PharmacyDetails { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string ImageName { get; set; }

        [NotMapped]
        public IFormFile ImageFile { get; set; }

        [NotMapped]
        public string ImageSrc { get; set; }

    }
}
