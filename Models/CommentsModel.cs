using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Model.Posts;
using Models.User;

namespace Model.Comment;


public class CommentModel
{
    public int Id { get; set; }
    public int PostId { get; set; }
    public int UserId { get; set; }
    [Required]
    [MaxLength(400)]

    public string? Text { get; set; }

    public UserModel? User { get; set; }
 
    public PostModel? Post { get; set; }

}