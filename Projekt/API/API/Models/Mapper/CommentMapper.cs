namespace API.Models.Mapper
{
    public static class CommentMapper
    {
        public static Comment mapDtoToComment(CommentDto dto, UserProfile user, Post post)
        {
            if (dto == null)
            {
                return null;
            }

            return new Comment
            {
                Id = dto.Id,
                Text = dto.Text,
                CreatedAt = DateTime.ParseExact(dto.CreatedAt, "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture),
                User = user,
                PostId = post.Id
            };
        }

        public static Comment mapDtoToComment(CommentDto dto, UserProfile user, int postId)
        {
            if (dto == null)
            {
                return null;
            }

            return new Comment
            {
                Id = dto.Id,
                Text = dto.Text,
                CreatedAt = DateTime.ParseExact(dto.CreatedAt, "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture),
                User = user,
                PostId = postId
            };
        }

        public static CommentDto mapCommentToDto(Comment comment)
        {
            if (comment == null)
            {
                return null;
            }

            return new CommentDto
            {
                Id = comment.Id,
                Text = comment.Text,
                CreatedAt = comment.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss"),
                UserId = comment.User.Id,
                PostId = comment.PostId
            };
        }
    }
}
