using System.ComponentModel.DataAnnotations;

namespace DTOs.Post;
public class PostDto{
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

 