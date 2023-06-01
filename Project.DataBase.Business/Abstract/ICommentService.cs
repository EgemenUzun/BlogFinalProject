using Project.DataBase.Entities.ComplexTypes;
using Project.DataBase.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DataBase.Business.Abstract
{
    public interface ICommentService
    {
        void Add(Comment comment);
        void Update(Comment comment);
        void Delete(int commentId);
        List<Comment> GetByPost(int PostId);
        public List<CommentJoin> GetJoin(int PostId);
    }
}
