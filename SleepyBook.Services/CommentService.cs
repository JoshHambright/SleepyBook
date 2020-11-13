using SleepyBook.Data;
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
                    Id = model.Id
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
                                    Id = e.Id,
                                    CommentID = e.CommentID,
                                    Text = e.Text,
                                    Author = _userId
                                    //Title = e.Title,
                                    //CreatedUtc = e.CreatedUtc
                                }
                        );

                return query.ToArray();
            }
        }

        public CommentDetail GetCommentsByPostId(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Comments
                        .Single(e => e.Id == id);
                return
                    new CommentDetail
                    {
                        CommentID = entity.CommentID,
                        Text = entity.Text,
                        Author = _userId
                    };
            }
        }


    }
}
