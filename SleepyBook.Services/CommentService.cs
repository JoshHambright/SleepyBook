﻿using SleepyBook.Data;
using SleepyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SleepyBook.Services
{
    public class CommentService
    {
        private readonly Guid _userId;

        public CommentService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateComment(CommentCreate model)
        {
            var entity =
                new Comment()
                {
                    Author = _userId,
                    //Title = model.Title,
                    Text = model.Text,
                    //CreatedUtc = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Comments.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CommentList> GetComments()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Comments
                        //.Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new CommentList
                                {
                                    CommentID = e.CommentID,
                                    //Title = e.Title,
                                    //CreatedUtc = e.CreatedUtc
                                }
                        );

                return query.ToArray();
            }
        }
    }
}