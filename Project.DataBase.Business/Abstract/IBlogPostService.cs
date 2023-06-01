using Project.DataBase.Entities.ComplexTypes;
using Project.DataBase.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DataBase.Business.Abstract
{
    public interface IBlogPostService
    {
        List<BlogPost> GetAll();
        List<BlogPost> GetOtherPosts(int? AuthorID);
        List<BlogPost> GetAuthorPosts(int? AuthorID);
        BlogPost GetPostbyId(int Id);
        void Add(BlogPost blogPost);
        void Update(BlogPost blogPost);
        void Delete(int postId);
        public BlogAuthorJoin GetJoin(int? authorId, int postId);
    }
}
