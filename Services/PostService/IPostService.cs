using DTOs.Post;
using Model.Posts;

namespace Services.PostService;



public interface IPostService
{

	Task<string> CreatePost(PostDto requestBody);
	Task<string> PutPost(UpdatePostDto requestBody);

	Task<string> DeletePost( int postId, int userId );

	Task<List<PostModel>> GetAllPosts(string? search, int? userId);
 


    // Task<PostModel> GetSingle(int id);


}