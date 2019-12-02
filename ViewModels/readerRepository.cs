using Library.Models;

namespace Library.ViewModels
{
    internal class readerRepository
    {
        private MyAppContext appContext;

        public readerRepository(MyAppContext appContext)
        {
            this.appContext = appContext;
        }
    }
}