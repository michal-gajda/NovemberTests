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
                        MiddleName = string.Empty,
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