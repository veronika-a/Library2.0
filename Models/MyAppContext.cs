using Library.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    public class MyAppContext : DbContext
    {
        static MyAppContext() 
        {
            Database.SetInitializer(new ContextInitializer());
        }
        public MyAppContext() : base("LibraryDbConnection") { }

        public DbSet<Book> Books { get; set; }
        public DbSet<Reader> Readers { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Chapter> Chapters { get; set; }
        public DbSet<ReaderCard> ReaderCards { get; set; }
        public DbSet<AuthorCard> AuthorCards { get; set; }


    }
}
