using Microsoft.EntityFrameworkCore;

namespace Library_SQLI.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext>opt):base(opt) { }  
       public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
    }
}
