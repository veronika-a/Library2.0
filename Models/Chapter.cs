
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Models
{
    public class Chapter
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column("Id")]
        private int id;
        private int bookid;
        private double number;
        private string title;
        private int firstPage;
        private int lastPage;
        [ForeignKey("bookid")]
        private Book book;

        public int Id { get => id; set => id = value; }
        public double Number { get => number; set => number = value; }
        public string Title { get => title; set => title = value; }
        public int FirstPage { get => firstPage; set => firstPage = value; }
        public int LastPage { get => lastPage; set => lastPage = value; }
        public int BookId { get => bookid; set => bookid = value; }
        public Book Book { get => book; set => book = value; }
    }
}
