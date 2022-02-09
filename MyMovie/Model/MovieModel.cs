using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyMovie.Models
{
    
    public class MovieModel
    {
        [Key]
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public string ShowTiming { get; set; }
        public int Rating { get; set; }
    }
}