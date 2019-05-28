using Microsoft.EntityFrameworkCore;
using Test.Model;

namespace Test.Service
{
    public class MyContext:DbContext
    {
        public MyContext(DbContextOptions<MyContext> options):base(options)
        {

        }
        public DbSet<User> User { get; set; }
    }
}
