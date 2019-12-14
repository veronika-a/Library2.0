using Library.Models;
using Library.Repository;
using Library.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Library.ViewModels
{
    public class CabinetReaderViewModel : INotifyPropertyChanged
    {
        private Reader reader;


        public CabinetReaderViewModel(Reader reader)
        {
            Reader = reader;

        }

        public Reader Reader { get => reader; set => reader = value; }

        public event EventHandler Closing;

        public bool Validated = false;


        //void Reload()
        //{
        //    using (MyAppContext appContext = new MyAppContext())
        //    {
        //        cabinetReaderViewModel = new CabinetReaderViewModel(reader);
        //        readerRepository = new ReaderRepository(appContext);

        //        // foreach (MessageModel model in messagesRepository.GetAll(i => i.ChatID == SelectedChat.Id))

        //        Email = reader.Email;
        //        Phone = reader.Phone;
        //        Name = reader.FirstName +" "+ reader.SecondName;
        //        Date = reader.Date.ToString();


        //    }
        //}

        private RelayCommand _setting;

        public RelayCommand Setting
        {
            get
            {
                return _setting ??
                    (_setting = new RelayCommand(obj =>
                    {
                        ProfileSettingsReader profileSettingsReader = new ProfileSettingsReader(ref reader);
                        profileSettingsReader.Show();
                        Closing?.Invoke(this, EventArgs.Empty);
                    }));
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

    }
}
