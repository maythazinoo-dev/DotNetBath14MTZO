using Dapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Xml;

namespace DotNetBath14MTZO.Dbservice.Shared;

public class BlogDapperService : IBlogService
{
    private readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder;

    public BlogDapperService(string connectionString)
    {
        //_sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        //{
        //    DataSource = ".",
        //    InitialCatalog = "WalletDB",
        //    UserID = "sa",
        //    Password = "mtzoo@123",
        //    TrustServerCertificate = true
        //};

        _sqlConnectionStringBuilder = new SqlConnectionStringBuilder(connectionString);

    }

    // want to service switch
    public BlogDapperService(IConfiguration configuration)
    {
        _sqlConnectionStringBuilder = new SqlConnectionStringBuilder(configuration.GetConnectionString("DbConnection"));
    }


    public List<BlogModel> GetBlogs()
    {
        using IDbConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
        string query = "select * from Tbl_Blog";
        var blog = connection.Query<BlogModel>(query).ToList();
        return blog;
    }
    public BlogModel GetBlog(string id)
    {
        string query = "select * from Tbl_Blog with (nolock) where [BlogId]=@BlogId";
        using IDbConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
        var item = connection.QueryFirstOrDefault<BlogModel>(query);
        return item!;
    }

    public BlogResponseModel CreateBlog(BlogModel requestModel)
    {
        string query = @"INSERT INTO [dbo].[Tbl_Blog]
            ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
     VALUES
           (@BlogTitle
            ,@BlogAuthor
            ,@BlogContent)";

        using IDbConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
        int result = connection.Execute(query, requestModel);

        string message = result > 0 ? "Saving is Successful" : "Saving is Failed";
        BlogResponseModel model = new BlogResponseModel();
        model.IsSuccess = result > 0;
        model.Message = message;
        return model;

    }
    public BlogResponseModel UpsertBlog([FromBody] BlogModel requestModel)
    {
        BlogResponseModel model = new BlogResponseModel();
        var blog = GetBlog(requestModel.BlogId!);
        if (blog is not null)
        {
            string query = $@"UPDATE [dbo].[Tbl_Blog]
   SET
       [BlogTitle] = @BlogTitle
      ,[BlogAuthor] = @BlogAuthor
      ,[BlogContent] =@BlogContent
 WHERE [BlogId]=@BlogId";
            using IDbConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);

            int result = connection.Execute(query, requestModel);

            string message = result > 0 ? "Updating Successful" : "Updating Failed";
            model.IsSuccess = result > 0;
            model.Message = message;


        }
        else if (blog is null)
        {
            model = CreateBlog(requestModel);
        }

        return model;


    }

    public BlogResponseModel UpdateBlog(BlogModel requestModel)
    {
        string query = $@"UPDATE [dbo].[Tbl_Blog]
   SET
       [BlogTitle] = @BlogTitle
      ,[BlogAuthor] = @BlogAuthor
      ,[BlogContent] =@BlogContent
 WHERE [BlogId]=@BlogId";
        using IDbConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
        var item = GetBlog(requestModel.BlogId!);
        if (item is null)
        {
            return new BlogResponseModel()
            {
                IsSuccess = false,
                Message = "No Found Data"
            };

        }
        if (string.IsNullOrEmpty(requestModel.BlogTitle))
        {
            item.BlogTitle = requestModel.BlogTitle;
        }
        if (string.IsNullOrEmpty(requestModel.BlogAuthor))
        {
            item.BlogAuthor = requestModel.BlogAuthor;
        }
        if (string.IsNullOrEmpty(requestModel.BlogContent))
        {
            item.BlogContent = requestModel.BlogContent;

        }

        int result = connection.Execute(query, requestModel);
        string message = result > 0 ? "Updating Successful" : "Updating Failed";
        BlogResponseModel model = new BlogResponseModel();
        model.IsSuccess = result > 0;
        model.Message = message;
        return model;
    }

    public BlogResponseModel DeleteBlog(string Id)
    {
        string query = "Delete from Tbl_Blog where [BlogId]=@BlogId";
        using IDbConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
        int result = connection.Execute(query, new BlogModel
        {
            BlogId = Id
        });

        string message = result > 0 ? "Delete is Successful" : "Delete is Failed";
        BlogResponseModel model = new BlogResponseModel();

        model.IsSuccess = result > 0;
        model.Message = message;

        return model;

    }
}
