using Dapper;
using DotNetBath14MTZOPractce.ConsoleApp;
using DotNetBath14MTZOPractce.ConsoleApp.DapperPractices.BlogDtos;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DotNetBath14MTZO.Practice.ConsoleApp.DapperPractices
{
    public class DapperPractice
    {
        private readonly string _connection = AppDbSetting.SqlConnectionStringBuilder.ConnectionString;
        public void Read()
        {
            using IDbConnection connection = new SqlConnection(_connection);
            string query = "select * from Tbl_Blog";

            List<BlogDto> lst = connection.Query<BlogDto>(query).ToList();
            foreach (BlogDto item in lst)
            {
                Console.WriteLine(item.BlogId);
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogContent);
            }

        }

        public void Edit(string id)
        {
            using IDbConnection dbConnection = new SqlConnection(_connection);

            string query = $@"SELECT [BlogId]
      ,[BlogTitle]
      ,[BlogAuthor]
      ,[BlogContent]
  FROM [dbo].[Tbl_Blog] where BlogId='{id}'";

            var item = dbConnection.Query<BlogDto>(query).FirstOrDefault();
            if (item is null)
            {
                Console.WriteLine("Not Found Data");
                return;

            }
            Console.WriteLine(item.BlogId);
            Console.WriteLine(item.BlogTitle);
            Console.WriteLine(item.BlogAuthor);
            Console.WriteLine(item.BlogContent);
        }

        public void Create(string title, string author, string content)
        {
            using IDbConnection dbConnection = new SqlConnection(_connection);
            string query = $@"INSERT INTO [dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
     VALUES
           ('{title}'
           ,'{author}'
           ,'{content}')";

            int result = dbConnection.Execute(query);
            var message = result > 0 ? "Saving is Successful" : "Saving is failed";
            Console.WriteLine(message);

        }

        public void Update(string id, string title, string author, string content)
        {
            using IDbConnection dbConnection = new SqlConnection(_connection);

            string query = $@"UPDATE [dbo].[Tbl_Blog]
   SET [BlogTitle] ='{title}'
      ,[BlogAuthor] = '{author}'
      ,[BlogContent] = '{content}'
 WHERE BlogId = '{id}'";

            int result = dbConnection.Execute(query);
            var message = result > 0 ? "Updating Successful" : "Updating Failed";
            Console.WriteLine(message);
        }

        public void Delete(string id)
        {
            using IDbConnection dbConnection = new SqlConnection(_connection);
            string query = $"delete from tbl_blog where BlogID= '{id}'";

            int result = dbConnection.Execute(query);
            var message = result > 0 ? "Delete is successed" : "Delete is failed";
            Console.WriteLine(message);
        }

    }
}
