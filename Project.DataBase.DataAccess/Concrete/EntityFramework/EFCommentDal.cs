using Project.Core.DataAccess.EntityFramework;
using Project.DataBase.DataAccess.Abstract;
using Project.DataBase.Entities.ComplexTypes;
using Project.DataBase.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DataBase.DataAccess.Concrete.EntityFramework
{
    public class EFCommentDal : EfEntityRepositoryBase<Comment, BlogContext>, ICommentDal
    {
        public List<CommentJoin> GetJoin(int PostId) 
        {
            using (BlogContext context = new BlogContext()) 
            {
                var result = from c in context.Comments
                             join u in context.Users
                             on c.userId equals u.UserID
                             where c.postId == PostId
                             select new CommentJoin
                             {
                                 postId = PostId,
                                 Username = u.Username,
                                 comment = c.comment
                             };
             return result.ToList();
            }





        }
    }
}
