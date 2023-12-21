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
                CreatedAt = dto.CreatedAt,
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
                CreatedAt = post.CreatedAt,
                UserId = post.User.Id
            };
        }
    }
}
