using MDS_BE.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MDS_BE.Repositories
{
    public class PostRepository : IPostRepository
    {
        private DatabaseContext db;

        public PostRepository(DatabaseContext db)
        {
            this.db = db;
        }

        public IQueryable<Post> GetPostsIQueryable()
        {
            var posts = db.Posts;

            return posts;
        }

        public void Create(Post post)
        {
            db.Posts.Add(post);

            db.SaveChanges();
        }

        public void Update(Post post)
        {
            db.Posts.Update(post);

            db.SaveChanges();
        }

        public void Delete(Post post)
        {
            db.Posts.Remove(post);

            db.SaveChanges();
        }

        public Post GetPostById(int postId)
        {
            Post post = db.Posts.Include(p => p.User).FirstOrDefault(p => p.Id == postId);

            return post;
        }
    }
}