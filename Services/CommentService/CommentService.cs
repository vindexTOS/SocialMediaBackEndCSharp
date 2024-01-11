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
}

