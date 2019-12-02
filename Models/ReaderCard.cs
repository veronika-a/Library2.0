using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Models
{
    public class ReaderCard
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column("Id")]
        private int id;
        [ForeignKey("Reader")]
        private int readerid;
        [ForeignKey("Book")]
        private int bookid;
        private DateTime? dateOrdered;
        private DateTime? dateTook;
        private DateTime? dateReturn;

       

        public int Id { get => id; set => id = value; }
        public DateTime? DateOrdered { get => dateOrdered; set => dateOrdered = value; }
        public DateTime? DateTook { get => dateTook; set => dateTook = value; }
        public DateTime? DateReturn { get => dateReturn; set => dateReturn = value; }
        public int ReaderId { get => readerid; set => readerid = value; }
        public int BookId { get => bookid; set => bookid = value; }
    }
}
