using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace DotNetBath14MTZO.BurmaProject.PhayarSar
{
    internal class PhayarSarRefitService
    {
        private readonly IphayarSarApi _api;
        public PhayarSarRefitService()
        {
            _api = RestService.For<IphayarSarApi>("https://raw.githubusercontent.com/");
        }

        public async Task<List<PhayarSarTitle>> GetPhayarSars()
        {
            var phayarSar = await _api.GetPhayarSars();
            return phayarSar;
        }

        public async Task<PhayarSarDetail> GetPhayarSar(int groupId, int detailId)
        {
            var phayarSar = await _api.GetPhayarSar(groupId, detailId);
            return phayarSar;
        }
    }

    public interface IphayarSarApi
    {
        [Get("/burma-project-ideas/phayar-sar/refs/heads/main/data/data.json")]
        Task<List<PhayarSarTitle>> GetPhayarSars();

        [Get("/burma-project-ideas/phayar-sar/refs/heads/main/data/{groupId}/{detailId}.json")]
        Task<PhayarSarDetail> GetPhayarSar(int groupId, int detailId);


    }
}

