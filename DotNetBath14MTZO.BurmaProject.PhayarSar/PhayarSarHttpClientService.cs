using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBath14MTZO.BurmaProject.PhayarSar
{
    internal class PhayarSarHttpClientService
    {
        private readonly HttpClient _httpClient;
        private readonly string _endponit = "https://burma-project-ideas.vercel.app";
        public PhayarSarHttpClientService()
        {
            _httpClient = new HttpClient();
        }


        public async Task<List<PhayarSarModel>> GetPhayarSar()
        {

            HttpResponseMessage response = await _httpClient.GetAsync(_endponit);
            string content = await response.Content.ReadAsStringAsync();
            Console.WriteLine(content);
            return JsonConvert.DeserializeObject<List<PhayarSarModel>>(content)!;

        }

        public async Task<List<PhayarSarModel>> GetPhayarSar(int groupId, int iddetailId)
        {

            HttpResponseMessage response = await _httpClient.GetAsync(_endponit);
            string content = await response.Content.ReadAsStringAsync();
            Console.WriteLine(content);
            return JsonConvert.DeserializeObject<List<PhayarSarModel>>(content)!;

        }
    }
}
