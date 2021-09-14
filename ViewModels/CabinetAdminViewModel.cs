using Library.Models;
using Library.Views;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Library.ViewModels
{

    public class CabinetAdminViewModel : INotifyPropertyChanged
    {
        private Reader reader;
        CabinetAdminModel cabinetAdminModel;
        public CabinetAdminViewModel(Reader reader)
        {
            Reader = reader;
            cabinetAdminModel = new CabinetAdminModel();
            ReaderCards = new ObservableCollection<ReaderCard>(cabinetAdminModel.GetReaderCards());
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
                        cabinetAdminModel.doOrder(SelectedReaderCard);
                        CabinetAdmin cabinet = new CabinetAdmin(ref reader);
                        cabinet.Show();
                        Closing?.Invoke(this, EventArgs.Empty);
                    }));
            }
        }
       
    }
}
