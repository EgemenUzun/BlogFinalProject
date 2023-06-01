using Project.DataBase.Business.Abstract;
using Project.DataBase.DataAccess.Abstract;
using Project.DataBase.Entities.ComplexTypes;
using Project.DataBase.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DataBase.Business.Concrete
{
    public class CommentManager : ICommentService
    {
        ICommentDal _commentDal;
        public CommentManager(ICommentDal commentDal) 
        {
        _commentDal = commentDal;
        }
        public void Add(Comment comment)
        {
            _commentDal.Add(comment);
        }

        public void Delete(int commentId)
        {
            _commentDal.Delete(new Comment { id = commentId});
        }

        public List<Comment> GetByPost(int PostId)
        {
            return _commentDal.GetList(c => c.postId == PostId);
        }

        public List<CommentJoin> GetJoin(int PostId)
        {
            return _commentDal.GetJoin(PostId);
        }

        public void Update(Comment comment)
        {
            _commentDal.Update(comment);
        }
    }
}
