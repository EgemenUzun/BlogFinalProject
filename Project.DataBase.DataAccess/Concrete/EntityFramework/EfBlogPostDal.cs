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
    public class EfBlogPostDal : EfEntityRepositoryBase<BlogPost, BlogContext>, IBlogPostDal
    {
        public BlogAuthorJoin GetJoin(int? authorId, int postId)
        {
            using (BlogContext context = new BlogContext())
            {
                var result = from b in context.BlogPosts
                             join u in context.Users
                             on b.AuthorID equals u.UserID
                             where b.PostID == postId
                             select new BlogAuthorJoin
                             {
                                 PostID = b.PostID,
                                 Author = u.Username,
                                 Content = b.Content,
                                 DatePosted = b.DatePosted,
                                 Image = b.Image,
                                 Summary = b.Summary,
                                 Title = b.Title,
                                 AuthorId = b.AuthorID
                             };
                return result.FirstOrDefault();
            }
        }
    }
}
