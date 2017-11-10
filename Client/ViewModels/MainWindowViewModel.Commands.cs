namespace Gajda.NovemberTests.Client.ViewModels
{
    using System.Linq;
    using System.Windows.Input;

    using Gajda.NovemberTests.Client.Extensions;

    public partial class MainWindowViewModel
    {
        public ICommand SearchCommand => new RelayCommand(this.Search, this.CanSearch);
        public ICommand ResetCommand => new RelayCommand(this.Reset);


        private void Search(object parameter)
        {
            var value = parameter as string;
            if (string.IsNullOrEmpty(value))
            {
                return;
            }

            this.People.Clear();

            foreach (var person in from person in this.source
                                   where person.FirstName.Contains(value)
                                         || !string.IsNullOrEmpty(person.MiddleName)
                                             && person.MiddleName.Contains(value) || person.LastName.Contains(value)
                                             orderby person.LastName
                                   select person)
            {
                this.People.Add(person);
            }
        }

        private bool CanSearch(object parameter)
        {
            var value = parameter as string;

            return !string.IsNullOrEmpty(value);
        }

        private void Reset(object parameter)
        {
            this.SearchValue = string.Empty;
            this.People.Clear();

            foreach (var person in from person in this.source orderby person.LastName select person)
            {
                this.People.Add(person);
            }
        }
    }
}