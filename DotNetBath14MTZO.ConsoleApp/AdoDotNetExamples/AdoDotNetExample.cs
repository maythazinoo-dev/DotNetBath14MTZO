using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace DotNetBath14MTZO.ConsoleApp.AdoDotNetExamples;

public class AdoDotNetExample
{
    private readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
    {
        DataSource = ".",
        InitialCatalog = "WalletDB",
        UserID = "sa",
        Password = "mtzoo@123",
        TrustServerCertificate = true

    };

    public void Read()
    {
        SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
        connection.Open();

        string query = @"SELECT [BlogId]
      ,[BlogTitle]
      ,[BlogAuthor]
      ,[BlogContent]
       FROM [dbo].[Tbl_Blog]";
        SqlCommand cmd = new SqlCommand(query, connection);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapter.Fill(dt);

        connection.Close();

        foreach (DataRow dr in dt.Rows)
        {
            Console.WriteLine("Blog Id = " + dr["BlogId"]);
            Console.WriteLine("Blog Title = " + dr["BlogTitle"]);
            Console.WriteLine("Blog Author" + dr["BlogAuthor"]);
            Console.WriteLine("Blog Content" + dr["BlogContent"]);
        }
    }

    public void Edit(string id)
    {

        SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
        connection.Open();
        string query = $"select * from Tbl_Blog where BlogId = '{id}'";
        SqlCommand cmd = new SqlCommand(query, connection);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapter.Fill(dt);

        connection.Close();

        if (dt.Rows.Count == 0)
        {
            Console.WriteLine("Data not Found");
            return;
        }

        DataRow row = dt.Rows[0];
        Console.WriteLine("ID =" + row["BlogId"]);
        Console.WriteLine("Title =" + row["BlogTitle"]);
        Console.WriteLine("Author =" + row["BlogAuthor"]);
        Console.WriteLine("Content =" + row["BlogContent"]);
    }

    public void Create(string title, string author, string content)
    {
        SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
        connection.Open();
        string query = $@"INSERT INTO [dbo].[Tbl_Blog]
           ([BlogTitle]
           , [BlogAuthor]
           , [BlogContent])
     VALUES
           ('{title}'
           ,'{author}'
           ,'{content}')";

        SqlCommand cmd = new SqlCommand(query, connection);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        int result = cmd.ExecuteNonQuery();
        connection.Close();

        string message = result > 0 ? "Saving Successful" : "Saving Failed";
        Console.WriteLine(message);
    }

    public void Update(string id, string title, string author, string content)
    {
        SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
        connection.Open();
        string query = $@"UPDATE [dbo].[Tbl_Blog]

   SET [BlogTitle] = '{title}'
       ,[BlogAuthor] = '{author}'
      ,[BlogContent] = '{content}'
 WHERE [BlogId] = '{id}'";

        SqlCommand cmd = new SqlCommand(query, connection);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);

        int result = cmd.ExecuteNonQuery();
        string message = result > 0 ? "Update Sucessful" : "Update Failed";
        Console.WriteLine(message);


    }
    public void Delete(string id)
    {
        SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
        connection.Open();
        string query = $"DELETE FROM [dbo].[Tbl_Blog] WHERE [BlogId]='{id}'";
        SqlCommand cmd = new SqlCommand(query, connection);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        int result = cmd.ExecuteNonQuery();
        string message = result > 0 ? "Delete Complete" : "Delete Failed";
        Console.WriteLine(message);
    }

}
