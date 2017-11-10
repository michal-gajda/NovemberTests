namespace Gajda.NovemberTests.Client.ViewModels
{
    using System.Collections.ObjectModel;

    using Gajda.NovemberTests.Client.Extensions;
    using Gajda.NovemberTests.Client.Models;

    public partial class MainWindowViewModel
    {
        private string searchValue = string.Empty;

        private string status = string.Empty;

        private DispatchingObservableCollection<Person> people = new DispatchingObservableCollection<Person>();

        public string SearchValue
        {
            get
            {
                return this.searchValue;
            }

            set
            {
                this.searchValue = value;
                this.OnPropertyChanged();
            }
        }

        public string Status
        {
            get
            {
                return this.status;
            }

            set
            {
                if (!value.Equals(this.status))
                {
                    this.status = value;
                    this.OnPropertyChanged();
                }
            }
        }


        public DispatchingObservableCollection<Person> People
        {
            get
            {
                return this.people;
            }

            set
            {
                this.people = value;
                this.OnPropertyChanged();
            }
        }
    }
}
