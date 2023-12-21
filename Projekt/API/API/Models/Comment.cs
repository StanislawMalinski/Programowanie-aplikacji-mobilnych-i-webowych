using System;

public class Comment
{
    public Comment(){}
    public Comment(CommentDto dto)
    {
        Id = dto.Id;
        Text = dto.Text;
        CreatedAt = dto.CreatedAt;
    }
    public int Id { get; set; }
    public string Text { get; set; }
    public DateTime CreatedAt { get; set; }
    public UserProfile User { get; set; }
    public int PostId { get; set; }
}