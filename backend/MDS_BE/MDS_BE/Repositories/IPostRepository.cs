using MDS_BE.Entities;
using System.Linq;

namespace MDS_BE.Repositories
{
    public interface IPostRepository
    {
        IQueryable<Post> GetPostsIQueryable();

        void Create(Post post);
        void Update(Post post);
        void Delete(Post post);
        Post GetPostById(int postId);
    }
}