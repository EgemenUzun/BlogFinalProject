using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DataBase.Entities.ComplexTypes
{
    public class CommentJoin
    {
        public int postId { get; set; }
        public string Username { get; set; }
        public string comment { get; set; }
    }
}
