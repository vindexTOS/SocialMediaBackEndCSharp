using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Model.Comment;
using Model.Likes;
using Models.User;

namespace Model.Posts;


public class PostModel
{
    internal List<CommentModel> comments;

    public int Id { get; set; }
	public int UserId { get; set; }
	[Required]
	[MaxLength(2000)]
	public string? Text { get; set; }
	[MaxLength(2000)]
	public string? Photo { get; set; }

	public bool isDeleted { get; set; } = false;

	public UserModel? User { get; set; }
 
    public virtual ICollection<CommentModel>? Comments { get; set; }

	public int Likes { get; set; }
 
}

public class UpdateModel : PostModel
{
	public int PostID { get; set; }
	public bool? IsDeleted { get; set; }
}