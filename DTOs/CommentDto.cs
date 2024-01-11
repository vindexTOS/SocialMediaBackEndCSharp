using System.ComponentModel.DataAnnotations;
using DTOs.User;
using Model.Posts;
using Models.User;

namespace DTOs.Comemtns;


public class CommentDto
{
    internal int Id;
    internal UserDto User;

    [Required]
    public int UserId { get; set; }
    [Required]
    public string? Text { get; set; }
    [Required]
    public int PostId { get; set; }

 


}