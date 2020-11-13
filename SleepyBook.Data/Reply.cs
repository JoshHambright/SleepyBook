using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SleepyBook.Data
{
    public class Reply
    {
        [Key]
        public int ReplyID { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public Guid Author { get; set; }
        [Required]
        public int CommentId { get; set; }
        //[ForeignKey(nameof(CommentId))]
        //public virtual Comment Comment { get; set; }

        //public virtual List<Reply> Replies { get; set; }




        public DateTimeOffset CreatedUtc { get; set; }

    }
}
