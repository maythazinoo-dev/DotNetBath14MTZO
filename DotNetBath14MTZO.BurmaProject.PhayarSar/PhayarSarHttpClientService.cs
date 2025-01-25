using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBath14MTZO.BurmaProject.PhayarSar
{
    internal class PhayarSarHttpClientService
    {
        private readonly HttpClient _httpClient;
        private readonly string _endpoint = "https://raw.githubusercontent.com/burma-project-ideas/phayar-sar/refs/heads/main/data/data.json";
        public PhayarSarHttpClientService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<List<PhayarSarTitle>> GetAll()
        {

            HttpResponseMessage response = await _httpClient.GetAsync(_endpoint);
            string content = await response.Content.ReadAsStringAsync();


            return JsonConvert.DeserializeObject<List<PhayarSarTitle>>(content)!;
        }

        public async Task<PhayarSarDetail> GetPhayarSar(int groupId, int detailId)
        {

            HttpResponseMessage response = await _httpClient.GetAsync($"https://raw.githubusercontent.com/burma-project-ideas/phayar-sar/refs/heads/main/data/{groupId}/{detailId}.json");
            string content = await response.Content.ReadAsStringAsync();


            return JsonConvert.DeserializeObject<PhayarSarDetail>(content)!;

        }
    }
}
