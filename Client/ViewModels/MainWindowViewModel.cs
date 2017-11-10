namespace Gajda.NovemberTests.Client.ViewModels
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Gajda.NovemberTests.Client.Extensions;
    using Gajda.NovemberTests.Client.Interfaces;
    using Gajda.NovemberTests.Client.Models;

    public sealed partial class MainWindowViewModel : BaseViewModel
    {
        private readonly IPeopleService peopleService = new PeopleService();

        private readonly List<Person> source = new List<Person>();

        public MainWindowViewModel()
        {
            Task.Run(async () => await this.Init());
        }

        private async Task Init()
        {
            foreach (var person in await this.peopleService.GetPeople())
            {
                this.source.Add(person.Map());
            }

            foreach (var person in from person in this.source orderby person.LastName select person)
            {
                this.People.Add(person);
            }

            this.Status = "Ready";
        }
    }
}