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
                CreatedAt = dto.CreatedAt,
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
                CreatedAt = dto.CreatedAt,
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
                CreatedAt = comment.CreatedAt,
                UserId = comment.User.Id,
                PostId = comment.PostId
            };
        }
    }
}
