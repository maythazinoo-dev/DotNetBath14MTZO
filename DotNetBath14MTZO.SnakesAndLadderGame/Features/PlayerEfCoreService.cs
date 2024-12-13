namespace DotNetBath14MTZO.SnakesAndLadderGame.Features
{
    public class PlayerEfCoreService
    {
        private readonly AppDbContext _appDbContext;
        public PlayerEfCoreService()
        {
            _appDbContext = new AppDbContext();
        }

        public List<PlayerModel> GetPlayers() 
        {
            var playerModel = _appDbContext.gamePlayer.ToList();
            return playerModel;
        }
        public PlayerResponseModel CreateRegister(PlayerModel requestModel)
        {
            PlayerResponseModel responseModel = new PlayerResponseModel();
            var player = _appDbContext.gamePlayer.FirstOrDefault(x => x.PlayerName == requestModel.PlayerName);

            if (player is null)
            {
                _appDbContext.gamePlayer.Add(new PlayerModel
                {
                    PlayerName = requestModel.PlayerName,
                    PlayerCurrentPosition = requestModel.PlayerCurrentPosition

                });
                int result = _appDbContext.SaveChanges();
                string message = result > 0 ? "Register is Successful" : "Register is failed";

                responseModel.IsSuccess = result > 0;
                responseModel.Message = message;
                return responseModel;

            }
      
                responseModel.IsSuccess = false;
                responseModel.Message = "Player already exists";
                return responseModel;
   
        }

        public PlayerResponseModel PlayerLogin(PlayerModel requestPlayerModel) 
        { 
            var player = _appDbContext.gamePlayer.FirstOrDefault(x => x.PlayerId == requestPlayerModel.PlayerId && x.PlayerName == requestPlayerModel.PlayerName);
            if (player is not null)
            {
                return new PlayerResponseModel()
                {
                    IsSuccess = true,
                    Message = "Login Success"
                };
            }
                return new PlayerResponseModel()
                {
                    IsSuccess = false,
                    Message = "Unauthorized Player , Please Firstly Register"
                };
        }

    }
}
