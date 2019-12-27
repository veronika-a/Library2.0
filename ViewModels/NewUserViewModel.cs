using Library.Models;
using Library.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.ViewModels
{
    public class NewUserViewModel
    {
        Reader thisreader;
        public event EventHandler Closing;

        public NewUserViewModel( Reader reader)
        {
            thisreader = reader;
        }
        private RelayCommand _back;

        public RelayCommand Back
        {
            get
            {
                return _back ??
                    (_back = new RelayCommand(obj =>
                    {
                        CatalogReaders catalog = new CatalogReaders(ref thisreader);
                        catalog.Show();
                        Closing?.Invoke(this, EventArgs.Empty);
                    }));
            }
        }
    }
}
