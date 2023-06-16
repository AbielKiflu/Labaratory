using Microsoft.EntityFrameworkCore;

namespace DbAcess.DataAcess
{
    public class MyDataContext : DbContext
    {
        public  MyDataContext(DbContextOptions options):base(options){ }

    }
}