using Dapper;
using DotNetBath14MTZO.ConsoleApp.DapperExamples.BlogDtos;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBath14MTZO.ConsoleApp.DapperExamples
{
    public class DapperExample
    {
        private readonly string _connectionString = AppSettings.SqlConnectionStringBuilder.ConnectionString;

        public void Read()
        {
            using IDbConnection connection = new SqlConnection(_connectionString);
            string query = @"SELECT [BlogId]
      ,[BlogTitle]
      ,[BlogAuthor]
      ,[BlogContent]
  FROM [dbo].[Tbl_Blog]";

            List<BlogDto> lst = connection.Query<BlogDto>(query).ToList();
            foreach (BlogDto item in lst)
            {
                Console.WriteLine("Blog Id.." + item.BlogId);
                Console.WriteLine("Blog Title.." + item.BlogTitle);
                Console.WriteLine("Blog Author.." + item.BlogAuthor);
                Console.WriteLine("Blog Content.." + item.BlogContent);
            }

        }
        public void Edit(string id)
        {
            using IDbConnection connection = new SqlConnection(_connectionString);
            string query = $@"SELECT [BlogId]
      ,[BlogTitle]
      ,[BlogAuthor]
      ,[BlogContent]
  FROM [dbo].[Tbl_Blog] where [BlogId]= '{id}'";
            var item = connection.Query<BlogDto>(query).FirstOrDefault();
            if (item is null)
            {
                Console.WriteLine("Data Not Found");
                return;
            }
            Console.WriteLine("Blog Id.." + item.BlogId);
            Console.WriteLine("Blog Title.." + item.BlogTitle);
            Console.WriteLine("Blog Author.." + item.BlogAuthor);
            Console.WriteLine("Blog Content.." + item.BlogContent);
        }

        public void Create(string title, string author, string content)
        {
            using IDbConnection connection = new SqlConnection(_connectionString);
            string query = $@"INSERT INTO [dbo].[Tbl_Blog]
            ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
     VALUES
           ('{title}'
            ,'{author}'
            ,'{content}')";

            int result = connection.Execute(query);
            string message = result > 0 ? "Saving Successful" : "Saving Failed";
            Console.WriteLine(message);

        }

        public void Update(string id, string title, string author, string content)
        {
            using IDbConnection connection = new SqlConnection(_connectionString);
            string query = $@"UPDATE [dbo].[Tbl_Blog]
   SET
       [BlogTitle] = '{title}'
      ,[BlogAuthor] = '{author}'
      ,[BlogContent] = '{content}'
 WHERE [BlogId]='{id}'";

            int result = connection.Execute(query);
            string message = result > 0 ? "Update Successful" : "Update failed";
            Console.WriteLine(message);
        }

        public void Delete(string id)
        {
            using IDbConnection connection = new SqlConnection(_connectionString);
            string query = $"DELETE FROM [dbo].[Tbl_Blog] WHERE [BlogId]='{id}'";
            int result = connection.Execute(query);
            string message = result > 0 ? "Delet Complete" : "Delete Failed";
            Console.WriteLine(message);
        }

    }
}
