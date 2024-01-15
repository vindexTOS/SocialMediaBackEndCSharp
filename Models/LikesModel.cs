
using System.ComponentModel.DataAnnotations.Schema;
using Models.User;

namespace Model.Likes;


public class LikesModel { 
	public int Id { get; set; }
    public int PostId { get; set; }
 
    public int UserId { get; set; }
 
  }
