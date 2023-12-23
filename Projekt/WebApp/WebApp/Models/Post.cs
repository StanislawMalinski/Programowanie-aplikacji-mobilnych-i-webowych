using System;

public class Post
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; }
    public UserProfile User { get; set; } // Foreign key for UserProfile
    public List<Comment> Comments { get; set; }
    // Add other properties as needed
}