using System.ComponentModel.DataAnnotations;
using DTOs.User;

namespace DTOs.Post;
public class PostDto{
    internal bool isDeleted;
    internal int Id;
    internal UserDto User;
    internal object Comments;

    [Required]
    public int UserId  { get; set; }
    [Required]
    [MaxLength(2000)]
    public string? Text { get; set; }
    [MaxLength(2000)]
    public string? Photo { get; set; }

  
}

public class UpdatePostDto : PostDto{
   

    public int  PostId  { get; set; }

 
}

 