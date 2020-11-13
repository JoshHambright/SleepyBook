using SleepyBook.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SleepyBook.Models
{
    public class CommentCreate
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public Guid Author { get; set; }
       
    }
}
