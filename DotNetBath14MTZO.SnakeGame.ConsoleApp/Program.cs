// See https://aka.ms/new-console-template for more information
using DotNetBath14MTZO.SnakeGame.ConsoleApp;

Console.WriteLine("Hello, World!");

SnakeGameRefit snakeGameRefit = new SnakeGameRefit();

List<PlayerModel> players = new List<PlayerModel>()
{
    new PlayerModel
    {
        PlayerName = "Mg Mg",
        CurrentPosition = 1
    },
     new PlayerModel
     {
         PlayerName = "Theint Theint",
         CurrentPosition = 1
     },
      new PlayerModel
      {
          PlayerName = "Thu Ya",
          CurrentPosition = 1
      }
};

var model = await snakeGameRefit.CreateGame(players);
Console.WriteLine(model.IsSuccessful);
Console.WriteLine(model.Message);
Console.ReadLine();

var play = await snakeGameRefit.PlayGame(29);
Console.WriteLine(play.IsSuccessful);
Console.WriteLine(play.Message);
Console.ReadLine();


