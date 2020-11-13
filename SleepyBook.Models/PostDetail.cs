using SleepyBook.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SleepyBook.Models
{
    public class PostDetail
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public Guid Author { get; set; }
        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        //public virtual List<CommentList> Comments { get; set; } = new List<Comment>();
    }
}
