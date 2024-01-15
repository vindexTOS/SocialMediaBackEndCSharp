using Data.Context;
using DTOs.Comemtns;
using Model.Comment;
using Services.GeneralServise;

namespace Services.CommentService;





public class CommentService : ICommentService
{


    private readonly DataDbContext _dbContext;
    private readonly IGeneralServices _generalService;

    public CommentService(DataDbContext dbContext, IGeneralServices generalServices)
    {
        _dbContext = dbContext;
        _generalService = generalServices;
    }

    public async Task<string> CreateComment(CommentDto requestBody)
    {
        var newComment = _generalService.ConvertDtoToModel<CommentDto, CommentModel>(requestBody);


        await _dbContext.AddAsync(newComment);
        await _dbContext.SaveChangesAsync();

        return "Comment Has Been Made";
    }
    public async Task<string> DeleteComment(int id)
    {
        var result = _dbContext.Comments.FirstOrDefault(x => x.Id == id) ?? throw new InvalidOperationException("Item not found");

        _dbContext.Remove(result);
        await _dbContext.SaveChangesAsync();
        return "Comment Has Been Deleted";
    }


    public async Task<string> EditComment(CommentDto requestBody)
    {
        var updatedComment = _generalService.ConvertDtoToModel<CommentDto, CommentModel>(requestBody);
       
        var existingComment = await _dbContext.Comments.FindAsync(updatedComment.Id);
        if (existingComment is null) throw new InvalidOperationException("Comment not found");


        existingComment = updatedComment;

        await _dbContext.SaveChangesAsync();
        return "Comment Has Been updated";
    }
}

