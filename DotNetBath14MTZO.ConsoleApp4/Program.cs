// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

string endpoint = "https://localhost:7263/api/blog";
HttpClient client = new HttpClient();
HttpResponseMessage response = await client.GetAsync(endpoint);
if (response.IsSuccessStatusCode)
{
    string content = await response.Content.ReadAsStringAsync();
    Console.WriteLine(content);
}
Console.ReadLine();