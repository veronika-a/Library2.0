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
        [ForeignKey("Author")]
        private int authorid;
        [ForeignKey("Book")]
        private int bookid;

        public int Id { get => id; set => id = value; }
        public int Authorid { get => authorid; set => authorid = value; }
        public int Bookid { get => bookid; set => bookid = value; }
    }
}
