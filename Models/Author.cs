using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Models
{
    public class Author
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column("Id")]
        private int id;
        [MaxLength(20)]
        private string firstName;
        [MaxLength(20)]
        private string secondName;
        private DateTime? dateBorn;
        private DateTime? dateDied;
        private string nationality;


        public int Id { get => id; set => id = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string SecondName { get => secondName; set => secondName = value; }
        public DateTime? DateBorn { get => dateBorn; set => dateBorn = value; }
        public DateTime? DateDied { get => dateDied; set => dateDied = value; }
        public string Nationality { get => nationality; set => nationality = value; }


        // List<Books>



    }
}
