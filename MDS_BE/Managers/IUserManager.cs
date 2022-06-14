using MDS_BE.Entities;
using MDS_BE.Models;
using System.Collections.Generic;

namespace MDS_BE.Managers
{
    public interface IUserManager
    {
        List<User> GetUsers();
        //List<Post> GetUserPosts(string id);
        void Create(string name);
        void Create(UserModel model);
        void Update(UserModel model);
        void Delete(string id);
        void AssignOrganization(string userId, int organizationId);
        void AssignCourse(string userId, int courseId);
    }
}