using Blog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Project.DataBase.Business.Abstract;
using Project.DataBase.Entities.Concrete;

namespace Blog.ViewComponents
{
    public class CommentViewComponent : ViewComponent
    {
        ICommentService _commentService;
        IUserService _userService;
        public CommentViewComponent(ICommentService commentService, IUserService userService)
        {
            _commentService = commentService;
            _userService = userService;

        }
        public ViewViewComponentResult Invoke(int PostId)
        {
            var user = new User();
            var model = new CommentListViewModel {
                comments = _commentService.GetJoin(PostId),
            };

            return View(model);
        }
    }
}
