namespace Gajda.NovemberTests.Client.ViewModels
{
    using System.Linq;
    using System.Windows.Input;

    using Gajda.NovemberTests.Client.Extensions;

    public partial class MainWindowViewModel
    {
        public ICommand SearchCommand
        {
            get
            {
                return new RelayCommand(this.Search, this.CanSearch);
            }
        }

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
                                   select person)
            {
                this.People.Add(person);
            }
        }

        public bool CanSearch(object parameter)
        {
            var value = parameter as string;

            return !string.IsNullOrEmpty(value);
        }
    }
}