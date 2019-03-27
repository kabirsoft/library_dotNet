using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_data.Models
{
    public class LibraryContext : DbContext
    {
        public LibraryContext() : base("name=LibraryContextCon") {
            Database.SetInitializer<LibraryContext>(new DropCreateDatabaseIfModelChanges<LibraryContext>());            
        }
        public DbSet<Library_data.Models.Book> Books { get; set; }
        public DbSet<Library_data.Models.Cost> Cost { get; set; }
    }
}
