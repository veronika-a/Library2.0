using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Models
{
    public class AuthorCard
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column("Id")]
        private int id;
        private int authorid;
        private int bookid;
        [ForeignKey("authorid")]
        private Author author;
        [ForeignKey("bookid")]
        private Book book;

        public int Id { get => id; set => id = value; }
        public int Authorid { get => authorid; set => authorid = value; }
        public int Bookid { get => bookid; set => bookid = value; }
        public Book Book { get => book; set => book = value; }
        public Author Author { get => author; set => author = value; }
    }
}
