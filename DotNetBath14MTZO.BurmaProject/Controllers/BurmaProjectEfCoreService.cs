using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DotNetBath14MTZO.BurmaProject.Shared
{
    public class BurmaProjectEfCoreService
    {
        private readonly AppDbContext _appDbContext;
        private readonly HttpClient _httpClient;
        private readonly string _endPoint;

        public BurmaProjectEfCoreService()
        {
            _appDbContext = new AppDbContext();
            _httpClient = new HttpClient();
            _endPoint = "https://github.com/burma-project-ideas/phayar-sar/blob/main/data/data.json";
        }
        public async Task SaveDataFromJsonAsync()
        {
            var jsonResponse = await _httpClient.GetAsync(_endPoint);
            string content = await jsonResponse.Content.ReadAsStringAsync();
            var groups = JsonConvert.DeserializeObject<List<BurmaProjectModel>>(content);

            if(groups == null || groups.Count == 0)
            {
                foreach (var group in groups)
                {
                    _appDbContext.Add<BurmaProjectModel>(group);
                    _appDbContext.SaveChanges();

                    foreach (var GroupData in group.DataItems)
                    {
                        GroupData.groupId = group.groupId;

                    }
                    _appDbContext.groupData.Add;

                }
            }
                   
        }
    }
}
