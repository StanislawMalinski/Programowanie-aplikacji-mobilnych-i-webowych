using System;

public class PostDto
{
    public PostDto(){}
    public PostDto(Post post){
        this.Id = post.Id;
        this.Title = post.Title;
        this.Content = post.Content;
        this.CreatedAt = post.CreatedAt;
        this.UserId = post.User.Id;
    }
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; }
    public int UserId { get; set; }
}