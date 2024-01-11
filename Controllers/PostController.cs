using DTOs.Post;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.PostService;
using Services.UserServices;


namespace Post.Controller;
[Authorize]
[ApiController]
[Route("api/[controller]")]




public class PostController : ControllerBase
{
    private readonly IPostService _PostService;




    public PostController(IPostService PostService)
    {
        _PostService = PostService;
    }


    [HttpPost("make")]
    public async Task<IActionResult> CreatePost([FromBody] PostDto requestBody)
    {
        try
        {
            return Ok(new { message = await _PostService.CreatePost(requestBody) });
        }
        catch (InvalidOperationException ex)
        {

            return NotFound(new { message = ex.Message });

        }
    }

    [HttpPut("update")]

    public async Task<IActionResult> PutPost([FromBody] UpdatePostDto requestBody)
    {
        try
        {
            return Ok(new { message = await _PostService.PutPost(requestBody) });
        }
        catch (InvalidOperationException ex)
        {
            return NotFound(new { message = ex.Message });
        }
        catch (InvalidDataException ex)
        {
            return StatusCode(500, new { message = ex.Message });

        }
    }
    [HttpDelete("delete")]

    public async Task<IActionResult> DeletePost([FromQuery] int postId, [FromQuery] int userId)
    {

        try
        {
            return Ok(new { message = await _PostService.DeletePost(postId, userId) });

        }
        catch (InvalidOperationException ex)
        {

            return NotFound(new { message = ex.Message });

        }
        catch (InvalidDataException ex)
        {
            return StatusCode(500, new { message = ex.Message });

        }
    }
    [AllowAnonymous]
    [HttpGet("get-all")]
    public async Task<IActionResult> GetAll([FromQuery] string? search, [FromQuery] int? userId,[FromQuery] int page = 1 ,  [FromQuery] int pageSize = 10)
    {

        try
        {
            return Ok(new { data = await _PostService.GetAllPosts(search, userId,   page ,  pageSize) });
        }
        catch (InvalidDataException ex)
        {

            return StatusCode(500, new { message = ex.Message });

        }
    }

    [AllowAnonymous]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetSingle(int id)
    {
        try
        {
            return Ok(new { data =  await _PostService.GetSingle(id)   });
        }
        catch (InvalidDataException ex)
        {

            return StatusCode(500, new { message = ex.Message });

        }
    }

}