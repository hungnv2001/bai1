using bai1.Models;
using Microsoft.EntityFrameworkCore;

namespace bai1.Context
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options)
        {
        }

        public MyDbContext()
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.\\sqlexpress;Initial Catalog=baic5;Integrated Security=True;Trust Server Certificate=True");
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Company> Companys { get; set; }
    }
}
