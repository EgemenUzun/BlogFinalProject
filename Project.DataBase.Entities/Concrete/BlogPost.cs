using Project.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DataBase.Entities.Concrete
{
    public class BlogPost : IEntity
    {
        [Required]
        public int PostID { get; set; }
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        [Required]
        [MaxLength(255)]
        public string Content { get; set; }
        public int? AuthorID { get; set; }
        public string? DatePosted { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        public string Summary { get; set; }
    }
}
