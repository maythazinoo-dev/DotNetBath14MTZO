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
            _api = RestService.For<IphayarSarApi>("https://burma-project-ideas.vercel.app/");
        }

        public async Task<List<PhayarSarModel>> GetPhayarSars()
        {
            var phayarSar = await _api.GetPhayarSars();
            return phayarSar;
        }

        public async Task<PhayarSarModel> GetPhayarSar(int groupId, int detailId)
        {
            var phayarSar = await _api.GetPhayarSar(groupId,detailId);
            return phayarSar;
        }
    }

    public interface IphayarSarApi
    {
        [Get("/PhayarSar")]
        Task<List<PhayarSarModel>> GetPhayarSars();

        [Get("/PhayarSar/{id}")]
        Task<PhayarSarModel> GetPhayarSar(int groupId, int detailId);


    }
}

