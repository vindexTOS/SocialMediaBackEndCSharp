using AutoMapper;
using Data.Context;
using DTOs.Post;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.ObjectPool;
using Microsoft.OpenApi.Any;
using Model.Posts;

namespace Services.PostService;




public class PostService : IPostService
{
    private readonly DataDbContext _dbContext;


    public PostService(DataDbContext dbContext)
    {
        _dbContext = dbContext;

    }
    public async Task<string> CreatePost(PostDto requestBody)
    {
        var newPost = ConvertDtoToModel<PostDto, PostModel>(requestBody);

        await _dbContext.AddAsync(newPost);
        await _dbContext.SaveChangesAsync();
        return "Post has been made";
    }

    public async Task<string> PutPost(UpdatePostDto requestBody)
    {
        var PutPost = ConvertDtoToModel<UpdatePostDto, UpdateModel>(requestBody);

        if (!await CheckUser(PutPost.PostID, PutPost.UserId)) throw new InvalidOperationException("User not found");
        var existingPost = await _dbContext.Posts.FindAsync(PutPost.PostID);
        if (existingPost is null) throw new InvalidOperationException("Post not found");


        existingPost.Text = PutPost.Text;
        existingPost.UserId = PutPost.UserId;
        existingPost.Photo = PutPost.Photo;
        await _dbContext.SaveChangesAsync();
        return "Item Has Been Updated";
    }

    public async Task<string> DeletePost(int postId, int userId)
    {

        if (!await CheckUser(postId, userId)) throw new InvalidOperationException("User not found");
        var existingPost = await _dbContext.Posts.FindAsync(postId);
        if (existingPost is null) throw new InvalidOperationException("Post not found");
        existingPost.isDeleted = true;
        await _dbContext.SaveChangesAsync();

        return "Item Has Been Deleted";

    }


    public async Task<List<PostModel>> GetAllPosts(string? search, int? userId)
{
    IQueryable<PostModel> query = _dbContext.Posts;

    if (!string.IsNullOrEmpty(search))
    {
        query = query.Where(post => post.Text.Contains(search));
    }

    if (userId.HasValue && userId != 0)
    {
        query = query.Where(post => post.UserId == userId);
    }

    List<PostModel> posts = await query.ToListAsync();
    return posts;
}


    private async Task<bool> CheckUser(int postId, int userId)
    {

        var user = await _dbContext.Users.FindAsync(userId);
        var post = await _dbContext.Posts.FindAsync(postId);
        Console.WriteLine(postId);
        return user != null && post != null && user.Id == post.UserId;
    }



    private static TDestination ConvertDtoToModel<TSource, TDestination>(TSource dto) where TSource : class
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<TSource, TDestination>());
        var mapper = new Mapper(config);

        return mapper.Map<TSource, TDestination>(dto);
    }


}


