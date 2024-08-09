using EsteraApp.Models;
using Newtonsoft.Json;

namespace EsteraApp.Services
{
    public class JokeService
    {
        private readonly HttpClient _httpClient;

        public JokeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Joke> GetRandomJokeAsync()
        {
            var response = await _httpClient.GetStringAsync("https://official-joke-api.appspot.com/random_joke");
            var joke = JsonConvert.DeserializeObject<Joke>(response);

            joke.Id = 0;

            return joke;
        }
    }
}
