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
        public int LikeID { get; set; }
        public Post LikedPost { get; set; }
        public Guid Liker { get; set; }
    }
}
