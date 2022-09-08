using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary
{
    public class Review
    {
        [Key]
        public int Id { get; set; }
        public string ReviewText { get; set; } = String.Empty;
        public double Rating { get; set; } = 0;
        [ForeignKey("MovieId")]
        public virtual int Movie { get; set; }
        public virtual string UserEmail { get; set; }


    }
}
