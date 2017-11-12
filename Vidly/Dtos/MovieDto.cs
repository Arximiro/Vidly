using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }
        public DateTime DateAdded { get; set; }

        [Required, MaxLength(255)]
        public string Name { get; set; }

        
        public DateTime ReleaseDate { get; set; }

        [Range(1, 20)]
        public byte NumberInStock { get; set; }

        
        public byte GenreId { get; set; }
    }
}