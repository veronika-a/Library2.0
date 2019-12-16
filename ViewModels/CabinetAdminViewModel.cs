using Library.Models;
using Library.Repository;
using Library.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Library.ViewModels
{
    
    public class CabinetAdminViewModel : INotifyPropertyChanged
    {
        private Reader reader;

        public CabinetAdminViewModel() {}
        public CabinetAdminViewModel(Reader reader)
        {
            Reader = reader;

            using (MyAppContext appContext = new MyAppContext())
            {
                ReaderCardRepository readerCardRepository = new ReaderCardRepository(appContext);
                ReaderCards = new ObservableCollection<ReaderCard>(readerCardRepository.GetAll(u => u.Status == false));

            }
        }

        public Reader Reader { get => reader; set => reader = value; }
        public event EventHandler Closing;

        public bool Validated = false;


        ObservableCollection<ReaderCard> _readerCards;
        public ObservableCollection<ReaderCard> ReaderCards
        {
            get { return _readerCards; }
            set
            {
                _readerCards = value;
                OnPropertyChanged(nameof(ReaderCards));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        ReaderCard selectedReaderCard;
        public ReaderCard SelectedReaderCard
        {
            get { return selectedReaderCard; }
            set
            {
                selectedReaderCard = value;
                OnPropertyChanged(nameof(SelectedReaderCard));
            }
        }
        private RelayCommand _DoOrder;

        public RelayCommand DoOrder
        {
            get
            {
                return _DoOrder ??
                    (_DoOrder = new RelayCommand(obj =>
                    {
                        using (MyAppContext appContext = new MyAppContext())
                        {

                            ReaderCardRepository readerCardRepository = new ReaderCardRepository(appContext);
                            var rc = readerCardRepository.GetById(SelectedReaderCard.Id);
                            rc.Status = true;
                            rc.DateTook = DateTime.Now;

                            readerCardRepository.Update(rc);
                            MessageBox.Show($" {rc.Status} !", "Update ", MessageBoxButton.OK, MessageBoxImage.Information);

                            CabinetAdmin cabinet = new CabinetAdmin();
                            cabinet.Show();
                            Closing?.Invoke(this, EventArgs.Empty);
                        }
                    }));
            }
        }
    }
}
