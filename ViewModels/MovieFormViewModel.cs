using MyFirstMVCWebApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyFirstMVCWebApp.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }

        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
       

        [Display(Name = "Genre")]
        [Required]
        public byte? GenreId { get; set; }

        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }

        [Display(Name = "Date Added")]
        public DateTime? DateAdded { get; set; }

        [Display(Name = "Number In Stock")]
        public int? NumberInStock { get; set; }

        public string Title
        {
            get
            {
                return Id != 0 ? "Edit Movie" : "New Movie";
            }
        }

        public MovieFormViewModel()
        {
            Id = 0;
        }
    }
}