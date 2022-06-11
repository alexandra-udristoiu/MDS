using MDS_BE.Entities;
using MDS_BE.Models;
using System.Collections.Generic;

namespace MDS_BE.Managers
{
    public interface ICommentManager
    {
        List<Comment> GetComments();
        List<Comment> GetUserComments(string userId);
        void Create(CommentModel model);
        void Update(CommentModel model);
        void Delete(int id, string userId);
        void DeleteComment(string userId, int postId, int commentId);
        List<Comment> GetPostComments(int postId);
    }
}