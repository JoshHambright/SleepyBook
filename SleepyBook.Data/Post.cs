﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SleepyBook.Data
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Text { get; set; }
        public Guid Author { get; set; }
        //public virtual List<Comment> Comments { get; set; } = new List<Comment>();

        public DateTimeOffset CreatedUtc { get; set; }




    }
}
