namespace Library.Migrations
{
    using Library.Models;
    using Library.Repository;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;

    public class ContextInitializer : CreateDatabaseIfNotExists<MyAppContext>
    {
        private ReaderRepository readerRepository;
        protected override void Seed(MyAppContext mainContext)
        {
            readerRepository = new ReaderRepository(mainContext);
            InitializeUsers();
        }


        private void InitializeUsers()
        {

            List<Reader> users = new List<Reader>
            {

                 new Reader() {Email="user@gmail.com", Password="user", Gender="man", Phone="", FirstName = "user", SecondName = "user", Date = new DateTime(2000, 8, 28) },
                 new Reader() {Email="admin@gmail.com", Password="admin", Gender="female", Phone="0930000000", FirstName = "admin", SecondName = "admin", Date = new DateTime(2000, 01, 06) }

                 // new Author() { FirstName = "Лев", SecondName = "Толстой", DateBorn = new DateTime(1828, 8, 28), DateDied = new DateTime(1910, 11, 7), Nationality = "Россия" }

                //new Reader{Login = "user", Password = "user", Admin = false},
                //new Reader { Login = "admin", Password = "admin", Admin = true }
            };
            foreach (Reader user in users)
            {
                readerRepository.Insert(user);
            }
        }

    }
}
