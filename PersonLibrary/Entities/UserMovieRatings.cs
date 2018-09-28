using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PersonLibrary.Entities
{
    public class UserMovieRatings
    {
        [Key]
        public int UserMovieRatingID { get; set; }
        [Required]
        public int MovieId { get; set; }
        [Required]
        public short Rating { get; set; }

        public virtual Movie Movie {get;set;}
    }
}
