using MDS_BE.Entities;
using MDS_BE.Models;
using System.Collections.Generic;

namespace MDS_BE.Managers
{
    public interface IPostManager
    {
        List<Post> GetPosts();
        List<Post> GetUserPosts(string userId);
        Post Create(PostModel model);
        void Update(PostModel model);
        void Delete(int id, string userId);
        Post GetAnyPostById(int postId);
    }
}
