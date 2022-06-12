using MDS_BE.Entities;
using System.Linq;

namespace MDS_BE.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private DatabaseContext db;

        public CommentRepository(DatabaseContext db)
        {
            this.db = db;
        }

        public IQueryable<Comment> GetCommentsIQueryable()
        {
            var comments = db.Comments;

            return comments;
        }

        public void Create(Comment comment)
        {
            db.Comments.Add(comment);

            db.SaveChanges();
        }

        public void Update(Comment comment)
        {
            db.Comments.Update(comment);

            db.SaveChanges();
        }

        public void Delete(Comment comment)
        {
            db.Comments.Remove(comment);

            db.SaveChanges();
        }
    }
}
