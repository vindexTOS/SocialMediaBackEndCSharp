using DTOs.Post;
using Microsoft.AspNetCore.Mvc;
using Model.Posts;

namespace Services.PostService;



public interface IPostService
{

	Task<string> CreatePost(PostDto requestBody);
	Task<string> PutPost(UpdatePostDto requestBody);

	Task<string> DeletePost( int postId, int userId );

	Task<List<PostModel>> GetAllPosts(string? search, int? userId, int page , int pageSize);
 	Task<object> GetSingle(int id);


}