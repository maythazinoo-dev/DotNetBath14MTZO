using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBath14MTZO.BurmaProject.PhayarSar
{
    internal class PhayarSarRestSharpService
    {

        private readonly RestClient _restClient;

        public PhayarSarRestSharpService()
        {
            _restClient = new RestClient();
        }

        public async Task<List<PhayarSarTitle>> GetPhayarSars()
        {
            RestRequest request = new RestRequest("https://raw.githubusercontent.com/burma-project-ideas/phayar-sar/refs/heads/main/data/data.json", Method.Get);
            var response = await _restClient.GetAsync(request);
            string content = response.Content!;
            return JsonConvert.DeserializeObject<List<PhayarSarTitle>>(content)!;

        }

        public async Task<PhayarSarDetail> GetPhayarSar(int groupId, int detailId)
        {
            RestRequest request = new RestRequest($"https://raw.githubusercontent.com/burma-project-ideas/phayar-sar/refs/heads/main/data/{groupId}/{detailId}.json", Method.Get);
            var response = await _restClient.GetAsync(request);
            string content = response.Content!;
            return JsonConvert.DeserializeObject<PhayarSarDetail>(content)!;

        }
    }
}
