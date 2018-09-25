using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PersonLibrary.Entities
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }
        [Required]
        public string Title { get; set; }
        public string Genres { get; set; }
        public string Directors { get; set; }
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public int Runtime { get; set; }
        public string Type { get; set; }
        public string ImdbCode { get; set; }
        public decimal ImdbRating { get; set; }
        public int UserRating { get; set; }
        [DataType(DataType.Date)]
        public DateTime UserRatingDate { get; set; }

    }
}

