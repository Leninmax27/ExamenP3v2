using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenP3v2.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<string> GetJoke()
        {
            var response = await _httpClient.GetStringAsync("https://api.chucknorris.io/jokes/random");
            var joke = JsonConvert.DeserializeObject<JokeApiResponse>(response);
            return joke.Value;
        }
    }

    public class JokeApiResponse
    {
        public string Value { get; set; }
    }

}
