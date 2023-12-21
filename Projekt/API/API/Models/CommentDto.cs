using System;

public class CommentDto
{
    public int Id { get; set; }
    public string Text { get; set; }
    public DateTime CreatedAt { get; set; }
    public int UserId { get; set; } // Foreign key for UserProfile
    public int PostId { get; set; }
}