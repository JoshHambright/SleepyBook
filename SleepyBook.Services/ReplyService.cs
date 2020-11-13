using SleepyBook.Models;
using SleepyBook.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SleepyBook.Services
{
    public class ReplyService
    {
        private readonly Guid _userId;

        public ReplyService(Guid userId)
        {
            _userId = userId;
        }
        //Create
        //Post a reply to a comment
        public bool CreateReply(ReplyCreate model)
        {
            var entity = new Reply()
            {
                Author = _userId,
                Text = model.Text,
                CommentID = model.CommentID,
                //CreatedUtc = DateTimeOffset.Now
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Replies.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }


        //Read
        //Get Comment Replies
        public IEnumerable<ReplyDetails> GetRepliesByCommentID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Replies
                        .Where(e => e.CommentID == id)
                        .Select(
                            e =>
                                new ReplyDetails
                                {
                                    ReplyID = e.ReplyID,
                                    Text = e.Text,
                                    Author = e.Author,
                                    //CreatedUtc = e.CreatedUtc,
                                }
                        );
                return query.ToArray();
            }
        }

    }
}
