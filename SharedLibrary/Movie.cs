using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        public string Url { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; } = String.Empty;
        public string Director { get; set; } = String.Empty;
        public DateTime DateCreate { get; set; } = DateTime.Now;
        public string ReleaseYear { get; set; } = String.Empty;
        public string Image { get; set; } = String.Empty;
        public virtual ICollection<Review>? Reviews { get; set; }
    }
}
