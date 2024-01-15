using DTOs.Comemtns;

namespace Services.CommentService;

public interface ICommentService{
    Task<string> CreateComment(CommentDto requestBody);
    Task<string> DeleteComment(int id);

    Task<string> EditComment(CommentDto requestBody);
}