using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SleepyBook.Models
{
    public class LikeCreate
    {   
      
        public int PostId { get; set; }
        public Guid Liker { get; set; }
    }
}
