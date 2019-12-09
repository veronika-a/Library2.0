using Library.Models;
using Library.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.ViewModels
{
    public class CatalogReadersViewModel : INotifyPropertyChanged
    {
        //ObservableCollection<UserModel> selectedUsers;
        public event EventHandler Closing;


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        Reader _reader;

        ObservableCollection<Reader> _readers;
        public ObservableCollection<Reader> Readers
        {
            get { return _readers; }
            set
            {
                _readers = value;
                OnPropertyChanged(nameof(Readers));
            }
        }
        public CatalogReadersViewModel()
        {
            Readers = new ObservableCollection<Reader>(GetReaders());
        }

        List<Reader> GetReaders()
        {
            List<Reader> allreaders = new List<Reader>();

            using (MyAppContext appContext = new MyAppContext())
            {
                ReaderRepository readerRepository = new ReaderRepository(appContext);
                return (List<Reader>)readerRepository.GetAll();
            }
        }

        private string _search;
        public string Search
        {
            get { return _search; }
            set
            {
                _search = value;
                OnPropertyChanged(nameof(Search));

                // does not work
                Readers = new ObservableCollection<Reader>(GetReaders().Where(i => i.Email.Contains(Search)));
                                                                                // || i.FirstName.Contains(Search)
                                                                               // || i.SecondName.Contains(Search))); ;

            }
        }
    }
}
