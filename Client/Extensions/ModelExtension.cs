namespace Gajda.NovemberTests.Client.Extensions
{
    using Gajda.NovemberTests.Infrastructure;

    public static class ModelExtension
    {
        public static Gajda.NovemberTests.Infrastructure.Person Map(
            this Gajda.NovemberTests.Client.Models.Person source)
        {
            return new Person
                       {
                           Id = source.Id,
                           DateOfBirth = source.DateOfBirth,
                           FirstName = source.FirstName,
                           MiddleName = source.MiddleName,
                           LastName = source.LastName
                       };
        }

        public static Gajda.NovemberTests.Client.Models.Person Map(
            this Gajda.NovemberTests.Infrastructure.Person source)
        {
            return new Gajda.NovemberTests.Client.Models.Person
                       {
                           Id = source.Id,
                           DateOfBirth = source.DateOfBirth,
                           FirstName = source.FirstName,
                           MiddleName = source.MiddleName,
                           LastName = source.LastName
                       };
        }

    }
}