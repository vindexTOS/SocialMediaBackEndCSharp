using System.ComponentModel.DataAnnotations;
using DTOs.User;
using Model.Posts;
using Models.User;

namespace DTOs.Comemtns;


public class CommentDto
{
 public int Id { get; set; } 
    internal UserDto User;

    [Required]
    public int UserId { get; set; }
    [Required]
    public string? Text { get; set; }
    [Required]
    public int PostId { get; set; }

 


}


public class UpdateCommentDto {

    internal int id;
    public string? Text { get; set; }
    public int UserId { get; set; }
    public int PostId { get; set; }

}