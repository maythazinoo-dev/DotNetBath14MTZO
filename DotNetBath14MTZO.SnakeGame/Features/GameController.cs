using DotNetBath14MTZO.SnakesAndLadderGame.Features;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNetBath14MTZO.SnakeGame.Features
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly GameService _gameService;
        public GameController() { 
            _gameService = new GameService();
        }

        [HttpPost("GameBoard")]
        public IActionResult CreateBoard(BoardModel requestBoardModel)
        {
            var board = _gameService.CreateBoard(requestBoardModel);
            if (board is null) 
            {
                return BadRequest(board);
            }
            return Ok(board);
        }


        [HttpPost("CreateGame")]
        public IActionResult CreateGame(List<PlayerModel> playerlist)
        {
            try
            {
                var response = _gameService.CreateGame(playerlist);

                if (!response.IsSuccess) return BadRequest(response);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new GameResponseModel
                {
                    Message = ex.ToString(),
                });
            }
        }
    }
}
