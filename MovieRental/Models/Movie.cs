using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MovieRental.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter Movie Name")]
        public string MovieName { get; set; }

        public MovieGenre MovieType { get; set; }
        [Required(ErrorMessage ="Please select Movie Genre")]
        public int MovieTypeId { get; set; }
        [Required(ErrorMessage = "Please enter Release Date")]
        public DateTime ReleaseDate { get; set; }

        public DateTime DateAdded { get; set; }
        [Display(Name ="Number in Stock")]
        [Range(1,99, ErrorMessage ="Number in stock should be between 1-99")]
        public int NumberInStock { get; set; }
    }
}