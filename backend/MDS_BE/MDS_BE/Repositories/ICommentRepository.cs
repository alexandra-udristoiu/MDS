using MDS_BE.Entities;
using System.Linq;

namespace MDS_BE.Repositories
{
    public interface ICommentRepository
    {
        IQueryable<Comment> GetCommentsIQueryable();

        void Create(Comment comment);
        void Update(Comment comment);
        void Delete(Comment comment);
    }
}