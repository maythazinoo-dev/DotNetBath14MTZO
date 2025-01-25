namespace DotNetBath14MTZO.SnakesAndLadderGame.Features
{
    public class GameMoveEFCoreService
    {
        private readonly AppDbContext _appDbContext;
        public GameMoveEFCoreService()
        {
            _appDbContext = new AppDbContext();
        }

        public GameResponseModel CreateGame(GameModel requestGameModel)
        {
            var player = _appDbContext.game.FirstOrDefault(x => x.CurrentPlayerId == requestGameModel.CurrentPlayerId);
            if (player is null)
            {
                return new GameResponseModel
                {
                    IsSuccess = false,
                    Message = "Game not Found"
                };
            }

            _appDbContext.game.Add(requestGameModel);
            int result = _appDbContext.SaveChanges();
            string message = result > 0 ? "Game Create is Successful" : "Game Create is failed";
            GameResponseModel gameResponseModel = new GameResponseModel();
            gameResponseModel.IsSuccess = result > 0;
            gameResponseModel.Message = message;
            return gameResponseModel;
        }

        public GameResponseModel GameInvitePlayer(GameModel requestGameModel)
        {
            var game = _appDbContext.game.FirstOrDefault(x => x.GameId == requestGameModel.GameId);
            
            if (game is null)
            {
                return new GameResponseModel
                {
                    IsSuccess = false,
                    Message = "Not found game ,Please game create"
                };
            }
         
            else if (game.GameStatus == "Completed")
            {
                return new GameResponseModel
                {
                    IsSuccess = false,
                    Message = "Game is completed"
                };
            }
           

            var gameplayer = new GameModel
            {
                
                GameStatus = requestGameModel.GameStatus,
                CurrentPlayerId = requestGameModel.CurrentPlayerId

            };

            _appDbContext.game.Add(gameplayer);
            int result =_appDbContext.SaveChanges();
            string message = result > 0 ? "Invitation successful" : "Invitation failed";
            GameResponseModel response = new GameResponseModel();
            response.IsSuccess = result > 0;
            response.Message = message; 
            return response;

        }

        //public GameMoveResponseModel MoveGame(GameMoveModel requestgameMoveModel)
        //{
        //    var game = _appDbContext.gameMove.FirstOrDefault(x => x.GameId == requestgameMoveModel.GameId);
        //    var player = _appDbContext.gamePlayer.FirstOrDefault(x =>x.PlayerId == requestgameMoveModel.PlayerId);

        //    if (game is null)
        //    {
        //        return new GameMoveResponseModel
        //        {
        //            IsSuccess = false,
        //            Message="Game not found"
        //        };
        //    }
        //    if (player is null)
        //    {
        //        return new GameMoveResponseModel
        //        { 
        //            IsSuccess = false,
        //            Message="Player Not found"
        //        };
        //    }
        //    var dieRoll = new Random().Next(1, 7);
          



        }
    }
}
