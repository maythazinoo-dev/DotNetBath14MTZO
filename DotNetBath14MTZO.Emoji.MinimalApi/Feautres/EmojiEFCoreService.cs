using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace DotNetBath14MTZO.Emoji.MinimalApi.Feautres
{
    public class EmojiEFCoreService
    {

        private readonly EmojiAppDBContext _dbContext;
        private readonly HttpClient _httpClient;
        private readonly string _endpoint;

        public EmojiEFCoreService()
        {
            _dbContext = new EmojiAppDBContext();
            _httpClient = new HttpClient();
            _endpoint = "https://gist.githubusercontent.com/oliveratgithub/0bf11a9aff0d6da7b46f1490f86a71eb/raw/d8e4b78cfe66862cf3809443c1dba017f37b61db/emojis.json";

        }

        public async Task SavingDataAsync()
        {
            HttpResponseMessage response = await _httpClient.GetAsync(_endpoint);
            string content = await response.Content.ReadAsStringAsync();

            var requestModel = JsonConvert.DeserializeObject<EmojiRequestModel>(content);
            if (requestModel?.Emojis != null)
            {
                foreach (var emoji in requestModel.Emojis)
                {

                    await _dbContext.AddAsync(emoji);
                    await _dbContext.SaveChangesAsync();

                }
            }
        }

        public async Task<EmojiListResponseModel> GetEmojiAsync()
        {
            var emojis = await _dbContext.EmojiModels.ToListAsync();
            return new EmojiListResponseModel
            {
                IsSuccess = true,
                Message = "Get All Emoji Success",
                Data = emojis
            };
         }

        public async Task<EmojiResponseModel> GetEmojiByIdAsync(int id)
        {
            EmojiResponseModel emojiResponseModel = new EmojiResponseModel();
            var emoji = await _dbContext.EmojiModels.FindAsync(id);
            if(emoji is null)
            {
              
                emojiResponseModel.IsSuccess = false;
                emojiResponseModel.Message = "Data not found";
                
                return emojiResponseModel;
            }

            emojiResponseModel.IsSuccess = true;
            emojiResponseModel.Message = " Success";
            emojiResponseModel.Data= emoji;
            return emojiResponseModel;

        }

        public async Task<EmojiListResponseModel> FilterByName(string name)
        {
            //var emojilist = await _dbContext.EmojiModels.Where(x => x.Name.Contains($"%{name}%")).ToListAsync();
            var emojilist = await _dbContext.EmojiModels.Where(x => x.Name.Contains(name)).ToListAsync();
            EmojiListResponseModel emojiResponseModel= new EmojiListResponseModel();
            emojiResponseModel.IsSuccess= true;
            emojiResponseModel.Message = "Filter By Name Success";
            emojiResponseModel.Data = emojilist;
            return emojiResponseModel;
        }
    }
}

   

    

