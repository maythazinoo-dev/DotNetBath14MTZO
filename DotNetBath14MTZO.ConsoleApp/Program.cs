//// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
//Console.Write("Enter username: ");
//string username = Console.ReadLine();
//Console.WriteLine($"Hello {username}");

using Microsoft.Data.SqlClient;
using System.Data;

SqlConnectionStringBuilder connectionStringBulider= new SqlConnectionStringBuilder();

//Console.ReadLine();
connectionStringBulider.DataSource = ".";//Servername
connectionStringBulider.InitialCatalog = "WalletDB";//DatabaseName
connectionStringBulider.UserID = "sa";
connectionStringBulider.Password = "mtzoo@123";
connectionStringBulider.TrustServerCertificate = true;

string connectionString = connectionStringBulider.ConnectionString;
SqlConnection connection = new SqlConnection(connectionString);

Console.WriteLine("Connection Opening");
connection.Open();
string query = "select * from tbl_blog";
SqlCommand cmd = new SqlCommand(query, connection);
SqlDataAdapter adapter = new SqlDataAdapter(cmd);
DataTable dt = new DataTable();
adapter.Fill(dt);

//Console.WriteLine("Connection Open");

//Console.WriteLine("Connection Closing");
connection.Close();
foreach(DataRow dr in dt.Rows)
{
    Console.WriteLine(dr["BlogId"]);
    Console.WriteLine(dr["BlogTitle"]);
    Console.WriteLine(dr["BlogAuthor"]);
    Console.WriteLine(dr["BlogContent"]);
}
Console.WriteLine("Connection Close");

   
