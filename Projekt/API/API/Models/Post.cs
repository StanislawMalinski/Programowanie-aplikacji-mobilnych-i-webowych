using System;
using System.Runtime.CompilerServices;

public class Post
{
    public Post(){}
    public Post(PostDto dto){
        Id = dto.Id;
        Title = dto.Title;
        Content = dto.Content;
        CreatedAt = DateTime.ParseExact(dto.CreatedAt, "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
        }
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; }
    public UserProfile User{ get; set; }
    public List<Comment> Comments { get; set; }
}