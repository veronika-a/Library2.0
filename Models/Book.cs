using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Models
{
    public class Book
    //: INotifyPropertyChanged
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column("Id")]
        private int id;
        private string title;
        private string ganre;
        private string location;
        private string edition;

        public int Id { get => id; set => id = value; }
        public string Title { get => title; set => title = value; }
        public string Ganre { get => ganre; set => ganre = value; }
        public string Location { get => location; set => location = value; }
        public string Edition { get => edition; set => edition = value; }


        //Author author;
        //string code;
        //List<Chapter>;





        // OnPropertyChanged("Id");


        //public static List<Book> GetBooks()
        //{
        //    var result = new List<BookDTO>
        //    {
        //        //new Book(){ Author="Лев Толстой", Title="Война и мир" },
        //       // new Book(){ Author="Михаил Булгаков", Title="Мастер и Маргарита" },
        //        //new Book(){ Author="Михаил Булгаков", Title="Оно" }
        //    };
        //    BookService bookService = new BookService();
        //    foreach (var bo in result)
        //    {
        //        bookService.Add(bo);
        //    }
        //    return result;
        //}


        void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }

}
