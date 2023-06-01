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
    public class BlogPostManager : IBlogPostService
    {
        IBlogPostDal _blogPostDal;
        public BlogPostManager(IBlogPostDal blogPostDal)
        {
            _blogPostDal = blogPostDal;
        }
        public void Add(BlogPost blogPost)
        {
            _blogPostDal.Add(blogPost);
        }

        public void Delete(int postId)
        {
            _blogPostDal.Delete(new BlogPost { PostID = postId });
        }

        public List<BlogPost> GetAll()
        {
            return _blogPostDal.GetList();
        }

        public List<BlogPost> GetAuthorPosts(int? AuthorID)
        {
            return _blogPostDal.GetList(b => b.AuthorID == AuthorID);
        }

        public BlogAuthorJoin GetJoin(int? authorId, int postId)
        {
            return _blogPostDal.GetJoin(authorId, postId);
        }

        public List<BlogPost> GetOtherPosts(int? AuthorID)
        {
            return _blogPostDal.GetList(b => b.AuthorID !=AuthorID);
        }

        public BlogPost GetPostbyId(int Id)
        {
           return _blogPostDal.Get(b => b.PostID == Id);
        }

        public void Update(BlogPost blogPost)
        {
            _blogPostDal.Update(blogPost);
        }
    }
}
