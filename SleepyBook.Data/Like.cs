using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SleepyBook.Data
{
    public class Like
    {
        [Key]

        public int LikeId { get; set; }
        [Required]
        public int PostId { get; set; }


        public Guid Liker { get; set; }
        public virtual Post LikedPost { get; set; }
    }
}
