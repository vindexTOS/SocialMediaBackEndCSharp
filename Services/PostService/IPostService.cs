using DTOs.Post;

namespace Services.PostService;



public interface IPostService{
   	Task<string>CreatePost(PostDto requestBody);

}