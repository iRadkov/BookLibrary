using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibDatabase.Entities
{
    public class Genre
    {
        [Key]
        public int GenreId { get; set; }

        [Display(Name = "Genre")]
        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string GenreName { get; set; }

        [Display(Name = "Description")]
        [StringLength(200, MinimumLength = 1)]
        public string GenreDescription { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
