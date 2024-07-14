using Microsoft.EntityFrameworkCore;

namespace Library_Sqli_Api.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext>opt):base(opt) { }  
       public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
    }
}
