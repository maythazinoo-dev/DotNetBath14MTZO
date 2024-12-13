using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace DotNetBath14MTZO.SnakesAndLadderGame.Features
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly PlayerEfCoreService _playerEfCoreService;
        private readonly BoardEfCoreService _boardEfCoreService;
        private readonly GameMoveEFCoreService _gameMovieEfCoreService;
        private readonly GameEfCoreService _gameEfCoreService;
        public PlayerController()
        {
            _playerEfCoreService = new PlayerEfCoreService();
            _boardEfCoreService = new BoardEfCoreService();
            _gameMovieEfCoreService = new GameMoveEFCoreService();
            _gameEfCoreService = new GameEfCoreService();
        }

        [HttpGet]
        public IActionResult GetPlayer()
        {
            var player = _playerEfCoreService.GetPlayers();
            return Ok(player);
        }

        [HttpPost("Register")]
        public IActionResult CreateRegister(PlayerModel requestPlayerModel)
        {
            var player = _playerEfCoreService.CreateRegister(requestPlayerModel);
            if (!player.IsSuccess)
            {
                return BadRequest(player);
            }
            return Ok(player);

        }

        [HttpPost("Login")]

        public IActionResult playerLogin(PlayerModel requestPlayerModel)
        {
            var player = _playerEfCoreService.PlayerLogin(requestPlayerModel);
            if (!player.IsSuccess)
            {
                return BadRequest(player);
            }
            return Ok(player);
        }

        [HttpGet("Board")]
        public IActionResult GetBoardModels()
        {
            var lst = _boardEfCoreService.GetBoardModels();
            return Ok(lst);
        }

        [HttpGet("boardid")]
        public IActionResult GetBoardModel(int id)
        {
            var item = _boardEfCoreService.GetBoardModel(id);
            if(item is null)
            {
                return NotFound("No data found");

            }
            return Ok(item);
        }

        [HttpPost("CreateGameBoard")]
        public IActionResult CreateBoard(BoardModel requestBoardModel)
        {
            var model= _boardEfCoreService.CreateBoard(requestBoardModel);
            if (!model.IsSuccess)
            {
                return BadRequest(model);
            }
            return Ok(model);

        }

        [HttpPut("GameBoard/{id}")]
        public IActionResult UpadteBoardModel(BoardModel requestBoardModel,int id)
        { 
            requestBoardModel.BoardId = id;
            var item = _boardEfCoreService.UpdateBoardModel(requestBoardModel);
            if (!item.IsSuccess)
            {
                return BadRequest(item);
            }
            return Ok(item);
        }

        [HttpDelete("GamaeBoard/{id}")]
        public IActionResult DeleteBoard(int id) 
        {
            var item = _boardEfCoreService.DeleteBoardModel(id);
            if (!item.IsSuccess)
            {
                return BadRequest(item);
            }
            return Ok(item);
        }

        [HttpPost("PlayGame")]
        public IActionResult CreateGame (GameModel requestGameModel)
        {
            var game = _gameMovieEfCoreService.CreateGame(requestGameModel);
            if (!game.IsSuccess)
            { 
                return BadRequest(game);
            }
            return Ok(game);
        }

        [HttpGet("Game")]
        public IActionResult GetGames()
        {
            var games = _gameEfCoreService.GetGames();
            return Ok(games);
        }

        [HttpGet("Game/{id}")]
        public IActionResult GetGame(int id) 
        { 
            var game = _gameEfCoreService.GetGameById(id);
            if(game is null)
            {
                return NotFound("Game not gound");
            }
            return Ok(game);
        }

        [HttpPost("Game")]
        public IActionResult CreateGames(GameModel requestGame) 
        {
            var game = _gameEfCoreService.CreateGame(requestGame);
            if (!game.IsSuccess)
            {
                return BadRequest(game);
            }
            return Ok(game);
        }
    }
}

