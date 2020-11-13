using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SleepyBook.Models
{
    public class ReplyDetails
    {
        public int ReplyID { get; set; }
        public string Text { get; set; }
        public Guid Author { get; set; }
        public int CommentID { get; set; }
        //public DateTimeOffset CreatedUtc { get; set; }
    }
}
