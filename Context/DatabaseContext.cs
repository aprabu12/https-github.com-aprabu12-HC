using System.Data.Entity;
using HCServices.Models;

namespace HCServices.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("DefaultConnection") { }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<User> Users { get; set; }
        
    }
}