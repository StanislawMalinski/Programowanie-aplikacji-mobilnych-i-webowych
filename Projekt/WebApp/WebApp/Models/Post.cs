using System;

public class Post
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; }
    public UserProfile User { get; set; } 
    public List<Comment> Comments { get; set; }
}