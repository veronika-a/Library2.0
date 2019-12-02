using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
     class MyAppContext : DbContext
    {
        public MyAppContext() : base("DbConnection")
        {
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Reader> Readers { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Chapter> Chapters { get; set; }
        public DbSet<ReaderCard> ReaderCards { get; set; }
        public DbSet<AuthorCard> AuthorCards { get; set; }


    }
}
