// See https://aka.ms/new-console-template for more information
using DotNetBath14MTZO.Practice.ConsoleApp.AdoDotNetPractices;

Console.WriteLine("Hello, World!");

AdoDotNetPractice adoDotNetPractice = new AdoDotNetPractice();
adoDotNetPractice.Read();
adoDotNetPractice.Edit("14F1959E-F700-42F4-98A1-5926F3804EE2");
adoDotNetPractice.Create("Blog Tiltle 10", "Blog Author 10", "Blog Content 10");
adoDotNetPractice.Update("95856D59-41A4-4F62-8CA4-9DCE62955813", "Blog Title 11", "Blog Author 11", "Blog Content 11");
adoDotNetPractice.Delete("95856D59-41A4-4F62-8CA4-9DCE62955813"); 