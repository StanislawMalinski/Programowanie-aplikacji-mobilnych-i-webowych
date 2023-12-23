using System;

public class CommentDto
{
    public CommentDto(){}
    public CommentDto(Comment comment){
        this.Id = comment.Id;
        this.Text = comment.Text;
        this.CreatedAt = comment.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss");
        this.UserId = comment.User.Id;
        this.PostId = comment.PostId;
    }
    public int Id { get; set; }
    public string Text { get; set; }
    public string CreatedAt { get; set; }
    public int UserId { get; set; } // Foreign key for UserProfile
    public int PostId { get; set; }// Foreign key for UserProfile
}