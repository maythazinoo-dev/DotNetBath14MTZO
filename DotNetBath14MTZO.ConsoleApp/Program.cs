//// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
//Console.Write("Enter username: ");
//string username = Console.ReadLine();
//Console.WriteLine($"Hello {username}");

using DotNetBath14MTZO.ConsoleApp.AdoDotNetExamples;
using DotNetBath14MTZO.ConsoleApp.DapperExamples;
using DotNetBath14MTZO.ConsoleApp.DapperExamples.BlogDtos;
using DotNetBath14MTZO.ConsoleApp.EfCoreExamples;
//using Microsoft.Data.SqlClient;
//using System.Data;

//SqlConnectionStringBuilder connectionStringBulider = new SqlConnectionStringBuilder
//{
//    //Console.ReadLine();
//    DataSource = ".",//Servername
//    InitialCatalog = "WalletDB",//DatabaseName
//    UserID = "sa",
//    Password = "mtzoo@123",
//    TrustServerCertificate = true
//};

//string connectionString = connectionStringBulider.ConnectionString;
//SqlConnection connection = new SqlConnection(connectionString);

//Console.WriteLine("Connection Opening");
//connection.Open();
//string query = "select * from tbl_blog";
//SqlCommand cmd = new SqlCommand(query, connection);
//SqlDataAdapter adapter = new SqlDataAdapter(cmd);
//DataTable dt = new DataTable();
//adapter.Fill(dt);

////Console.WriteLine("Connection Open");

////Console.WriteLine("Connection Closing");
//connection.Close();
//foreach (DataRow dr in dt.Rows)
//{
//    Console.WriteLine(dr["BlogId"]);
//    Console.WriteLine(dr["BlogTitle"]);
//    Console.WriteLine(dr["BlogAuthor"]);
//    Console.WriteLine(dr["BlogContent"]);
//}

//AdoDotNetExample adoDotNetExample = new AdoDotNetExample();
//adoDotNetExample.Read();

//adoDotNetExample.Edit("D42789B4-29CA-4B21-A0D5-6B77822C4108");
//adoDotNetExample.Edit("");
//adoDotNetExample.Create("Blog Title3", "Blog Author3", "Blog Content3");
//adoDotNetExample.Update("F3D7C910-EA73-4F39-A517-E88C60D458EF","Blog Tilte 3","Blog Author 3","Blog Content 3");
//adoDotNetExample.Delete("FC7D8C80-045B-4160-B302-D75132BF9921");


//Dapper
//DapperExample dapperExample = new DapperExample();
//dapperExample.Read();
//dapperExample.Edit("DA6D1F70-14AC-474A-8E7C-C0D42CAD7290");
//dapperExample.Edit("");
//dapperExample.Create("Blog Title 7", "Blog Author 7", "Blog Content 7");
//dapperExample.Update("F6C147D4-99F2-44E2-8094-57CBFC409C89", "Blog Title 8", "Blog Author 8", "Blog Content 8");
//dapperExample.Delete("A7CEB4C4-80D4-4D92-BABD-99A4E7717450");

//FECore

EfCoreExample efCoreExample = new EfCoreExample();
efCoreExample.Read();
efCoreExample.Edit("D42789B4-29CA-4B21-A0D5-6B77822C4108");
efCoreExample.Edit(" ");
efCoreExample.Create("Blog Title 9", "Blog Author 9", "Blog Content 9");
efCoreExample.Update("6b5a4e78-5675-4d99-9de4-c4a13291c0df", "Blog Title", "Blog Author", "Blog Content");
efCoreExample.Delete("6b5a4e78-5675-4d99-9de4-c4a13291c0df");
Console.WriteLine("Connection Close");






