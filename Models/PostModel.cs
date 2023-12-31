using System.ComponentModel.DataAnnotations;
using Model.Comment;
using Model.Likes;
using Models.User;

namespace Model.Posts;


public class PostModel { 
	public int  Id { get; set; }  	
	public int UserId { get; set; }   
	[Required]
	[MaxLength(2000)]
	public string? Text { get; set; }
	[MaxLength(2000)]
	public string? Photo { get; set; }

	public bool isDeleted { get; set; } = false;
	
	public UserModel? User { get; set; }
	public ICollection<CommentModel>? Comments { get; set; }
    public ICollection<LikesModel>? Likes { get; set; }

}

public class UpdateModel : PostModel{
	  public int  PostID  { get; set; }
	  public bool? IsDeleted { get; set; }
}