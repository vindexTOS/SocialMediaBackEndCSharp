

using System.Security.Authentication;
using System.Text.Json;
using System.Text.Json.Serialization;
using Data.Context;
using DTOs.Post;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.ObjectPool;
using Model.Posts;
using Newtonsoft.Json;
using Services.GeneralServise;

namespace Services.PostService;




public class PostService : IPostService
{
    private readonly DataDbContext _dbContext;
    private readonly IGeneralServices _generalService;

    public PostService(DataDbContext dbContext, IGeneralServices generalServices)
    {
        _dbContext = dbContext;
        _generalService = generalServices;

    }
    public async Task<string> CreatePost(PostDto requestBody)
    {
        var newPost = _generalService.ConvertDtoToModel<PostDto, PostModel>(requestBody);

        await _dbContext.AddAsync(newPost);
        await _dbContext.SaveChangesAsync();
        return "Post has been made";
    }

    public async Task<string> PutPost(UpdatePostDto requestBody)
    {
        var PutPost = _generalService.ConvertDtoToModel<UpdatePostDto, UpdateModel>(requestBody);

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


    public async Task<List<PostModel>> GetAllPosts(string? search, int? userId, int page = 1, int pageSize = 10)
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
        int skip = (page - 1) * pageSize;

        List<PostModel> posts = await query
           .Skip(skip)
           .Take(pageSize)
           .ToListAsync();

        return posts;
    }


    public async Task<object> GetSingle(int id)
    {
        var singlePost = await _dbContext.Posts.Include(u => u.User)
        .Include((p) =>   p.Comments )
        .FirstOrDefaultAsync(p => p.Id == id) 
        ?? throw new InvalidOperationException("Post not found");
    var likes = await _dbContext.Likes
    .Where(l => l.PostId == id)
  .CountAsync();
    var options = new JsonSerializerOptions
    {
        ReferenceHandler = ReferenceHandler.Preserve,
        MaxDepth = 32,
        // Other options as needed
    };

        var postData = new
        {
            Post = new
            {
                singlePost.Text,
                singlePost.Photo,
                singlePost.isDeleted,
                singlePost.User.UserName,
                singlePost.User.Avatar,
                singlePost.UserId,
                singlePost.Id,
            
 
            Comments = singlePost.Comments.Select(comment => new
            {
                comment.Id,
                comment.Text,
                User = new
                {
                    comment.User.Id,
                    comment.User.UserName
                }
            }),
            Likes = likes 
        }
    };

    var jsonString = System.Text.Json.JsonSerializer.Serialize(postData, options);
    var jsonObject = JsonDocument.Parse(jsonString).RootElement.Clone();
    return jsonObject;
    }
    private async Task<bool> CheckUser(int postId, int userId)
    {

        var user = await _dbContext.Users.FindAsync(userId);
        var post = await _dbContext.Posts.FindAsync(postId);

        return user != null && post != null && user.Id == post.UserId;
    }






}


