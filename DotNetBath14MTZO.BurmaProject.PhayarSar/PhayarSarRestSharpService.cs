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
        private readonly string _endpoint = "https://burma-project-ideas.vercel.app";
        private readonly RestClient _restClient;

        public PhayarSarRestSharpService()
        {
            _restClient = new RestClient(_endpoint);
        }

        public async Task<List<PhayarSarModel>> GetPhayarSars()
        {
            RestRequest request = new RestRequest("PhayarSar",Method.Get);
            var response = await _restClient.GetAsync(request);
            string content = response.Content!;
            return JsonConvert.DeserializeObject<List<PhayarSarModel>>(content)!;

        }

        public async Task<PhayarSarModel> GetPhayarSar(int groupId, int DetailId)
        {
            RestRequest request = new RestRequest($"PhayarSar/{id}",Method.Get);
            var response = await _restClient.GetAsync(request);
            string content = response.Content!;
            return JsonConvert.DeserializeObject<PhayarSarModel>(content)!;

        }
    }
}
