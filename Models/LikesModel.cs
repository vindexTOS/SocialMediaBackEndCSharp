using Model.Posts;
using Models.User;

namespace Model.Likes;


public class LikesModel { 
	public int Id { get; set; }
    public int PostId { get; set; }
    public int UserId { get; set; }  

    public UserModel? User { get; set; }
    public PostModel? Post { get;   set; }
}