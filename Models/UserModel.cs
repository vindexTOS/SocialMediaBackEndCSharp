

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Comment;
using Model.Likes;
using Model.Posts;

namespace Models.User;
 
	public class UserModel
	{
		public int Id { get; set; }
		[Required]
		[MaxLength(150)]
		public string? Email { get; set; }
		[Required]
		[MaxLength(50)]
		public required string  UserName { get; set; }
		[MaxLength(1000)]
		public string? Password { get; set;}
		[MaxLength(1500)]
   		public string? Avatar { get; set; } = "https://images-wixmp-ed30a86b8c4ca887773594c2.wixmp.com/f/271deea8-e28c-41a3-aaf5-2913f5f48be6/de7834s-6515bd40-8b2c-4dc6-a843-5ac1a95a8b55.jpg?token=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJzdWIiOiJ1cm46YXBwOjdlMGQxODg5ODIyNjQzNzNhNWYwZDQxNWVhMGQyNmUwIiwiaXNzIjoidXJuOmFwcDo3ZTBkMTg4OTgyMjY0MzczYTVmMGQ0MTVlYTBkMjZlMCIsIm9iaiI6W1t7InBhdGgiOiJcL2ZcLzI3MWRlZWE4LWUyOGMtNDFhMy1hYWY1LTI5MTNmNWY0OGJlNlwvZGU3ODM0cy02NTE1YmQ0MC04YjJjLTRkYzYtYTg0My01YWMxYTk1YThiNTUuanBnIn1dXSwiYXVkIjpbInVybjpzZXJ2aWNlOmZpbGUuZG93bmxvYWQiXX0.BopkDn1ptIwbmcKHdAOlYHyAOOACXW0Zfgbs0-6BY-E";
		[MaxLength(10)]
		[Column(TypeName = "varchar(10)")]
		public string? Role { get; set; } = "user";



		public ICollection<CommentModel> Comments { get; set; } = new List<CommentModel>();
        public ICollection<PostModel> Posts { get; set; } = new List<PostModel>();
        public ICollection<LikesModel> Likes { get; set; } = new List<LikesModel>();
	}
 