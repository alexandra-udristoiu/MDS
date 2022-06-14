using MDS_BE.Entities;
using MDS_BE.Models;
using MDS_BE.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MDS_BE.Managers
{
    public class CommentManager : ICommentManager
    {
        private readonly ICommentRepository commentsRepository;

        public CommentManager(ICommentRepository commentsRepository)
        {
            this.commentsRepository = commentsRepository;
        }

        private Comment GetCommentById(int id, string userId)
        {
            var comment = commentsRepository.GetCommentsIQueryable()
                .FirstOrDefault(x => x.Id == id && x.UserId == userId);

            return comment;
        }

        public void Create(CommentModel model)
        {
            var newComment = new Comment
            {
                PostId = model.PostId,
                Text = model.Text,
                UserId = model.UserId,

            };

            commentsRepository.Create(newComment);

        }

        public void Delete(int id, string userId)
        {
            var comment = GetCommentById(id, userId);
            if (comment == null)
            {
                return;
            }

            commentsRepository.Delete(comment);
        }

        public List<Comment> GetComments()
        {
            var comments = commentsRepository
                .GetCommentsIQueryable()
                .Include(p => p.User)
                .ToList();

            for (var i = 0; i < comments.Count; i++)
            {
                comments[i].User = new User
                {
                    UserName = comments[i].User.UserName,
                    Id = comments[i].User.Id
                };
            }

            return comments;
        }

        public List<Comment> GetUserComments(string userId)
        {
            var cursor = commentsRepository.GetCommentsIQueryable()
                .Where(p => p.UserId == userId);
            return cursor.ToList();
        }

        public void Update(CommentModel model)
        {
            var comment = GetCommentById(model.Id, model.UserId);
            if (comment == null || model.PostId != comment.PostId)
            {
                throw new Exception();
            }

            comment.Text = model.Text;
            commentsRepository.Update(comment);
        }

        public List<Comment> GetPostComments(int postId)
        {
            var cursor = commentsRepository.GetCommentsIQueryable()
                .Where(c => c.PostId == postId)
                .Include(c => c.User);
            return cursor.ToList();
        }

        public void DeleteComment(string userId, int postId, int commentId)
        {
            var comment = GetCommentById(commentId, userId);
            if (comment == null || comment.PostId != postId)
            {
                return;
            }

            commentsRepository.Delete(comment);
        }
    }
}