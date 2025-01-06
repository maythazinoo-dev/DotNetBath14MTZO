using DotNetBath14MTZO.Shared;

namespace DotNetBatch14MTZO.MinimalApi.Endpoints
{
    public static class BlogEndpoints
    {
        public static void UseBlogEndpoints(this IEndpointRouteBuilder app)
        {

            app.MapGet("/api/blogs", () =>
            {

                BlogEfCoreService blogEfCoreService = new BlogEfCoreService();
                var model = blogEfCoreService.GetBlogs();
                return Results.Ok(model);
            })
            .WithName("GetBlogs")
            .WithOpenApi();

            app.MapGet("/api/blogs/{id}", (string id) => {
                BlogEfCoreService blogEfCoreService = new BlogEfCoreService();
                var model = blogEfCoreService.GetBlog(id);
                return Results.Ok(model);
            })
            .WithName("GetBlog")
            .WithOpenApi();

            app.MapPost("/api/blogs", (BlogModel requestModel) => {
                BlogEfCoreService blogEfCoreService = new BlogEfCoreService();
                var model = blogEfCoreService.CreateBlog(requestModel);
                return Results.Ok(model);
            })
            .WithName("CreateBlog")
            .WithOpenApi();

            app.MapPatch("/api/blogs/{id}", (string id, BlogModel requestModel) =>
            {
                requestModel.BlogId = id;
                BlogEfCoreService blogEfCoreService = new BlogEfCoreService();
                var model = blogEfCoreService.UpdateBlog(requestModel);
                return Results.Ok(model);
            })
            .WithName("UpdateBlog")
            .WithOpenApi();

            app.MapPut("/api/blogs/{id}", (string id, BlogModel requestModel) =>
            {
                requestModel.BlogId = id;
                BlogEfCoreService blogEfCoreService = new BlogEfCoreService();
                var model = blogEfCoreService.UpsertBlog(requestModel);
                return Results.Ok(model);

            })
            .WithName("UpsertBlog")
            .WithOpenApi();

            app.MapDelete("/api/blogs/{id}", (string id) =>
            {
                BlogEfCoreService blogEfCoreService = new BlogEfCoreService();
                var model = blogEfCoreService.DeleteBlog(id);
                return Results.Ok(model);
            })
            .WithName("DeleteBlog")
            .WithOpenApi();

        }
    }
}
