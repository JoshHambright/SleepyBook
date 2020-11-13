using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SleepyBook.Models
{
    public class CommentDetail
    {
        //public int Id { get; set; } Technically unnecessary because they should know which post they're loading comments for...
        public int CommentID { get; set; }
        public string Text { get; set; }
        public Guid Author { get; set; }
        //Select FROM Comment WHERE (Post) Id = *insert here*
    }
}
