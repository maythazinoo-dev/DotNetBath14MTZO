// See https://aka.ms/new-console-template for more information
using DotNetBath14MTZO.Practice.ConsoleApp.AdoDotNetPractices;
using DotNetBath14MTZO.Practice.ConsoleApp.DapperPractices;

Console.WriteLine("Hello, World!");

//AdoDotNetPractice adoDotNetPractice = new AdoDotNetPractice();
//adoDotNetPractice.Read();
//adoDotNetPractice.Edit("14F1959E-F700-42F4-98A1-5926F3804EE2");
//adoDotNetPractice.Create("Blog Tiltle 10", "Blog Author 10", "Blog Content 10");
//adoDotNetPractice.Update("95856D59-41A4-4F62-8CA4-9DCE62955813", "Blog Title 11", "Blog Author 11", "Blog Content 11");
//adoDotNetPractice.Delete("95856D59-41A4-4F62-8CA4-9DCE62955813"); 

DapperPractice dapperPractice = new DapperPractice();
dapperPractice.Read();
dapperPractice.Edit("8D7C0EB0-CB03-472E-9FD1-016A4CF20A85");
dapperPractice.Create("Blog Title 4", "Blog Author 4", "Blog Content 4");
dapperPractice.Update("AC9CB7FF-5792-47BA-A561-B289610AB182", "Blog Title 5", "Blog Author 5", "Blog Content 5");
dapperPractice.Delete("53163E21-5C5A-4AD0-A92D-BC943F0B496C");

   