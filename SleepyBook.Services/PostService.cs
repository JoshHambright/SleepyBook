﻿using SleepyBook.Data;
using SleepyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SleepyBook.Services
{
    public class PostService
    {
        private readonly Guid _userId;

        public PostService(Guid userId)
        {
            _userId = userId;
        }
        //Create
        public bool CreatePost(PostCreate model)
        {

            var entity = new Post()
            {
                Author = _userId,
                Title = model.Title,
                Text = model.Text,
                CreatedUtc = DateTimeOffset.Now
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Posts.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        //Read
        public IEnumerable<PostListItem> GetPosts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Posts
                        .Select(
                            e =>
                                new PostListItem
                                {
                                    Id = e.Id,
                                    Title = e.Title,
                                    Author = e.Author
                                    //Text = e.Text
                                }
                        );
                return query.ToArray();
            }
        }

        public PostDetail GetPostById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Posts
                        .Single(e => e.Id == id);

                return
                    new PostDetail
                    {
                        Id = entity.Id,
                        Author = entity.Author,
                        Title = entity.Title,
                        Text = entity.Text,
                        LikeCount = entity.LikeCount,
                        Comments = entity.Comments.Select(
                            e => 
                                new CommentList
                                {
                                    CommentID = e.CommentID,
                                    Text = e.Text,
                                    Author = e.Author,
                                    Replies = e.Replies.Select(
                                        x =>
                                            new ReplyDetails
                                            {
                                                ReplyID = x.ReplyID,
                                                Text = x.Text,
                                                Author = x.Author,
                                                CommentID = x.CommentID
                                            }).ToList()
                                }).ToList()
                        ,
                        CreatedUtc = entity.CreatedUtc
                    };
            }
        }




    }
}
