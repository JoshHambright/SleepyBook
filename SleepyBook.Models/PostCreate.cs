using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SleepyBook.Models
{
    public class PostCreate
    {
        [Required]
        [MinLength(1, ErrorMessage = "Please enter a title of atleast 1 characters.")]
        [MaxLength(100, ErrorMessage="There are too many characters in this title")]
        public string Title { get; set; }
        [MaxLength(10000)]
        public string Text { get; set; }

    }
}
