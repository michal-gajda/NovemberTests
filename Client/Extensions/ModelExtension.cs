namespace Gajda.NovemberTests.Client.Extensions
{
    using Gajda.NovemberTests;

    public static class ModelExtension
    {
        public static Infrastructure.Person Map(this Models.Person source)
        {
            if (source == null)
            {
                return null;
            }

            return new Infrastructure.Person
                       {
                           Id = source.Id,
                           DateOfBirth = source.DateOfBirth,
                           FirstName = source.FirstName,
                           MiddleName = source.MiddleName,
                           LastName = source.LastName
                       };
        }

        public static Models.Person Map(this Infrastructure.Person source)
        {
            if (source == null)
            {
                return null;
            }

            return new Models.Person
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