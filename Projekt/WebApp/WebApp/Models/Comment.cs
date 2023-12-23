using System;

public class Comment
{
    public int Id { get; set; }
    public string Text { get; set; }
    public DateTime CreatedAt { get; set; }
    public UserProfile User { get; set; } 
    public int PostId { get; set; } 
}