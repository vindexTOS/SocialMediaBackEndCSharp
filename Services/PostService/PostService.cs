using Data.Context;
using DTOs.Post;
using Microsoft.AspNetCore.Http.HttpResults;
using Model.Posts;

namespace Services.PostService;




public class PostService : IPostService {
    private readonly DataDbContext _dbContext;
    public PostService(DataDbContext dbContext) {
        _dbContext = dbContext;
    }

  public async Task <string> CreatePost(PostDto requestBody){
        var newPost = new PostModel
        {
            Text = requestBody.Text,
            UserId  = requestBody.UserId,
            Photo = requestBody.Photo
        };

        await _dbContext.AddAsync( newPost);
        await _dbContext.SaveChangesAsync();
        return "Post has been made";
    }

 
} 