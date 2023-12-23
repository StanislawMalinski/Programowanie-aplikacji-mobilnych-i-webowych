namespace API.Models.Mapper
{
    public static class PostMapper
    {
        public static Post mapDtoToPost(PostDto dto, UserProfile user, List<Comment> comments)
        {
            if (dto == null)
            {
                return null;
            }

            return new Post
            {
                Id = dto.Id,
                Title = dto.Title,
                Content = dto.Content,
                CreatedAt = DateTime.ParseExact(dto.CreatedAt, "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture),
                User = user,
                Comments = comments
            };
        }

        public static PostDto mapPostToDto(Post post)
        {
            if (post == null)
            {
                return null;
            }

            return new PostDto
            {
                Id = post.Id,
                Title = post.Title,
                Content = post.Content,
                CreatedAt = post.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss"),
                UserId = post.User.Id
            };
        }
    }
}
