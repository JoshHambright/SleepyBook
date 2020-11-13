using SleepyBook.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SleepyBook.Models
{
    public class CommentList
    {
        public int Id { get; set; }
        public int CommentID { get; set; }
        public string Text { get; set; }
        public Guid Author { get; set; }
        public List<ReplyDetails> Replies { get; set; } = new List<ReplyDetails>();
        //Select FROM *
    }
}
