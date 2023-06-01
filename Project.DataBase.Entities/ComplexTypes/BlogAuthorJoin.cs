using Project.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DataBase.Entities.ComplexTypes
{
    public class BlogAuthorJoin 
    {
        public int PostID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public int? AuthorId { get; set; }
        public string DatePosted { get; set; }
        public string Image { get; set; }
        public string Summary { get; set; }
    }
}
