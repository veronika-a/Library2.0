using Library.Repository;
using Library.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Library.Models
{
    public class CabinetAdminModel
    {
        public void doOrder(ReaderCard SelectedReaderCard)
        {
            using (MyAppContext appContext = new MyAppContext())
            {

                ReaderCardRepository readerCardRepository = new ReaderCardRepository(appContext);
                var rc = readerCardRepository.GetById(SelectedReaderCard.Id);
                rc.Status = true;
                rc.DateTook = DateTime.Now;

                readerCardRepository.Update(rc);
                MessageBox.Show($" {rc.Status} !", "Update ", MessageBoxButton.OK, MessageBoxImage.Information);

                
            }
        }
        public ObservableCollection<ReaderCard> GetReaderCards()
        {
            using (MyAppContext appContext = new MyAppContext())
            {
                ReaderCardRepository readerCardRepository = new ReaderCardRepository(appContext);
                var ReaderCards = new ObservableCollection<ReaderCard>(readerCardRepository.GetAll(u => u.Status == false));
                return ReaderCards;
            }

        }
    }
}
