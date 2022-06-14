using MDS_BE.Entities;
using MDS_BE.Managers;
using MDS_BE.Models;
using MDS_BE.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MDS_BE.Managers
{
    public class UserManager : IUserManager
    {
        private readonly IUserRepository usersRepository;
        //private readonly IPostRepository postsRepository;
        //private readonly IUserCourseRepository userCourseRepository;

        public UserManager(IUserRepository usersRepository)
        {
            this.usersRepository = usersRepository;
            //this.postsRepository = postsRepository;
            //this.userCourseRepository = userCourseRepository;
        }

        public User GetUserById(string id)
        {
            var user = usersRepository.GetUsersIQueryable()
                .FirstOrDefault(x => x.Id == id);

            return user;
        }

        public void Create(string name)
        {
            var newUser = new User
            {
                UserName = name
            };

            usersRepository.Create(newUser);
        }

        public void Create(UserModel model)
        {
            throw new NotImplementedException();
        }

        public void Delete(string id)
        {
            var user = GetUserById(id);

            usersRepository.Delete(user);
        }

        public List<User> GetUsers()
        {
            var cursor = usersRepository.GetUsersIQueryable().ToList();
            return cursor;
        }

        //public List<Post> GetUserPosts(string id)
        //{
        //    return postsRepository
        //        .GetPostsIQueryable()
        //        .Where(p => p.UserId == id)
        //        .ToList();
        //}

        //public List<UserCourse> GetUserCourses(string userId)
        //{
        //    var courses = userCourseRepository.GetUsersCoursesIQueryable()
        //                .Where(uc => uc.UserId == userId)
        //                .Include(x => x.Course)
        //                .ToList();

        //    return courses;
        //}

        public void Update(UserModel model)
        {
            if (model.Id == "")
            {
                Create(model.Name);
                return;
            }

            var user = GetUserById(model.Id);

            user.UserName = model.Name;
            usersRepository.Update(user);
        }

        public void AssignOrganization(string userId, int organizationId)
        {
            if (userId == null)
            {
                throw new Exception();
            }

            usersRepository.AssignOrganization(userId, organizationId);
        }

        public void AssignCourse(string userId, int courseId)
        {

            if (userId == null)
            {
                throw new Exception();
            }

            usersRepository.AssignOrganization(userId, courseId);
        }
    }
}