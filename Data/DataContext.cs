using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DataContext : DbContext
    {
        public DbSet<User>Users { get; set; }
        public DbSet<Tenant>Tenants { get; set; }
        public DbSet<Landlord> Landlords { get; set;}
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Apartment> Apartments { get; set; } 
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    }
}
