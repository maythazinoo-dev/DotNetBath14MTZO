using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics.Eventing.Reader;

namespace DotNetBath14MTZO.SnakesAndLadderGame.Features
{
    public class BoardEfCoreService
    {
        private readonly AppDbContext _dbContext;
        public BoardEfCoreService()
        {
            _dbContext = new AppDbContext();
        }
       public List<BoardModel> GetBoardModels()
        {
            var boardModels = _dbContext.gameBoard.ToList();
            return boardModels;
        }

        public BoardModel GetBoardModel(int id)
        {
            var item = _dbContext.gameBoard.FirstOrDefault(x => x.BoardId == id);
            return item!;
        }

        public BoardResponseModel CreateBoard(BoardModel requestBoardModel)
        {
            _dbContext.gameBoard.Add(requestBoardModel);
            int result = _dbContext.SaveChanges();
            string message = result > 0 ? "Create board Successful" : "Create board  Failed";
            BoardResponseModel response = new BoardResponseModel();
            response.IsSuccess = result > 0;
            response.Message = message;
            return response;
        }

        public BoardResponseModel UpdateBoardModel(BoardModel requestBoardModel) 
        { 
            var model = GetBoardModel(requestBoardModel.BoardId);
            if (model is not null)
            {
                model.BoardCellNumber = requestBoardModel.BoardCellNumber;
                model.BoardCellType= requestBoardModel.BoardCellType;
                model.BoardMoveToCell = requestBoardModel.BoardMoveToCell;
                _dbContext.Entry(model).State = EntityState.Modified;
                int result = _dbContext.SaveChanges();
                string message = result > 0 ? "Game Board Update Successful" : "Game Board Update Failed";
                BoardResponseModel modelResponse = new BoardResponseModel();
                modelResponse.IsSuccess = result > 0;
                modelResponse.Message = message;
                return modelResponse;
            }
            BoardResponseModel boardResponseModel = new BoardResponseModel();
            boardResponseModel.IsSuccess = false;
            boardResponseModel.Message = "Game Board not Found";
            return boardResponseModel;

        }

        public BoardResponseModel DeleteBoardModel(int id) 
        { 
            var model = _dbContext.gameBoard.FirstOrDefault(x => x.BoardId == id);
            if(model is null)
            {
                return new BoardResponseModel()
                {
                    IsSuccess = false,
                    Message = "Board not found"
                };
            }
            _dbContext.gameBoard.Add(model);
            var result = _dbContext.SaveChanges();
            string message = result > 0 ? "Game Board Delete is Successful" : "Game Board Delete is Failed";
            BoardResponseModel responseModel = new BoardResponseModel();
            responseModel.IsSuccess = result > 0;
            responseModel.Message = message;
            return responseModel;
        }
    }
}


