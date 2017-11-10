namespace Gajda.NovemberTests.Client.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Gajda.NovemberTests.Infrastructure;

    public interface IPeopleService
    {
        Task<IEnumerable<Person>> GetPeople();
    }
}