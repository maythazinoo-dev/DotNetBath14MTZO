﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNetBath14MTZO.SnakeAndLadder.Shared
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly GameService _gameService;
        public GameController()
        {
            _gameService = new GameService();
        }

        [HttpPost("Create GameBoard")]
        public IActionResult CreateGameBoard(BoardModel gameBoard)
        {
            try
            {
                var response = _gameService.CreateGameBoard(gameBoard);
                if (!response.IsSuccessful) return BadRequest(response);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseModel
                {
                    Message = ex.ToString(),
                });
            }
        }

        [HttpPost("CreateGame")]
        public IActionResult CreateGame(List<PlayerModel> playerlist)
        {
            try
            {
                var response = _gameService.CreateGame(playerlist);
                if (!response.IsSuccessful) return BadRequest(response);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseModel
                {
                    Message = ex.ToString(),
                });
            }
        }

        [HttpPost("PlayGame")]
        public IActionResult PlayGame(int firstPlayerId)
        {
            try
            {
                var response = _gameService.PlayGame(firstPlayerId);
                if (!response.IsSuccessful) return BadRequest(response);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseModel
                {
                    Message = ex.ToString(),
                });
            }
        }
    }
}
