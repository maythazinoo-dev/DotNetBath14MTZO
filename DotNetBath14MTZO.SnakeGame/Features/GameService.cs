using DotNetBath14MTZO.SnakesAndLadderGame.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Diagnostics.Eventing.Reader;

namespace DotNetBath14MTZO.SnakeGame.Features
{
    public class GameService
    {
        private readonly AppDbContext _appDbContext;
        public GameService()
        {
            _appDbContext = new AppDbContext();



        }
        public BoardResponseModel CreateBoard(BoardModel requestBoardModel)
        {
            _appDbContext.gameBoard.Add(requestBoardModel);
            int result = _appDbContext.SaveChanges();
            string message = result > 0 ? "Game Board Create Successful" : "Game Board Create Failed";
            return new BoardResponseModel
            {
                IsSuccess = result > 0,
                Message = message
            };
        }

        public GameResponseModel CreateGame(List<PlayerModel> PlayerArray)
        {
            if (PlayerArray.Count == 0)
            {
                return new GameResponseModel
                {
                    IsSuccess = false,
                    Message = "No Player for the game"
                };

            }
            foreach (var player in PlayerArray)
            {
                player.PlayerCurrentPosition = 1;

            }
            _appDbContext.gamePlayer.AddRange(PlayerArray);
            _appDbContext.SaveChanges();


            int firstPlayerId = (int)PlayerArray.First().PlayerId!;
            var game = new GameModel
            {
                GameStatus = "InProgress",
                CurrentPlayerId = firstPlayerId,
                //GameMember = PlayerArray.Count()
            };
            _appDbContext.game.Add(game);
            _appDbContext.SaveChanges();

            for (int i = 0; i < PlayerArray.Count; i++)
            {
                var initialGameMove = new GameMoveModel
                {
                    GameId = game.GameId,
                    PlayerId = (int)PlayerArray.First().PlayerId!,
                    FromCell = 0,
                    ToCell = 0,
                    MoveDate = DateTime.Now
                };
                _appDbContext.gameMove.Add(initialGameMove);
            }
            int result = _appDbContext.SaveChanges();
            string message = result > 0 ? "Game Create Successful" : "Game Create Failed";
            return new GameResponseModel
            {
                IsSuccess = result > 0,
                Message = message
            };


            //foreach (var player in PlayerArray)
            //{
            //    player.PlayerCurrentPosition = 1;

            //    var initialGameMove = new GameMoveModel
            //    {
            //        GameId = game.GameId,
            //        PlayerId = (int)player.PlayerId !,
            //        FromCell = 0,
            //        ToCell = 0,
            //        MoveDate = DateTime.Now
            //    };
            //    _appDbContext.gameMove.Add(initialGameMove);
            //}

            // _appDbContext.gamePlayer.AddRange(PlayerArray);
            //int result = _appDbContext.SaveChanges();
            // string message = result > 0 ? "Game Create Successful" : "Game Create Failed";
            // return new GameResponseModel
            // {
            //     IsSuccess = result > 0,
            //     Message = message
            // };


        }

        public GameResponseModel MoveGame(int gameId, int PlayerId)
        {
            var game = _appDbContext.game.AsNoTracking().FirstOrDefault(x => x.GameId == gameId);
            var player = _appDbContext.gamePlayer.AsNoTracking().FirstOrDefault(x => x.PlayerId == PlayerId);
            var gameboard = _appDbContext.gameBoard.ToList();

            if (game is null || player is null)
            {
                return new GameResponseModel
                {
                    IsSuccess = false,
                    Message = "Game & Player not found "
                };
            }

            if (game.CurrentPlayerId != PlayerId)
            {
                return new GameResponseModel
                {
                    IsSuccess = false,
                    Message = "This player is not turn"
                };

            }
            Random random= new Random();
            int diceRoll = random.Next(1, 7);
            int newPosition = (int)player.PlayerCurrentPosition! + diceRoll;
         

            var moveGame = new GameMoveModel
            {
                GameId = gameId,
                PlayerId = PlayerId,
                FromCell = (int)player.PlayerCurrentPosition,
                ToCell = newPosition,
                MoveDate = DateTime.Now

            };
            

            if (newPosition >= 100)
            {
                game.GameStatus = "Completed";
                
                _appDbContext.Entry(game).State= EntityState.Modified;
                _appDbContext.SaveChanges();


            } 
               
                var allPlayers = _appDbContext.gamePlayer.ToList();
                var currentIndex = allPlayers.FindIndex(p => p.PlayerId == PlayerId);
                var nextIndex = (currentIndex + 1) % allPlayers.Count;
                game.CurrentPlayerId = (int)allPlayers[nextIndex].PlayerId!;
             
                _appDbContext.Entry(game).State = EntityState.Modified;
                _appDbContext.SaveChanges();

                

            foreach(var cell in gameboard)
            {
                if(cell.BoardCellNumber == newPosition)
                {
                    if (cell.BoardCellType == "Normal")
                    {
                        moveGame.ToCell = newPosition;
                        player.PlayerCurrentPosition = newPosition;
                       
                    }

                    else if (cell.BoardCellType == "SnakeHead"){
                        moveGame.ToCell = newPosition;
                        player.PlayerCurrentPosition = newPosition;

                    }
                    else if(cell.BoardCellType == "LadderBottom")
                    {
                        moveGame.ToCell = newPosition;  
                        player.PlayerCurrentPosition = newPosition;
                    }
                    break;


                }
                player.PlayerCurrentPosition = newPosition;
                _appDbContext.Entry(player).State= EntityState.Modified;
                _appDbContext.SaveChanges();

                _appDbContext.gameMove.Add(moveGame);
                _appDbContext.SaveChanges();

                return new GameResponseModel
                {
                    IsSuccess = true,
                    Message =""
                };

            }

            



        }
    }
    }

