using DTOs.Post;
using Microsoft.AspNetCore.Mvc;
using Services.PostService;
using Services.UserServices;


namespace Post.Controller;
[ApiController]
[Route("api/[controller]")]




public class PostController : ControllerBase
{
    private readonly  IPostService _PostService;




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


}