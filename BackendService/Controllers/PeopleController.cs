namespace BackendService.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Web.Http;

    using Gajda.NovemberTests.Infrastructure;

    using Newtonsoft.Json;

    public class PeopleController : ApiController
    {
        private readonly List<Person> people = new List<Person>();

        public PeopleController()
        {
            this.people.Add(
                new Person
                    {
                        Id = new Guid("133e4066-9e6e-4ae1-8f5c-05dd6f87f87e"),
                        FirstName = "Tom",
                        LastName = "Cruise",
                        DateOfBirth = new DateTime(1962, 7, 3)
                    });

            this.people.Add(
                new Person
                    {
                        Id = new Guid("2338de98-2fce-4926-b276-8fa052abb223"),
                        FirstName = "Julia",
                        MiddleName = "Fiona",
                        LastName = "Roberts",
                        DateOfBirth = new DateTime(1967, 10, 28)
                    });

            this.people.Add(
                new Person
                    {
                        Id = Guid.NewGuid(),
                        FirstName = "Leonardo",
                        MiddleName = "Wilhelm",
                        LastName = "DiCaprio",
                        DateOfBirth = new DateTime(1978, 11, 11)
                    });

            this.people.Add(
                new Person
                    {
                        Id = Guid.NewGuid(),
                        FirstName = "Tom",
                        LastName = "Hanks",
                        DateOfBirth = new DateTime(1956, 7, 9)
                    });

            this.people.Add(
                new Person
                    {
                        Id = Guid.NewGuid(),
                        FirstName = "Audrey",
                        LastName = "Hupburn",
                        DateOfBirth = new DateTime(1993, 5, 4)
                    });

            this.people.Add(
                new Person
                    {
                        Id = Guid.NewGuid(),
                        FirstName = "Jack",
                        MiddleName = "Joseph",
                        LastName = "Nicholson",
                        DateOfBirth = new DateTime(1937, 4, 22)
                    });

            this.people.Add(
                new Person
                    {
                        Id = Guid.NewGuid(),
                        FirstName = "Meg",
                        LastName = "Ryan",
                        DateOfBirth = new DateTime(1961, 11, 19)
                    });

            this.people.Add(
                new Person
                    {
                        Id = Guid.NewGuid(),
                        FirstName = "Arnold",
                        MiddleName = "Alois",
                        LastName = "Schwarzenegger",
                        DateOfBirth = new DateTime(1947, 7, 30)
                    });

            this.people.Add(
                new Person
                    {
                        Id = Guid.NewGuid(),
                        FirstName = "Meryl",
                        MiddleName = "Louise",
                        LastName = "Streep",
                        DateOfBirth = new DateTime(1949, 6, 22)
                    });
        }

        [HttpGet]
        public HttpResponseMessage Index()
        {
            string json = JsonConvert.SerializeObject(
                this.people,
                Formatting.Indented,
                new JsonSerializerSettings { NullValueHandling = NullValueHandling.Include });

            return new HttpResponseMessage
                       {
                           Content = new StringContent(
                               json,
                               System.Text.Encoding.UTF8,
                               "application/json")
                       };
        }
    }
}