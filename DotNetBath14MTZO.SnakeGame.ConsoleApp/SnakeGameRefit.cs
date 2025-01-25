using Refit;


namespace DotNetBath14MTZO.SnakeGame.ConsoleApp
{
    public class SnakeGameRefit
    {

        private readonly ISnakeAndLadderApi _api;

        public SnakeGameRefit()
        {
            _api = RestService.For<ISnakeAndLadderApi>("https://localhost:7057");
        }

        public async Task<ResponseModel> CreateGameBoard(BoardModel RequestGameBoard)
        {
            var model = await _api.CreateGameBoard(RequestGameBoard);
            return model!;
        }

        public async Task<ResponseModel> CreateGame(List<PlayerModel> RequestPlayers)
        {
            var model = await _api.CreateGame(RequestPlayers);
            return model;
        }


        public async Task<ResponseModel> PlayGame(int id)
        {
            var model = await _api.PlayGame(id);
            return model;
        }


    }


    public interface ISnakeAndLadderApi
    {
        [Post("/api/Game/CreateGameBoard")]
        Task<ResponseModel> CreateGameBoard(BoardModel RequestGameModel);

        [Post("/api/Game")]
        Task<ResponseModel> CreateGame(List<PlayerModel> RequestPlayers);

        [Post("/api/Game/{id}")]
        Task<ResponseModel> PlayGame(int id);
    }
}
