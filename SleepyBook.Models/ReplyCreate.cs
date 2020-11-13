using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SleepyBook.Models
{
    public class ReplyCreate
    {
        [MaxLength(10000)]
        public string Text { get; set; }
        public int CommentId { get; set; }

    }
}
