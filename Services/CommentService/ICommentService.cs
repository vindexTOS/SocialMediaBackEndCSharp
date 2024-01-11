using DTOs.Comemtns;

namespace Services.CommentService;

public interface ICommentService{
    Task<string> CreateComment(CommentDto requestBody);
}