using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DotNetBath14MTZO.SnakeGame.ConsoleApp
{
    public class SnakeGameHttpClient
    {
        private readonly string endpoint = "https://localhost:7057/api/snakeandladder";
        private readonly HttpClient _httpClient;
        public SnakeGameHttpClient()
        {
            _httpClient = new HttpClient();
        }

        public async Task<ResponseModel> CreateGameBoard(BoardModel RequestGameBoard)
        {
            string Json = JsonConvert.SerializeObject(RequestGameBoard);
            var StringContent = new StringContent(Json, Encoding.UTF8, Application.Json);

            HttpResponseMessage response = await _httpClient.PostAsync(endpoint, StringContent);
            string content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<ResponseModel>(content)!;
        }

        public async Task<ResponseModel> CreateGame(List<PlayerModel> RequestPlayerModel)
        {
            string content = JsonConvert.SerializeObject(RequestPlayerModel);
            var StringContent = new StringContent(content, Encoding.UTF8, Application.Json);

            HttpResponseMessage response = await _httpClient.PostAsync(endpoint, StringContent);
            string json = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<ResponseModel>(content)!;
        }

        public async Task<ResponseModel> PlayGame(int id)
        {
            string Json = JsonConvert.SerializeObject(id);
            var StringContent = new StringContent(endpoint, Encoding.UTF8, Application.Json);

            HttpResponseMessage response = await _httpClient.PostAsync(endpoint, StringContent);
            string content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<ResponseModel>(content)!;
        }
    }
}
