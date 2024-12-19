// See https://aka.ms/new-console-template for more information
using DotNetBath14MTZO.JsonPlaceholder;

Console.WriteLine("Hello, World!");

JsonPlaceholderRefitService jsonPlaceholderService = new JsonPlaceholderRefitService();
try
{
    var jsonLists = await jsonPlaceholderService.GetPosts();

    foreach (var item in jsonLists)
    {
        Console.WriteLine($"ID: {item.Id}, Title: {item.Title}, Body: {item.Body}");
    }
}
catch (Exception ex)
{

    Console.WriteLine($"Error: {ex.Message}");
}

Console.ReadLine();

var post = await jsonPlaceholderService.GetPost(1);
Console.WriteLine(post.Title);
Console.ReadLine();


var createPost= await jsonPlaceholderService.CreatePost(new JsonModel
{
    UserId = 100,
    Title = "Refit Json Testing Title",
    Body = "Refit Json Testing Body"
});

Console.WriteLine(createPost.UserId);
Console.WriteLine(createPost.Title);
Console.WriteLine(createPost.Body);
Console.ReadLine();


JsonModel updatePostModel = new JsonModel();

updatePostModel.Id = 100;
updatePostModel.Title = "Updating JsonPlace Holder Title using Refit";
updatePostModel.Body = "Updating JsonPlace Holder Body using Refit";

var updateResponse = await jsonPlaceholderService.UpdatePost(10, updatePostModel);
Console.WriteLine(updateResponse.UserId);
Console.WriteLine(updateResponse.Title);
Console.WriteLine(updateResponse.Body);
Console.ReadLine();


var deletePost = await jsonPlaceholderService.DeletePost(10);
Console.WriteLine(deletePost.Title);
Console.ReadLine();