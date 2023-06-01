using Project.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DataBase.Entities.Concrete
{
    public class Comment : IEntity
    {
        public int id { get; set; }
        public int postId { get; set; }
        public int userId { get; set; }
        [Required]
        [MaxLength(255)]
        public string comment { get; set; }
    }
}
