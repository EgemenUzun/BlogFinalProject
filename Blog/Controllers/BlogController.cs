using Blog.Models;
using Blog.Services;
using Microsoft.AspNetCore.Mvc;
using Project.DataBase.Business.Abstract;
using Project.DataBase.Entities.Concrete;

namespace Blog.Controllers
{
    public class BlogController : UserControl
    {
        IBlogPostService _blogPostService;
        ICommentService _commentService;
        public BlogController(IBlogPostService blogPostService, ICommentService commentService)
        {
            _blogPostService = blogPostService;
            _commentService = commentService;
        }
        public IActionResult Index()
        {
            var a = HttpContext.Session.GetInt32("UserId");
            var temp = _blogPostService.GetAuthorPosts(a);
            var model = new ShowTitlesViewModel
            {
                posts = temp
            };
            return View(model);
        }
        public IActionResult Send()
        {            var model = new SendPostViewModel
            {
                blogPost = new BlogPost()
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult Send(BlogPost blogPost)
        {
            if (ModelState.IsValid)
            {
                blogPost.AuthorID = HttpContext.Session.GetInt32("UserId");
                blogPost.DatePosted = DateTime.Now.ToString("d");
                _blogPostService.Add(blogPost);
                TempData.Add("message", "Post Succesfully Sended");
                return RedirectToAction("Index");
            }
            TempData.Add("message", "Something went wrong");
            return RedirectToAction("Send");
        }
        public IActionResult Delete(int PostID)
        {
            _blogPostService.Delete(PostID);
            TempData.Add("message", "Blog was successfully deleted");
            return RedirectToAction("Index");
        }
        public ActionResult Update(int PostID)
        {
            var model = new UpdatePostViewModel
            {
                blogPost = _blogPostService.GetPostbyId(PostID),
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult Update(BlogPost blog)
        {
            if (ModelState.IsValid)
            {

                _blogPostService.Update(blog);
                TempData.Add("message", "Product was successfully updated");
            }

            return RedirectToAction("Update");
        }
        [HttpPost]
        public ActionResult Comment(string comment, int postId)
        {
            if(ModelState.IsValid && HttpContext.Session.GetInt32("UserId") != null)
            {
                var model = new Comment { comment = comment, postId = postId, userId = (int)HttpContext.Session.GetInt32("UserId") };
                _commentService.Add(model);
                return RedirectToAction("SeePost","Home", new { PostId = postId });
            }
            TempData.Add("message", "Something went wrong check the comment area is not empty or You wouldn't login");
            return RedirectToAction("SeePost", "Home", new { PostId = postId });

        }
    }
}
