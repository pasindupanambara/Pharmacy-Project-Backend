using E_Pharmacy.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Pharmacy.Data
{
    public class PharmacyDataContext: DbContext
    {
        public PharmacyDataContext(DbContextOptions<PharmacyDataContext> options):base(options)
        {

        }
        public DbSet<Login> Login { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Message> Message { get; set; }
        public DbSet<Pharmacy> Pharmacy { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<ProductModel> Products { get; set; }


    }
}
