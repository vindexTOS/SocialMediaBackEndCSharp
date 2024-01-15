
using DTOs.Likes;
using Like.Service.interfa;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Likes.Controller;



[Authorize]
[ApiController]
[Route("api/[controller]")]






public class LikesController : ControllerBase
{

    private readonly ILikesService _LikesService;



    public LikesController(ILikesService likesService)
    {
        _LikesService = likesService;
    }


    [HttpPost ]
    public async Task<IActionResult> MakeLike([FromBody] LikesDto requestBody)
    {
        try
        {
            return Ok(new { message = await _LikesService.CreateLike(requestBody) });

        }
        catch (InvalidOperationException ex)
        {

            return NotFound(new { message = ex.Message });

        }
    }

};