using DTOs.Likes;

namespace Like.Service.interfa;

public interface ILikesService{
    Task<string> CreateLike(LikesDto requestBody);
}