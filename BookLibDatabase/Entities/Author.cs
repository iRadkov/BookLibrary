using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibDatabase.Entities
{
   public class Author
    {
        [Key]
        public int AuthorId { get; set; }

        [Display(Name = "First Name")]
        [Required]
        [StringLength(200, MinimumLength = 1)]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [StringLength(200, MinimumLength = 1)]
        public string LastName { get; set; }

        [Display(Name = "UserName")]
        [StringLength(105, MinimumLength = 1)]
        public string UserName { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
