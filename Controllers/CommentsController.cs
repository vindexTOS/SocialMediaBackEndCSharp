using DTOs.Comemtns;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.CommentService;

namespace Comments.Controller;
[Authorize]
[ApiController]
[Route("api/[controller]")]



public class CommentsController : ControllerBase
{

    private readonly ICommentService _commentService;

    public CommentsController(ICommentService commentService)
    {
        _commentService = commentService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateComment([FromBody] CommentDto requestBody)
    {
        try
        {

            return Ok(new { message = await _commentService.CreateComment(requestBody) });
        }
        catch (InvalidOperationException ex)
        {

            return NotFound(new { message = ex.Message });

        }
    }

    [HttpDelete]

    public async Task<IActionResult> DeleteComment(int id)
    {
        try
        {
            return Ok(new { message = await _commentService.DeleteComment(id) });
        }
        catch (InvalidOperationException ex)
        {

            return NotFound(new { message = ex.Message });
        }
    }

    [HttpPut]
    public async Task<IActionResult> PutComment([FromBody] CommentDto requestBody)
    {

        try
        {
            return Ok(new { message = await _commentService.EditComment(requestBody) });
        }
        catch (InvalidOperationException ex)
        {

            return NotFound(new { message = ex.Message });

        }
    }
}
