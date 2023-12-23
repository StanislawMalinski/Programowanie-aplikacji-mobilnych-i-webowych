using System;

namespace WebApp.Components.Services
{
    public interface IClientComment
    {
        public Task<Comment> PostComment(Comment comment);
        public Task<Comment> GetComment(string id);        
        public Task<List<Comment>> GetCommentsForPost(string id);
        public Task<Comment> PutComment(Comment comment);
        public Task<Boolean> DeleteComment(string id);
    }
}
