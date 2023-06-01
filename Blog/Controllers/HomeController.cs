using Blog.Models;
using Blog.Services;
using Microsoft.AspNetCore.Mvc;
using Project.DataBase.Business.Abstract;
using Project.DataBase.DataAccess.Abstract;
using Project.DataBase.Entities.Concrete;

namespace Blog.Controllers
{
    public class HomeController : Controller
    {
        IBlogPostService _blogPostService;
        public HomeController(IBlogPostService blogPostService, IBlogPostDal blogPostDal)
        {
            _blogPostService = blogPostService;
        }
        public IActionResult Index()
        {
            var temp = HttpContext.Session.GetInt32("UserId");
            var model = new ShowTitlesViewModel();
            if (temp == null)
                model.posts = _blogPostService.GetAll();//Girş yapmazsa kayıtlı tüm kullanıcıların postunu görüyor
            else
                model.posts = _blogPostService.GetOtherPosts(temp);//Giriş yaparsa kendisi dışında herkesinkini görüyor
            return View(model);
        }
        public IActionResult SeePost(int postId)
        {
            var temp = _blogPostService.GetPostbyId(postId);
            var join = _blogPostService.GetJoin(temp.AuthorID, postId);

            var model = new PostViewModel
            {
                blogPost = join
            };

            return View(model);
        }
        public IActionResult ShowAuthorPosts(int? authorId)
        {
            var model = new ShowTitlesViewModel
            {
                posts = _blogPostService.GetAuthorPosts(authorId)
            };
            return View(model);
        }
    }
}
