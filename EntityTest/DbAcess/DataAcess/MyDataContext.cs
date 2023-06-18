using DbAcess.Models;
using Microsoft.EntityFrameworkCore;

namespace DbAcess.DataAcess
{
    public class MyDataContext : DbContext
    {
        public MyDataContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }


    }
}