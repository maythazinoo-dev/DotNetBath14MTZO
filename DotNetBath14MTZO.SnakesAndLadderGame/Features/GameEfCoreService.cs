using Microsoft.EntityFrameworkCore;

namespace DotNetBath14MTZO.SnakesAndLadderGame.Features
{
    public class GameEfCoreService
    {
        private readonly AppDbContext _appDbContext;
        public GameEfCoreService()
        {
            _appDbContext = new AppDbContext();
        }

        public List<GameModel> GetGames()
        {
            var game = _appDbContext.game.AsNoTracking().ToList();
            return game;
        }
        public GameModel GetGameById(int id)
        { 
            var game = _appDbContext.game.AsNoTracking().FirstOrDefault(x => x.GameId == id);
            return game!;
        }

        public GameResponseModel CreateGame(GameModel requestGame)
        {
            _appDbContext.game.Add(requestGame);
            int result = _appDbContext.SaveChanges();
            string message = result > 0 ? " Create Game successful" : "Create Game Failed";
            GameResponseModel response = new GameResponseModel();
            response.IsSuccess = result > 0;
            response.Message = message;
            return response;

        }
    }
}
