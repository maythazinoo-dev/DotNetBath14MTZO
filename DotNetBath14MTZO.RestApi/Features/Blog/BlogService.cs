using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.HttpSys;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DotNetBath14MTZO.RestApi.Features.Blog
{
    public class BlogService
    {
        private readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder = new SqlConnectionStringBuilder() 
        { 
            DataSource = ".",
            InitialCatalog="WalletDB",
            UserID ="sa",
            Password="mtzoo@123",
            TrustServerCertificate = true
        };  

        public List<BlogModel> GetBlogs()
        {
            string query = @"SELECT [BlogId]
      ,[BlogTitle]
      ,[BlogAuthor]
      ,[BlogContent]
       FROM [dbo].[Tbl_Blog]";
            SqlConnection connection= new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            connection.Close();

            List<BlogModel> lst = new List<BlogModel>();
            foreach (DataRow dr in dt.Rows) 
            { 
                BlogModel item = new BlogModel();
                item.BlogId = dr["BlogId"].ToString()!;
                item.BlogTitle = dr["BlogTitle"].ToString()!;
                item.BlogAuthor = dr["BlogAuthor"].ToString()!;
                item.BlogContent = dr["BlogContent"].ToString()!;
                lst.Add(item);
            }
            return lst;
        }

        public BlogModel GetBlog(string id)
        {
            string query = "select * from Tbl_Blog where BlogId = @BlogId";
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString); 
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogId", id);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            connection.Close();

            if (dt.Rows.Count == 0)
            {
                return null;
            }
            BlogModel model = new BlogModel();
            DataRow row = dt.Rows[0];
            model.BlogId = row["BlogId"].ToString()!;
            model.BlogTitle = row["BlogTitle"].ToString()!;
            model.BlogAuthor = row["BlogAuthor"].ToString()!;
            model.BlogContent = row["BlogContent"].ToString()!;
            return model;
            
        }

        public BlogResponseModel CreateBlog([FromBody]BlogModel requestModel)
        {
            string query = @"INSERT INTO [dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
            VALUES
           (@BlogTitle
           ,@BlogAuthor
           ,@BlogContent)";
            SqlConnection connection = new SqlConnection( _sqlConnectionStringBuilder.ConnectionString);    
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogTitle",requestModel.BlogTitle);
            cmd.Parameters.AddWithValue("@BlogAuthor",requestModel.BlogAuthor);
            cmd.Parameters.AddWithValue("@BlogContent",requestModel.BlogContent);
            int result = cmd.ExecuteNonQuery();
            connection.Close();

            string message = result > 0 ? "Saving Successful" : "Saving Failed";
            BlogResponseModel model = new BlogResponseModel(); 
            model.IsSuccess = result > 0;
            model.Message = message;
            return model;
        }

    

        public BlogResponseModel UpsertBlog(BlogModel requestModel)
        {
            BlogResponseModel model = new BlogResponseModel();
            var item = GetBlog(requestModel.BlogId!);
            if(item is not null)
            {
                string query = @"UPDATE [dbo].[Tbl_Blog]
   SET [BlogTitle] = @BlogTitle
      ,[BlogAuthor] = @BlogAuthor
      ,[BlogContent] = @BlogContent
 WHERE BlogId = @BlogId";
                SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@BlogId", requestModel.BlogId);
                cmd.Parameters.AddWithValue("@BlogTitle", requestModel.BlogTitle);
                cmd.Parameters.AddWithValue("@BlogAuthor", requestModel.BlogAuthor);
                cmd.Parameters.AddWithValue("@BlogContent", requestModel.BlogContent);
                int result = cmd.ExecuteNonQuery();
                connection.Close();

                string message = result > 0 ? "Updating Successful" : "Updating Failed";
                model.IsSuccess= result > 0;
                model.Message =  message;
               

            }
            else if(item is null)
            {
                model = CreateBlog(requestModel);
            }
            return model;
        }

        public BlogResponseModel UpdatetBlog(BlogModel requestModel)
        {
            var item = GetBlog(requestModel.BlogId!);
            if (item is null)
            {
                return new BlogResponseModel()
                {
                    IsSuccess = false,
                    Message = "No found Data"
                };
            }
            if (string.IsNullOrEmpty(requestModel.BlogTitle))
            {
                requestModel.BlogTitle = item.BlogTitle;
            }
            if (string.IsNullOrEmpty(requestModel.BlogAuthor))
            {
                requestModel.BlogAuthor = item.BlogAuthor;
            }
            if (string.IsNullOrEmpty(requestModel.BlogContent))
            {
                requestModel.BlogContent = item.BlogContent;
            }

            string query = $@"UPDATE [dbo].[Tbl_Blog]

          SET [BlogTitle] = @BlogTitle
              ,[BlogAuthor] = @BlogAuthor
             ,[BlogContent] = @BlogContent
        WHERE [BlogId] = @BlogId";

            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogId", requestModel.BlogId);
            cmd.Parameters.AddWithValue("@BlogTitle", requestModel.BlogTitle);
            cmd.Parameters.AddWithValue("@BlogAuthor", requestModel.BlogAuthor);
            cmd.Parameters.AddWithValue("@BlogContent", requestModel.BlogContent);
            int result = cmd.ExecuteNonQuery();
            connection.Close();

            BlogResponseModel responseModel = new BlogResponseModel();
            string message = result > 0 ? "Updating is Successful" : "Updating is failed";
            responseModel.IsSuccess = result > 0;
            responseModel.Message = message;

            return responseModel;
        }

        public BlogResponseModel DeleteBlog(string id)
        {
            string query = "delete from Tbl_Blog where [BlogId]= @BlogId";
            SqlConnection connection = new SqlConnection( _sqlConnectionStringBuilder.ConnectionString);
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@BlogId", id);
            int result = command.ExecuteNonQuery();
            connection.Close();
            string message = result > 0 ? "Delete Successful" : "Delete Failed";
            BlogResponseModel model = new BlogResponseModel();
            model.IsSuccess = result > 0;
            model.Message = message;
            return model;
        }

    }
}

