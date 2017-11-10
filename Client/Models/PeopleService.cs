namespace Gajda.NovemberTests.Client.Models
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;

    using Gajda.NovemberTests.Client.Interfaces;

    using Newtonsoft.Json;

    public class PeopleService : IPeopleService
    {
        private string url = "http://localhost:12345/api/people/";

        public async Task<IEnumerable<Infrastructure.Person>> GetPeople()
        {
            var json = await this.GetString();

            try
            {
                var people = JsonConvert.DeserializeObject<List<Infrastructure.Person>>(
                    json,
                    new JsonSerializerSettings { NullValueHandling = NullValueHandling.Include });
                return people;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }

            return null;
        }

        private async Task<string> GetString()
        {
            var client = new HttpClient();
            var response = await client.GetAsync(this.url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}