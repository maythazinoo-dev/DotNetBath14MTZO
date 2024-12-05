using Dapper;
using DotNetBath14MTZO.RestApi.Features.Blog;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DotNetBath14MTZO.RestApi.Features.BlogDapper
{
    public class BlogDapperService
    {
        private readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder;
        public BlogDapperService()
        {
            _sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
            {
                DataSource = ".",
                InitialCatalog = "WalletDB",
                UserID = "sa",
                Password = "mtzoo@123",
                TrustServerCertificate = true
            };
        }

        public List<BlogModel> GetBlogs()
        {
            string query = "Select * from tbl_Blog";
            using IDbConnection dbConnection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString );

            var list = dbConnection.Query<BlogModel>(query).ToList();
            return list;
        }

        public BlogModel GetBlog(string id)

        {
            string query = "select * from tbl_blog with (nolock)";
            using IDbConnection dbConnection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            var item = dbConnection.QueryFirstOrDefault<BlogModel>(query);
            return item;
        }

        public BlogResponseModel CreateBlog(BlogModel requestModel)
        {
            string query = @$"INSERT INTO [dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
     VALUES
           (@BlogTitle
           ,@BlogAuthor
           ,@BlogContent)";

            using IDbConnection dbConnection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            var result = dbConnection.Execute(query, requestModel);

            string message = result > 0 ? "Saving Successful." : "Saving Failed.";

            BlogResponseModel model = new BlogResponseModel();
            model.IsSuccess = result > 0;
            model.Message = message;
            return model;
        }

        public BlogResponseModel UpdateBlog(BlogModel requestModel)
        {
            var item = GetBlog(requestModel.BlogId!);
            if(item is null)
            {
                return new BlogResponseModel
                {
                    IsSuccess = false,
                    Message = "No data found."
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

            string query = @"UPDATE [dbo].[Tbl_Blog]
   SET [BlogTitle] = @BlogTitle
      ,[BlogAuthor] = @BlogAuthor
      ,[BlogContent] = @BlogContent
 WHERE BlogId = @BlogId";
            using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            var result = db.Execute(query, requestModel);

            string message = result > 0 ? "Saving Successful." : "Saving Failed.";
            BlogResponseModel model = new BlogResponseModel();
            model.IsSuccess = result > 0;
            model.Message = message;

            return model;
        
    }

        public BlogResponseModel UpsertBlog(BlogModel requestModel)
        {
            BlogResponseModel model = new BlogResponseModel();

            var item = GetBlog(requestModel.BlogId!);
            if (item is not null)
            {
                string query = @"UPDATE [dbo].[Tbl_Blog]
   SET [BlogTitle] = @BlogTitle
      ,[BlogAuthor] = @BlogAuthor
      ,[BlogContent] = @BlogContent
 WHERE BlogId = @BlogId";

                using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
                var result = db.Execute(query, requestModel);

                string message = result > 0 ? "Updating Successful." : "Updating Failed.";

                model.IsSuccess = result > 0;
                model.Message = message;
            }
            else if (item is null)
            {
                model = CreateBlog(requestModel);
            }

            return model;
        }

        public BlogResponseModel DeleteBlog(string id)
        {
            string query = "Delete from [dbo].[Tbl_Blog] where BlogId = @BlogId";

            using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            var result = db.Execute(query, new BlogModel
            {
                BlogId = id
            });

            string message = result > 0 ? "Delete Success." : "Delete Fail!";
            BlogResponseModel model = new BlogResponseModel();
            model.IsSuccess = result > 0;
            model.Message = message;

            return model;
        }

    }
}
