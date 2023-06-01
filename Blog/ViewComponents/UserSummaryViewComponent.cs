using Blog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Project.DataBase.Business.Abstract;

namespace Blog.ViewComponents
{
    public class UserSummaryViewComponent : ViewComponent
    {
        IUserService _userService;
        public UserSummaryViewComponent(IUserService userService)
        {
            _userService = userService;
        }
        public ViewViewComponentResult Invoke()
        {
            var temp = _userService.GetbyUserId(HttpContext.Session.GetInt32("UserId"));
            if (temp != null) {
                var model = new UserSummaryViewModel
                {
                    Username = temp.Username
                };
                return View(model);
            }
            var modele = new UserSummaryViewModel();
            return View(modele);
        }
    }
}
