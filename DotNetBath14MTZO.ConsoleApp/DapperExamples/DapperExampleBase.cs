using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DotNetBath14MTZO.ConsoleApp.DapperExamples
{
    public class DapperExampleBase
    {

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

        public void Update(string id, string title, string author, string content)
        {

        }
    }
}