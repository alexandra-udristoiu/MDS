using MDS_BE.Entities;
using MDS_BE.Models;
using MDS_BE.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MDS_BE.Managers
{
    public class PostManager : IPostManager
    {
        private readonly IPostRepository postsRepository;

        public PostManager(IPostRepository postsRepository)
        {
            this.postsRepository = postsRepository;
        }

        private Post GetPostById(int id, string userId)
        {
            var post = postsRepository.GetPostsIQueryable()
                .FirstOrDefault(x => x.Id == id && x.UserId == userId);

            return post;
        }

        public Post Create(PostModel model)
        {
            var newPost = new Post
            {
                Title = model.Title,
                Text = model.Text,
                UserId = model.UserId,
                Tags = model.Tags
            };

            postsRepository.Create(newPost);
            return newPost;
        }

        public void Delete(int id, string userId)
        {
            var post = GetPostById(id, userId);
            if (post == null)
            {
                return;
            }

            postsRepository.Delete(post);
        }

        public List<Post> GetPosts()
        {
            var posts = postsRepository
                .GetPostsIQueryable()
                .Include(p => p.User)
                .ToList();

            for (var i = 0; i < posts.Count; i++)
            {
                posts[i].User = new User
                {
                    UserName = posts[i].User.UserName,
                    Id = posts[i].User.Id
                };
            }

            return posts;
        }

        public List<Post> GetUserPosts(string userId)
        {
            var cursor = postsRepository.GetPostsIQueryable()
                .Where(p => p.UserId == userId);
            return cursor.ToList();
        }

        public void Update(PostModel model)
        {
            var post = GetPostById(model.Id, model.UserId);
            if (post == null)
            {
                throw new Exception();
            }

            if (model.Title != null)
            {
                post.Title = model.Title;
            }
            if (model.Text != null)
            {
                post.Text = model.Text;
            }
            postsRepository.Update(post);
        }
        public Post GetAnyPostById(int postId)
        {
            return postsRepository.GetPostById(postId);
        }
    }
}